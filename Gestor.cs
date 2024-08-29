using SistemaKinesiologia.Clases;
using SistemaKinesiologia.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SistemaKinesiologia
{
    public class Gestor
    {
        // Atributos
        public EvaluacionService evaluacionService;
        public KinesiologoService kinesiologoService;
        public LesionService lesionService;
        public PacienteService pacienteService;
        public PlanDeEntrenamientoService planDeEntrenamientoService;
        public SesionService sesionService;

        public Gestor(EvaluacionService evaluacionService, KinesiologoService kinesiologoService, LesionService lesionService, PacienteService pacienteService, PlanDeEntrenamientoService planDeEntrenamientoService, SesionService sesionService)
        {
            this.evaluacionService = evaluacionService;
            this.kinesiologoService = kinesiologoService;
            this.lesionService = lesionService;
            this.pacienteService = pacienteService;
            this.planDeEntrenamientoService = planDeEntrenamientoService;
            this.sesionService = sesionService;
        }

        // Para combo box de obras sociales
        List<string> listadoObrasSociales = new List<string> { "Particular", "Apross", "OSDE", "Jerarquicos" };

        // Para primera evaluacion
        bool primeraEvaluacionRealizada = false;
        Evaluacion? evaluacionActual;
        Evaluacion? evaluacionParaComparar;

        bool banderaPlanDeEntrenamientoCreado = false;
        PlanDeGimnasio? planDeGimnasioActual;

        Paciente? pacienteActual;
        Lesion? lesionActual;

        bool banderaPrimeraSesion = false;
        Sesion? sesionActual;

        bool banderaSegundaTabla = false;
        bool banderaNuevaLesion = false;

        Kinesiologo kinesiologoActual;

        bool banderaPacienteEditado = false;
        bool banderaLesionEditada = false;

        // Metodos
        internal List<string> GetListadoObraSociales()
        {
            return listadoObrasSociales;
        }
        internal bool GetBanderaNuevaLesion() { return this.banderaNuevaLesion; }
        internal void SetBanderaNuevaLesion(bool b) { this.banderaNuevaLesion = b; }

        internal bool GetBanderaPacienteEditado() { return this.banderaPacienteEditado; }
        internal void SetBanderaPacienteEditado(bool b) { this.banderaPacienteEditado = b; }

        internal bool GetBanderaLesionEditado() { return this.banderaLesionEditada; }
        internal void SetBanderaLesionEditado(bool b) { this.banderaLesionEditada = b; }
        // Metodos relacionados a una Evaluacion
        #region Evaluacion
        internal void SetBanderaPrimeraEvaluacion(bool valor)
        {
            this.primeraEvaluacionRealizada = valor;
        }
        internal void SetEvaluacionActual(Evaluacion evaluacion)
        {
            this.evaluacionActual = evaluacion;
        }
        internal Evaluacion GetEvaluacionParaComparar()
        {
            return this.evaluacionParaComparar;
        }
        internal void SetEvaluacionParaComparar(Evaluacion evaluacion)
        {
            this.evaluacionParaComparar = evaluacion;
        }
        internal string GetNombrePrimeraEvaluacion()
        {
            return evaluacionActual.GetNombre();
        }
        internal DateTime GetFechaPrimeraEvaluacion()
        {
            return evaluacionActual.GetFecha();
        }

        internal void SetBanderaSegundaTabla(bool valor)
        {
            this.banderaSegundaTabla = valor;
        }

        internal bool GetSegundaTablaBandera()
        {
            return banderaSegundaTabla;
        }
        internal Evaluacion GetEvaluacionActual() { return evaluacionActual; }
        internal bool GetBanderaEvaluacion()
        {
            return primeraEvaluacionRealizada;
        }

        #endregion

        // Metodos Relacionados a un paciente
        #region Paciente
        internal void SetPacienteActual(Paciente paciente)
        {
            this.pacienteActual = paciente;
        }
        internal string GetNombrePacienteActual()
        {
            return pacienteActual.GetNombre();
        }
        internal int GetEdadPacienteActual()
        {
            return pacienteActual.GetEdad();
        }
        internal string GetAntecedentesPacienteActual()
        {
            return pacienteActual.GetAntecedentes();
        }
        internal Paciente GetPacienteActual()
        {
            return pacienteActual;
        }
        #endregion

        // Metodos Relacionados a una lesion
        #region Lesion
        internal void SetLesionActual(Lesion lesion)
        {
            this.lesionActual = lesion;
        }
        internal Lesion GetLesionActual()
        {
            return lesionActual;
        }
        #endregion

        // Metodos Relacionados a una Sesion
        #region Sesion
        internal void SetSesionActual(Sesion sesion)
        {
            this.sesionActual = sesion;
        }
        internal void SetBanderaSesion(bool valor)
        {
            this.banderaPrimeraSesion = valor;
        }
        internal Sesion GetSesionActual() { return sesionActual; }
        internal bool GetBanderaSesion() { return banderaPrimeraSesion; }
        #endregion

        // Metodos Relacionados a un plan de entrenamiento
        #region Plan de entrenamiento
        internal void SetBanderaPlanDeEntrenamiento(bool valor)
        {
            this.banderaPlanDeEntrenamientoCreado = valor;
        }
        internal void SetPlanDeEntrenamientoActual(PlanDeGimnasio plan)
        {
            this.planDeGimnasioActual = plan;
        }
        internal string GetNombrePlanDeEntrenamiento()
        {
            return planDeGimnasioActual.GetNombre();
        }
        internal DateTime GetFechaPlanDeEntrenamiento()
        {
            return planDeGimnasioActual.GetFecha();
        }
        internal PlanDeGimnasio GetPlanDeEntrenamientoActual() { return planDeGimnasioActual; }
        internal bool GetBanderaEntrenamientoCreado()
        {
            return banderaPlanDeEntrenamientoCreado;
        }
        #endregion

        // Metodos Relacionado al Kinesiologo
        #region Kine
        internal void SetKinesiologo(Kinesiologo kinesiologo)
        {
            this.kinesiologoActual = kinesiologo;
        }
        internal Kinesiologo GetKinesiologoActual()
        {
            return this.kinesiologoActual;
        }
        #endregion

    }
}
