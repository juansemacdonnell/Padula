using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaKinesiologia.Clases
{
    public class Kinesiologo
    {
        // Atributos
        internal int IdKinesiologo {  get; set; }
        internal string nombre {  get; set; }

        // Para BD
        internal List<Evaluacion> evaluaciones { get; set; }
        internal List<PlanDeGimnasio> planesDeGimnasio { get; set; }
        internal List<Sesion> sesiones { get; set; }

        // Constructores
        public Kinesiologo(string nombre)
        {
            this.nombre = nombre;
        }

        // Metodos
        internal string GetNombre()
        {
            return this.nombre;
        }
    }
}
