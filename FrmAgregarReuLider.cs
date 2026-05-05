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

        // Nueva variable global para guardar los datos originales de las reuniones
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
            _reunionesCargadas = new List<Reunion>(); // Inicializamos la lista

            // Agregamos al líder automáticamente a la lista temporal
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
        }

        private void ValidarEntradaHora(object sender, KeyPressEventArgs e)
        {
            // Validamos que la tecla presionada NO sea un número, NO sea la tecla de borrar (Control) y NO sean los dos puntos ':'
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ':')
            {
                // e.Handled = true le dice a Windows: "Ya me encargué de esta tecla, no la escribas en la pantalla"
                e.Handled = true;

                MessageBox.Show("En este campo solo puedes escribir números y el símbolo de dos puntos (:).",
                    "Carácter Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Guardamos el resultado en nuestra variable global en lugar de una local
            _reunionesCargadas = await _context.Reuniones.Find(filtro).ToListAsync();

            // Usamos esa misma variable global para llenar la grilla
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
            combo_investigadores.DataSource = null;
            combo_investigadores.DataSource = _investigadoresDisponibles;
            combo_investigadores.DisplayMember = "Nombre";
            combo_investigadores.ValueMember = "IdUsuario";
        }

        private bool IntentarParsearHoras(out DateTime inicio, out DateTime fin)
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

            if (!IntentarParsearHoras(out DateTime inicioProp, out DateTime finProp)) return;

            // Buscamos el conflicto en BD obligando a las fechas propuestas a estar en UTC
            var builder = Builders<Reunion>.Filter;
            var filtro = builder.And(
                builder.AnyEq(r => r.ParticipantesIds, inv.IdUsuario),
                builder.Lt(r => r.FechaInicio, finProp.ToUniversalTime()),
                builder.Gt(r => r.FechaFin, inicioProp.ToUniversalTime())
            );

            var conflicto = await _context.Reuniones.Find(filtro).FirstOrDefaultAsync();

            if (conflicto != null)
            {
                // CONVERSIÓN ESTRICTA PARA LA ALERTA
                string horaInicioReal = conflicto.FechaInicio.ToLocalTime().ToString("HH:mm");
                string horaFinReal = conflicto.FechaFin.ToLocalTime().ToString("HH:mm");

                MessageBox.Show($"Conflicto: {inv.Nombre} ya está en '{conflicto.Nombre}' de {horaInicioReal} a {horaFinReal}.",
                    "Usuario Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _participantesAgregados.Add(inv);
            _investigadoresDisponibles.Remove(inv);
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

            if (!IntentarParsearHoras(out DateTime inicio, out DateTime fin)) return;

            // ====================================================================
            // AQUÍ SE ELIMINÓ EL FILTRO GLOBAL DE HORARIOS. 
            // Ahora la base de datos permite múltiples reuniones a la misma hora.
            // ====================================================================

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

        // Dejar vacíos si no se utilizan eventos automáticos de texto
        private void txtMes_TextChanged(object sender, EventArgs e) { }
        private void txtDia_TextChanged(object sender, EventArgs e) { }
        private void txtHoraInicio_TextChanged(object sender, EventArgs e) { }
        private void txtHoraFinal_TextChanged(object sender, EventArgs e) { }
        private void datagrid_reuniones_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void combo_investigadores_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtnombrereu_TextChanged(object sender, EventArgs e) { }

        // MÉTODOS DE DOBLE CLIC COMPLETADO
        private async void datagrid_reuniones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _reunionesCargadas.Count) return;

            // Esta es la reunión "vieja" que quedó en la memoria de la grilla
            var reunionEnMemoria = _reunionesCargadas[e.RowIndex];

            try
            {
                // SOLUCIÓN: Vamos a Mongo a buscar la versión MÁS RECIENTE de esta reunión usando su ID
                var reunionFresca = await _context.Reuniones
                    .Find(r => r.IdReunion == reunionEnMemoria.IdReunion)
                    .FirstOrDefaultAsync();

                if (reunionFresca != null)
                {
                    // Ahora buscamos a los usuarios usando los IDs de la reunión fresca
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