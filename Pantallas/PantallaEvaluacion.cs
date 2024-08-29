using SistemaKinesiologia.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaKinesiologia.Pantallas
{
    public partial class PantallaEvaluacion : Form
    {
        Gestor gestor;
        Evaluacion evaluacionRealizada;

        bool banderaParaPrimeraEvaluacion = true;

        public PantallaEvaluacion(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            banderaParaPrimeraEvaluacion = true;

            this.CargarDatosCliente();

            dtpFechaEvaluacion.Value = DateTime.Now;

        }

        public PantallaEvaluacion(Gestor gestor, int numero)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            banderaParaPrimeraEvaluacion = false;

            this.CargarDatosCliente();

            this.CargarDatosEvaluacion();

            btnCancelarEvaluacion.Text = "Cerrar";
            btnConfirmarEvaluacion.Text = "Confirmar cambios";
        }

        private void btnConfirmarEvaluacion_Click(object sender, EventArgs e)
        {
            // Tomamos los datos de la pantalla y validamos  
            if (banderaParaPrimeraEvaluacion)
            {
                if (this.ValidarCamposIngresados())
                {
                    DialogResult = DialogResult.OK;

                    gestor.SetBanderaPrimeraEvaluacion(true);
                    gestor.SetEvaluacionActual(evaluacionRealizada);

                    this.Close();
                }
            }
            else
            {
                if (this.ValidarCamposActualizados())
                {
                    DialogResult = DialogResult.OK;

                    this.Close();
                }
            }
        }

        private void btnCancelarEvaluacion_Click(object sender, EventArgs e)
        {
            if (banderaParaPrimeraEvaluacion)
            {
                DialogResult = DialogResult.Cancel;
                gestor.SetBanderaPrimeraEvaluacion(false);
                gestor.SetEvaluacionActual(null);
            }

            this.Close();
        }


        private void btnAgregarTabla1_Click(object sender, EventArgs e)
        {
            panelGrandeMasTablas.Visible = true;
            gestor.SetBanderaSegundaTabla(true);
        }

        void CargarDatosCliente()
        {
            TBoxPacienteCompletar.Text = gestor.GetNombrePacienteActual();
            TBoxEdadCompletar.Text = gestor.GetEdadPacienteActual().ToString();
            textAntecedentesCompletar.Text = gestor.GetAntecedentesPacienteActual();
        }

        private void btnLimpiarTabla1_Click(object sender, EventArgs e)
        {
            this.LimpiarTabla1();
        }

        void LimpiarTabla1()
        {
            // FIla 1:
            primeraTabla11.Clear();
            primeraTabla12.Clear();
            primeraTabla13.Clear();
            primeraTabla14.Clear();
            primeraTabla1c5.Clear();
            // FIla 2:
            primeraTabla21.Clear();
            primeraTabla22.Clear();
            primeraTabla23.Clear();
            primeraTabla24.Clear();
            primeraTabla25.Clear();
            // FIla 3:
            primeraTabla31.Clear();
            primeraTabla32.Clear();
            primeraTabla33.Clear();
            primeraTabla34.Clear();
            primeraTabla35.Clear();
            // FIla 4:
            primeraTabla41.Clear();
            primeraTabla42.Clear();
            primeraTabla43.Clear();
            primeraTabla44.Clear();
            primeraTabla45.Clear();
            // FIla 5:
            primeraTabla51.Clear();
            primeraTabla52.Clear();
            primeraTabla53.Clear();
            primeraTabla54.Clear();
            primeraTabla55.Clear();
        }

        void LimpiarTabla2()
        {
            // FIla 1:
            segundaTabla1f1.Clear();
            segundaTabla12.Clear();
            segundaTabla13.Clear();
            segundaTabla14.Clear();
            segundaTabla15.Clear();
            // FIla 2:
            segundaTabla21.Clear();
            segundaTabla22.Clear();
            segundaTabla23.Clear();
            segundaTabla24.Clear();
            segundaTabla25.Clear();
            // FIla 3:
            segundaTabla31.Clear();
            segundaTabla32.Clear();
            segundaTabla33.Clear();
            segundaTabla34.Clear();
            segundaTabla35.Clear();
            // FIla 4:
            segundaTabla41.Clear();
            segundaTabla42.Clear();
            segundaTabla43.Clear();
            segundaTabla44.Clear();
            segundaTabla45.Clear();
            // FIla 5:
            segundaTabla51.Clear();
            segundaTabla52.Clear();
            segundaTabla53.Clear();
            segundaTabla54.Clear();
            segundaTabla55.Clear();
        }

        private void btnLimpiarTabla2_Click(object sender, EventArgs e)
        {
            this.LimpiarTabla2();
        }

        private void btnLimpiarPlanilla_Click(object sender, EventArgs e)
        {
            this.LimpiarPlanillaDeEvaluacion();
        }

        void LimpiarPlanillaDeEvaluacion()
        {
            // Parte de evaluacion
            TBoxNombreEvaluacion.Text = "descriptivo de la evaluación.";
            dtpFechaEvaluacion.Value = DateTime.Now;
            textObservacionesEvaluacion.Text = "Ninguna.";

            // primera tabla
            TBoxNombreTabla1.Text = "descriptivo de la tabla.";
            this.LimpiarTabla1();

            // segunda tabla
            TBoxNombreTabla2.Text = "descriptivo de la tabla.";
            this.LimpiarTabla2();
        }

        private void TBoxNombreEvaluacion_Enter(object sender, EventArgs e)
        {
            TBoxNombreEvaluacion.Text = "";
        }

        private void TBoxNombreTabla1_Enter(object sender, EventArgs e)
        {
            TBoxNombreTabla1.Text = "";
        }

        private void TBoxNombreTabla2_Enter(object sender, EventArgs e)
        {
            TBoxNombreTabla2.Text = "";
        }

        private void btnBorrarTabla_Click(object sender, EventArgs e)
        {
            panelGrandeMasTablas.Visible = false;
            gestor.SetBanderaSegundaTabla(false);
            this.LimpiarTabla2();
            TBoxNombreTabla2.Text = "descriptivo de la tabla.";

        }


        bool ValidarCamposIngresados()
        {
            Evaluacion nuevaEvaluacion = new Evaluacion();
            //Banderas
            bool banderaGeneral = false;
            bool banderaTabla1 = false;
            bool banderaTabla2 = true;

            // General
            if (this.ValidarNombre())
            {
                banderaGeneral = true;
                nuevaEvaluacion.SetNombre(TBoxNombreEvaluacion.Text.ToUpper());
                nuevaEvaluacion.SetFecha(dtpFechaEvaluacion.Value);
                nuevaEvaluacion.SetObservaciones(textObservacionesEvaluacion.Text.ToUpper());
            }
            else
            {
                MessageBox.Show("Por favor ingrese un nombre válido para la evaluación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            // Tabla 1
            if (this.ValidarNombreTabla(TBoxNombreTabla1.Text))
            {
                banderaTabla1 = true;
                nuevaEvaluacion.SetNombreTabla1(TBoxNombreTabla1.Text.ToUpper());
                nuevaEvaluacion.SetFila1Tabla1(new List<string> { primeraTabla11.Text, primeraTabla12.Text, primeraTabla13.Text, primeraTabla14.Text, primeraTabla1c5.Text });
                nuevaEvaluacion.SetFila2Tabla1(new List<string> { primeraTabla21.Text, primeraTabla22.Text, primeraTabla23.Text, primeraTabla24.Text, primeraTabla25.Text });
                nuevaEvaluacion.SetFila3Tabla1(new List<string> { primeraTabla31.Text, primeraTabla32.Text, primeraTabla33.Text, primeraTabla34.Text, primeraTabla35.Text });
                nuevaEvaluacion.SetFila4Tabla1(new List<string> { primeraTabla41.Text, primeraTabla42.Text, primeraTabla43.Text, primeraTabla44.Text, primeraTabla45.Text });
                nuevaEvaluacion.SetFila5Tabla1(new List<string> { primeraTabla51.Text, primeraTabla52.Text, primeraTabla53.Text, primeraTabla54.Text, primeraTabla55.Text });
            }
            else { MessageBox.Show("Por favor ingrese un nombre válido para la primera tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }


            // Tabla 2
            if (gestor.GetSegundaTablaBandera())
            {
                banderaTabla2 = false;
                if (this.ValidarNombreTabla(TBoxNombreTabla2.Text))
                {
                    banderaTabla2 = true;
                    nuevaEvaluacion.SetNombreTabla2(TBoxNombreTabla2.Text.ToUpper());
                    nuevaEvaluacion.SetFila1Tabla2(new List<string> { segundaTabla1f1.Text, segundaTabla12.Text, segundaTabla13.Text, segundaTabla14.Text, segundaTabla15.Text });
                    nuevaEvaluacion.SetFila2Tabla2(new List<string> { segundaTabla21.Text, segundaTabla22.Text, segundaTabla23.Text, segundaTabla24.Text, segundaTabla25.Text });
                    nuevaEvaluacion.SetFila3Tabla2(new List<string> { segundaTabla31.Text, segundaTabla32.Text, segundaTabla33.Text, segundaTabla34.Text, segundaTabla35.Text });
                    nuevaEvaluacion.SetFila4Tabla2(new List<string> { segundaTabla41.Text, segundaTabla42.Text, segundaTabla43.Text, segundaTabla44.Text, segundaTabla45.Text });
                    nuevaEvaluacion.SetFila5Tabla2(new List<string> { segundaTabla51.Text, segundaTabla52.Text, segundaTabla53.Text, segundaTabla54.Text, segundaTabla55.Text });
                }
                else { MessageBox.Show("Por favor ingrese un nombre válido para la segunda tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }

            if (banderaGeneral && banderaTabla1 && banderaTabla2)
            {
                evaluacionRealizada = nuevaEvaluacion;
                return true;
            }
            else
            {
                return false;
            }
        }

        bool ValidarCamposActualizados()
        {
            //Banderas
            bool banderaGeneral = false;
            bool banderaTabla1 = false;
            bool banderaTabla2 = true;

            // General
            if (this.ValidarNombre())
            {
                banderaGeneral = true;
                gestor.GetEvaluacionActual().SetNombre(TBoxNombreEvaluacion.Text.ToUpper());
                gestor.GetEvaluacionActual().SetFecha(dtpFechaEvaluacion.Value);
                gestor.GetEvaluacionActual().SetObservaciones(textObservacionesEvaluacion.Text.ToUpper());
            }
            else
            {
                MessageBox.Show("Por favor ingrese un nombre válido para la evaluación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            // Tabla 1
            if (this.ValidarNombreTabla(TBoxNombreTabla1.Text))
            {
                banderaTabla1 = true;
                gestor.GetEvaluacionActual().SetNombreTabla1(TBoxNombreTabla1.Text.ToUpper());
                gestor.GetEvaluacionActual().SetFila1Tabla1(new List<string> { primeraTabla11.Text, primeraTabla12.Text, primeraTabla13.Text, primeraTabla14.Text, primeraTabla1c5.Text });
                gestor.GetEvaluacionActual().SetFila2Tabla1(new List<string> { primeraTabla21.Text, primeraTabla22.Text, primeraTabla23.Text, primeraTabla24.Text, primeraTabla25.Text });
                gestor.GetEvaluacionActual().SetFila3Tabla1(new List<string> { primeraTabla31.Text, primeraTabla32.Text, primeraTabla33.Text, primeraTabla34.Text, primeraTabla35.Text });
                gestor.GetEvaluacionActual().SetFila4Tabla1(new List<string> { primeraTabla41.Text, primeraTabla42.Text, primeraTabla43.Text, primeraTabla44.Text, primeraTabla45.Text });
                gestor.GetEvaluacionActual().SetFila5Tabla1(new List<string> { primeraTabla51.Text, primeraTabla52.Text, primeraTabla53.Text, primeraTabla54.Text, primeraTabla55.Text });
            }
            else { MessageBox.Show("Por favor ingrese un nombre válido para la primera tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }


            // Tabla 2
            if (gestor.GetSegundaTablaBandera())
            {
                banderaTabla2 = false;
                if (this.ValidarNombreTabla(TBoxNombreTabla2.Text))
                {
                    banderaTabla2 = true;
                    gestor.GetEvaluacionActual().SetNombreTabla2(TBoxNombreTabla2.Text.ToUpper());
                    gestor.GetEvaluacionActual().SetFila1Tabla2(new List<string> { segundaTabla1f1.Text, segundaTabla12.Text, segundaTabla13.Text, segundaTabla14.Text, segundaTabla15.Text });
                    gestor.GetEvaluacionActual().SetFila2Tabla2(new List<string> { segundaTabla21.Text, segundaTabla22.Text, segundaTabla23.Text, segundaTabla24.Text, segundaTabla25.Text });
                    gestor.GetEvaluacionActual().SetFila3Tabla2(new List<string> { segundaTabla31.Text, segundaTabla32.Text, segundaTabla33.Text, segundaTabla34.Text, segundaTabla35.Text });
                    gestor.GetEvaluacionActual().SetFila4Tabla2(new List<string> { segundaTabla41.Text, segundaTabla42.Text, segundaTabla43.Text, segundaTabla44.Text, segundaTabla45.Text });
                    gestor.GetEvaluacionActual().SetFila5Tabla2(new List<string> { segundaTabla51.Text, segundaTabla52.Text, segundaTabla53.Text, segundaTabla54.Text, segundaTabla55.Text });
                }
                else { MessageBox.Show("Por favor ingrese un nombre válido para la segunda tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }

            if (banderaGeneral && banderaTabla1 && banderaTabla2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool ValidarNombre()
        {
            if (!Regex.IsMatch(TBoxNombreEvaluacion.Text, @"\d") && !string.IsNullOrWhiteSpace(TBoxNombreEvaluacion.Text) &&
                TBoxNombreEvaluacion.Text != "descriptivo de la evaluación")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool ValidarNombreTabla(string nombre)
        {
            if (!Regex.IsMatch(nombre, @"\d") && !string.IsNullOrWhiteSpace(nombre) &&
               nombre != "descriptivo de la tabla")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void CargarDatosEvaluacion()
        {
            if (gestor.GetEvaluacionActual() != null)
            {
                // Primera parte:
                TBoxNombreEvaluacion.Text = gestor.GetEvaluacionActual().GetNombre();
                dtpFechaEvaluacion.Value = gestor.GetEvaluacionActual().GetFecha();
                textObservacionesEvaluacion.Text = gestor.GetEvaluacionActual().GetObservacionesEvaluacion();

                // tabla 1
                TBoxNombreTabla1.Text = gestor.GetEvaluacionActual().GetNombreTabla1();
                // Fila 1:
                while (gestor.GetEvaluacionActual().GetFila1Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila1Tabla1().Add(" ");
                }
                primeraTabla11.Text = gestor.GetEvaluacionActual().GetFila1Tabla1()[0].ToString();
                primeraTabla12.Text = gestor.GetEvaluacionActual().GetFila1Tabla1()[1].ToString();
                primeraTabla13.Text = gestor.GetEvaluacionActual().GetFila1Tabla1()[2].ToString();
                primeraTabla14.Text = gestor.GetEvaluacionActual().GetFila1Tabla1()[3].ToString();
                primeraTabla1c5.Text = gestor.GetEvaluacionActual().GetFila1Tabla1()[4].ToString();

                // Fila 2:
                while (gestor.GetEvaluacionActual().GetFila2Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila2Tabla1().Add(" ");
                }
                primeraTabla21.Text = gestor.GetEvaluacionActual().GetFila2Tabla1()[0].ToString();
                primeraTabla22.Text = gestor.GetEvaluacionActual().GetFila2Tabla1()[1].ToString();
                primeraTabla23.Text = gestor.GetEvaluacionActual().GetFila2Tabla1()[2].ToString();
                primeraTabla24.Text = gestor.GetEvaluacionActual().GetFila2Tabla1()[3].ToString();
                primeraTabla25.Text = gestor.GetEvaluacionActual().GetFila2Tabla1()[4].ToString();

                // Fila 3:
                while (gestor.GetEvaluacionActual().GetFila3Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila3Tabla1().Add(" ");
                }
                primeraTabla31.Text = gestor.GetEvaluacionActual().GetFila3Tabla1()[0].ToString();
                primeraTabla32.Text = gestor.GetEvaluacionActual().GetFila3Tabla1()[1].ToString();
                primeraTabla33.Text = gestor.GetEvaluacionActual().GetFila3Tabla1()[2].ToString();
                primeraTabla34.Text = gestor.GetEvaluacionActual().GetFila3Tabla1()[3].ToString();
                primeraTabla35.Text = gestor.GetEvaluacionActual().GetFila3Tabla1()[4].ToString();

                // Fila 4:
                while (gestor.GetEvaluacionActual().GetFila4Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila4Tabla1().Add(" ");
                }
                primeraTabla41.Text = gestor.GetEvaluacionActual().GetFila4Tabla1()[0].ToString();
                primeraTabla42.Text = gestor.GetEvaluacionActual().GetFila4Tabla1()[1].ToString();
                primeraTabla43.Text = gestor.GetEvaluacionActual().GetFila4Tabla1()[2].ToString();
                primeraTabla44.Text = gestor.GetEvaluacionActual().GetFila4Tabla1()[3].ToString();
                primeraTabla45.Text = gestor.GetEvaluacionActual().GetFila4Tabla1()[4].ToString();

                // Fila 5:
                while (gestor.GetEvaluacionActual().GetFila5Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila5Tabla1().Add(" ");
                }
                primeraTabla51.Text = gestor.GetEvaluacionActual().GetFila5Tabla1()[0].ToString();
                primeraTabla52.Text = gestor.GetEvaluacionActual().GetFila5Tabla1()[1].ToString();
                primeraTabla53.Text = gestor.GetEvaluacionActual().GetFila5Tabla1()[2].ToString();
                primeraTabla54.Text = gestor.GetEvaluacionActual().GetFila5Tabla1()[3].ToString();
                primeraTabla55.Text = gestor.GetEvaluacionActual().GetFila5Tabla1()[4].ToString();

                if (gestor.GetEvaluacionActual().nombreTabla2 != null)
                {
                    panelGrandeMasTablas.Visible = true;
                    // tabla 2
                    TBoxNombreTabla2.Text = gestor.GetEvaluacionActual().GetNombreTabla2();

                    // Fila 1:
                    while (gestor.GetEvaluacionActual().GetFila1Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila1Tabla2().Add(" ");
                    }
                    segundaTabla1f1.Text = gestor.GetEvaluacionActual().GetFila1Tabla2()[0].ToString();
                    segundaTabla12.Text = gestor.GetEvaluacionActual().GetFila1Tabla2()[1].ToString();
                    segundaTabla13.Text = gestor.GetEvaluacionActual().GetFila1Tabla2()[2].ToString();
                    segundaTabla14.Text = gestor.GetEvaluacionActual().GetFila1Tabla2()[3].ToString();
                    segundaTabla15.Text = gestor.GetEvaluacionActual().GetFila1Tabla2()[4].ToString();

                    // Fila 2:
                    while (gestor.GetEvaluacionActual().GetFila2Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila2Tabla2().Add(" ");
                    }
                    segundaTabla21.Text = gestor.GetEvaluacionActual().GetFila2Tabla2()[0].ToString();
                    segundaTabla22.Text = gestor.GetEvaluacionActual().GetFila2Tabla2()[1].ToString();
                    segundaTabla23.Text = gestor.GetEvaluacionActual().GetFila2Tabla2()[2].ToString();
                    segundaTabla24.Text = gestor.GetEvaluacionActual().GetFila2Tabla2()[3].ToString();
                    segundaTabla25.Text = gestor.GetEvaluacionActual().GetFila2Tabla2()[4].ToString();

                    // Fila 3:
                    while (gestor.GetEvaluacionActual().GetFila3Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila3Tabla2().Add(" ");
                    }
                    segundaTabla31.Text = gestor.GetEvaluacionActual().GetFila3Tabla2()[0].ToString();
                    segundaTabla32.Text = gestor.GetEvaluacionActual().GetFila3Tabla2()[1].ToString();
                    segundaTabla33.Text = gestor.GetEvaluacionActual().GetFila3Tabla2()[2].ToString();
                    segundaTabla34.Text = gestor.GetEvaluacionActual().GetFila3Tabla2()[3].ToString();
                    segundaTabla35.Text = gestor.GetEvaluacionActual().GetFila3Tabla2()[4].ToString();

                    // Fila 4:
                    while (gestor.GetEvaluacionActual().GetFila4Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila4Tabla2().Add(" ");
                    }
                    segundaTabla41.Text = gestor.GetEvaluacionActual().GetFila4Tabla2()[0].ToString();
                    segundaTabla42.Text = gestor.GetEvaluacionActual().GetFila4Tabla2()[1].ToString();
                    segundaTabla43.Text = gestor.GetEvaluacionActual().GetFila4Tabla2()[2].ToString();
                    segundaTabla44.Text = gestor.GetEvaluacionActual().GetFila4Tabla2()[3].ToString();
                    segundaTabla45.Text = gestor.GetEvaluacionActual().GetFila4Tabla2()[4].ToString();

                    // Fila 5:
                    while (gestor.GetEvaluacionActual().GetFila5Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila5Tabla2().Add(" ");
                    }
                    segundaTabla51.Text = gestor.GetEvaluacionActual().GetFila5Tabla2()[0].ToString();
                    segundaTabla52.Text = gestor.GetEvaluacionActual().GetFila5Tabla2()[1].ToString();
                    segundaTabla53.Text = gestor.GetEvaluacionActual().GetFila5Tabla2()[2].ToString();
                    segundaTabla54.Text = gestor.GetEvaluacionActual().GetFila5Tabla2()[3].ToString();
                    segundaTabla55.Text = gestor.GetEvaluacionActual().GetFila5Tabla2()[4].ToString();
                }

            }
        }

        private void btnImprimirEvaluacion_Click(object sender, EventArgs e)
        {
            ImpresionEvaluacion impresionEvaluacion = new ImpresionEvaluacion(gestor);
            impresionEvaluacion.Show();
        }
    }
}
