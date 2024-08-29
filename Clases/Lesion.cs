using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.Native.WinApi;

namespace SistemaKinesiologia.Clases
{
    public class Lesion
    {
        // Atributos
        internal int IdLesion {  get; set; }
        internal string diagnostico {  get; set; }
        internal string medico {  get; set; }
        internal DateTime fecha { get; set; }
        internal string consideracionesTratamiento {get; set; }

        // Para BD
        internal List<PlanDeGimnasio> planesDeGimnasioParaLesion { get; set; }
        internal List<Evaluacion> evaluaciones {  get; set; }
        internal List<Sesion> sesiones { get; set; }

        internal int IdPaciente { get; set; }
        internal Paciente paciente { get; set; }

        // Constructores
        public Lesion(string diagnostico, string medico, DateTime fecha, string consideracionesTratamiento)
        {
            this.diagnostico = diagnostico;
            this.medico = medico;
            this.fecha = fecha;
            this.consideracionesTratamiento = consideracionesTratamiento;

            this.sesiones = new List<Sesion>(); 
            this.evaluaciones = new List<Evaluacion>();
            this.planesDeGimnasioParaLesion = new List<PlanDeGimnasio>();
        }

        // Metodos
        internal void AsignarPaciente(Paciente paciente) { this.paciente =  paciente; }
        internal void AgregarPlanDeEntrenamientoParaLesion(PlanDeGimnasio plan) { this.planesDeGimnasioParaLesion.Add(plan); }  
        internal void AgregarEvaluacion(Evaluacion evaluacion) { this.evaluaciones.Add(evaluacion); }
        internal void AgregarSesion(Sesion sesion) { this.sesiones.Add(sesion); }

        internal int GetIdLesion() { return this.IdLesion; }    
    }
}
