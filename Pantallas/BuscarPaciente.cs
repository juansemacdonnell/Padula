using SistemaKinesiologia.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaKinesiologia.Pantallas
{
    public partial class BuscarPaciente : Form
    {
        Gestor gestor;

        public BuscarPaciente(Gestor gestor)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.gestor = gestor;
        }

        private void btnEditarDatosPaciente_Click(object sender, EventArgs e)
        {
            this.HabilitarTextBoxPaciente();
            gestor.SetBanderaPacienteEditado(true);
            btnConfirmarEdicion.Visible = true;
        }

        void HabilitarTextBoxPaciente()
        {
            TBoxNombreYApellido.Enabled = true;
            TBoxEdad.Enabled = true;
            TBoxTelefono.Enabled = true;
            TBoxDni.Enabled = true;
            textAntecedentes.Enabled = true;
            cmbBoxObraSocial.Enabled = true;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Iniciar busqueda
            // Aca conecta el metodo de busqueda por nombre de la BD.
            List<Paciente> pacientesEncontrados = gestor.pacienteService.GetPacientesXNombre(TBoxPacienteABuscar.Text);
            dgvPacientesEncontrados.Rows.Clear();

            if (pacientesEncontrados.Count > 0)
            {
                foreach (Paciente pacienteEncontrado in pacientesEncontrados)
                {
                    AgregarPaciente(pacienteEncontrado);
                }
            }
            else
            {
                MessageBox.Show("No se han encontrado pacientes con los datos ingresados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AgregarPaciente(Paciente paciente)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell idPaciente = new DataGridViewTextBoxCell();
            idPaciente.Value = paciente.IdPaciente;

            DataGridViewTextBoxCell nombrePaciente = new DataGridViewTextBoxCell();
            nombrePaciente.Value = paciente.nombre;

            DataGridViewTextBoxCell edadPaciente = new DataGridViewTextBoxCell();
            edadPaciente.Value = paciente.edad;

            DataGridViewTextBoxCell telefonoPaciente = new DataGridViewTextBoxCell();
            telefonoPaciente.Value = paciente.telefono;

            DataGridViewTextBoxCell obraSocialPaciente = new DataGridViewTextBoxCell();
            obraSocialPaciente.Value = paciente.obraSocial;

            fila.Cells.Add(idPaciente);
            fila.Cells.Add(nombrePaciente);
            fila.Cells.Add(edadPaciente);
            fila.Cells.Add(telefonoPaciente);
            fila.Cells.Add(obraSocialPaciente);

            dgvPacientesEncontrados.Rows.Add(fila);
        }
        private void dgvPacientesEncontrados_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar panel paciente y cargar paciente
            this.HabilitarPanelInfoPaciente();
            // Obtengo el paciente seleccionado
            if (dgvPacientesEncontrados.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvPacientesEncontrados.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    gestor.SetPacienteActual(gestor.pacienteService.GetPacienteXId((int)selectedRow.Cells[0].Value));
                    this.CargarDatosPanelInfoPaciente();
                }
                else
                {
                    gestor.SetPacienteActual(null);
                }
            }
            else
            {
                gestor.SetPacienteActual(null);
            }

            this.OcultarPanelSesionesDeLesion();
            this.OcultarPanelPlanesDeEntreno();
            this.OcultarPanelLesiones();
            this.OcultarPanelEvaluacionesLesion();
            this.OcultarPanelPlanesDeEntrenoDeLesion();
            this.OcultarPanelInfoLesion();
            this.OcultarPanelSesiones();

            this.DeshabilitarTextBoxPaciente();
            this.DeshabilitarTextBoxLesion();
            gestor.SetBanderaPacienteEditado(false);
            gestor.SetBanderaLesionEditado(false);
            btnConfirmarEdicion.Visible = false;
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            this.DeshabilitarTextBoxPaciente();
            this.DeshabilitarTextBoxLesion();
            gestor.SetBanderaPacienteEditado(false);
            gestor.SetBanderaLesionEditado(false);
            btnConfirmarEdicion.Visible = false;

            this.Close();
        }
        private void btnVerSesiones_Click(object sender, EventArgs e)
        {
            if (gestor.GetPacienteActual() != null)
            {
                if (gestor.GetPacienteActual().sesiones.Count > 0)
                {
                    panelSesiones.Visible = true;
                    panelSesiones.Location = new Point(512, 42);

                    lblCompletarNombrePanelSesion.Text = gestor.GetPacienteActual().nombre.ToString();

                    int inicio = (452 - (lblTituloPanelSesion.Width + 5 + lblCompletarNombrePanelSesion.Width)) / 2;
                    lblTituloPanelSesion.Location = new Point(inicio, 0);
                    lblCompletarNombrePanelSesion.Location = new Point((inicio + lblTituloPanelSesion.Width + 5), 0);

                    this.OcultarPanelSesionesDeLesion();
                    this.OcultarPanelPlanesDeEntreno();
                    this.OcultarPanelLesiones();
                    this.OcultarPanelEvaluacionesLesion();
                    this.OcultarPanelPlanesDeEntrenoDeLesion();
                    this.OcultarPanelInfoLesion();

                    this.DeshabilitarTextBoxLesion();
                    gestor.SetBanderaLesionEditado(false);

                    if(gestor.GetBanderaPacienteEditado() == false)
                    {
                        btnConfirmarEdicion.Visible = false;
                    }

                    dgvSesiones.Rows.Clear();
                    foreach (Sesion sesion in gestor.GetPacienteActual().sesiones)
                    {
                        this.AgregarSesion(sesion);
                    }
                }
                else
                {
                    MessageBox.Show("No hay sesiones registradas para este paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione un paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerPlanesDeEntrenamiento_Click(object sender, EventArgs e)
        {
            if (gestor.GetPacienteActual() != null)
            {
                if (gestor.GetPacienteActual().planesDeGimnasio.Count > 0)
                {
                    panelPlanesDeEntreno.Visible = true;
                    panelPlanesDeEntreno.Location = new Point(512, 42);

                    lblNombreCompletarPanelPLanEntrenamiento.Text = gestor.GetPacienteActual().nombre.ToString();

                    int inicio = (452 - (lblTituloPanelPlanEntrenamiento.Width + 5 + lblNombreCompletarPanelPLanEntrenamiento.Width)) / 2;
                    lblTituloPanelPlanEntrenamiento.Location = new Point(inicio, 0);
                    lblNombreCompletarPanelPLanEntrenamiento.Location = new Point((inicio + lblTituloPanelPlanEntrenamiento.Width + 5), 0);

                    this.OcultarPanelSesionesDeLesion();
                    this.OcultarPanelSesiones();
                    this.OcultarPanelLesiones();
                    this.OcultarPanelEvaluacionesLesion();
                    this.OcultarPanelPlanesDeEntrenoDeLesion();
                    this.OcultarPanelInfoLesion();

                    this.DeshabilitarTextBoxLesion();
                    gestor.SetBanderaLesionEditado(false);

                    if (gestor.GetBanderaPacienteEditado() == false)
                    {
                        btnConfirmarEdicion.Visible = false;
                    }

                    dgvPlanesDeEntrenamiento.Rows.Clear();
                    foreach (PlanDeGimnasio plan in gestor.GetPacienteActual().planesDeGimnasio)
                    {
                        this.AgregarPlanDeEntrenamiento(plan);
                    }
                }
                else
                {
                    MessageBox.Show("No hay planes de entrenamiento registrados para este paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione un paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerLesiones_Click(object sender, EventArgs e)
        {
            if (gestor.GetPacienteActual() != null)
            {
                if (gestor.GetPacienteActual().lesiones.Count > 0)
                {
                    panelLesiones.Visible = true;
                    panelLesiones.Location = new Point(512, 42);
                    lblCompletarNombrePanelLesiones.Text = gestor.GetPacienteActual().nombre.ToString();

                    int inicio = (452 - (lblTituloPanel.Width + 5 + lblCompletarNombrePanelLesiones.Width)) / 2;
                    lblTituloPanel.Location = new Point(inicio, 0);
                    lblCompletarNombrePanelLesiones.Location = new Point((inicio + lblTituloPanel.Width + 5), 0);

                    this.OcultarPanelSesionesDeLesion();
                    this.OcultarPanelPlanesDeEntreno();
                    this.OcultarPanelSesiones();
                    this.OcultarPanelEvaluacionesLesion();
                    this.OcultarPanelPlanesDeEntrenoDeLesion();
                    this.OcultarPanelInfoLesion();

                    dgvLesiones.Rows.Clear();
                    foreach (Lesion lesion in gestor.GetPacienteActual().lesiones)
                    {
                        this.AgregarLesion(lesion);
                    }
                }
                else
                {
                    MessageBox.Show("No hay lesiones registradas de este paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione un paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void AgregarLesion(Lesion lesion)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell idLesion = new DataGridViewTextBoxCell();
            idLesion.Value = lesion.IdLesion;

            DataGridViewTextBoxCell diagnosticoLesion = new DataGridViewTextBoxCell();
            diagnosticoLesion.Value = lesion.diagnostico;

            DataGridViewTextBoxCell medicoLesion = new DataGridViewTextBoxCell();
            medicoLesion.Value = lesion.medico;

            DataGridViewTextBoxCell fechaLesion = new DataGridViewTextBoxCell();
            fechaLesion.Value = lesion.fecha;

            fila.Cells.Add(idLesion);
            fila.Cells.Add(diagnosticoLesion);
            fila.Cells.Add(medicoLesion);
            fila.Cells.Add(fechaLesion);

            dgvLesiones.Rows.Add(fila);
        }

        void OcultarPanelLesiones()
        {
            panelLesiones.Visible = false;
            dgvLesiones.Rows.Clear();
        }

        void OcultarPanelPlanesDeEntreno()
        {
            panelPlanesDeEntreno.Visible = false;
            dgvPlanesDeEntrenamiento.Rows.Clear();
        }
        void OcultarPanelPlanesDeEntrenoDeLesion()
        {
            panelPlanesDeEntrenoDeLesion.Visible = false;
            dgvPlanesDeEntrenamientoDeLaLesion.Rows.Clear();
        }
        void OcultarPanelSesiones()
        {
            panelSesiones.Visible = false;
            dgvSesiones.Rows.Clear();
        }

        void OcultarPanelSesionesDeLesion()
        {
            panelSesionesDeLesion.Visible = false;
            dgvSesionesDeLesion.Rows.Clear();

        }


        private void btnverSesionesDeLaLesion_Click(object sender, EventArgs e)
        {
            if (gestor.GetLesionActual() != null)
            {
                if (gestor.GetLesionActual().sesiones.Count > 0)
                {
                    panelSesionesDeLesion.Visible = true;
                    panelSesionesDeLesion.Location = new Point(1004, 42);
                    this.OcultarPanelEvaluacionesLesion();
                    this.OcultarPanelPlanesDeEntrenoDeLesion();

                    dgvSesionesDeLesion.Rows.Clear();
                    foreach (Sesion sesion in gestor.GetLesionActual().sesiones)
                    {
                        this.AgregarSesionLesion(sesion);
                    }
                }
                else
                {
                    MessageBox.Show("No se han encontrado sesiones para la lesión seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una lesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        void AgregarSesionLesion(Sesion sesion)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell idSesionDeLesion = new DataGridViewTextBoxCell();
            idSesionDeLesion.Value = sesion.IdSesion;

            DataGridViewTextBoxCell numeroSesionDeLesion = new DataGridViewTextBoxCell();
            numeroSesionDeLesion.Value = sesion.numeroSesionDelPaciente;

            DataGridViewTextBoxCell fechaSesionDeLesion = new DataGridViewTextBoxCell();
            fechaSesionDeLesion.Value = sesion.fecha;

            DataGridViewTextBoxCell kineSesionDeLesion = new DataGridViewTextBoxCell();
            kineSesionDeLesion.Value = sesion.kinesiologo.nombre;

            fila.Cells.Add(idSesionDeLesion);
            fila.Cells.Add(numeroSesionDeLesion);
            fila.Cells.Add(fechaSesionDeLesion);
            fila.Cells.Add(kineSesionDeLesion);

            dgvSesionesDeLesion.Rows.Add(fila);
        }
        private void btnCerrarPanelSesionesDeLesion_Click(object sender, EventArgs e)
        {
            this.OcultarPanelSesionesDeLesion();

        }

        void OcultarPanelEvaluacionesLesion()
        {
            panelEvaluaciones.Visible = false;
            dgvEvaluaciones.Rows.Clear();
        }
        private void btnCerrarEvaluacionesLesion_Click(object sender, EventArgs e)
        {
            this.OcultarPanelEvaluacionesLesion();
        }

        private void btnVerEvaluacionesDeLesion_Click(object sender, EventArgs e)
        {
            if (gestor.GetLesionActual() != null)
            {
                if (gestor.GetLesionActual().evaluaciones.Count > 0)
                {
                    panelEvaluaciones.Visible = true;
                    panelEvaluaciones.Location = new Point(1004, 42);
                    this.OcultarPanelSesionesDeLesion();
                    this.OcultarPanelPlanesDeEntrenoDeLesion();

                    dgvEvaluaciones.Rows.Clear();
                    foreach (Evaluacion evaluacion in gestor.GetLesionActual().evaluaciones)
                    {
                        this.AgregarEvaluaciones(evaluacion);
                    }
                }
                else
                {
                    MessageBox.Show("No se han encontrado evaluaciones para la lesión seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una lesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnVerDetallePlan_Click(object sender, EventArgs e)
        {
            if (gestor.GetPlanDeEntrenamientoActual() != null)
            {
                this.MostrarDetallePlanEntrenamiento();
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione un plan de entrenamiento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VerDetalleEvaluacion_Click(object sender, EventArgs e)
        {
            if (gestor.GetEvaluacionActual() != null)
            {
                PantallaEvaluacion pantallaEvaluacion = new PantallaEvaluacion(gestor, 1);
                pantallaEvaluacion.ShowDialog();
                if (pantallaEvaluacion.DialogResult == DialogResult.OK)
                {
                    // Actualizo en BD
                    gestor.evaluacionService.ActualizarEvaluacion(gestor.GetEvaluacionActual());

                    // Recargo dgv
                    dgvEvaluaciones.Rows.Clear();

                    foreach (Evaluacion evaluacion in gestor.GetLesionActual().evaluaciones)
                    {
                        this.AgregarEvaluaciones(evaluacion);
                    }

                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una evaluación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrarPLanesDeentrenamientoDeLaLesion_Click(object sender, EventArgs e)
        {
            this.OcultarPanelPlanesDeEntrenoDeLesion();
        }

        private void btnEditarLesion_Click(object sender, EventArgs e)
        {
            this.HabilitarTextBoxLesion();
            gestor.SetBanderaLesionEditado(true);
            btnConfirmarEdicion.Visible = true;
        }

        void HabilitarTextBoxLesion()
        {
            TBoxDiagnostico.Enabled = true;
            TBoxMedico.Enabled = true;
            dtpFechaLesion.Enabled = true;
            textConsideracionesTratamiento.Enabled = true;
        }
        void DeshabilitarTextBoxLesion()
        {
            TBoxDiagnostico.Enabled = false;
            TBoxMedico.Enabled = false;
            dtpFechaLesion.Enabled = false;
            textConsideracionesTratamiento.Enabled = false;
        }
        void HabilitarPanelInfoLesion()
        {
            panelInfoLesion.Visible = true;
        }
        void HabilitarPanelInfoPaciente()
        {
            panelInformacionPaciente.Visible = true;
        }
        void CargarDatosPanelInfoPaciente()
        {
            Paciente paciente = gestor.GetPacienteActual();

            TBoxNombreYApellido.Text = paciente.nombre.ToString();
            TBoxEdad.Text = paciente.edad.ToString();
            TBoxTelefono.Text = paciente.telefono.ToString();
            TBoxDni.Text = paciente.documento.ToString();
            textAntecedentes.Text = paciente.antecedentes.ToString();

            cmbBoxObraSocial.Items.Clear();

            for (int i = 0; i < gestor.GetListadoObraSociales().Count; i++)
            {
                cmbBoxObraSocial.Items.Add(gestor.GetListadoObraSociales()[i]);
                if (gestor.GetListadoObraSociales()[i].ToUpper() == paciente.obraSocial.ToString().ToUpper())
                {
                    cmbBoxObraSocial.SelectedIndex = i;
                }
            }
        }

        void OcultarPanelInfoLesion()
        {
            panelInfoLesion.Visible = false;
        }
        private void dgvLesiones_SelectionChanged(object sender, EventArgs e)
        {
            this.HabilitarPanelInfoLesion();

            dgvEvaluaciones.Rows.Clear();
            this.OcultarPanelEvaluacionesLesion();

            dgvPlanesDeEntrenamientoDeLaLesion.Rows.Clear();
            this.OcultarPanelPlanesDeEntrenoDeLesion();

            dgvSesionesDeLesion.Rows.Clear();
            this.OcultarPanelSesionesDeLesion();

            this.DeshabilitarTextBoxLesion();
            gestor.SetBanderaLesionEditado(false);

            if (gestor.GetBanderaPacienteEditado() == false)
            {
                btnConfirmarEdicion.Visible = false;
            }

            // Obtengo la lesion seleccionada
            if (dgvLesiones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvLesiones.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    gestor.SetLesionActual(gestor.lesionService.GetLesionXId((int)selectedRow.Cells[0].Value));
                    this.CargarDatosPanelInfoLesion();
                }
                else
                {
                    this.OcultarPanelInfoLesion();
                    gestor.SetLesionActual(null);
                }
            }
            else
            {
                this.OcultarPanelInfoLesion();
                gestor.SetLesionActual(null);
            }
        }

        void CargarDatosPanelInfoLesion()
        {
            TBoxDiagnostico.Text = gestor.GetLesionActual().diagnostico;
            TBoxMedico.Text = gestor.GetLesionActual().medico;
            textConsideracionesTratamiento.Text = gestor.GetLesionActual().consideracionesTratamiento;
            dtpFechaLesion.Value = gestor.GetLesionActual().fecha;
        }

        private void dgvEvaluaciones_SelectionChanged(object sender, EventArgs e)
        {
            // Obtengo la evaluacion seleccionada
            if (dgvEvaluaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEvaluaciones.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    gestor.SetEvaluacionActual(gestor.evaluacionService.GetEvaluacionXId((int)selectedRow.Cells[0].Value));
                }
                else
                {
                    gestor.SetEvaluacionActual(null);
                }
            }
            else
            {
                gestor.SetEvaluacionActual(null);
            }
        }

        private void btnCompararEvaluacion_Click(object sender, EventArgs e)
        {
            if (gestor.GetEvaluacionActual() != null)
            {
                CompararEvaluaciones ventanaComparacion = new CompararEvaluaciones(gestor);
                ventanaComparacion.Show();
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una evaluación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void verDetalleDeSesion_Click(object sender, EventArgs e)
        {
            if (gestor.GetSesionActual() != null)
            {
                DetalleSesion ventanaDetalleSesion = new DetalleSesion(gestor);
                ventanaDetalleSesion.ShowDialog();

                if (ventanaDetalleSesion.DialogResult == DialogResult.OK)
                {
                    dgvSesionesDeLesion.Rows.Clear();

                    foreach (Sesion sesion in gestor.GetLesionActual().sesiones)
                    {
                        this.AgregarSesionLesion(sesion);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una sesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSesionesDeLesion_SelectionChanged(object sender, EventArgs e)
        {
            // Obtengo la sesion seleccionada
            if (dgvSesionesDeLesion.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSesionesDeLesion.SelectedRows[0];
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

        private void dgvPlanesDeEntrenamientoDeLaLesion_SelectionChanged(object sender, EventArgs e)
        {
            // Obtengo la sesion seleccionada
            if (dgvPlanesDeEntrenamientoDeLaLesion.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvPlanesDeEntrenamientoDeLaLesion.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    gestor.SetPlanDeEntrenamientoActual(gestor.planDeEntrenamientoService.GetPlanXId((int)selectedRow.Cells[0].Value));
                }
                else
                {
                    gestor.SetPlanDeEntrenamientoActual(null);
                }
            }
            else
            {
                gestor.SetPlanDeEntrenamientoActual(null);
            }
        }

        private void btnVerDetallePlanesDeEntrenamientoDeLaLesion_Click(object sender, EventArgs e)
        {
            if (gestor.GetPlanDeEntrenamientoActual() != null)
            {
                this.MostrarDetallePlanEntrenamiento();
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione un plan de entrenamiento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void MostrarDetallePlanEntrenamiento()
        {
            PantallaPlanDeEntrenamiento pantallaPlanDeEntrenamiento = new PantallaPlanDeEntrenamiento(gestor, 1);
            pantallaPlanDeEntrenamiento.ShowDialog();

            if (pantallaPlanDeEntrenamiento.DialogResult == DialogResult.OK)
            {
                gestor.planDeEntrenamientoService.ActualizarPlanDeGimnasio(gestor.GetPlanDeEntrenamientoActual());

                // Recargo dgv
                dgvPlanesDeEntrenamiento.Rows.Clear();
                dgvPlanesDeEntrenamientoDeLaLesion.Rows.Clear();

                // llamo de nuevo al buscador de planes del paciente y agg
                if (gestor.GetLesionActual() != null)
                {
                    foreach (PlanDeGimnasio plan in gestor.GetLesionActual().planesDeGimnasioParaLesion)
                    {
                        this.AgregarPlanDeEntrenamientoLesion(plan);
                    }
                }
                else
                {
                    foreach (PlanDeGimnasio plan in gestor.GetPacienteActual().planesDeGimnasio)
                    {
                        this.AgregarPlanDeEntrenamiento(plan);
                    }
                }


            }
        }

        private void btnVerPlanesDeLesion_Click(object sender, EventArgs e)
        {
            if (gestor.GetLesionActual() != null)
            {
                if (gestor.GetLesionActual().planesDeGimnasioParaLesion.Count > 0)
                {
                    panelPlanesDeEntrenoDeLesion.Visible = true;
                    panelPlanesDeEntrenoDeLesion.Location = new Point(1004, 42);
                    this.OcultarPanelSesionesDeLesion();
                    this.OcultarPanelEvaluacionesLesion();

                    dgvPlanesDeEntrenamientoDeLaLesion.Rows.Clear();
                    foreach (PlanDeGimnasio plan in gestor.GetLesionActual().planesDeGimnasioParaLesion)
                    {
                        this.AgregarPlanDeEntrenamientoLesion(plan);
                    }
                }
                else
                {
                    MessageBox.Show("No se han encontrado planes de entrenamiento para la lesión seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una lesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void AgregarPlanDeEntrenamientoLesion(PlanDeGimnasio plan)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell idPlanDeEntrenamientoDeLaLesion = new DataGridViewTextBoxCell();
            idPlanDeEntrenamientoDeLaLesion.Value = plan.IdPlanGimnasio;

            DataGridViewTextBoxCell nombrePlanDeEntrenamientoDeLaLesion = new DataGridViewTextBoxCell();
            nombrePlanDeEntrenamientoDeLaLesion.Value = plan.nombre;

            DataGridViewTextBoxCell fechaPlanDeEntrenamientoDeLaLesion = new DataGridViewTextBoxCell();
            fechaPlanDeEntrenamientoDeLaLesion.Value = plan.fecha;

            fila.Cells.Add(idPlanDeEntrenamientoDeLaLesion);
            fila.Cells.Add(nombrePlanDeEntrenamientoDeLaLesion);
            fila.Cells.Add(fechaPlanDeEntrenamientoDeLaLesion);

            dgvPlanesDeEntrenamientoDeLaLesion.Rows.Add(fila);
        }

        void AgregarPlanDeEntrenamiento(PlanDeGimnasio plan)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell idPlan = new DataGridViewTextBoxCell();
            idPlan.Value = plan.IdPlanGimnasio;

            DataGridViewTextBoxCell nombrePlan = new DataGridViewTextBoxCell();
            nombrePlan.Value = plan.nombre;

            DataGridViewTextBoxCell lesionPlan = new DataGridViewTextBoxCell();
            if (plan.lesion != null)
            {
                lesionPlan.Value = plan.lesion.diagnostico;
            }
            else { lesionPlan.Value = "NINGUNA"; }


            DataGridViewTextBoxCell fechaPlan = new DataGridViewTextBoxCell();
            fechaPlan.Value = plan.fecha;

            fila.Cells.Add(idPlan);
            fila.Cells.Add(nombrePlan);
            fila.Cells.Add(lesionPlan);
            fila.Cells.Add(fechaPlan);

            dgvPlanesDeEntrenamiento.Rows.Add(fila);
        }


        private void btnAggEvaluacion_Click(object sender, EventArgs e)
        {
            if (gestor.GetLesionActual() != null)
            {
                PantallaEvaluacion pantallaEvaluacion = new PantallaEvaluacion(gestor);
                pantallaEvaluacion.ShowDialog();

                if (pantallaEvaluacion.DialogResult == DialogResult.OK)
                {
                    // agg el plan a la lesion y al paciente actual
                    gestor.GetEvaluacionActual().AsignarKine(gestor.GetKinesiologoActual());
                    gestor.GetLesionActual().AgregarEvaluacion(gestor.GetEvaluacionActual());
                    // guardar en BD
                    gestor.pacienteService.ActualizarPaciente(gestor.GetPacienteActual());
                    // mensaje de que se guardo correctamente
                    MessageBox.Show("La evaluación se agregó correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una lesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPlanesDeEntrenamiento_SelectionChanged(object sender, EventArgs e)
        {
            // Obtengo la sesion seleccionada
            if (dgvPlanesDeEntrenamiento.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvPlanesDeEntrenamiento.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    gestor.SetPlanDeEntrenamientoActual(gestor.planDeEntrenamientoService.GetPlanXId((int)selectedRow.Cells[0].Value));
                }
                else
                {
                    gestor.SetPlanDeEntrenamientoActual(null);
                }
            }
            else
            {
                gestor.SetPlanDeEntrenamientoActual(null);
            }
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

        void AgregarSesion(Sesion sesion)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell idSesion = new DataGridViewTextBoxCell();
            idSesion.Value = sesion.IdSesion;

            DataGridViewTextBoxCell numeroSesion = new DataGridViewTextBoxCell();
            numeroSesion.Value = sesion.numeroSesionDelPaciente;

            DataGridViewTextBoxCell lesionSesion = new DataGridViewTextBoxCell();
            if (sesion.lesion == null)
            {

                lesionSesion.Value = "NINGUNA";
            }
            else
            {
                lesionSesion.Value = sesion.lesion.diagnostico;
            }

            DataGridViewTextBoxCell fechaSesion = new DataGridViewTextBoxCell();
            fechaSesion.Value = sesion.fecha;

            DataGridViewTextBoxCell kineSesion = new DataGridViewTextBoxCell();
            kineSesion.Value = sesion.kinesiologo.nombre;

            fila.Cells.Add(idSesion);
            fila.Cells.Add(numeroSesion);
            fila.Cells.Add(lesionSesion);
            fila.Cells.Add(fechaSesion);
            fila.Cells.Add(kineSesion);

            if (sesion.lesion == null)
            {
                fila.DefaultCellStyle.BackColor = Color.Yellow;
            }
            else
            {
                for (int i = 0; i < gestor.GetPacienteActual().lesiones.Count; i++)
                {
                    if (sesion.IdLesion == gestor.GetPacienteActual().lesiones[0].GetIdLesion())
                    {
                        fila.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    }
                    else if (sesion.IdLesion == gestor.GetPacienteActual().lesiones[1].GetIdLesion())
                    {
                        fila.DefaultCellStyle.BackColor = Color.SkyBlue;
                    }
                    else if (sesion.IdLesion == gestor.GetPacienteActual().lesiones[2].GetIdLesion())
                    {
                        fila.DefaultCellStyle.BackColor = Color.Orange;
                    }
                    else if (sesion.IdLesion == gestor.GetPacienteActual().lesiones[3].GetIdLesion())
                    {
                        fila.DefaultCellStyle.BackColor = Color.MediumPurple;
                    }
                    else if (sesion.IdLesion == gestor.GetPacienteActual().lesiones[4].GetIdLesion())
                    {
                        fila.DefaultCellStyle.BackColor = Color.Gray;
                    }
                    else if (sesion.IdLesion == gestor.GetPacienteActual().lesiones[5].GetIdLesion())
                    {
                        fila.DefaultCellStyle.BackColor = Color.MidnightBlue;
                    }
                }
            }

            dgvSesiones.Rows.Add(fila);
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

                    foreach (Sesion sesion in gestor.GetPacienteActual().sesiones)
                    {
                        this.AgregarSesion(sesion);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione una sesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            if (gestor.GetPacienteActual() != null)
            {
                this.OcultarPanelSesionesDeLesion();
                this.OcultarPanelPlanesDeEntreno();
                this.OcultarPanelLesiones();
                this.OcultarPanelEvaluacionesLesion();
                this.OcultarPanelPlanesDeEntrenoDeLesion();
                this.OcultarPanelInfoLesion();
                this.OcultarPanelSesiones();

                this.DeshabilitarTextBoxPaciente();
                this.DeshabilitarTextBoxLesion();
                gestor.SetBanderaPacienteEditado(false);
                gestor.SetBanderaLesionEditado(false);
                btnConfirmarEdicion.Visible = false;

                PantallaPlanDeEntrenamiento pantallaPlanDeEntrenamiento = new PantallaPlanDeEntrenamiento(gestor, "cadena");
                pantallaPlanDeEntrenamiento.ShowDialog();

                if (pantallaPlanDeEntrenamiento.DialogResult == DialogResult.OK)
                {
                    // Actualizar BD
                    gestor.pacienteService.ActualizarPaciente(gestor.GetPacienteActual());

                    string lesion = "NINGUNA";
                    if (gestor.GetLesionActual() != null)
                    {
                        lesion = gestor.GetLesionActual().diagnostico;
                    }

                    MessageBox.Show("El plan de entrenamiento se agregó correctamente.\nPaciente: " + gestor.GetPacienteActual().nombre +
                        "\nLesión: " + lesion, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    gestor.SetLesionActual(null);
                    gestor.SetPlanDeEntrenamientoActual(null);
                }

            }
            else
            {
                MessageBox.Show("Por favor primero seleccione un paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregarSesion_Click(object sender, EventArgs e)
        {
            if (gestor.GetPacienteActual() != null)
            {
                this.OcultarPanelSesionesDeLesion();
                this.OcultarPanelPlanesDeEntreno();
                this.OcultarPanelLesiones();
                this.OcultarPanelEvaluacionesLesion();
                this.OcultarPanelPlanesDeEntrenoDeLesion();
                this.OcultarPanelInfoLesion();
                this.OcultarPanelSesiones();

                this.DeshabilitarTextBoxPaciente();
                this.DeshabilitarTextBoxLesion();
                gestor.SetBanderaPacienteEditado(false);
                gestor.SetBanderaLesionEditado(false);
                btnConfirmarEdicion.Visible = false;

                DetalleSesion detalleSesion = new DetalleSesion(gestor, 1);
                detalleSesion.ShowDialog();

                if (detalleSesion.DialogResult == DialogResult.OK)
                {
                    gestor.SetLesionActual(null);
                    gestor.SetSesionActual(null);
                }
            }
            else
            {
                MessageBox.Show("Por favor primero seleccione un paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregarLesion_Click(object sender, EventArgs e)
        {
            if (gestor.GetPacienteActual() != null)
            {
                this.OcultarPanelSesionesDeLesion();
                this.OcultarPanelPlanesDeEntreno();
                this.OcultarPanelLesiones();
                this.OcultarPanelEvaluacionesLesion();
                this.OcultarPanelPlanesDeEntrenoDeLesion();
                this.OcultarPanelInfoLesion();
                this.OcultarPanelSesiones();

                this.DeshabilitarTextBoxPaciente();
                this.DeshabilitarTextBoxLesion();
                gestor.SetBanderaPacienteEditado(false);
                gestor.SetBanderaLesionEditado(false);
                btnConfirmarEdicion.Visible = false;

                RegistrarPaciente nuevaLesionPantalla = new RegistrarPaciente(gestor, 1);
                nuevaLesionPantalla.ShowDialog();

                if (nuevaLesionPantalla.DialogResult == DialogResult.OK)
                {
                    gestor.SetLesionActual(null);
                    gestor.SetSesionActual(null);
                    gestor.SetPlanDeEntrenamientoActual(null);
                    gestor.SetEvaluacionActual(null);
                }
                else
                {
                    gestor.SetLesionActual(null);
                    gestor.SetSesionActual(null);
                    gestor.SetPlanDeEntrenamientoActual(null);
                    gestor.SetEvaluacionActual(null);
                }

            }
            else
            {
                MessageBox.Show("Por favor primero seleccione un paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfirmarEdicion_Click(object sender, EventArgs e)
        {
            if(gestor.GetBanderaPacienteEditado() == true && gestor.GetBanderaLesionEditado() == true)
            {
                if(ValidarPacienteEditado() && ValidarLesionEditada())
                {
                    gestor.pacienteService.ActualizarPaciente(gestor.GetPacienteActual());
                    gestor.lesionService.ActualizarLesion(gestor.GetLesionActual());

                    MessageBox.Show("Información del paciente: " + gestor.GetPacienteActual().nombre + " actualizada." +
                        "\nInformación sobre lesión: " + gestor.GetLesionActual().diagnostico + " actualizada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int idPacienteAnterior = gestor.GetPacienteActual().IdPaciente;
                    int idLesionAnterior = gestor.GetLesionActual().IdLesion;

                    List<Paciente> pacientesEncontrados = gestor.pacienteService.GetPacientesXNombre(TBoxPacienteABuscar.Text);
                    dgvPacientesEncontrados.Rows.Clear();

                    if (pacientesEncontrados.Count > 0)
                    {
                        for (int i = 0; i < pacientesEncontrados.Count; i++)
                        {
                            AgregarPaciente(pacientesEncontrados[i]);

                            if (pacientesEncontrados[i].IdPaciente == idPacienteAnterior)
                            {
                                dgvPacientesEncontrados.Rows[i].Selected = true;
                                dgvPacientesEncontrados.CurrentCell = dgvPacientesEncontrados.Rows[i].Cells[0];
                            }
                        }
                    }

                    panelLesiones.Visible = true;
                    panelLesiones.Location = new Point(512, 42);
                    lblCompletarNombrePanelLesiones.Text = gestor.GetPacienteActual().nombre.ToString();

                    int inicio = (452 - (lblTituloPanel.Width + 5 + lblCompletarNombrePanelLesiones.Width)) / 2;
                    lblTituloPanel.Location = new Point(inicio, 0);
                    lblCompletarNombrePanelLesiones.Location = new Point((inicio + lblTituloPanel.Width + 5), 0);

                    dgvLesiones.Rows.Clear();
                    for(int i = 0; i < gestor.GetPacienteActual().lesiones.Count; i++)
                    {
                        this.AgregarLesion(gestor.GetPacienteActual().lesiones[i]);
                        if (gestor.GetPacienteActual().lesiones[i].IdLesion == idLesionAnterior)
                        {
                            dgvLesiones.Rows[i].Selected = true;
                            dgvLesiones.CurrentCell = dgvLesiones.Rows[i].Cells[0];
                        }
                    }
                    

                }
                
            }
            else if (gestor.GetBanderaLesionEditado() == true)
            {
                if (ValidarLesionEditada())
                {
                    gestor.lesionService.ActualizarLesion(gestor.GetLesionActual());

                    MessageBox.Show("Información sobre lesión: " + gestor.GetLesionActual().diagnostico + " del paciente " + gestor.GetPacienteActual().nombre + ", actualizada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int idLesionAnterior = gestor.GetLesionActual().IdLesion;
                    dgvLesiones.Rows.Clear();
                    for (int i = 0; i < gestor.GetPacienteActual().lesiones.Count; i++)
                    {
                        this.AgregarLesion(gestor.GetPacienteActual().lesiones[i]);
                        if (gestor.GetPacienteActual().lesiones[i].IdLesion == idLesionAnterior)
                        {
                            dgvLesiones.Rows[i].Selected = true;
                            dgvLesiones.CurrentCell = dgvLesiones.Rows[i].Cells[0];
                        }
                    }
                }

            }
            else if(gestor.GetBanderaPacienteEditado() == true)
            {
                if (ValidarPacienteEditado())
                {
                    gestor.pacienteService.ActualizarPaciente(gestor.GetPacienteActual());
                    MessageBox.Show("Información del paciente: " + gestor.GetPacienteActual().nombre + " actualizada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int idPacienteAnterior = gestor.GetPacienteActual().IdPaciente;

                    List<Paciente> pacientesEncontrados = gestor.pacienteService.GetPacientesXNombre(TBoxPacienteABuscar.Text);
                    dgvPacientesEncontrados.Rows.Clear();

                    if (pacientesEncontrados.Count > 0)
                    {
                        for (int i = 0; i < pacientesEncontrados.Count; i++)
                        {
                            AgregarPaciente(pacientesEncontrados[i]);

                            if (pacientesEncontrados[i].IdPaciente == idPacienteAnterior)
                            {
                                dgvPacientesEncontrados.Rows[i].Selected = true;
                                dgvPacientesEncontrados.CurrentCell = dgvPacientesEncontrados.Rows[i].Cells[0];
                            }
                        }
                    }
                }
            }

            gestor.SetBanderaPacienteEditado(false);
            gestor.SetBanderaLesionEditado(false);
            this.DeshabilitarTextBoxLesion();
            this.DeshabilitarTextBoxPaciente();

            btnConfirmarEdicion.Visible = false;

            

        }

        bool ValidarPacienteEditado()
        {
            // Por ahora solo validamos el nombre y edad
            if (!Regex.IsMatch(TBoxNombreYApellido.Text, @"\d") && !string.IsNullOrWhiteSpace(TBoxNombreYApellido.Text))
            {
                if (int.TryParse(TBoxEdad.Text, out int edadPaciente) && edadPaciente > 0)
                {
                    // Creamos el paciente y lo asignamos al gestor (paciente actual)
                    gestor.GetPacienteActual().nombre = TBoxNombreYApellido.Text.ToUpper();
                    gestor.GetPacienteActual().edad = edadPaciente;
                    gestor.GetPacienteActual().telefono = TBoxTelefono.Text;
                    gestor.GetPacienteActual().antecedentes = textAntecedentes.Text.ToUpper();
                    gestor.GetPacienteActual().documento = TBoxDni.Text;
                    gestor.GetPacienteActual().obraSocial = cmbBoxObraSocial.SelectedItem.ToString();

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
        bool ValidarLesionEditada()
        {
            if (!Regex.IsMatch(TBoxDiagnostico.Text, @"\d") && !string.IsNullOrWhiteSpace(TBoxDiagnostico.Text))
            {
                // creamos la lesion y la asignamos al gestor
                gestor.GetLesionActual().diagnostico = TBoxDiagnostico.Text.ToUpper();
                gestor.GetLesionActual().medico = TBoxMedico.Text.ToUpper();
                gestor.GetLesionActual().fecha = dtpFechaLesion.Value;
                gestor.GetLesionActual().consideracionesTratamiento = textConsideracionesTratamiento.Text.ToUpper();

                return true;
            }
            else
            {
                MessageBox.Show("Hay un error en el nombre que identifica a la lesión.\n Por favor ingrese un nombre válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }

}
