using SistemaKinesiologia.Clases;
using SistemaKinesiologia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaKinesiologia.Servicios
{
    public class KinesiologoService
    {
        private readonly ContextDB _contextoDB;

        public KinesiologoService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        // Agrega un cliente nuevo a la BD 
        public void AddKinesiologo(Kinesiologo kine)
        {
            _contextoDB.Kinesiologos.Add(kine);

            _contextoDB.SaveChanges();
        }

        // Actualiza un cliente ya cargado en la BD
        public void ActualizarKinesiologo(Kinesiologo kine)
        {
            _contextoDB.Kinesiologos.Update(kine);

            _contextoDB.SaveChanges();
        }

        // Elimina un cliente 
        public void BorrarKinesiologo(Kinesiologo kine)
        {
            _contextoDB.Kinesiologos.Remove(kine);

            _contextoDB.SaveChanges();
        }

        public List<Kinesiologo> GetKinesiologos()
        {
            return _contextoDB.Kinesiologos.ToList();
        }
    }
}
