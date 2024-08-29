using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.Native.WinApi;

namespace SistemaKinesiologia.Clases
{
    public class Paciente
    {
        // Atributos
        internal int IdPaciente {  get; set; }
        internal string nombre {  get; set; }
        internal int edad {  get; set; }
        internal string telefono { get; set; }
        internal string antecedentes {  get; set; }
        internal string documento { get; set; }
        internal string obraSocial {  get; set; }

        // Para BD
        internal List<PlanDeGimnasio> planesDeGimnasio { get; set; }
        internal List<Lesion> lesiones {  get; set; }
        internal List<Sesion> sesiones {  get; set; }

        // Constructores
        public Paciente(string nombre, int edad, string telefono, string antecedentes, string documento, string obraSocial)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.telefono = telefono;
            this.antecedentes = antecedentes;
            this.documento = documento;
            this.obraSocial = obraSocial;

            this.planesDeGimnasio = new List<PlanDeGimnasio>();
            this.lesiones = new List<Lesion>();
            this.sesiones = new List<Sesion>();
        }

        // Metodos

        internal string GetNombre() { return nombre; }
        internal int GetEdad() {  return edad; }
        internal string GetAntecedentes() { return antecedentes; }
        internal void AgregarLesion(Lesion lesion) { this.lesiones.Add(lesion); }
        internal void AgregarSesion(Sesion sesion) { this.sesiones.Add(sesion); }
        internal void AgregarPlanDeEntrenamiento(PlanDeGimnasio plan) { this.planesDeGimnasio.Add(plan); }
    }
}
