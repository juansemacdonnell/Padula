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
    public class EvaluacionService
    {
        private readonly ContextDB _contextoDB;

        public EvaluacionService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        // Agrega un cliente nuevo a la BD 
        public void AddEvaluacion(Evaluacion evaluacion)
        {
            _contextoDB.Evaluaciones.Add(evaluacion);

            _contextoDB.SaveChanges();
        }

        // Actualiza un cliente ya cargado en la BD
        public void ActualizarEvaluacion(Evaluacion evaluacion)
        {
            _contextoDB.Evaluaciones.Update(evaluacion);

            _contextoDB.SaveChanges();
        }

        // Elimina un cliente 
        public void BorrarEvaluacion(Evaluacion evaluacion)
        {
            _contextoDB.Evaluaciones.Remove(evaluacion);

            _contextoDB.SaveChanges();
        }

        // Trae un cliente particular de la BD
        public Evaluacion GetEvaluacionXId(int IdEvaluacionABuscar)
        {
            return _contextoDB.Evaluaciones
                      .FirstOrDefault(x => x.IdEvaluacion == IdEvaluacionABuscar);
        }
    }
}
