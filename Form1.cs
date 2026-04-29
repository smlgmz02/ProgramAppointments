using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgramAppointments.Application;
using ProgramAppointments.Infrastructure;


namespace ProgramAppointments
{
    public partial class Form1 : Form
    {

        private readonly AuthService _authService;
        public Form1()
        {
            InitializeComponent();
            // comentario feat de prueba
            // Inicializamos la conexión (Paso temporal, luego se puede inyectar)
            var context = new MongoDbContext("mongodb://localhost:27017", "REUNION");
            _authService = new AuthService(context);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Usamos el mismo contexto que ya creaste arriba
                var context = new MongoDbContext("mongodb://localhost:27017", "REUNION");

                // Le pedimos a Mongo que cuente cuántos documentos hay en la colección
                long cantidadUsuarios = await context.Usuarios.CountDocumentsAsync(new MongoDB.Bson.BsonDocument());

                MessageBox.Show($"Conexión exitosa a Mongo.\nUsuarios encontrados: {cantidadUsuarios}", "Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"La conexión falló: {ex.Message}", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void AbrirMenuSegunRol(string rol)
        {
           

            if (rol == "Lider")
            {

                FrmMenuLider menuLider = new FrmMenuLider();
                 menuLider.Show();
       

            }
            else if (rol == "Investigador")
            {

                FrmMenuInvestigador menuInv = new FrmMenuInvestigador();
                 menuInv.Show();
           
             

            }

        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private async void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPassword.Text;

            var usuario = await _authService.LoginAsync(email, pass);

            if (usuario != null)
            {
                SesionUsuario.UsuarioLogueado = usuario;
                AbrirMenuSegunRol(usuario.Rol);
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
