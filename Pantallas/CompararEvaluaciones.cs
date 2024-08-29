using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaKinesiologia.Pantallas
{
    public partial class CompararEvaluaciones : Form
    {
        Gestor gestor;
        public CompararEvaluaciones(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            lblNombrePacienteCompletar.Text = gestor.GetPacienteActual().nombre;
            lblCompletarLesionPaciente.Text = gestor.GetLesionActual().diagnostico;

            int inicio = (1109 - (lblNombrePacienteCompletar.Width + 5 + lblTituloPaciente.Width + 20 + lblCompletarLesionPaciente.Width + 5 + lblTituloLesion.Width)) / 2;

            lblTituloPaciente.Location = new Point(inicio, 20);
            lblNombrePacienteCompletar.Location = new Point(inicio + 5 + lblTituloPaciente.Width, 20);
            lblTituloLesion.Location = new Point(inicio + 5 + lblTituloPaciente.Width + 20 + lblNombrePacienteCompletar.Width, 20);
            lblCompletarLesionPaciente.Location = new Point(inicio + 5 + lblTituloPaciente.Width + 20 + lblNombrePacienteCompletar.Width + 5 + lblTituloLesion.Width, 20);

            btnAggEvaluacion.Location = new Point(895, 293);

            this.CargarEvaluacionUno();
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CargarEvaluacionUno()
        {
            if (gestor.GetEvaluacionActual() != null)
            {
                // Primera parte:
                TBoxNombreEvaluacion1.Text = gestor.GetEvaluacionActual().GetNombre();
                lblFechaACompletarE1.Text = gestor.GetEvaluacionActual().GetFecha().ToString("d");
                textObservacionesEvaluacion1.Text = gestor.GetEvaluacionActual().GetObservacionesEvaluacion();

                // tabla 1
                TBoxNombreTabla1E1.Text = gestor.GetEvaluacionActual().GetNombreTabla1();
                // tabla 1
                TBoxNombreTabla1E1.Text = gestor.GetEvaluacionActual().GetNombreTabla1();
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
                    // tabla 2
                    TBoxNombreTabla2E1.Text = gestor.GetEvaluacionActual().GetNombreTabla2();

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

        private void btnAggEvaluacion_Click_1(object sender, EventArgs e)
        {
            SelectorEvaluacion ventanaSelector = new SelectorEvaluacion(gestor);

            if (ventanaSelector.ShowDialog() == DialogResult.OK)
            {
                btnAggEvaluacion.Visible = false;
                panelEvaluacion2.Visible = true;

                // Cargar datos de evaluacion 
                this.CargarEvaluacionDos();
            }
        }

        void CargarEvaluacionDos()
        {
            if (gestor.GetEvaluacionParaComparar() != null)
            {
                // Primera parte:
                lblNombreEvaluacion2.Text = gestor.GetEvaluacionParaComparar().GetNombre();
                lblFechaCompletarE2.Text = gestor.GetEvaluacionParaComparar().GetFecha().ToString("d");
                textObservacionesE2.Text = gestor.GetEvaluacionParaComparar().GetObservacionesEvaluacion();

                // tabla 1
                lblNombreTabla1E2.Text = gestor.GetEvaluacionParaComparar().GetNombreTabla1();
                // Fila 1:
                while (gestor.GetEvaluacionActual().GetFila1Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila1Tabla1().Add(" ");
                }
                TBox11Tabla1E2.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla1()[0].ToString();
                TBox12Tabla1E2.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla1()[1].ToString();
                guna2TextBox41.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla1()[2].ToString();
                guna2TextBox36.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla1()[3].ToString();
                guna2TextBox27.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla1()[4].ToString();

                // Fila 2:
                while (gestor.GetEvaluacionActual().GetFila2Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila2Tabla1().Add(" ");
                }
                TBox21Tabla1E2.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla1()[0].ToString();
                TBox22Tabla1E2.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla1()[1].ToString();
                guna2TextBox40.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla1()[2].ToString();
                guna2TextBox35.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla1()[3].ToString();
                guna2TextBox31.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla1()[4].ToString();

                // Fila 3:
                while (gestor.GetEvaluacionActual().GetFila3Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila3Tabla1().Add(" ");
                }
                TBox31Tabla1E2.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla1()[0].ToString();
                TBox32Tabla1E2.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla1()[1].ToString();
                guna2TextBox39.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla1()[2].ToString();
                guna2TextBox34.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla1()[3].ToString();
                guna2TextBox30.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla1()[4].ToString();

                // Fila 4:
                while (gestor.GetEvaluacionActual().GetFila4Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila4Tabla1().Add(" ");
                }
                TBox41Tabla1E2.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla1()[0].ToString();
                guna2TextBox43.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla1()[1].ToString();
                guna2TextBox38.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla1()[2].ToString();
                guna2TextBox33.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla1()[3].ToString();
                guna2TextBox29.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla1()[4].ToString();

                // Fila 5:
                while (gestor.GetEvaluacionActual().GetFila5Tabla1().Count < 5)
                {
                    gestor.GetEvaluacionActual().GetFila5Tabla1().Add(" ");
                }
                TBox51Tabla1E2.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla1()[0].ToString();
                guna2TextBox42.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla1()[1].ToString();
                guna2TextBox37.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla1()[2].ToString();
                guna2TextBox32.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla1()[3].ToString();
                guna2TextBox28.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla1()[4].ToString();

                if (gestor.GetEvaluacionParaComparar().nombreTabla2 != null)
                {
                    // tabla 2
                    lblNombreTabla2E2.Text = gestor.GetEvaluacionParaComparar().GetNombreTabla2();

                    // Fila 1:
                    while (gestor.GetEvaluacionActual().GetFila1Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila1Tabla2().Add(" ");
                    }
                    guna2TextBox1.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla2()[0].ToString();
                    guna2TextBox7.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla2()[1].ToString();
                    guna2TextBox12.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla2()[2].ToString();
                    guna2TextBox17.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla2()[3].ToString();
                    guna2TextBox22.Text = gestor.GetEvaluacionParaComparar().GetFila1Tabla2()[4].ToString();

                    // Fila 2:
                    while (gestor.GetEvaluacionActual().GetFila2Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila2Tabla2().Add(" ");
                    }
                    guna2TextBox3.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla2()[0].ToString();
                    guna2TextBox8.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla2()[1].ToString();
                    guna2TextBox13.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla2()[2].ToString();
                    guna2TextBox18.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla2()[3].ToString();
                    guna2TextBox23.Text = gestor.GetEvaluacionParaComparar().GetFila2Tabla2()[4].ToString();

                    // Fila 3:
                    while (gestor.GetEvaluacionActual().GetFila3Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila3Tabla2().Add(" ");
                    }
                    guna2TextBox4.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla2()[0].ToString();
                    guna2TextBox9.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla2()[1].ToString();
                    guna2TextBox14.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla2()[2].ToString();
                    guna2TextBox19.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla2()[3].ToString();
                    guna2TextBox24.Text = gestor.GetEvaluacionParaComparar().GetFila3Tabla2()[4].ToString();

                    // Fila 4:
                    while (gestor.GetEvaluacionActual().GetFila4Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila4Tabla2().Add(" ");
                    }
                    guna2TextBox5.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla2()[0].ToString();
                    guna2TextBox10.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla2()[1].ToString();
                    guna2TextBox15.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla2()[2].ToString();
                    guna2TextBox20.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla2()[3].ToString();
                    guna2TextBox25.Text = gestor.GetEvaluacionParaComparar().GetFila4Tabla2()[4].ToString();

                    // Fila 5:
                    while (gestor.GetEvaluacionActual().GetFila5Tabla2().Count < 5)
                    {
                        gestor.GetEvaluacionActual().GetFila5Tabla2().Add(" ");
                    }
                    guna2TextBox6.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla2()[0].ToString();
                    guna2TextBox11.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla2()[1].ToString();
                    guna2TextBox16.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla2()[2].ToString();
                    guna2TextBox21.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla2()[3].ToString();
                    guna2TextBox26.Text = gestor.GetEvaluacionParaComparar().GetFila5Tabla2()[4].ToString();
                }
            }
        }
    }
}


