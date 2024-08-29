using Microsoft.EntityFrameworkCore;
using SistemaKinesiologia.Clases;
using SistemaKinesiologia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaKinesiologia.Servicios
{
    public class SesionService
    {
        private readonly ContextDB _contextoDB;

        public SesionService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        public void AddSesion(Sesion sesion)
        {
            _contextoDB.Sesiones.Add(sesion);

            _contextoDB.SaveChanges();
        }

        public void ActualizarSesion(Sesion sesion)
        {
            _contextoDB.Sesiones.Update(sesion);

            _contextoDB.SaveChanges();
        }

        public void BorrarSesion(Sesion sesion)
        {
            _contextoDB.Sesiones.Remove(sesion);

            _contextoDB.SaveChanges();
        }

        public List<Sesion> GetSesionesDeLesion(int idLesionABuscar)
        {
            return _contextoDB.Sesiones
                .Include(x => x.kinesiologo)
                .Where(x => x.IdLesion == idLesionABuscar).ToList();
        }
        public Sesion GetSesionXId(int idSesionABuscar)
        {
            return _contextoDB.Sesiones
                      .FirstOrDefault(x => x.IdSesion == idSesionABuscar);
        }

        public List<Sesion> GetUltimasSesiones()
        {
            return _contextoDB.Sesiones
                .Include(x => x.kinesiologo)
                .Include(x => x.paciente)
                .Include(x => x.lesion)
                .OrderByDescending(x => x.fecha) // Ordenar por fecha descendente
                .Take(20) // Tomar las últimas 20 sesiones
                .ToList();
        }

        public int GetCantidadPacientesDistintosPorMes(int año, int mes)
        {
            return _contextoDB.Sesiones
                .Where(x => x.fecha.Year == año && x.fecha.Month == mes)
                .Select(x => x.paciente.IdPaciente) // Asumiendo que `Id` es la propiedad única del paciente
                .Distinct()
                .Count();
        }

        public int GetCantidadSesionesPorMes(int año, int mes)
        {
            return _contextoDB.Sesiones
                .Where(x => x.fecha.Year == año && x.fecha.Month == mes)
                .Count();
        }

        public List<int> GetCantidadSesionesPorMesDeUnAño(int año)
        {
            // Inicializar la lista con 12 ceros (uno por cada mes)
            List<int> sesionesPorMes = Enumerable.Repeat(0, 12).ToList();

            var sesiones = _contextoDB.Sesiones
                .Where(x => x.fecha.Year == año)
                .GroupBy(x => x.fecha.Month)
                .Select(g => new { Mes = g.Key, Cantidad = g.Count() });

            // Actualizar la lista con los conteos
            foreach (var sesion in sesiones)
            {
                sesionesPorMes[sesion.Mes - 1] = sesion.Cantidad;
            }

            return sesionesPorMes;
        }
    }
}
