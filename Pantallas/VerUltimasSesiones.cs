using SistemaKinesiologia.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaKinesiologia.Pantallas
{
    public partial class VerUltimasSesiones : Form
    {
        Gestor gestor;
        public VerUltimasSesiones(Gestor gestor)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.gestor = gestor;

            List<Sesion> ultimasSesiones = gestor.sesionService.GetUltimasSesiones();

            if (ultimasSesiones.Count > 0)
            {
                foreach (Sesion sesion in ultimasSesiones)
                {
                    this.AgregarSesion(sesion);
                }
            }

            // Llenar ComboBox de Meses
            cmbSelectorMes.Items.AddRange(new string[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" });

            int posicionMesActual = (DateTime.Now.Month) - 1;
            cmbSelectorMes.SelectedIndex = posicionMesActual;

            cmbSelectorAnio.Items.AddRange(new string[] { "2024", "2025", "2026", "2027", "2028", "2029", "2030" });
            int posicionAnioActual = (DateTime.Now.Year);

            for (int i = 0; i < cmbSelectorAnio.Items.Count; i++)
            {
                if (cmbSelectorAnio.Items[i].ToString() == posicionAnioActual.ToString())
                {
                    cmbSelectorAnio.SelectedIndex = i; break;
                }
            }
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void AgregarSesion(Sesion sesion)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell idSesion = new DataGridViewTextBoxCell();
            idSesion.Value = sesion.IdSesion;

            DataGridViewTextBoxCell pacienteSesion = new DataGridViewTextBoxCell();
            pacienteSesion.Value = sesion.paciente.nombre;

            DataGridViewTextBoxCell lesionSesion = new DataGridViewTextBoxCell();
            if (sesion.lesion == null)
            {

                lesionSesion.Value = "NINGUNA";
            }
            else
            {
                lesionSesion.Value = sesion.lesion.diagnostico;
            }

            DataGridViewTextBoxCell numeroSesion = new DataGridViewTextBoxCell();
            numeroSesion.Value = sesion.numeroSesionDelPaciente;

            DataGridViewTextBoxCell fechaSesion = new DataGridViewTextBoxCell();
            fechaSesion.Value = sesion.fecha;

            DataGridViewTextBoxCell kineSesion = new DataGridViewTextBoxCell();
            kineSesion.Value = sesion.kinesiologo.nombre;

            fila.Cells.Add(idSesion);
            fila.Cells.Add(pacienteSesion);
            fila.Cells.Add(lesionSesion);
            fila.Cells.Add(numeroSesion);
            fila.Cells.Add(fechaSesion);
            fila.Cells.Add(kineSesion);

            dgvSesiones.Rows.Add(fila);
        }

        private void dgvSesiones_SelectionChanged(object sender, EventArgs e)
        {
            // Obtengo la sesion seleccionada
            if (dgvSesiones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSesiones.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    gestor.SetSesionActual(gestor.sesionService.GetSesionXId((int)selectedRow.Cells[0].Value));
                }
                else
                {
                    gestor.SetSesionActual(null);
                }
            }
            else
            {
                gestor.SetSesionActual(null);
            }
        }

        private void btnVerDetalleSesion_Click(object sender, EventArgs e)
        {
            if (gestor.GetSesionActual() != null)
            {
                DetalleSesion ventanaDetalleSesion = new DetalleSesion(gestor);
                ventanaDetalleSesion.ShowDialog();

                if (ventanaDetalleSesion.DialogResult == DialogResult.OK)
                {
                    dgvSesiones.Rows.Clear();

                    List<Sesion> ultimasSesiones = gestor.sesionService.GetUltimasSesiones();

                    if (ultimasSesiones.Count > 0)
                    {
                        foreach (Sesion sesion in ultimasSesiones)
                        {
                            this.AgregarSesion(sesion);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una sesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbSelectorMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualizar datos
            var meses = new Dictionary<string, int>
            {
                { "Enero", 1 },
                { "Febrero", 2 },
                { "Marzo", 3 },
                { "Abril", 4 },
                { "Mayo", 5 },
                { "Junio", 6 },
                { "Julio", 7 },
                { "Agosto", 8 },
                { "Septiembre", 9 },
                { "Octubre", 10 },
                { "Noviembre", 11 },
                { "Diciembre", 12 }
            };

            // Tomamos las selecciones:
            // Obtener año y mes seleccionados
            if (cmbSelectorAnio.SelectedItem != null && cmbSelectorMes.SelectedItem != null)
            {
                int añoSeleccionado = int.Parse(cmbSelectorAnio.SelectedItem.ToString());
                string mesSeleccionado = cmbSelectorMes.SelectedItem.ToString();
                // Verificar que el mes seleccionado existe en el diccionario
                if (meses.TryGetValue(mesSeleccionado, out int numeroMes))
                {
                    // Llamar a CargarDatosEstadisticos con el año y el número de mes
                    this.CargarDatosEstadisticos(añoSeleccionado, numeroMes);
                }
            }
                
        }

        void CargarDatosEstadisticos(int anio, int mes)
        {
            string cantidadSesiones = gestor.sesionService.GetCantidadSesionesPorMes(anio, mes).ToString();
            string cantidadPacientes = gestor.sesionService.GetCantidadPacientesDistintosPorMes(anio, mes).ToString();

            lblCantidadSesionesCompletar.Text = cantidadSesiones;
            lblCantidadPacientesCompletar.Text = cantidadPacientes;

            this.GenerarHistograma(gestor.sesionService.GetCantidadSesionesPorMesDeUnAño(anio));

        }

        private void cmbSelectorAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualizar datos
            var meses = new Dictionary<string, int>
            {
                { "Enero", 1 },
                { "Febrero", 2 },
                { "Marzo", 3 },
                { "Abril", 4 },
                { "Mayo", 5 },
                { "Junio", 6 },
                { "Julio", 7 },
                { "Agosto", 8 },
                { "Septiembre", 9 },
                { "Octubre", 10 },
                { "Noviembre", 11 },
                { "Diciembre", 12 }
            };

            // Tomamos las selecciones:
            if (cmbSelectorAnio.SelectedItem != null && cmbSelectorMes.SelectedItem != null)
            {
                int añoSeleccionado = int.Parse(cmbSelectorAnio.SelectedItem.ToString());
                string mesSeleccionado = cmbSelectorMes.SelectedItem.ToString();
                // Verificar que el mes seleccionado existe en el diccionario
                if (meses.TryGetValue(mesSeleccionado, out int numeroMes))
                {
                    // Llamar a CargarDatosEstadisticos con el año y el número de mes
                    this.CargarDatosEstadisticos(añoSeleccionado, numeroMes);
                }
            }
            }

        // Metodo que genera el histograma
        void GenerarHistograma(List<int> sesionesPorMes)

        {
            histogramaFrecuencias.Series["Fo"].Points.Clear();

            // Ocultar la grilla del eje X y del eje Y
            histogramaFrecuencias.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            histogramaFrecuencias.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Deshabilitar las marcas mayores y menores del eje X
            histogramaFrecuencias.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            histogramaFrecuencias.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;

            // Ajustar el ancho de las barras para que haya espacio entre ellas
            histogramaFrecuencias.Series["Fo"]["PointWidth"] = "0.8"; // Ajusta el ancho según tu preferencia

            // Configurar el color del borde de las barras
            histogramaFrecuencias.Series["Fo"].BorderColor = System.Drawing.Color.Black;

            // Configurar etiquetas del eje X para que se muestren los números de los meses
            histogramaFrecuencias.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            histogramaFrecuencias.ChartAreas[0].AxisX.Interval = 1;

            // Iterar sobre los datos para agregar puntos al histograma
            for (int i = 0; i < sesionesPorMes.Count; i++)
            {
                // Agregar un punto al histograma para cada mes (i + 1 para que los meses empiecen en 1)
                histogramaFrecuencias.Series["Fo"].Points.AddXY(i + 1, sesionesPorMes[i]);
            }
        }
    }
}
