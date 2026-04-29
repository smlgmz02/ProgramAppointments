using MongoDB.Driver;
using ProgramAppointments.Application;
using ProgramAppointments.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
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
            // Inicializamos la conexión a Mongo para poder consultar los días ocupados
            _context = new MongoDbContext("mongodb://localhost:27017", "REUNION");
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_seleccionar_dia_Click(object sender, EventArgs e)
        {
            // Capturamos el día exacto que el usuario tiene clickeado en el calendario
            DateTime diaSeleccionado = calendar_picker.SelectionStart;

            // Instanciamos la siguiente pantalla pasándole la fecha como parámetro
            FrmAgregarReuLider frmAgregar = new FrmAgregarReuLider(diaSeleccionado);
            frmAgregar.Show();

            // Ocultamos esta pantalla de selección de día
            this.Hide();
        }


        private async Task MarcarDiasOcupados()
        {
            try
            {
                // Traemos todas las reuniones de la base de datos
                var reuniones = await _context.Reuniones.Find(_ => true).ToListAsync();

                // Extraemos solo la fecha (sin la hora) de cada reunión y quitamos los duplicados 
                // para que no marque el mismo día dos veces si tiene varias reuniones
                DateTime[] diasConReunion = reuniones
                    .Select(r => r.FechaInicio.Date)
                    .Distinct()
                    .ToArray();

                // Le decimos al calendario que ponga en NEGRITA esos días
                calendar_picker.BoldedDates = diasConReunion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al cargar los días ocupados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void FrmCrearReuLider_Load(object sender, EventArgs e)
        {
            // 1. RESTRICCIÓN DE DÍAS PASADOS:
            // Al asignar MinDate al día de hoy, el calendario bloquea automáticamente 
            // el clic en días de ayer o meses anteriores.
            calendar_picker.MinDate = DateTime.Today;

            // 2. Personalización del Label con el nombre del usuario logueado
            if (SesionUsuario.UsuarioLogueado != null)
            {
                // Asumo que tu label se llama label1, cámbialo si le pusiste otro nombre
                lbl_welcome.Text = $"HOLA {SesionUsuario.UsuarioLogueado.Nombre.ToUpper()}, BIENVENIDO";
            }

            // 3. Buscar y marcar los días que ya tienen reuniones en la base de datos
            await MarcarDiasOcupados(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuLider menuLider = new FrmMenuLider();
            menuLider.Show();
             this.Hide();   
        }
    }


  
        }
    
