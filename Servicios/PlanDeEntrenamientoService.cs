using SistemaKinesiologia.Clases;
using SistemaKinesiologia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaKinesiologia.Servicios
{
    public class PlanDeEntrenamientoService
    {
        private readonly ContextDB _contextoDB;

        public PlanDeEntrenamientoService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        public void AddPlanDeGimnasio(PlanDeGimnasio plan)
        {
            _contextoDB.Planes.Add(plan);

            _contextoDB.SaveChanges();
        }

        public void ActualizarPlanDeGimnasio(PlanDeGimnasio plan)
        {
            _contextoDB.Planes.Update(plan);

            _contextoDB.SaveChanges();
        }

        public void BorrarPlanDeGimnasio(PlanDeGimnasio plan)
        {
            _contextoDB.Planes.Remove(plan);

            _contextoDB.SaveChanges();
        }

        public PlanDeGimnasio GetPlanXId(int idPlanABuscar)
        {
            return _contextoDB.Planes
                      .FirstOrDefault(x => x.IdPlanGimnasio == idPlanABuscar);
        }

        public List<PlanDeGimnasio> GetPlanesSinPaciente()
        {
            return _contextoDB.Planes
                              .Where(plan => plan.IdPaciente == null)
                              .ToList();
        }
    }
}
