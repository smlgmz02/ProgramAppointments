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
    public partial class FrmMenuInvestigador : Form
    {
        public FrmMenuInvestigador()
        {
            InitializeComponent();
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
    }
}
