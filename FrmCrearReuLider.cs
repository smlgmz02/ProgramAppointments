using MongoDB.Driver;
using ProgramAppointments.Application;
using ProgramAppointments.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramAppointments
{
    public partial class FrmCrearReuLider : Form
    {
        private readonly MongoDbContext _context;

        public FrmCrearReuLider()
        {
            InitializeComponent();
            _context = new MongoDbContext("mongodb://localhost:27017", "REUNION");
        }

        private async void FrmCrearReuLider_Load(object sender, EventArgs e)
        {
            // configuracon visual (lunesnicio)
            calendar_picker.FirstDayOfWeek = (System.Windows.Forms.Day)DayOfWeek.Monday;
            // restriccion de fechas pasadas
            calendar_picker.MinDate = DateTime.Today;
            if (SesionUsuario.UsuarioLogueado != null)
            {
                lbl_welcome.Text = $"HOLA {SesionUsuario.UsuarioLogueado.Nombre.ToUpper()}, BIENVENIDO";
            }
            await MarcarDiasOcupados();
        }

        // ESTE EVENTO SOLO VALIDA, NO CAMBIA DE VENTANA
        private void calendar_picker_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("No se pueden programar reuniones los domingos. Por favor, seleccione otro día.",
                    "Día no laboral", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Resetear la selección para que no se quede en domingo
                if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                    calendar_picker.SetDate(DateTime.Today.AddDays(1));
                else
                    calendar_picker.SetDate(DateTime.Today);
            }
        }

        private void btn_seleccionar_dia_Click(object sender, EventArgs e)
        {
            
        }

        private async Task MarcarDiasOcupados()
        {
            try
            {
                var reuniones = await _context.Reuniones.Find(_ => true).ToListAsync();
                DateTime[] diasConReunion = reuniones
                    .Select(r => r.FechaInicio.Date)
                    .Distinct()
                    .ToArray();

                calendar_picker.BoldedDates = diasConReunion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al cargar los días ocupados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuLider menuLider = new FrmMenuLider();
            menuLider.Show();
            this.Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas Cerrar Sesión?", "MEETLY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SesionUsuario.UsuarioLogueado = null;
                Form1 login = new Form1();
                login.Show();
                this.Close();
            }
        }

        private void btnSeleccionarDia_Click(object sender, EventArgs e)
        {
            // Obtenemos la fecha que el usuario dejó marcada en el calendario
            DateTime diaSeleccionado = calendar_picker.SelectionStart;

            // Validación de seguridad final
            if (diaSeleccionado.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Por favor, seleccione un día válido (lunes a sábado) antes de continuar.",
                    "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                FrmAgregarReuLider frmAgregar = new FrmAgregarReuLider(diaSeleccionado);
                frmAgregar.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de registro: " + ex.Message);
            }
        }
    }
}