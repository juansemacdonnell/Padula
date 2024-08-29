using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.Native.WinApi;
using SistemaKinesiologia.Clases;
using SistemaKinesiologia.Configuracion;

namespace SistemaKinesiologia.Contexto
{
    public class ContextDB : DbContext
    {
        
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Kinesiologo> Kinesiologos { get; set; }
        public DbSet<Lesion> Lesiones { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PlanDeGimnasio> Planes { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.AppSettings["BD"];
            // DESKTOP-A85G4VT\SQLEXPRESS
            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            EvaluacionEntityConfig.SetEvaluacionEntityConfig(modelBuilder.Entity<Evaluacion>());
            KinesiologoEntityConfig.SetKinesiologoEntityConfig(modelBuilder.Entity<Kinesiologo>()); 
            LesionEntityConfig.SetLesionEntityConfig(modelBuilder.Entity<Lesion>());
            PacienteEntityConfig.SetPacienteEntityConfig(modelBuilder.Entity<Paciente>());
            PlanDeGimnasioEntityConfig.SetPlanDeGimnasioEntityConfig(modelBuilder.Entity<PlanDeGimnasio>());
            SesionEntityConfig.SetSesionEntityConfig(modelBuilder.Entity<Sesion>());

        }
    }

}
