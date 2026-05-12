using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using ProgramAppointments.Application;
using ProgramAppointments.Domain;
using ProgramAppointments.Infrastructure;

namespace ProgramAppointments
{
    public partial class EditarReuLider : Form
    {
        private Reunion _reunionActual;
        private readonly MongoDbContext _context;
        private List<Usuario> _investigadoresDisponibles;
        private List<Usuario> _investigadoresVinculados;

        // Variable para manejar el estado antes de guardar en Base de Datos
        private string _estadoTemporal;

        public EditarReuLider()
        {
            InitializeComponent();
        }

        public EditarReuLider(Reunion reunion)
        {
            InitializeComponent();
            _reunionActual = reunion;
            _context = new MongoDbContext("mongodb://localhost:27017", "REUNION");

            _investigadoresDisponibles = new List<Usuario>();
            _investigadoresVinculados = new List<Usuario>();

            // Asignamos el estado actual al abrir la ventana
            _estadoTemporal = string.IsNullOrEmpty(_reunionActual.Estado) ? "Programada" : _reunionActual.Estado;
        }

        private async void EditarReuLider_Load(object sender, EventArgs e)
        {
            // Esta validación por si acaso se cuela una reunión finalizada
            if (_estadoTemporal == "Finalizada" || _reunionActual.FechaFin.ToLocalTime() < DateTime.Now)
            {
                MessageBox.Show("Esta reunión ya finalizó y no puede ser editada.",
                    "Reunión Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            calendar_fecha.FirstDayOfWeek = (System.Windows.Forms.Day)DayOfWeek.Monday;
            calendar_fecha.MinDate = DateTime.Today;

            DateTime fechaInicioLocal = _reunionActual.FechaInicio.ToLocalTime();
            calendar_fecha.SelectionStart = fechaInicioLocal.Date;
            calendar_fecha.SelectionEnd = fechaInicioLocal.Date;

            txtnombrereu.Text = _reunionActual.Nombre;
            txtmotivoreu.Text = _reunionActual.Motivo;
            txtHoraInicio.Text = fechaInicioLocal.ToString("HH:mm");
            txtHoraFinal.Text = _reunionActual.FechaFin.ToLocalTime().ToString("HH:mm");

            txtHoraInicio.KeyPress += ValidarEntradaHora;
            txtHoraFinal.KeyPress += ValidarEntradaHora;

            txtHoraInicio.Leave += async (s, ev) => await CargarListasUsuarios();
            txtHoraFinal.Leave += async (s, ev) => await CargarListasUsuarios();

            await CargarListasUsuarios();
        }

        private async Task CargarListasUsuarios()
        {
            if (!IntentarParsearHoras(out DateTime inicioUtc, out DateTime finUtc))
            {
                inicioUtc = _reunionActual.FechaInicio;
                finUtc = _reunionActual.FechaFin;
            }

            var todosLosInvestigadores = await _context.Usuarios
                .Find(u => u.Rol == "Investigador")
                .ToListAsync();

            var filtroConflictos = Builders<Reunion>.Filter.And(
                Builders<Reunion>.Filter.Ne(r => r.IdMongo, _reunionActual.IdMongo),
                Builders<Reunion>.Filter.Lt(r => r.FechaInicio, finUtc),
                Builders<Reunion>.Filter.Gt(r => r.FechaFin, inicioUtc)
            );

            var reunionesConflictivas = await _context.Reuniones.Find(filtroConflictos).ToListAsync();
            var idsOcupados = reunionesConflictivas.SelectMany(r => r.ParticipantesIds).Distinct().ToList();

            if (_investigadoresVinculados.Count == 0 && _reunionActual.ParticipantesIds.Count > 0)
            {
                _investigadoresVinculados = todosLosInvestigadores
                   .Where(u => _reunionActual.ParticipantesIds.Contains(u.IdUsuario))
                   .ToList();
            }

            var idsVinculadosActuales = _investigadoresVinculados.Select(v => v.IdUsuario).ToList();
            _investigadoresDisponibles = todosLosInvestigadores
                .Where(u => !idsVinculadosActuales.Contains(u.IdUsuario) && !idsOcupados.Contains(u.IdUsuario))
                .ToList();

            ActualizarComboboxes();
        }

        private void ActualizarComboboxes()
        {
            combobox_investig_vinculados.DataSource = null;
            combobox_investig_vinculados.DataSource = _investigadoresVinculados;
            combobox_investig_vinculados.DisplayMember = "Nombre";

            combobox_investig_disponibles.DataSource = null;
            combobox_investig_disponibles.DataSource = _investigadoresDisponibles;
            combobox_investig_disponibles.DisplayMember = "Nombre";
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if (combobox_investig_disponibles.SelectedItem is Usuario seleccionado)
            {
                _investigadoresDisponibles.Remove(seleccionado);
                _investigadoresVinculados.Add(seleccionado);
                ActualizarComboboxes();
            }
        }

        private void btnDesvincular_Click(object sender, EventArgs e)
        {
            if (combobox_investig_vinculados.SelectedItem is Usuario seleccionado)
            {
                _investigadoresVinculados.Remove(seleccionado);
                _investigadoresDisponibles.Add(seleccionado);
                ActualizarComboboxes();
            }
        }

        private async void calendar_fecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (EsDiaValido(e.Start))
            {
                await CargarListasUsuarios();
            }
        }

        private bool EsDiaValido(DateTime fecha)
        {
            if (fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("No se pueden programar reuniones los domingos.", "Día no laboral", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                calendar_fecha.SetDate(_reunionActual.FechaInicio.ToLocalTime().Date);
                return false;
            }
            return true;
        }

        private bool IntentarParsearHoras(out DateTime inicio, out DateTime fin)
        {
            inicio = DateTime.MinValue; fin = DateTime.MinValue;

            if (!TimeSpan.TryParseExact(txtHoraInicio.Text, @"hh\:mm", null, System.Globalization.TimeSpanStyles.None, out TimeSpan hInicio) ||
                !TimeSpan.TryParseExact(txtHoraFinal.Text, @"hh\:mm", null, System.Globalization.TimeSpanStyles.None, out TimeSpan hFin))
            {
                return false;
            }

            inicio = calendar_fecha.SelectionStart.Date.Add(hInicio).ToUniversalTime();
            fin = calendar_fecha.SelectionStart.Date.Add(hFin).ToUniversalTime();
            return true;
        }

        private async void btn_guardar_edicion_Click(object sender, EventArgs e)
        {
            if (!EsDiaValido(calendar_fecha.SelectionStart)) return;

            if (string.IsNullOrWhiteSpace(txtnombrereu.Text) || string.IsNullOrWhiteSpace(txtmotivoreu.Text))
            {
                MessageBox.Show("El nombre y motivo son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_investigadoresVinculados.Count == 0)
            {
                MessageBox.Show("La reunión debe tener al menos un investigador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IntentarParsearHoras(out DateTime inicioUtc, out DateTime finUtc))
            {
                MessageBox.Show("Formato de hora inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // AÑADIMOS EL ESTADO EN EL UPDATE PARA MONGODB
            var updateDef = Builders<Reunion>.Update
                .Set(r => r.Nombre, txtnombrereu.Text)
                .Set(r => r.Motivo, txtmotivoreu.Text)
                .Set(r => r.FechaInicio, inicioUtc)
                .Set(r => r.FechaFin, finUtc)
                .Set(r => r.ParticipantesIds, _investigadoresVinculados.Select(i => i.IdUsuario).ToList())
                .Set(r => r.Estado, _estadoTemporal);

            await _context.Reuniones.UpdateOneAsync(r => r.IdMongo == _reunionActual.IdMongo, updateDef);

            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ValidarEntradaHora(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ':') e.Handled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cancelar la edición? Se perderán los cambios no guardados.", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // LÓGICA DE CANCELAR REUNIÓN
        private void btn_cancelar_reunion_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "¿Seguro que quiere cancelar esta reunión? Esta cancelación será permanente al guardar los cambios y no podrá ser reversible.",
                "Confirmación de Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                _estadoTemporal = "Cancelada";
                MessageBox.Show("El estado se ha cambiado a 'Cancelada'. Por favor, presione 'Guardar Cambios' para hacer esta acción permanente en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}