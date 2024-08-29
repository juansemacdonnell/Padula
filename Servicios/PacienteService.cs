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
    public class PacienteService
    {
        private readonly ContextDB _contextoDB;

        public PacienteService(ContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        public void AddPaciente(Paciente paciente)
        {
            _contextoDB.Pacientes.Add(paciente);

            _contextoDB.SaveChanges();
        }

        public void ActualizarPaciente(Paciente paciente)
        {
            _contextoDB.Pacientes.Update(paciente);

            _contextoDB.SaveChanges();
        }

        public void BorrarPaciente(Paciente paciente)
        {
            _contextoDB.Pacientes.Remove(paciente);

            _contextoDB.SaveChanges();
        }

        public List<Paciente> GetPacientesXNombre(String nombrePaciente)
        {
            return _contextoDB.Pacientes.Where(x => x.nombre.ToUpper().Contains(nombrePaciente.ToUpper())).ToList();
        }

        public Paciente GetPacienteXId(int idPacienteABuscar)
        {
            return _contextoDB.Pacientes
                .Include(x => x.lesiones)
                .Include(x => x.sesiones)
                .Include(x => x.planesDeGimnasio)
                .FirstOrDefault(x => x.IdPaciente == idPacienteABuscar);
        }
    }
}
