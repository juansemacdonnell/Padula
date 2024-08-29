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
    public partial class SelectorEvaluacion : Form
    {
        Gestor gestor;
        public SelectorEvaluacion(Gestor gestor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;

            if (gestor.GetLesionActual().evaluaciones.Count > 0)
            {
                foreach (Evaluacion evaluacion in gestor.GetLesionActual().evaluaciones)
                {
                    this.AgregarEvaluaciones(evaluacion);
                }
            }
            else
            {
                MessageBox.Show("No hay evaluaciones de esta lesion para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCerrarEvaluacionesLesion_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnSeleccionarEvaluacion_Click(object sender, EventArgs e)
        {
            if(gestor.GetEvaluacionParaComparar() != null)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una evaluación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void AgregarEvaluaciones(Evaluacion evaluacion)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell idEvaluacion = new DataGridViewTextBoxCell();
            idEvaluacion.Value = evaluacion.IdEvaluacion;

            DataGridViewTextBoxCell nombreEvaluacion = new DataGridViewTextBoxCell();
            nombreEvaluacion.Value = evaluacion.nombre;

            DataGridViewTextBoxCell fechaEvaluacion = new DataGridViewTextBoxCell();
            fechaEvaluacion.Value = evaluacion.fecha;

            fila.Cells.Add(idEvaluacion);
            fila.Cells.Add(nombreEvaluacion);
            fila.Cells.Add(fechaEvaluacion);

            dgvEvaluaciones.Rows.Add(fila);
        }

        private void dgvEvaluaciones_SelectionChanged(object sender, EventArgs e)
        {
            // Obtengo la evaluacion seleccionada
            if (dgvEvaluaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEvaluaciones.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    gestor.SetEvaluacionParaComparar(gestor.evaluacionService.GetEvaluacionXId((int)selectedRow.Cells[0].Value));
                }
                else
                {
                    gestor.SetEvaluacionParaComparar(null);
                }
            }
            else
            {
                gestor.SetEvaluacionParaComparar(null);
            }
        }
    }
}
