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
    public partial class FrmAgregarReuLider : Form
    {
        private DateTime _diaElegido;
        public FrmAgregarReuLider()
        {
            InitializeComponent();
        }

        public FrmAgregarReuLider(DateTime diaSeleccionado)
        {
            InitializeComponent();

            // Guardamos la fecha que nos enviaron desde el calendario
            _diaElegido = diaSeleccionado;
        }

        private void FrmAgregarReuLider_Load(object sender, EventArgs e)
        {
            // Ejemplo: Mostrar la fecha recibida en el título de la ventana
            this.Text = $"Programando reunión para el: {_diaElegido.ToShortDateString()}";
        }

        private void txtMes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoraInicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoraFinal_TextChanged(object sender, EventArgs e)
        {

        }

        private void datagrid_reuniones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combo_investigadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_agg_inv_Click(object sender, EventArgs e)
        {

        }

        private void btn_agendar_reu_Click(object sender, EventArgs e)
        {

        }
    }
}
