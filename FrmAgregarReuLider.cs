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
    public partial class FrmAgregarReuLider : Form
    {
        private DateTime _diaElegido;
        private readonly MongoDbContext _context;
        private List<Usuario> _investigadoresDisponibles;
        private List<Usuario> _participantesAgregados;
        private List<Reunion> _reunionesCargadas;

        public FrmAgregarReuLider()
        {
            InitializeComponent();
        }

        public FrmAgregarReuLider(DateTime diaSeleccionado)
        {
            InitializeComponent();
            _diaElegido = diaSeleccionado;
            _context = new MongoDbContext("mongodb://localhost:27017", "REUNION");
            _participantesAgregados = new List<Usuario>();
            _reunionesCargadas = new List<Reunion>();

            if (SesionUsuario.UsuarioLogueado != null)
            {
                _participantesAgregados.Add(SesionUsuario.UsuarioLogueado);
            }
        }

        private async void FrmAgregarReuLider_Load(object sender, EventArgs e)
        {
            this.Text = $"Programando reunión para el: {_diaElegido.ToShortDateString()}";

            txtMes.Text = _diaElegido.ToString("MMMM").ToUpper();
            txtDia.Text = _diaElegido.Day.ToString();
            txtMes.Enabled = false;
            txtDia.Enabled = false;

            txtHoraInicio.Text = "08:00";
            txtHoraFinal.Text = "09:00";

            await CargarReunionesDelDia();
            await CargarInvestigadores();

            txtHoraInicio.KeyPress += ValidarEntradaHora;
            txtHoraFinal.KeyPress += ValidarEntradaHora;

            // eventos para validación en tiempo real
            txtHoraInicio.TextChanged += Horas_TextChanged;
            txtHoraFinal.TextChanged += Horas_TextChanged;
        }

        private void ValidarEntradaHora(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
                MessageBox.Show("En este campo solo puedes escribir números y el símbolo de dos puntos (:).",
                    "Carácter Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Horas_TextChanged(object sender, EventArgs e)
        {
            // solo se refresca el combo si ambos campos tienen la longitud completa (ej. 08:30)
            if (txtHoraInicio.Text.Length == 5 && txtHoraFinal.Text.Length == 5)
            {
                ActualizarComboBox();
            }
            else
            {
                // si el usuario está borrando o editando, mostramos la lista completa de disponibles
                // para evitar que el combo se quede vacío mientras escribe
                ActualizarComboBox();
            }
        }

        private async Task CargarReunionesDelDia()
        {
            DateTime inicioDelDia = _diaElegido.Date;
            DateTime finDelDia = inicioDelDia.AddDays(1).AddTicks(-1);

            var builder = Builders<Reunion>.Filter;
            var filtro = builder.And(
                builder.Gte(r => r.FechaInicio, inicioDelDia),
                builder.Lte(r => r.FechaInicio, finDelDia)
            );

            _reunionesCargadas = await _context.Reuniones.Find(filtro).ToListAsync();

            var dataParaMostrar = _reunionesCargadas.Select(r => new
            {
                Nombre = r.Nombre,
                Motivo = r.Motivo,
                Inicio = r.FechaInicio.ToLocalTime().ToString("HH:mm"),
                Fin = r.FechaFin.ToLocalTime().ToString("HH:mm")
            }).ToList();

            datagrid_reuniones.DataSource = dataParaMostrar;
        }

        private async Task CargarInvestigadores()
        {
            _investigadoresDisponibles = await _context.Usuarios
                .Find(u => u.Rol == "Investigador")
                .ToListAsync();
            ActualizarComboBox();
        }

        private void ActualizarComboBox()
        {
            if (_investigadoresDisponibles == null) return;

            var listaAMostrar = _investigadoresDisponibles.ToList();

            // solo filtramos si hay 5 caracteres en ambos para evitar que el combo se quede vacío mientras el usuario escribe
            if (txtHoraInicio.Text.Length == 5 && txtHoraFinal.Text.Length == 5)
            {
                if (IntentarParsearHorasSilencioso(out DateTime inicioProp, out DateTime finProp))
                {
                    var inicioUtc = inicioProp.ToUniversalTime();
                    var finUtc = finProp.ToUniversalTime();

                    // solo quita al investigador si la hora coincide exactamente
                    var reunionesConflictivas = _reunionesCargadas.Where(r =>
                        r.FechaInicio == inicioUtc && r.FechaFin == finUtc
                    ).ToList();

                    var idsOcupados = reunionesConflictivas.SelectMany(r => r.ParticipantesIds).Distinct().ToList();

                    listaAMostrar = listaAMostrar.Where(inv => !idsOcupados.Contains(inv.IdUsuario)).ToList();
                }
            }

            // tambien quitamos a los que ya fueron agregados a la lista actual de la reunión
            var idsYaAgregados = _participantesAgregados.Select(p => p.IdUsuario).ToList();
            listaAMostrar = listaAMostrar.Where(inv => !idsYaAgregados.Contains(inv.IdUsuario)).ToList();

            combo_investigadores.DataSource = null;
            combo_investigadores.DataSource = listaAMostrar;
            combo_investigadores.DisplayMember = "Nombre";
            combo_investigadores.ValueMember = "IdUsuario";
        }

        private bool IntentarParsearHorasSilencioso(out DateTime inicio, out DateTime fin)
        {
            inicio = DateTime.MinValue; fin = DateTime.MinValue;
            if (TimeSpan.TryParseExact(txtHoraInicio.Text, @"hh\:mm", null, out TimeSpan hInicio) &&
                TimeSpan.TryParseExact(txtHoraFinal.Text, @"hh\:mm", null, out TimeSpan hFin))
            {
                if (hInicio < hFin)
                {
                    inicio = _diaElegido.Date.Add(hInicio);
                    fin = _diaElegido.Date.Add(hFin);
                    return true;
                }
            }
            return false;
        }

        private bool ParsearHoras(out DateTime inicio, out DateTime fin)
        {
            inicio = DateTime.MinValue; fin = DateTime.MinValue;
            if (!TimeSpan.TryParseExact(txtHoraInicio.Text, @"hh\:mm", null, out TimeSpan hInicio) ||
                !TimeSpan.TryParseExact(txtHoraFinal.Text, @"hh\:mm", null, out TimeSpan hFin))
            {
                MessageBox.Show("Usa formato 24h (HH:mm). Ej: 14:30", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (hInicio >= hFin)
            {
                MessageBox.Show("La hora de inicio debe ser anterior a la final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            inicio = _diaElegido.Date.Add(hInicio);
            fin = _diaElegido.Date.Add(hFin);
            return true;
        }

        private async void btn_agg_inv_Click(object sender, EventArgs e)
        {
            if (combo_investigadores.SelectedItem == null) return;
            Usuario inv = (Usuario)combo_investigadores.SelectedItem;

            if (!ParsearHoras(out DateTime inicioProp, out DateTime finProp)) return;

            // Validación robusta contra MongoDB (detecta cualquier cruce)
            var builder = Builders<Reunion>.Filter;
            var filtro = builder.And(
                builder.AnyEq(r => r.ParticipantesIds, inv.IdUsuario),
                builder.Lt(r => r.FechaInicio, finProp.ToUniversalTime()),
                builder.Gt(r => r.FechaFin, inicioProp.ToUniversalTime())
            );

            var conflicto = await _context.Reuniones.Find(filtro).FirstOrDefaultAsync();

            if (conflicto != null)
            {
                string horaInicioReal = conflicto.FechaInicio.ToLocalTime().ToString("HH:mm");
                string horaFinReal = conflicto.FechaFin.ToLocalTime().ToString("HH:mm");

                MessageBox.Show($"Conflicto: {inv.Nombre} ya está en '{conflicto.Nombre}' de {horaInicioReal} a {horaFinReal}.",
                    "Usuario Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _participantesAgregados.Add(inv);
            ActualizarComboBox();
            MessageBox.Show($"{inv.Nombre} agregado a la lista.", "Éxito");
        }

        private async void btn_agendar_reu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnombrereu.Text) || _participantesAgregados.Count < 2)
            {
                MessageBox.Show("Completa los datos y agrega al menos un investigador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ParsearHoras(out DateTime inicio, out DateTime fin)) return;

            var nueva = new Reunion
            {
                IdReunion = new Random().Next(1000, 9999),
                Nombre = txtnombrereu.Text,
                Motivo = txtmotivoreu.Text,
                FechaInicio = inicio.ToUniversalTime(),
                FechaFin = fin.ToUniversalTime(),
                ParticipantesIds = _participantesAgregados.Select(p => p.IdUsuario).ToList()
            };

            await _context.Reuniones.InsertOneAsync(nueva);
            MessageBox.Show("Reunión agendada.", "Éxito");

            FrmCrearReuLider frmCrear = new FrmCrearReuLider();
            frmCrear.Show();
            this.Close();
        }

        private async void datagrid_reuniones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _reunionesCargadas.Count) return;

            var reunionEnMemoria = _reunionesCargadas[e.RowIndex];

            try
            {
                var reunionFresca = await _context.Reuniones
                    .Find(r => r.IdReunion == reunionEnMemoria.IdReunion)
                    .FirstOrDefaultAsync();

                if (reunionFresca != null)
                {
                    var integrantes = await _context.Usuarios
                        .Find(u => reunionFresca.ParticipantesIds.Contains(u.IdUsuario))
                        .ToListAsync();

                    string listaNombres = string.Join("\n", integrantes.Select(i => $"- {i.Nombre} {i.Apellido} ({i.Rol})"));

                    MessageBox.Show($"Integrantes de la reunión '{reunionFresca.Nombre}':\n\n{listaNombres}",
                        "Detalles de Integrantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los integrantes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCrearReuLider frmCrear = new FrmCrearReuLider();
            frmCrear.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e) { }
        private void datagrid_reuniones_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void txtHoraInicio_TextChanged_1(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}