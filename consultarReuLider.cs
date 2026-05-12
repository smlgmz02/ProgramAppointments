using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using ProgramAppointments.Domain;
using ProgramAppointments.Infrastructure;

namespace ProgramAppointments
{
    public partial class consultarReuLider : Form
    {
        private readonly MongoDbContext _context;
        private List<Reunion> _reunionesDelDia;

        public consultarReuLider()
        {
            InitializeComponent();
            _context = new MongoDbContext("mongodb://localhost:27017", "REUNION");
            _reunionesDelDia = new List<Reunion>();
        }

        private async void consultarReuLider_Load(object sender, EventArgs e)
        {
            await MarcarDiasOcupados();
            await CargarReunionesPorFecha(calendar_picker.SelectionStart);
        }

        private async Task MarcarDiasOcupados()
        {
            try
            {
                var reuniones = await _context.Reuniones.Find(_ => true).ToListAsync();

                DateTime[] diasConReunion = reuniones
                    .Select(r => r.FechaInicio.ToLocalTime().Date)
                    .Distinct()
                    .ToArray();

                calendar_picker.BoldedDates = diasConReunion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al marcar el calendario: " + ex.Message);
            }
        }

        private async Task CargarReunionesPorFecha(DateTime fechaSeleccionada)
        {
            DateTime inicioDiaLocal = fechaSeleccionada.Date;
            DateTime finDiaLocal = inicioDiaLocal.AddDays(1).AddTicks(-1);

            var builder = Builders<Reunion>.Filter;
            var filtro = builder.And(
                builder.Gte(r => r.FechaInicio, inicioDiaLocal.ToUniversalTime()),
                builder.Lte(r => r.FechaInicio, finDiaLocal.ToUniversalTime())
            );

            _reunionesDelDia = await _context.Reuniones.Find(filtro).ToListAsync();

            // 1. LÓGICA DE AUTO-FINALIZACIÓN
            bool huboCambiosDeEstado = false;
            foreach (var r in _reunionesDelDia)
            {
                // Si está programada pero su fecha/hora final ya pasó respecto a la hora actual local
                if ((string.IsNullOrEmpty(r.Estado) || r.Estado == "Programada") && r.FechaFin.ToLocalTime() < DateTime.Now)
                {
                    r.Estado = "Finalizada";
                    var updateDef = Builders<Reunion>.Update.Set(x => x.Estado, "Finalizada");
                    await _context.Reuniones.UpdateOneAsync(x => x.IdMongo == r.IdMongo, updateDef);
                    huboCambiosDeEstado = true;
                }
            }

            // Si cambiamos estados silenciosamente, recargamos la lista limpia de DB para asegurar sincronía
            if (huboCambiosDeEstado)
            {
                _reunionesDelDia = await _context.Reuniones.Find(filtro).ToListAsync();
            }

            // 2. MOSTRAR EL ESTADO DE PRIMERO EN LA GRILLA
            var dataParaMostrar = _reunionesDelDia.Select(r => new
            {
                Estado = string.IsNullOrEmpty(r.Estado) ? "Programada" : r.Estado, // Si por alguna razón está nulo, asume Programada
                Nombre = r.Nombre,
                Motivo = r.Motivo,
                Inicio = r.FechaInicio.ToLocalTime().ToString("HH:mm"),
                Fin = r.FechaFin.ToLocalTime().ToString("HH:mm")
            }).ToList();

            datagrid_reuniones.DataSource = dataParaMostrar;
        }

        private async void calendar_picker_DateChanged(object sender, DateRangeEventArgs e)
        {
            await CargarReunionesPorFecha(e.Start);
        }

        private async void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (datagrid_reuniones.CurrentRow == null || datagrid_reuniones.CurrentRow.Index < 0 || datagrid_reuniones.CurrentRow.Index >= _reunionesDelDia.Count)
            {
                MessageBox.Show("Por favor, selecciona una reunión en la tabla para poder eliminarla.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indiceFila = datagrid_reuniones.CurrentRow.Index;
            Reunion reunionAEliminar = _reunionesDelDia[indiceFila];

            DialogResult respuesta = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar la reunión '{reunionAEliminar.Nombre}' programada de {reunionAEliminar.FechaInicio.ToLocalTime():HH:mm} a {reunionAEliminar.FechaFin.ToLocalTime():HH:mm}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await _context.Reuniones.DeleteOneAsync(r => r.IdMongo == reunionAEliminar.IdMongo);
                    MessageBox.Show("La reunión fue eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await MarcarDiasOcupados();
                    await CargarReunionesPorFecha(calendar_picker.SelectionStart);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btn_editar_Click(object sender, EventArgs e)
        {
            if (datagrid_reuniones.CurrentRow == null || datagrid_reuniones.CurrentRow.Index < 0 || datagrid_reuniones.CurrentRow.Index >= _reunionesDelDia.Count)
            {
                MessageBox.Show("Por favor, selecciona una reunión para editar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indiceFila = datagrid_reuniones.CurrentRow.Index;
            Reunion reunionAEditar = _reunionesDelDia[indiceFila];

            // 3. BLOQUEO DE EDICIÓN SEGÚN ESTADO
            string estadoActual = string.IsNullOrEmpty(reunionAEditar.Estado) ? "Programada" : reunionAEditar.Estado;
            if (estadoActual != "Programada")
            {
                MessageBox.Show($"No se puede editar esta reunión porque se encuentra en estado: {estadoActual}.", "Edición Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EditarReuLider editarForm = new EditarReuLider(reunionAEditar);
            editarForm.ShowDialog();

            await MarcarDiasOcupados();
            await CargarReunionesPorFecha(calendar_picker.SelectionStart);
        }

        private void datagrid_reuniones_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuLider frm = new FrmMenuLider();
            frm.Show();
            this.Hide();
        }
    }
}