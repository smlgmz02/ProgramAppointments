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

        // Listas en memoria para manejar el estado visual
        private List<Usuario> _investigadoresDisponibles;
        private List<Usuario> _investigadoresVinculados;

        public EditarReuLider()
        {
            InitializeComponent();
        }

        // Constructor que recibe la reunión a editar
        public EditarReuLider(Reunion reunion)
        {
            InitializeComponent();
            _reunionActual = reunion;
            _context = new MongoDbContext("mongodb://localhost:27017", "REUNION");

            _investigadoresDisponibles = new List<Usuario>();
            _investigadoresVinculados = new List<Usuario>();
        }

        private async void EditarReuLider_Load(object sender, EventArgs e)
        {
            calendar_fecha.MinDate = DateTime.Today;

            // mapear datos básicos a la interfaz
            txtnombrereu.Text = _reunionActual.Nombre;
            txtmotivoreu.Text = _reunionActual.Motivo;

            // pasamos a hora local para mostrar en pantalla
            DateTime fechaInicioLocal = _reunionActual.FechaInicio.ToLocalTime();
            DateTime fechaFinLocal = _reunionActual.FechaFin.ToLocalTime();

            txtHoraInicio.Text = fechaInicioLocal.ToString("HH:mm");
            txtHoraFinal.Text = fechaFinLocal.ToString("HH:mm");

            // setear el calendario a la fecha de la reunión original
            calendar_fecha.SelectionStart = fechaInicioLocal.Date;
            calendar_fecha.SelectionEnd = fechaInicioLocal.Date;

            // bloquear teclas no válidas en las horas
            txtHoraInicio.KeyPress += ValidarEntradaHora;
            txtHoraFinal.KeyPress += ValidarEntradaHora;

            //  finalmente se cargan a las listas de investigadores
            await CargarListasUsuarios();
        }

        private async Task CargarListasUsuarios()
        {
            // Traemos a todos los investigadores
            var todosLosInvestigadores = await _context.Usuarios
                .Find(u => u.Rol == "Investigador")
                .ToListAsync();

            // Separamos: Si su ID está en la reunión actual, van a "Vinculados", si no, a "Disponibles"
            _investigadoresVinculados = todosLosInvestigadores
                .Where(u => _reunionActual.ParticipantesIds.Contains(u.IdUsuario))
                .ToList();

            _investigadoresDisponibles = todosLosInvestigadores
                .Where(u => !_reunionActual.ParticipantesIds.Contains(u.IdUsuario))
                .ToList();

            // Aseguramos que el líder actual se mantenga internamente en la lista de IDs (aunque no se muestre en los combos de investigadores)
            if (SesionUsuario.UsuarioLogueado != null && !_reunionActual.ParticipantesIds.Contains(SesionUsuario.UsuarioLogueado.IdUsuario))
            {
                _reunionActual.ParticipantesIds.Add(SesionUsuario.UsuarioLogueado.IdUsuario);
            }

            ActualizarComboboxes();
        }

        private void ActualizarComboboxes()
        {
            combobox_investig_vinculados.DataSource = null;
            // El .ToList() fuerza a Windows Forms a crear una lista fresca y repintar
            combobox_investig_vinculados.DataSource = _investigadoresVinculados.ToList();
            combobox_investig_vinculados.DisplayMember = "Nombre";

            combobox_investig_disponibles.DataSource = null;
            combobox_investig_disponibles.DataSource = _investigadoresDisponibles.ToList();
            combobox_investig_disponibles.DisplayMember = "Nombre";
        }

        private void ValidarEntradaHora(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }

        private bool IntentarParsearHoras(out DateTime inicio, out DateTime fin)
        {
            inicio = DateTime.MinValue; fin = DateTime.MinValue;
            if (!TimeSpan.TryParseExact(txtHoraInicio.Text, @"hh\:mm", null, out TimeSpan hInicio) ||
                !TimeSpan.TryParseExact(txtHoraFinal.Text, @"hh\:mm", null, out TimeSpan hFin))
            {
                MessageBox.Show("Usa formato 24h (HH:mm).", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (hInicio >= hFin)
            {
                MessageBox.Show("La hora de inicio debe ser anterior a la final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Usamos la fecha seleccionada en el calendario
            inicio = calendar_fecha.SelectionStart.Date.Add(hInicio);
            fin = calendar_fecha.SelectionStart.Date.Add(hFin);
            return true;
        }

        // evento para vincular un investigador seleccionado
        private async void btnVincular_Click(object sender, EventArgs e)
        {
            if (combobox_investig_disponibles.SelectedItem == null) return;

            Usuario invSeleccionado = (Usuario)combobox_investig_disponibles.SelectedItem;
            int idAAgregar = invSeleccionado.IdUsuario;

            if (!IntentarParsearHoras(out DateTime inicioProp, out DateTime finProp)) return;

            var builder = Builders<Reunion>.Filter;
            var filtro = builder.And(
                builder.Ne(r => r.IdMongo, _reunionActual.IdMongo),
                builder.AnyEq(r => r.ParticipantesIds, idAAgregar),
                builder.Lt(r => r.FechaInicio, finProp.ToUniversalTime()),
                builder.Gt(r => r.FechaFin, inicioProp.ToUniversalTime())
            );

            var conflicto = await _context.Reuniones.Find(filtro).FirstOrDefaultAsync();

            if (conflicto != null)
            {
                MessageBox.Show($"Conflicto: {invSeleccionado.Nombre} ya está en '{conflicto.Nombre}' de {conflicto.FechaInicio.ToLocalTime():HH:mm} a {conflicto.FechaFin.ToLocalTime():HH:mm}.",
                    "Usuario Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _investigadoresDisponibles.RemoveAll(u => u.IdUsuario == idAAgregar);

            if (!_investigadoresVinculados.Any(u => u.IdUsuario == idAAgregar))
            {
                _investigadoresVinculados.Add(invSeleccionado);
            }

            ActualizarComboboxes();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // no se pueden quedar reuniones sin investigadores
            if (combobox_investig_vinculados.SelectedItem == null) return;
            if (_investigadoresVinculados.Count <= 1)
            {
                MessageBox.Show("No puedes desvincular a este investigador porque la reunión quedaría vacía. Si deseas cambiarlo, primero vincula al nuevo investigador y luego desvincula a este.",
                    "Mínimo de Integrantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Cortamos la ejecución aquí, no borra nada
            }

            // obtenemos el objeto y extraemos su ID único
            Usuario invSeleccionado = (Usuario)combobox_investig_vinculados.SelectedItem;
            int idAEliminar = invSeleccionado.IdUsuario;
            _investigadoresVinculados.RemoveAll(u => u.IdUsuario == idAEliminar);
            // lo agregamos a disponibles solo si no existe ya
            if (!_investigadoresDisponibles.Any(u => u.IdUsuario == idAEliminar))
            {
                _investigadoresDisponibles.Add(invSeleccionado);
            }

            ActualizarComboboxes();
        }

        private async void btn_guardar_edicion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnombrereu.Text) || string.IsNullOrWhiteSpace(txtmotivoreu.Text))
            {
                MessageBox.Show("El nombre y motivo son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // NUEVA VALIDACIÓN DE SEGURIDAD ANTES DE GUARDAR
            if (_investigadoresVinculados.Count == 0)
            {
                MessageBox.Show("La reunión debe tener al menos un investigador vinculado.", "Faltan Integrantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IntentarParsearHoras(out DateTime inicioUtc, out DateTime finUtc)) return;

            var builder = Builders<Reunion>.Filter;
            var filtroGlobal = builder.And(
                builder.Ne(r => r.IdMongo, _reunionActual.IdMongo),
                builder.Lt(r => r.FechaInicio, finUtc.ToUniversalTime()),
                builder.Gt(r => r.FechaFin, inicioUtc.ToUniversalTime())
            );

            if (await _context.Reuniones.Find(filtroGlobal).AnyAsync())
            {
                MessageBox.Show("Ya existe otra reunión programada en este horario. Elige una hora distinta.", "Cruce de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // LIMPIEZA TOTAL DE IDs: Solo pasan los que de verdad quedaron en la lista visual
            List<int> idsFinales = new List<int>();

            if (SesionUsuario.UsuarioLogueado != null)
            {
                idsFinales.Add(SesionUsuario.UsuarioLogueado.IdUsuario);
            }

            foreach (var inv in _investigadoresVinculados)
            {
                if (!idsFinales.Contains(inv.IdUsuario))
                {
                    idsFinales.Add(inv.IdUsuario);
                }
            }

            var updateDef = Builders<Reunion>.Update
                .Set(r => r.Nombre, txtnombrereu.Text)
                .Set(r => r.Motivo, txtmotivoreu.Text)
                .Set(r => r.FechaInicio, inicioUtc.ToUniversalTime())
                .Set(r => r.FechaFin, finUtc.ToUniversalTime())
                .Set(r => r.ParticipantesIds, idsFinales);

            var resultado = await _context.Reuniones.UpdateOneAsync(r => r.IdMongo == _reunionActual.IdMongo, updateDef);

            if (resultado.ModifiedCount == 0 && resultado.MatchedCount > 0)
            {
                MessageBox.Show("Los datos son iguales a los anteriores, no hubo cambios que guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Reunión actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        // Eventos vacíos para que el diseñador no arroje errores
        private void txtmotivoreu_TextChanged(object sender, EventArgs e) { }
        private void txtnombrereu_TextChanged(object sender, EventArgs e) { }
        private void txtHoraInicio_TextChanged(object sender, EventArgs e) { }
        private void txtHoraFinal_TextChanged(object sender, EventArgs e) { }
        private void combobox_investig_disponibles_SelectedIndexChanged(object sender, EventArgs e) { }
        private void combobox_investig_vinculados_SelectedIndexChanged(object sender, EventArgs e) { }
        private void calendar_fecha_DateChanged(object sender, DateRangeEventArgs e) { }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Estás seguro de que quieres cancelar la edición? Se perderán los cambios no guardados.", "MEETLY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}