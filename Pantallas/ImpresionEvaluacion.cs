using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaKinesiologia.Pantallas
{
    public partial class ImpresionEvaluacion : Form
    {
        Gestor gestor;
        private System.Windows.Forms.Timer timerMostrar;
        private System.Windows.Forms.Timer timerCerrar;

        public ImpresionEvaluacion(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            lblCompletarNombrePaciente.Text = gestor.GetPacienteActual().nombre;
            lblCompletarLesion.Text = gestor.GetLesionActual().diagnostico;
            lblEdadCompletar.Text = gestor.GetPacienteActual().edad.ToString();

            this.CargarDatos();
            this.SetearTextBoxs();

            // Configurar el primer Timer para esperar 3 segundos antes de generar el PDF
            timerMostrar = new System.Windows.Forms.Timer();
            timerMostrar.Interval = 1000; // 3000 ms = 3 segundos
            timerMostrar.Tick += new EventHandler(TimerMostrar_Tick);
            timerMostrar.Start();

        }
        void SetearTextBoxs()
        {
            // Tabla 1
            // Fila 1:
            primeraTabla11.ReadOnly = true;
            primeraTabla12.ReadOnly = true;
            primeraTabla13.ReadOnly = true;
            primeraTabla14.ReadOnly = true;
            primeraTabla1c5.ReadOnly = true;

            // Fila 2:
            primeraTabla21.ReadOnly = true;
            primeraTabla22.ReadOnly = true;
            primeraTabla23.ReadOnly = true;
            primeraTabla24.ReadOnly = true;
            primeraTabla25.ReadOnly = true;

            // Fila 3:
            primeraTabla31.ReadOnly = true;
            primeraTabla32.ReadOnly = true;
            primeraTabla33.ReadOnly = true;
            primeraTabla34.ReadOnly = true;
            primeraTabla35.ReadOnly = true;

            // Fila 4:
            primeraTabla41.ReadOnly = true;
            primeraTabla42.ReadOnly = true;
            primeraTabla43.ReadOnly = true;
            primeraTabla44.ReadOnly = true;
            primeraTabla45.ReadOnly = true;

            // Fila 5:
            primeraTabla51.ReadOnly = true;
            primeraTabla52.ReadOnly = true;
            primeraTabla53.ReadOnly = true;
            primeraTabla54.ReadOnly = true;
            primeraTabla55.ReadOnly = true;

            // Tabla 2
            // Fila 1:
            segundaTabla1f1.ReadOnly = true;
            segundaTabla12.ReadOnly = true;
            segundaTabla13.ReadOnly = true;
            segundaTabla14.ReadOnly = true;
            segundaTabla15.ReadOnly = true;

            // Fila 2:
            segundaTabla21.ReadOnly = true;
            segundaTabla22.ReadOnly = true;
            segundaTabla23.ReadOnly = true;
            segundaTabla24.ReadOnly = true;
            segundaTabla25.ReadOnly = true;

            // Fila 3:
            segundaTabla31.ReadOnly = true;
            segundaTabla32.ReadOnly = true;
            segundaTabla33.ReadOnly = true;
            segundaTabla34.ReadOnly = true;
            segundaTabla35.ReadOnly = true;

            // Fila 4:
            segundaTabla41.ReadOnly = true;
            segundaTabla42.ReadOnly = true;
            segundaTabla43.ReadOnly = true;
            segundaTabla44.ReadOnly = true;
            segundaTabla45.ReadOnly = true;

            // Fila 5:
            segundaTabla51.ReadOnly = true;
            segundaTabla52.ReadOnly = true;
            segundaTabla53.ReadOnly = true;
            segundaTabla54.ReadOnly = true;
            segundaTabla55.ReadOnly = true;

            // ********************************************

            // Tabla 1
            // Fila 1:
            primeraTabla11.TabStop = false;
            primeraTabla12.TabStop = false;
            primeraTabla13.TabStop = false;
            primeraTabla14.TabStop = false;
            primeraTabla1c5.TabStop = false;

            // Fila 2:
            primeraTabla21.TabStop = false;
            primeraTabla22.TabStop = false;
            primeraTabla23.TabStop = false;
            primeraTabla24.TabStop = false;
            primeraTabla25.TabStop = false;

            // Fila 3:
            primeraTabla31.TabStop = false;
            primeraTabla32.TabStop = false;
            primeraTabla33.TabStop = false;
            primeraTabla34.TabStop = false;
            primeraTabla35.TabStop = false;

            // Fila 4:
            primeraTabla41.TabStop = false;
            primeraTabla42.TabStop = false;
            primeraTabla43.TabStop = false;
            primeraTabla44.TabStop = false;
            primeraTabla45.TabStop = false;

            // Fila 5:
            primeraTabla51.TabStop = false;
            primeraTabla52.TabStop = false;
            primeraTabla53.TabStop = false;
            primeraTabla54.TabStop = false;
            primeraTabla55.TabStop = false;

            // Tabla 2
            // Fila 1:
            segundaTabla1f1.TabStop = false;
            segundaTabla12.TabStop = false;
            segundaTabla13.TabStop = false;
            segundaTabla14.TabStop = false;
            segundaTabla15.TabStop = false;

            // Fila 2:
            segundaTabla21.TabStop = false;
            segundaTabla22.TabStop = false;
            segundaTabla23.TabStop = false;
            segundaTabla24.TabStop = false;
            segundaTabla25.TabStop = false;

            // Fila 3:
            segundaTabla31.TabStop = false;
            segundaTabla32.TabStop = false;
            segundaTabla33.TabStop = false;
            segundaTabla34.TabStop = false;
            segundaTabla35.TabStop = false;

            // Fila 4:
            segundaTabla41.TabStop = false;
            segundaTabla42.TabStop = false;
            segundaTabla43.TabStop = false;
            segundaTabla44.TabStop = false;
            segundaTabla45.TabStop = false;

            // Fila 5:
            segundaTabla51.TabStop = false;
            segundaTabla52.TabStop = false;
            segundaTabla53.TabStop = false;
            segundaTabla54.TabStop = false;
            segundaTabla55.TabStop = false;
        }
        static string QuitarEspacios(string cadena)
        {
            return cadena.Replace(" ", "-");
        }

        void GenerarPDF()
        {
            // Quito espacios en el nombre para NombrePDF:
            string nombreSinEspacios = QuitarEspacios(gestor.GetPacienteActual().nombre);
            string evaluacionSinEspacios = QuitarEspacios(gestor.GetEvaluacionActual().nombre);

            // Definir las coordenadas del área que deseas capturar
            int x = 0; // coordenada x del punto de inicio de la captura
            int y = 0; // coordenada y del punto de inicio de la captura
            int ancho = 550; // ancho del área que deseas capturar
            int alto = 700; // alto del área que deseas capturar

            // Crear un Bitmap del tamaño del área que deseas capturar
            Bitmap bmp = new Bitmap(ancho, alto);

            // Capturar el contenido del formulario en el área especificada
            System.Drawing.Rectangle areaCaptura = new System.Drawing.Rectangle(x, y, ancho, alto);
            this.DrawToBitmap(bmp, areaCaptura);

            // Recortar la parte superior no deseada de la imagen
            Bitmap imagenRecortada = bmp.Clone(new System.Drawing.Rectangle(10, 35, bmp.Width - 10, bmp.Height - 35), bmp.PixelFormat);

            // Generar un nombre de archivo temporal único
            string nombreArchivoTemporal = "tempfile_" + DateTime.Now.Ticks + ".png";
            // Guardar la imagen recortada en un archivo temporal
            string archivoTemporal = Path.Combine(Path.GetTempPath(), nombreArchivoTemporal);
            imagenRecortada.Save(archivoTemporal, ImageFormat.Png);

            // Especificar la ruta de destino para el archivo PDF
            string directorioDestino = @"C:\OpticaPDF"; // Reemplaza con tu ruta de destino deseada

            // Crear un nuevo documento PDF
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            string archivoPDF = Path.Combine(directorioDestino, "Evaluacion_" + nombreSinEspacios + "---" + evaluacionSinEspacios + DateTime.Now.ToString("FFF") + ".pdf");
            PdfWriter.GetInstance(doc, new FileStream(archivoPDF, FileMode.Create));
            doc.Open();

            // Agregar la imagen recortada al documento PDF
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(archivoTemporal);
            doc.Add(imagen);

            doc.Close();
        }
        void CargarDatos()
        {
            if (gestor.GetEvaluacionActual() != null)
            {
                // Primera parte:
                TBoxNombreEvaluacion1.Text = gestor.GetEvaluacionActual().GetNombre();
                lblFechaACompletarE1.Text = gestor.GetEvaluacionActual().GetFecha().ToString("d");
                textObservacionesEvaluacion1.Text = gestor.GetEvaluacionActual().GetObservacionesEvaluacion();

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
                else { this.OcultarSegundaTabla(); }
            }
        }
        
        void OcultarSegundaTabla()
        {
            // tabla 2
            lblTituloNombreTabla2.Visible = false;
            TBoxNombreTabla2E1.Text = gestor.GetEvaluacionActual().GetNombreTabla2();

            // Fila 1:
            segundaTabla1f1.Visible = false;
            segundaTabla12.Visible = false;
            segundaTabla13.Visible = false;
            segundaTabla14.Visible = false;
            segundaTabla15.Visible = false;

            // Fila 2:
            segundaTabla21.Visible = false;
            segundaTabla22.Visible = false;
            segundaTabla23.Visible = false;
            segundaTabla24.Visible = false;
            segundaTabla25.Visible = false;

            // Fila 3:
            segundaTabla31.Visible = false;
            segundaTabla32.Visible = false;
            segundaTabla33.Visible = false;
            segundaTabla34.Visible = false;
            segundaTabla35.Visible = false;

            // Fila 4:
            segundaTabla41.Visible = false;
            segundaTabla42.Visible = false;
            segundaTabla43.Visible = false;
            segundaTabla44.Visible = false;
            segundaTabla45.Visible = false;

            // Fila 5:
            segundaTabla51.Visible = false;
            segundaTabla52.Visible = false;
            segundaTabla53.Visible = false;
            segundaTabla54.Visible = false;
            segundaTabla55.Visible = false;
        }
        private void TimerMostrar_Tick(object sender, EventArgs e)
        {
            // Detener el primer Timer
            timerMostrar.Stop();

            // Generar el PDF
            this.GenerarPDF();

            // Mostrar mensaje de confirmación
            MessageBox.Show("Archivo PDF evaluación generado exitosamente.", "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Configurar el segundo Timer para cerrar el formulario después de 2 segundos
            timerCerrar = new System.Windows.Forms.Timer();
            timerCerrar.Interval = 1000; // 2000 ms = 2 segundos
            timerCerrar.Tick += new EventHandler(TimerCerrar_Tick);
            timerCerrar.Start();
        }

        private void TimerCerrar_Tick(object sender, EventArgs e)
        {
            // Detener el segundo Timer y cerrar el formulario
            timerCerrar.Stop();
            this.Close();
        }
    }
}
