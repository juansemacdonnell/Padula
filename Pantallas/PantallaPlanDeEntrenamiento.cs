using iTextSharp.text.pdf;
using SistemaKinesiologia.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaKinesiologia.Pantallas
{
    public partial class PantallaPlanDeEntrenamiento : Form
    {
        Gestor gestor;
        PlanDeGimnasio planCreado;

        bool banderaPrimerPLan = true;
        bool banderaAgregarPlan = true;
        bool banderaPlanGenerico = false;
        public PantallaPlanDeEntrenamiento(Gestor gestor)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            banderaPrimerPLan = true;
            banderaAgregarPlan = false;
            banderaPlanGenerico = false;

            this.CargarNombrePaciente();
            dtpFechaPlan.Value = DateTime.Now;
        }

        public PantallaPlanDeEntrenamiento(Gestor gestor, string palabra)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            banderaPrimerPLan = true;
            banderaAgregarPlan = true;
            banderaPlanGenerico = false;

            this.CargarNombrePaciente();

            dtpFechaPlan.Value = DateTime.Now;

            lblTituloLesion.Visible = true;
            cmbLesion.Visible = true;

            lblPlanCargardo.Visible = true;
            cmbPlanCargado.Visible = true;

            cmbLesion.Items.Add("NINGUNA");

            foreach (Lesion lesion in gestor.GetPacienteActual().lesiones)
            {
                cmbLesion.Items.Add(lesion.diagnostico);
            }

            cmbLesion.SelectedItem = cmbLesion.Items[0];

            foreach (PlanDeGimnasio plan in gestor.planDeEntrenamientoService.GetPlanesSinPaciente())
            {
                cmbPlanCargado.Items.Add(plan.nombre);
            }
        }

        public PantallaPlanDeEntrenamiento(Gestor gestor, int numero)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            banderaPrimerPLan = false;
            banderaAgregarPlan = false;
            banderaPlanGenerico = false;

            this.CargarNombrePaciente();
            this.CargarPlanYaCreado();

            btnCancelarPlan.Text = "Cerrar";
            btnConfirmarPlan.Text = "Confirmar cambios";

        }

        public PantallaPlanDeEntrenamiento(Gestor gestor, bool bandera)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.gestor = gestor;

            banderaPrimerPLan = false;
            banderaAgregarPlan = false;
            banderaPlanGenerico = true;

            lblTituloPaciente.Visible = false;
            TBoxPacienteCompletar.Visible = false;
            dtpFechaPlan.Visible = false;

        }

        private void btnCancelarPlan_Click(object sender, EventArgs e)
        {
            if (banderaPrimerPLan)
            {
                if (banderaAgregarPlan == false)
                {
                    gestor.SetBanderaPlanDeEntrenamiento(false);
                    gestor.SetPlanDeEntrenamientoActual(null);
                    DialogResult = DialogResult.Cancel;
                }
            }

            this.Close();
        }

        private void btnConfirmarPlan_Click(object sender, EventArgs e)
        {
            if (banderaPrimerPLan)
            {
                if (banderaAgregarPlan == false)
                {
                    // Tomamos los datos de la pantalla y validamos
                    if (this.ValidarCamposIngresados())
                    {
                        DialogResult = DialogResult.OK;
                        gestor.SetBanderaPlanDeEntrenamiento(true);
                        gestor.SetPlanDeEntrenamientoActual(planCreado);

                        this.Close();
                    }
                }
                else
                {
                    // Tomamos los datos de la pantalla y validamos
                    if (this.ValidarCamposIngresados())
                    {
                        DialogResult = DialogResult.OK;
                        gestor.SetPlanDeEntrenamientoActual(planCreado);

                        gestor.GetPlanDeEntrenamientoActual().AsignarKine(gestor.GetKinesiologoActual());
                        gestor.GetPacienteActual().AgregarPlanDeEntrenamiento(gestor.GetPlanDeEntrenamientoActual());

                        string seleccion = cmbLesion.SelectedItem.ToString();

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

                            gestor.GetLesionActual().AgregarPlanDeEntrenamientoParaLesion(gestor.GetPlanDeEntrenamientoActual());
                        }

                        this.Close();
                    }
                }

            }
            else if (banderaPlanGenerico)
            {
                if (this.ValidarCamposIngresados())
                {
                    gestor.SetPlanDeEntrenamientoActual(planCreado);

                    gestor.GetPlanDeEntrenamientoActual().AsignarKine(gestor.GetKinesiologoActual());

                    gestor.planDeEntrenamientoService.AddPlanDeGimnasio(gestor.GetPlanDeEntrenamientoActual());

                    // Mostrar mensaje de confirmación
                    MessageBox.Show("Plan de entrenamiento cargado correctamente.\nNombre: " + gestor.GetPlanDeEntrenamientoActual().nombre, "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    gestor.SetPlanDeEntrenamientoActual(null);

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

        bool ValidarCamposIngresados()
        {
            // Solo validamos el nombre
            if (!string.IsNullOrWhiteSpace(TBoxNombrePlan.Text) && TBoxNombrePlan.Text != "descriptivo del plan")
            {
                List<string> Fila1 = new List<string> { rich11.Text, rich12.Text, rich13.Text };
                List<string> Fila2 = new List<string> { rich21.Text, rich22.Text, rich23.Text };
                List<string> Fila3 = new List<string> { rich31.Text, rich32.Text, rich33.Text };
                List<string> Fila4 = new List<string> { rich41.Text, rich42.Text, rich43.Text };
                List<string> Fila5 = new List<string> { rich51.Text, rich52.Text, rich53.Text };

                // Recorremos filas hasta que se encuentre 1 valor:
                bool banderaValor = false;

                foreach (string valor in Fila1)
                {
                    if (valor != "")
                    {
                        banderaValor = true;
                        break;
                    }
                }
                if (banderaValor == false)
                {
                    foreach (string valor in Fila2)
                    {
                        if (valor != "")
                        {
                            banderaValor = true;
                            break;
                        }
                    }
                }
                if (banderaValor == false)
                {
                    foreach (string valor in Fila3)
                    {
                        if (valor != "")
                        {
                            banderaValor = true;
                            break;
                        }
                    }
                }
                if (banderaValor == false)
                {
                    foreach (string valor in Fila4)
                    {
                        if (valor != "")
                        {
                            banderaValor = true;
                            break;
                        }
                    }
                }
                if (banderaValor == false)
                {
                    foreach (string valor in Fila5)
                    {
                        if (valor != "")
                        {
                            banderaValor = true;
                            break;
                        }
                    }
                }

                if (banderaValor)
                {
                    if (ValidarNombreColumna(TBoxColumna1.Text) && ValidarNombreColumna(TBoxColumna2.Text) && ValidarNombreColumna(TBoxColumna3.Text))
                    {
                        planCreado = new PlanDeGimnasio();
                        planCreado.SetTituloColumna1(TBoxColumna1.Text.ToUpper());
                        planCreado.SetTituloColumna2(TBoxColumna2.Text.ToUpper());
                        planCreado.SetTituloColumna3(TBoxColumna3.Text.ToUpper());
                        planCreado.SetNombre(TBoxNombrePlan.Text.ToUpper());
                        planCreado.SetFecha(dtpFechaPlan.Value);
                        planCreado.SetFila1(Fila1);
                        planCreado.SetFila2(Fila2);
                        planCreado.SetFila3(Fila3);
                        planCreado.SetFila4(Fila4);
                        planCreado.SetFila5(Fila5);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Hay un error en alguna de las cabeceras de columnas de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese al menos un valor en la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un nombre válido para el plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        bool ValidarCamposActualizados()
        {
            // Solo validamos el nombre
            if (!string.IsNullOrWhiteSpace(TBoxNombrePlan.Text) && TBoxNombrePlan.Text != "descriptivo del plan")
            {
                List<string> Fila1 = new List<string> { rich11.Text, rich12.Text, rich13.Text };
                List<string> Fila2 = new List<string> { rich21.Text, rich22.Text, rich23.Text };
                List<string> Fila3 = new List<string> { rich31.Text, rich32.Text, rich33.Text };
                List<string> Fila4 = new List<string> { rich41.Text, rich42.Text, rich43.Text };
                List<string> Fila5 = new List<string> { rich51.Text, rich52.Text, rich53.Text };

                // Recorremos filas hasta que se encuentre 1 valor:
                bool banderaValor = false;

                foreach (string valor in Fila1)
                {
                    if (valor != "")
                    {
                        banderaValor = true;
                        break;
                    }
                }
                if (banderaValor == false)
                {
                    foreach (string valor in Fila2)
                    {
                        if (valor != "")
                        {
                            banderaValor = true;
                            break;
                        }
                    }
                }
                if (banderaValor == false)
                {
                    foreach (string valor in Fila3)
                    {
                        if (valor != "")
                        {
                            banderaValor = true;
                            break;
                        }
                    }
                }
                if (banderaValor == false)
                {
                    foreach (string valor in Fila4)
                    {
                        if (valor != "")
                        {
                            banderaValor = true;
                            break;
                        }
                    }
                }
                if (banderaValor == false)
                {
                    foreach (string valor in Fila5)
                    {
                        if (valor != "")
                        {
                            banderaValor = true;
                            break;
                        }
                    }
                }

                if (banderaValor)
                {
                    if (ValidarNombreColumna(TBoxColumna1.Text) && ValidarNombreColumna(TBoxColumna2.Text) && ValidarNombreColumna(TBoxColumna3.Text))
                    {
                        gestor.GetPlanDeEntrenamientoActual().SetTituloColumna1(TBoxColumna1.Text.ToUpper());
                        gestor.GetPlanDeEntrenamientoActual().SetTituloColumna2(TBoxColumna2.Text.ToUpper());
                        gestor.GetPlanDeEntrenamientoActual().SetTituloColumna3(TBoxColumna3.Text.ToUpper());
                        gestor.GetPlanDeEntrenamientoActual().SetNombre(TBoxNombrePlan.Text.ToUpper());
                        gestor.GetPlanDeEntrenamientoActual().SetFecha(dtpFechaPlan.Value);
                        gestor.GetPlanDeEntrenamientoActual().SetFila1(Fila1);
                        gestor.GetPlanDeEntrenamientoActual().SetFila2(Fila2);
                        gestor.GetPlanDeEntrenamientoActual().SetFila3(Fila3);
                        gestor.GetPlanDeEntrenamientoActual().SetFila4(Fila4);
                        gestor.GetPlanDeEntrenamientoActual().SetFila5(Fila5);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Hay un error en alguna de las cabeceras de columnas de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese al menos un valor en la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un nombre válido para el plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void TBoxNombrePlan_Enter(object sender, EventArgs e)
        {
            TBoxNombrePlan.Text = "";
        }

        void CargarNombrePaciente()
        {
            TBoxPacienteCompletar.Text = gestor.GetNombrePacienteActual();
        }

        void CargarPlanYaCreado()
        {
            TBoxNombrePlan.Text = gestor.GetPlanDeEntrenamientoActual().GetNombre();
            dtpFechaPlan.Value = gestor.GetPlanDeEntrenamientoActual().GetFecha();

            while (gestor.GetPlanDeEntrenamientoActual().GetFila1().Count < 3)
            {
                gestor.GetPlanDeEntrenamientoActual().GetFila1().Add(" ");
            }
            rich11.Text = gestor.GetPlanDeEntrenamientoActual().GetFila1()[0];
            rich12.Text = gestor.GetPlanDeEntrenamientoActual().GetFila1()[1];
            rich13.Text = gestor.GetPlanDeEntrenamientoActual().GetFila1()[2];

            while (gestor.GetPlanDeEntrenamientoActual().GetFila2().Count < 3)
            {
                gestor.GetPlanDeEntrenamientoActual().GetFila2().Add(" ");
            }
            rich21.Text = gestor.GetPlanDeEntrenamientoActual().GetFila2()[0];
            rich22.Text = gestor.GetPlanDeEntrenamientoActual().GetFila2()[1];
            rich23.Text = gestor.GetPlanDeEntrenamientoActual().GetFila2()[2];

            while (gestor.GetPlanDeEntrenamientoActual().GetFila3().Count < 3)
            {
                gestor.GetPlanDeEntrenamientoActual().GetFila3().Add(" ");
            }
            rich31.Text = gestor.GetPlanDeEntrenamientoActual().GetFila3()[0];
            rich32.Text = gestor.GetPlanDeEntrenamientoActual().GetFila3()[1];
            rich33.Text = gestor.GetPlanDeEntrenamientoActual().GetFila3()[2];

            while (gestor.GetPlanDeEntrenamientoActual().GetFila4().Count < 3)
            {
                gestor.GetPlanDeEntrenamientoActual().GetFila4().Add(" ");
            }
            rich41.Text = gestor.GetPlanDeEntrenamientoActual().GetFila4()[0];
            rich42.Text = gestor.GetPlanDeEntrenamientoActual().GetFila4()[1];
            rich43.Text = gestor.GetPlanDeEntrenamientoActual().GetFila4()[2];

            while (gestor.GetPlanDeEntrenamientoActual().GetFila5().Count < 3)
            {
                gestor.GetPlanDeEntrenamientoActual().GetFila5().Add(" ");
            }
            rich51.Text = gestor.GetPlanDeEntrenamientoActual().GetFila5()[0];
            rich52.Text = gestor.GetPlanDeEntrenamientoActual().GetFila5()[1];
            rich53.Text = gestor.GetPlanDeEntrenamientoActual().GetFila5()[2];
        }

        bool ValidarNombreColumna(string nombre)
        {
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnImprimirPlan_Click(object sender, EventArgs e)
        {
            // Quito espacios en el nombre para NombrePDF:
            string nombreSinEspacios = QuitarEspacios(gestor.GetPacienteActual().nombre);
            string planSinEspacios = QuitarEspacios(gestor.GetPlanDeEntrenamientoActual().nombre);


            // Eliminamos botones que no queremos:
            btnCancelarPlan.Visible = false;
            btnConfirmarPlan.Visible = false;
            btnImprimirPlan.Visible = false;

            // CReamos el pdf con la imagen del formulario
            // ancho a4 550 y largo 750 918; 636
            // Definir las coordenadas del área que deseas capturar
            int x = 0; // coordenada x del punto de inicio de la captura
            int y = 0; // coordenada y del punto de inicio de la captura
            int ancho = 935; // ancho del área que deseas capturar
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
            // C:\Users\martin\Desktop\OpticaPDF  --  C:\OpticaPDF
            string directorioDestino = @"C:\OpticaPDF"; // Reemplaza con tu ruta de destino deseada

            // Crear un nuevo documento PDF
            //iTextSharp.text.Document doc = new iTextSharp.text.Document();
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate());
            string archivoPDF = Path.Combine(directorioDestino, "PlanDeEntrenamiento-" + planSinEspacios + "---Paciente-" + nombreSinEspacios + "-" + DateTime.Now.ToString("FFF") + ".pdf");
            PdfWriter.GetInstance(doc, new FileStream(archivoPDF, FileMode.Create));
            doc.Open();

            // Agregar la imagen recortada al documento PDF
            //iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(archivoTemporal);
            //doc.Add(imagen);

            // Agregar la imagen recortada al documento PDF
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(archivoTemporal);
            float escala1 = doc.PageSize.Width;
            float escala2 = doc.PageSize.Height;
            imagen.ScaleToFit(escala1, escala2);
            imagen.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
            doc.Add(imagen);

            doc.Close();

            // Mostrar mensaje de confirmación
            MessageBox.Show("Archivo PDF generado exitosamente.", "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnCancelarPlan.Visible = true;
            btnConfirmarPlan.Visible = true;
            btnImprimirPlan.Visible = true;
        }

        static string QuitarEspacios(string cadena)
        {
            return cadena.Replace(" ", "-");
        }

        private void cmbPlanCargado_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(PlanDeGimnasio plan in gestor.planDeEntrenamientoService.GetPlanesSinPaciente())
            {
                if(plan.nombre.ToUpper() == cmbPlanCargado.SelectedItem.ToString().ToUpper())
                {
                    gestor.SetPlanDeEntrenamientoActual(plan);
                }
            }

            if(gestor.GetPlanDeEntrenamientoActual() != null)
            {
                this.CargarPlanYaCreado();
            }
        }
    }
}
