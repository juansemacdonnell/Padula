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
    internal class SesionEntityConfig
    {
        internal static void SetSesionEntityConfig(EntityTypeBuilder<Sesion> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdSesion);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.numeroSesionDelPaciente)
                .IsRequired()
                .HasColumnName("Numero");

            entityBuilder.Property(x => x.fecha)
                .IsRequired()
                .HasColumnName("Fecha");

            entityBuilder.Property(x => x.observaciones)
                .IsRequired(false)
                .HasColumnName("Observaciones");

            // Relaciones con Lesion
            entityBuilder.HasOne(x => x.lesion)
                .WithMany(l => l.sesiones)
                .HasForeignKey(x => x.IdLesion);

            // Relaciones con Kinesiologo
            entityBuilder.HasOne(x => x.kinesiologo)
                .WithMany(k => k.sesiones)
                .HasForeignKey(x => x.IdKinesiologo);

            // Relaciones con Paciente
            entityBuilder.HasOne(x => x.paciente)
                .WithMany(p => p.sesiones)
                .HasForeignKey(x => x.IdPaciente);
        }
    }
}
