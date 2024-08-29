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
    public partial class RegistrarPaciente : Form
    {
        Gestor gestor;

        public RegistrarPaciente(Gestor gestor)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.gestor = gestor;

            gestor.SetBanderaNuevaLesion(false);
            // Cargamos cmb boxs
            this.CargarCmbBoxObrasSociales();
            this.CargarCmbBoxSesion();
            this.CargarKeyPress();

            dtpFechaDeSesion.Value = DateTime.Now;
            dtpFechaLesion.Value = DateTime.Now;    
        }

        public RegistrarPaciente(Gestor gestor, int numero)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.gestor = gestor;

            gestor.SetBanderaNuevaLesion(true);
            // Cargamos cmb boxs
            this.CargarCmbBoxObrasSociales();
            this.CargarCmbBoxSesion();
            this.CargarKeyPress();
            this.CargarDatosPaciente();
            this.DeshabilitarTextBoxPaciente();

            dtpFechaDeSesion.Value = DateTime.Now;
            dtpFechaLesion.Value = DateTime.Now;
        }


        // General
        #region General

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            if (gestor.GetBanderaNuevaLesion() == false)
            {
                gestor.SetPacienteActual(null);
            }
            gestor.SetLesionActual(null);
            gestor.SetSesionActual(null);
            gestor.SetEvaluacionActual(null);
            gestor.SetPlanDeEntrenamientoActual(null);

            gestor.SetBanderaSesion(false);
            gestor.SetBanderaPrimeraEvaluacion(false);
            gestor.SetBanderaPlanDeEntrenamiento(false);
            gestor.SetBanderaNuevaLesion(false);

            this.Close();
        }

        private void btnLimpiarPlanilla_Click(object sender, EventArgs e)
        {
            this.LimpiarPanelRegistro();
        }

        void LimpiarPanelRegistro()
        {
            // Parte Paciente
            if(gestor.GetBanderaNuevaLesion() == false)
            {
                gestor.SetPacienteActual(null);
            }
            TBoxNombreYApellido.Clear();
            TBoxEdad.Clear();
            TBoxTelefono.Clear();
            TBoxDni.Clear();
            textAntecedentes.Text = "No presenta.";
            this.CargarCmbBoxObrasSociales();

            // Parte Lesion
            gestor.SetLesionActual(null);
            TBoxDiagnostico.Clear();
            TBoxMedico.Clear();
            textConsideracionesTratamiento.Text = "Ninguna.";
            dtpFechaLesion.Value = DateTime.Now;

            // Parte primera Sesion
            gestor.SetBanderaSesion(false);
            gestor.SetSesionActual(null);
            this.CargarCmbBoxSesion();

            // Parte primera Evaluacion
            gestor.SetBanderaPrimeraEvaluacion(false);
            gestor.SetEvaluacionActual(null);
            this.DeshabilitarPanelPrimeraEvaluacion();

            // Parte plan de entrenamiento
            gestor.SetBanderaPlanDeEntrenamiento(false);
            gestor.SetPlanDeEntrenamientoActual(null);
            this.DeshabilitarPanelPlan();

        }
        #endregion

        // Paciente
        #region Paciente
        void CargarCmbBoxObrasSociales()
        {
            cmbBoxObraSocial.Items.Clear();

            foreach (string obraSocial in gestor.GetListadoObraSociales())
            {
                cmbBoxObraSocial.Items.Add(obraSocial);
            }

            cmbBoxObraSocial.SelectedItem = cmbBoxObraSocial.Items[0];
        }

        #endregion

        // Lesion
        #region Lesion

        #endregion

        // Sesion
        #region Sesion
        void CargarCmbBoxSesion()
        {
            cmbBoxDesicionPrimeraSesion.Items.Clear();
            cmbBoxDesicionPrimeraSesion.Items.AddRange(new string[] { "SI", "NO" });
            cmbBoxDesicionPrimeraSesion.SelectedItem = cmbBoxDesicionPrimeraSesion.Items[1];
        }
        private void cmbBoxDesicionPrimeraSesion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxDesicionPrimeraSesion.SelectedItem.ToString() == "NO")
            {
                panelPrimeraSesión.Enabled = false;
                this.LimpiarPanelPrimeraSesion();
            }
            else if (cmbBoxDesicionPrimeraSesion.SelectedItem.ToString() == "SI")
            {
                panelPrimeraSesión.Enabled = true;
            }
        }
        void LimpiarPanelPrimeraSesion()
        {
            dtpFechaDeSesion.Value = DateTime.Now;
            textObservacionesDeSesion.Text = "Ninguna.";
        }
        #endregion

        // Evaluacion
        #region Evaluacion
        private void btnAgregarEvaluacion_Click(object sender, EventArgs e)
        {
            // validamos datos del cliente para ya agg al gestor
            if(gestor.GetBanderaNuevaLesion() == false)
            {
                if (this.ValidarPaciente())
                {
                    PantallaEvaluacion pantallaEvaluacion = new PantallaEvaluacion(gestor);
                    pantallaEvaluacion.ShowDialog();

                    if (pantallaEvaluacion.DialogResult == DialogResult.OK)
                    {
                        this.HabilitarPanelPrimeraEvaluacion();
                    }
                }
                else
                {
                    MessageBox.Show("Para cargar una evaluación primero ingrese los datos del paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                PantallaEvaluacion pantallaEvaluacion = new PantallaEvaluacion(gestor);
                pantallaEvaluacion.ShowDialog();

                if (pantallaEvaluacion.DialogResult == DialogResult.OK)
                {
                    this.HabilitarPanelPrimeraEvaluacion();
                }
            }
        }
        void HabilitarPanelPrimeraEvaluacion()
        {
            btnAgregarEvaluacion.Visible = false;
            panelPrimeraEvaluacion.Visible = true;
            panelPrimeraEvaluacion.Enabled = true;
            lblNombrePrimeraEvaluacionCompletar.Text = gestor.GetNombrePrimeraEvaluacion();
            lblFechaPrimeraEvaluacionCompletar.Text = gestor.GetFechaPrimeraEvaluacion().ToString("dd/MM/yy");
        }

        private void btnVerEvaluacion_Click(object sender, EventArgs e)
        {
            PantallaEvaluacion pantallaEvaluacion = new PantallaEvaluacion(gestor, 1);
            pantallaEvaluacion.ShowDialog();

            if (pantallaEvaluacion.DialogResult == DialogResult.OK)
            {
                this.HabilitarPanelPrimeraEvaluacion();
            }
        }

        private void btnBorrarEvaluacion_Click(object sender, EventArgs e)
        {
            gestor.SetBanderaPrimeraEvaluacion(false);
            gestor.SetEvaluacionActual(null);

            this.DeshabilitarPanelPrimeraEvaluacion();
        }

        void DeshabilitarPanelPrimeraEvaluacion()
        {
            panelPrimeraEvaluacion.Visible = false;
            btnAgregarEvaluacion.Visible = true;
        }
        #endregion

        // Plan de entrenamiento
        #region PLan de entrenamiento
        private void btnAgregarPlanDeEntrenamiento_Click(object sender, EventArgs e)
        {
            if(gestor.GetBanderaNuevaLesion() == false)
            {
                // validamos datos del cliente para ya agg al gestor
                if (this.ValidarPaciente())
                {
                    PantallaPlanDeEntrenamiento panatallaPlan = new PantallaPlanDeEntrenamiento(gestor);
                    panatallaPlan.ShowDialog();

                    if (panatallaPlan.DialogResult == DialogResult.OK)
                    {
                        this.HabilitarPanelPlan();
                    }
                }
                else
                {
                    MessageBox.Show("Para cargar un plan de entrenamiento primero ingrese los datos del paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                PantallaPlanDeEntrenamiento panatallaPlan = new PantallaPlanDeEntrenamiento(gestor);
                panatallaPlan.ShowDialog();

                if (panatallaPlan.DialogResult == DialogResult.OK)
                {
                    this.HabilitarPanelPlan();
                }
            } 
        }

        void HabilitarPanelPlan()
        {
            btnAgregarPlanDeEntrenamiento.Visible = false;
            panelPlanDeEntrenamiento.Visible = true;
            panelPlanDeEntrenamiento.Enabled = true;
            lblNombrePlanDeEntrenamientoCompletar.Text = gestor.GetNombrePlanDeEntrenamiento();
            lblFechaPlanDeEntrenamientoCompletar.Text = gestor.GetFechaPlanDeEntrenamiento().ToString("dd/MM/yy");
        }
        private void btnVerPlanDeEntrenamiento_Click(object sender, EventArgs e)
        {
            PantallaPlanDeEntrenamiento pantallaPLan = new PantallaPlanDeEntrenamiento(gestor, 1);
            pantallaPLan.ShowDialog();

            if (pantallaPLan.DialogResult == DialogResult.OK)
            {
                this.HabilitarPanelPlan();
            }
        }

        private void btnBorrarPlanDeEntrenamiento_Click(object sender, EventArgs e)
        {
            gestor.SetBanderaPlanDeEntrenamiento(false);
            gestor.SetPlanDeEntrenamientoActual(null);

            this.DeshabilitarPanelPlan();
        }
        void DeshabilitarPanelPlan()
        {
            panelPlanDeEntrenamiento.Visible = false;
            btnAgregarPlanDeEntrenamiento.Visible = true;
        }
        #endregion

        // KeyPress
        #region KeyPress
        void CargarKeyPress()
        {
            // Paciente
            TBoxNombreYApellido.KeyPress += Nombres_KeyPress;
            TBoxEdad.KeyPress += SoloNumeros_KeyPress;
            TBoxDni.KeyPress += SoloNumeros_KeyPress;
            TBoxTelefono.KeyPress += NumeroTelefono_KeyPress;

            // Lesion
            TBoxDiagnostico.KeyPress += Nombres_KeyPress;
            TBoxMedico.KeyPress += Nombres_KeyPress;
        }
        // Para que solo se ingresen numeros
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Expresión regular que solo permite números
            Regex regex = new Regex(@"[^0-9]");

            // Verificar si el carácter ingresado coincide con la expresión regular
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                // Si no coincide, cancelar la pulsación
                e.Handled = true;
                // Reproducir un sonido de error
                SystemSounds.Beep.Play();
            }
        }
        // Para que solo se ingresen numeros, coma y punto
        private void NumeroTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Expresión regular que solo permite números, paréntesis y guiones
            Regex regex = new Regex(@"[^0-9\(\)\-]");

            // Verificar si el carácter ingresado coincide con la expresión regular
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                // Si no coincide, cancelar la pulsación
                e.Handled = true;
                // Reproducir un sonido de error
                SystemSounds.Beep.Play();
            }
        }

        // Para nombres
        private void Nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Expresión regular que permite letras, espacios y algunos caracteres especiales comunes en nombres
            Regex regex = new Regex(@"[^a-zA-ZñÑ\s\-\'\,]");

            // Verificar si el carácter ingresado coincide con la expresión regular
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                // Si no coincide, cancelar la pulsación
                e.Handled = true;
                // Reproducir un sonido de error
                SystemSounds.Beep.Play();
            }
        }
        #endregion

        private void btnConfirmarRegistro_Click(object sender, EventArgs e)
        {
            if(gestor.GetBanderaNuevaLesion() == false)
            {
                // Validar Paciente - Validar Lesion
                if (this.ValidarPaciente() && this.ValidarLesion() && this.ValidarSesion())
                {
                    PantallaConfirmacion pantallaConfirmacion = new PantallaConfirmacion(gestor);
                    pantallaConfirmacion.ShowDialog();

                    if (pantallaConfirmacion.DialogResult == DialogResult.OK)
                    {
                        this.LimpiarPanelRegistro();
                    }
                }
            }
            else
            {
                // Validar Paciente - Validar Lesion
                if (this.ValidarLesion() && this.ValidarSesion())
                {
                    PantallaConfirmacion pantallaConfirmacion = new PantallaConfirmacion(gestor, 1);
                    pantallaConfirmacion.ShowDialog();

                    if (pantallaConfirmacion.DialogResult == DialogResult.OK)
                    {
                        this.LimpiarPanelRegistro();
                        gestor.SetBanderaNuevaLesion(false);
                        this.Close();
                        
                    }
                }
            }
            
        }

        bool ValidarPaciente()
        {
            // Por ahora solo validamos el nombre y edad
            if (!Regex.IsMatch(TBoxNombreYApellido.Text, @"\d") && !string.IsNullOrWhiteSpace(TBoxNombreYApellido.Text))
            {
                if(int.TryParse(TBoxEdad.Text, out int edadPaciente) && edadPaciente > 0)
                {
                    // Creamos el paciente y lo asignamos al gestor (paciente actual)
                    Paciente pacienteNuevo = new Paciente(TBoxNombreYApellido.Text.ToUpper(), edadPaciente,
                        TBoxTelefono.Text, textAntecedentes.Text.ToUpper(), TBoxDni.Text, cmbBoxObraSocial.SelectedItem.ToString());
                    gestor.SetPacienteActual(pacienteNuevo);
                    return true;
                }
                else
                {
                    MessageBox.Show("Hay un error en la edad del paciente.\nPor favor ingrese un valor válido (solo números y distinto de 0).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else 
            {
                MessageBox.Show("Hay un error en el nombre del paciente.\n Por favor ingrese un nombre válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false; 
            }
        }

        bool ValidarLesion()
        {
            if (!Regex.IsMatch(TBoxDiagnostico.Text, @"\d") && !string.IsNullOrWhiteSpace(TBoxDiagnostico.Text))
            {
                // creamos la lesion y la asignamos al gestor
                Lesion nuevaLesion = new Lesion(TBoxDiagnostico.Text.ToUpper(), TBoxMedico.Text.ToUpper(), dtpFechaLesion.Value, textConsideracionesTratamiento.Text.ToUpper());
                gestor.SetLesionActual(nuevaLesion);
                return true;
            }
            else
            {
                MessageBox.Show("Hay un error en el nombre que identifica a la lesión.\n Por favor ingrese un nombre válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        bool ValidarSesion()
        {
            if (cmbBoxDesicionPrimeraSesion.SelectedItem.ToString() == "SI")
            {
                // creamos la sesion y la asignamos al gestor
                Sesion primeraSesion = new Sesion(dtpFechaDeSesion.Value, textObservacionesDeSesion.Text.ToUpper());
                primeraSesion.SetKinesiologoSesion(gestor.GetKinesiologoActual());
                gestor.SetSesionActual(primeraSesion);
                gestor.SetBanderaSesion(true);
                return true;
            }
            else
            {
                gestor.SetBanderaSesion(false);
                gestor.SetSesionActual(null);
                return true;
            }
        }

        void CargarDatosPaciente()
        {
            lblTituloNuevoPaciente.Text = "Información del paciente";
            int posicionInicio = (495 - lblTituloNuevoPaciente.Width) / 2;
            lblTituloNuevoPaciente.Location = new Point(posicionInicio, 7);

            TBoxNombreYApellido.Text = gestor.GetPacienteActual().nombre;
            TBoxEdad.Text = gestor.GetPacienteActual().edad.ToString();
            TBoxTelefono.Text = gestor.GetPacienteActual().telefono;
            TBoxDni.Text = gestor.GetPacienteActual().documento;
            textAntecedentes.Text = gestor.GetPacienteActual().antecedentes;

            cmbBoxObraSocial.Items.Clear();

            for (int i = 0; i < gestor.GetListadoObraSociales().Count; i++)
            {
                cmbBoxObraSocial.Items.Add(gestor.GetListadoObraSociales()[i]);
                if (gestor.GetListadoObraSociales()[i].ToUpper() == gestor.GetPacienteActual().obraSocial.ToString().ToUpper())
                {
                    cmbBoxObraSocial.SelectedIndex = i;
                }
            }
        }

        void DeshabilitarTextBoxPaciente()
        {
            TBoxNombreYApellido.Enabled = false;
            TBoxEdad.Enabled = false;
            TBoxTelefono.Enabled = false;
            TBoxDni.Enabled = false;
            textAntecedentes.Enabled = false;
            cmbBoxObraSocial.Enabled = false;
        }
    }
}
