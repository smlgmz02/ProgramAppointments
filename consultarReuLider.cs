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
        // Guardamos las reuniones del día seleccionado en memoria para poder eliminarlas
        private List<Reunion> _reunionesDelDia;

        public consultarReuLider()
        {
            InitializeComponent();
            _context = new MongoDbContext("mongodb://localhost:27017", "REUNION");
            _reunionesDelDia = new List<Reunion>();
        }

        // ====================================================================
        // EVENTO DE CARGA INICIAL
        // ====================================================================
        private async void consultarReuLider_Load(object sender, EventArgs e)
        {
            // Evitamos que puedan seleccionar fechas pasadas o muy lejanas si quieres
            // calendar_picker.MinDate = DateTime.Today; // Opcional

            // 1. Pintamos los días que tienen reuniones en el calendario
            await MarcarDiasOcupados();

            // 2. Cargamos las reuniones del día que esté seleccionado por defecto al abrir
            await CargarReunionesPorFecha(calendar_picker.SelectionStart);
        }

        // ====================================================================
        // MÉTODOS DE DATOS
        // ====================================================================
        private async Task MarcarDiasOcupados()
        {
            try
            {
                var reuniones = await _context.Reuniones.Find(_ => true).ToListAsync();

                // OJO AQUÍ: Convertimos a hora local ANTES de extraer el .Date
                // Si la reunión era a las 11 PM de Colombia, en Mongo es 4 AM del día siguiente.
                // Convertirlo primero nos asegura que pinte el día correcto en el calendario.
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
            // Tomamos el inicio y fin del día en hora LOCAL
            DateTime inicioDiaLocal = fechaSeleccionada.Date;
            DateTime finDiaLocal = inicioDiaLocal.AddDays(1).AddTicks(-1);

            // Convertimos esos límites a UTC para que Mongo los entienda
            var builder = Builders<Reunion>.Filter;
            var filtro = builder.And(
                builder.Gte(r => r.FechaInicio, inicioDiaLocal.ToUniversalTime()),
                builder.Lte(r => r.FechaInicio, finDiaLocal.ToUniversalTime())
            );

            // Guardamos el resultado en memoria
            _reunionesDelDia = await _context.Reuniones.Find(filtro).ToListAsync();

            // Llenamos el DataGrid mostrando la hora Local al usuario
            var dataParaMostrar = _reunionesDelDia.Select(r => new
            {
                Nombre = r.Nombre,
                Motivo = r.Motivo,
                Inicio = r.FechaInicio.ToLocalTime().ToString("HH:mm"),
                Fin = r.FechaFin.ToLocalTime().ToString("HH:mm")
            }).ToList();

            datagrid_reuniones.DataSource = dataParaMostrar;
        }

        // ====================================================================
        // EVENTOS DE LA INTERFAZ
        // ====================================================================

        // Este evento se dispara automáticamente CADA VEZ que el usuario hace clic en un día distinto
        private async void calendar_picker_DateChanged(object sender, DateRangeEventArgs e)
        {
            await CargarReunionesPorFecha(e.Start);
        }

        private async void btn_eliminar_Click(object sender, EventArgs e)
        {
            // 1. VALIDACIÓN: Revisar que haya una fila seleccionada
            if (datagrid_reuniones.CurrentRow == null || datagrid_reuniones.CurrentRow.Index < 0 || datagrid_reuniones.CurrentRow.Index >= _reunionesDelDia.Count)
            {
                MessageBox.Show("Por favor, selecciona una reunión en la tabla para poder eliminarla.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Identificar qué reunión seleccionó
            int indiceFila = datagrid_reuniones.CurrentRow.Index;
            Reunion reunionAEliminar = _reunionesDelDia[indiceFila];

            // 3. Confirmación visual con el usuario
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
                    // 4. Eliminar de la base de datos usando su ID único de Mongo
                    await _context.Reuniones.DeleteOneAsync(r => r.IdMongo == reunionAEliminar.IdMongo);

                    MessageBox.Show("La reunión fue eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Refrescar la pantalla (Actualizar el calendario por si ese día ya quedó vacío, y limpiar la tabla)
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
            // Validación de que algo esté seleccionado
            if (datagrid_reuniones.CurrentRow == null || datagrid_reuniones.CurrentRow.Index < 0 || datagrid_reuniones.CurrentRow.Index >= _reunionesDelDia.Count)
            {
                MessageBox.Show("Por favor, selecciona una reunión para editar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos la reunión seleccionada
            int indiceFila = datagrid_reuniones.CurrentRow.Index;
            Reunion reunionAEditar = _reunionesDelDia[indiceFila];

            // Abrimos el formulario de edición
            EditarReuLider editarForm = new EditarReuLider(reunionAEditar);
            editarForm.ShowDialog();

            // 2. OJO AQUÍ: Cambiamos los .Wait() por await
            await MarcarDiasOcupados();
            await CargarReunionesPorFecha(calendar_picker.SelectionStart);


        }

        private void datagrid_reuniones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lo dejamos vacío, no interfiere con la selección de la fila
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuLider frm = new FrmMenuLider();  
            frm.Show();
            this.Hide();
        }
    }
}