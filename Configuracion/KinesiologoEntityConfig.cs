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
    internal class KinesiologoEntityConfig
    {
        internal static void SetKinesiologoEntityConfig(EntityTypeBuilder<Kinesiologo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdKinesiologo);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.nombre)
                .IsRequired()
                .HasColumnName("Nombre");

            // Relaciones con Evaluacion
            entityBuilder.HasMany(x => x.evaluaciones)
                .WithOne(e => e.kinesiologo)
                .HasForeignKey(e => e.IdKinesiologo);

            // Relaciones con PlanDeGimnasio
            entityBuilder.HasMany(x => x.planesDeGimnasio)
                .WithOne(p => p.kinesiologo)
                .HasForeignKey(p => p.IdKinesiologo);

            // Relaciones con Sesion
            entityBuilder.HasMany(x => x.sesiones)
                .WithOne(s => s.kinesiologo)
                .HasForeignKey(s => s.IdKinesiologo);
        }
    }
}
