using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using ProgramAppointments.Application;
using ProgramAppointments.Domain;
using ProgramAppointments.Infrastructure;

namespace ProgramAppointments
{
    public partial class FrmMenuInvestigador : Form
    {
        // Lista en memoria para almacenar la consulta original
        private List<Reunion> _todasMisReuniones;

        public FrmMenuInvestigador()
        {
            InitializeComponent();
            _todasMisReuniones = new List<Reunion>();
            CargarMisReuniones();

            // Llama a este método para activar los filtros
            VincularEventosCheckboxes();
        }

        private void CargarMisReuniones()
        {
            try
            {
                if (SesionUsuario.UsuarioLogueado == null)
                {
                    MessageBox.Show("Error: No hay un investigador autenticado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idInvestigadorLogueado = SesionUsuario.UsuarioLogueado.IdUsuario;
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("REUNION");

                var collection = database.GetCollection<Reunion>("reuniones");

                var filter = Builders<Reunion>.Filter.AnyEq(r => r.ParticipantesIds, idInvestigadorLogueado);

                _todasMisReuniones = collection.Find(filter).ToList();

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                FiltrarReuniones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar tus reuniones: {ex.Message}", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VincularEventosCheckboxes()
        {
            // Usamos directamente guna2GroupBox1 y buscamos los Guna2CheckBox
            foreach (Control control in guna2GroupBox1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2CheckBox chk)
                {
                    // Vinculamos al evento que ya tienes creado
                    chk.CheckedChanged += guna2CheckBox1_CheckedChanged;
                }
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarReuniones();
        }

        private void FiltrarReuniones()
        {
            if (_todasMisReuniones == null) return;

            List<int> mesesSeleccionados = new List<int>();

            // Recorremos los controles dentro de tu Guna2GroupBox
            foreach (Control control in guna2GroupBox1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2CheckBox chk && chk.Checked)
                {
                    // Convertimos el Tag (1 para Enero, etc.) a número
                    if (int.TryParse(control.Tag?.ToString(), out int mes))
                    {
                        mesesSeleccionados.Add(mes);
                    }
                }
            }

            List<Reunion> listaFiltrada;

            if (mesesSeleccionados.Count == 0)
            {
                // Si no hay ninguno marcado, se muestran todas
                listaFiltrada = _todasMisReuniones;
            }
            else
            {
                // Filtramos por el mes de inicio (ajustado a hora local)
                listaFiltrada = _todasMisReuniones
                    .Where(r => mesesSeleccionados.Contains(r.FechaInicio.ToLocalTime().Month))
                    .ToList();
            }

            // Refrescamos el DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaFiltrada;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            consultarReuLider frmConsultar = new consultarReuLider();
            frmConsultar.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas Cerrar Sesión?", "MEETLY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SesionUsuario.UsuarioLogueado = null;
                Form1 login = new Form1();
                login.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
    }
}