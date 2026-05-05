using ProgramAppointments.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramAppointments
{
    public partial class FrmMenuLider : Form
    {
        public FrmMenuLider()
        {
            InitializeComponent();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            FrmCrearReuLider frmCrearReuLider = new FrmCrearReuLider();
            frmCrearReuLider.Show();
            this.Hide();
        }

 
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            consultarReuLider frmConsultar = new consultarReuLider();
            frmConsultar.Show();
            this.Hide();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
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
