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
    public partial class PantallaConfirmacion : Form
    {
        Gestor gestor;
        
        public PantallaConfirmacion(Gestor gestor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;
        }
        public PantallaConfirmacion(Gestor gestor, int numero)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;
            lblPregunta.Text = "¿Confirmar registro de lesión?";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            // proveniente de registrar paciente
            // agg lesion al paciente
            gestor.GetPacienteActual().AgregarLesion(gestor.GetLesionActual());

            if (gestor.GetBanderaSesion())
            {
                // agg sesion al paciente
                gestor.GetSesionActual().SetKinesiologoSesion(gestor.GetKinesiologoActual());
                gestor.GetPacienteActual().AgregarSesion(gestor.GetSesionActual());
                // agg lesion a la sesion
                gestor.GetSesionActual().SetLesionSesion(gestor.GetLesionActual());
            }
            if (gestor.GetBanderaEvaluacion())
            {
                // agg evaluacion a la lesion
                gestor.GetEvaluacionActual().AsignarKine(gestor.GetKinesiologoActual());
                gestor.GetLesionActual().AgregarEvaluacion(gestor.GetEvaluacionActual());
            }
            if (gestor.GetBanderaEntrenamientoCreado())
            {
                // agg kine al entrenamiento
                gestor.GetPlanDeEntrenamientoActual().AsignarKine(gestor.GetKinesiologoActual());
                // agg entrenamiento a la lesion
                gestor.GetLesionActual().AgregarPlanDeEntrenamientoParaLesion(gestor.GetPlanDeEntrenamientoActual());
                gestor.GetPacienteActual().AgregarPlanDeEntrenamiento(gestor.GetPlanDeEntrenamientoActual());

            }
            if (gestor.GetBanderaNuevaLesion() == false)
            {
                gestor.pacienteService.AddPaciente(gestor.GetPacienteActual());

                MessageBox.Show("Paciente registrado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                gestor.pacienteService.ActualizarPaciente(gestor.GetPacienteActual());

                MessageBox.Show("Lesión registrada correctamente.\nPaciente: " + gestor.GetPacienteActual().nombre
                    + " Lesión: " + gestor.GetLesionActual().diagnostico, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            this.Close();
        }
    }
}
