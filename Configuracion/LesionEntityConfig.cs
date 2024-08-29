using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaKinesiologia.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaKinesiologia.Configuracion
{
    internal class LesionEntityConfig
    {
        internal static void SetLesionEntityConfig(EntityTypeBuilder<Lesion> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdLesion);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.diagnostico)
                .IsRequired()
                .HasColumnName("Diagnostico");
            entityBuilder.Property(x => x.medico)
                .IsRequired(false)
                .HasColumnName("Medico");
            entityBuilder.Property(x => x.fecha)
                .IsRequired()
                .HasColumnName("Fecha");
            entityBuilder.Property(x => x.consideracionesTratamiento)
                .IsRequired(false)
                .HasColumnName("Consideraciones");

            // Relaciones con Paciente
            entityBuilder.HasOne(x => x.paciente)
                .WithMany(p => p.lesiones)
                .HasForeignKey(x => x.IdPaciente);

            // Relaciones con Evaluaciones
            entityBuilder.HasMany(x => x.evaluaciones)
                .WithOne(e => e.lesion)
                .HasForeignKey(e => e.IdLesion);

            // Relaciones con PlanDeGimnasio
            entityBuilder.HasMany(x => x.planesDeGimnasioParaLesion)
                .WithOne(p => p.lesion)
                .HasForeignKey(p => p.IdLesion);

            // Relaciones con Sesion
            entityBuilder.HasMany(x => x.sesiones)
                .WithOne(s => s.lesion)
                .HasForeignKey(s => s.IdLesion);
        }
    }
}
