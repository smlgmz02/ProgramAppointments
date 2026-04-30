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
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            consultarReuLider frmConsultar = new consultarReuLider();
            frmConsultar.Show();
            this.Hide();
        }
    }
}
