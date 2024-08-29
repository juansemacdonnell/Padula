using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.Native.WinApi;

namespace SistemaKinesiologia.Clases
{
    public class Sesion
    {
        // Atributos
        internal int IdSesion {  get; set; }
        internal int numeroSesionDelPaciente {  get; set; }
        internal DateTime fecha { get; set; }
        internal string observaciones {  get; set; }

        // Para BD
        internal int? IdLesion { get; set; }
        internal Lesion lesion {  get; set; }

        internal int IdKinesiologo {  get; set; }
        internal Kinesiologo kinesiologo { get; set; }

        internal int IdPaciente { get; set; }
        internal Paciente paciente { get; set; }

        public Sesion(DateTime fecha, string observaciones)
        {
            this.numeroSesionDelPaciente = 1;
            this.fecha = fecha;
            this.observaciones = observaciones;
        }
        // Constructores


        // Metodos
        public void SetLesionSesion(Lesion lesion)
        {
            this.lesion = lesion;
        }
        public void SetKinesiologoSesion(Kinesiologo kine)
        {
            this.kinesiologo = kine;
        }
        public void SetPaciente(Paciente paciente)
        {
            this.paciente = paciente;
        }

        public void SetNumeroSesion(int numero)
        {
            this.numeroSesionDelPaciente = numero;
        }
    }
}
