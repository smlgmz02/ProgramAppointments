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
        public FrmMenuInvestigador()
        {
            InitializeComponent();
            CargarMisReuniones();
        }

        private void CargarMisReuniones()
        {
            try
            {
                // validacion basica
                if (SesionUsuario.UsuarioLogueado == null)
                {
                    MessageBox.Show("Error: No hay un investigador autenticado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int idInvestigadorLogueado = SesionUsuario.UsuarioLogueado.IdUsuario;
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("REUNION");

                // Colección de reuniones
                var collection = database.GetCollection<Reunion>("reuniones");

                // se filtra donde el id_usuario de la reunión coincida con el id_usuario del investigador
                var filter = Builders<Reunion>.Filter.AnyEq(r => r.ParticipantesIds, idInvestigadorLogueado);
                var misReuniones = collection.Find(filter).ToList();

                // asignamos los datos al DataGridView existente
                dataGridView1.DataSource = misReuniones;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar tus reuniones: {ex.Message}", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            consultarReuLider frmConsultar = new consultarReuLider();
            frmConsultar.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas Cerrar Sesión?", "MEETLY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //fokinshit
                SesionUsuario.UsuarioLogueado = null;
                
                Form1 login = new Form1();
                login.Show();
                
                this.Close();
            }
        }
    }
}