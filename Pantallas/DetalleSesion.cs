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
    public partial class DetalleSesion : Form
    {
        Gestor gestor;
        bool banderaNuevaSesion = false;
        public DetalleSesion(Gestor gestor)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;
            banderaNuevaSesion = false;
            this.CargarDatosSesion();
        }

        public DetalleSesion(Gestor gestor, int numero)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.gestor = gestor;
            banderaNuevaSesion = true;
            btnEditarSesion.Visible = false;
            btnConfirmarEdicion.Visible = true;
            btnConfirmarEdicion.Text = "Confirmar sesión";
            btnConfirmarEdicion.Location = new Point(327, 376);

            lblTituloLesion.Visible = true;
            cmbLesion.Visible = true;

            dtpFechaDeSesion.Value = DateTime.Now;
            cmbLesion.Items.Add("NINGUNA");

            foreach (Lesion lesion in gestor.GetPacienteActual().lesiones)
            {
                cmbLesion.Items.Add(lesion.diagnostico);
            }
        }

        private void btnCerarr_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnEditarSesion_Click(object sender, EventArgs e)
        {
            panelSesión.Enabled = true;
            dtpFechaDeSesion.Enabled = true;
            textObservacionesDeSesion.Enabled = true;
            btnConfirmarEdicion.Visible = true;

        }

        void CargarDatosSesion()
        {
            lblnumeroSesionCompletar.Text = gestor.GetSesionActual().numeroSesionDelPaciente.ToString();
            dtpFechaDeSesion.Value = gestor.GetSesionActual().fecha;
            textObservacionesDeSesion.Text = gestor.GetSesionActual().observaciones;
        }

        private void btnConfirmarEdicion_Click(object sender, EventArgs e)
        {
            if (this.banderaNuevaSesion == false)
            {
                this.TomarDatosEdicion();

                // Guardar datos en BD
                gestor.sesionService.ActualizarSesion(gestor.GetSesionActual());

                MessageBox.Show("Los datos de la sesión se han actualizado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.TomarDatos();

                string lesion = "NINGUNA";
                if (gestor.GetLesionActual() != null)
                {
                    gestor.GetLesionActual().AgregarSesion(gestor.GetSesionActual());
                    lesion = gestor.GetLesionActual().diagnostico;
                }
                gestor.GetPacienteActual().AgregarSesion(gestor.GetSesionActual());

                // Guardar datos en BD
                gestor.pacienteService.ActualizarPaciente(gestor.GetPacienteActual());

                MessageBox.Show("La sesión se agregó correctamente.\nPaciente: " + gestor.GetPacienteActual().nombre +
                       "\nLesión: " + lesion, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
        void TomarDatosEdicion()
        {
            gestor.GetSesionActual().fecha = dtpFechaDeSesion.Value;

            gestor.GetSesionActual().observaciones = textObservacionesDeSesion.Text.ToUpper();

        }

        void TomarDatos()
        {
            if(cmbLesion.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione una opción de lesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Sesion sesion = new Sesion(dtpFechaDeSesion.Value, textObservacionesDeSesion.Text);
                if (int.TryParse(lblnumeroSesionCompletar.Text, out int numeroSesion))
                {
                    sesion.SetNumeroSesion(numeroSesion);
                }
                sesion.SetKinesiologoSesion(gestor.GetKinesiologoActual());

                gestor.SetSesionActual(sesion);
            }
            
        }

        private void cmbLesion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitamos los campos para editar:
            textObservacionesDeSesion.Enabled = true;
            dtpFechaDeSesion.Enabled = true;

            // Cargamos numero de sesion:
            string seleccion = cmbLesion.SelectedItem.ToString();

            int? numeroSesion = null;
            if (seleccion != "NINGUNA")
            {
                foreach (Lesion lesion in gestor.GetPacienteActual().lesiones)
                {
                    if (seleccion == lesion.diagnostico)
                    {
                        gestor.SetLesionActual(lesion);
                        break;
                    }
                }

                numeroSesion = gestor.GetLesionActual().sesiones.Count + 1;
            }
            else
            {
                gestor.SetLesionActual(null);
                int contadorSesionesParticulares = 0;
                foreach (Sesion sesion in gestor.GetPacienteActual().sesiones)
                {
                    if(sesion.lesion == null) { contadorSesionesParticulares++; }
                }

                numeroSesion = contadorSesionesParticulares + 1;
            }

            lblnumeroSesionCompletar.Text = numeroSesion.ToString();
        }
    }
}
