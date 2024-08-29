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
    public class LesionService
    {
        private readonly ContextDB _contextoDB;

        public LesionService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        public void AddLesion(Lesion lesion)
        {
            _contextoDB.Lesiones.Add(lesion);

            _contextoDB.SaveChanges();
        }

        public void ActualizarLesion(Lesion lesion)
        {
            _contextoDB.Lesiones.Update(lesion);

            _contextoDB.SaveChanges();
        }

        public void BorrarLesion(Lesion lesion)
        {
            _contextoDB.Lesiones.Remove(lesion);

            _contextoDB.SaveChanges();
        }
        public Lesion GetLesionXId(int idLesionABuscar)
        {
            return _contextoDB.Lesiones
                .Include(x => x.sesiones)
                .Include(x => x.planesDeGimnasioParaLesion)
                .Include(x => x.evaluaciones)
                .FirstOrDefault(x => x.IdLesion == idLesionABuscar);
        }

    }
}
