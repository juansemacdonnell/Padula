using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaKinesiologia.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaKinesiologia.Configuracion
{
    internal class PlanDeGimnasioEntityConfig
    {
        internal static void SetPlanDeGimnasioEntityConfig(EntityTypeBuilder<PlanDeGimnasio> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPlanGimnasio);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.nombre)
                .IsRequired()
                .HasColumnName("Nombre");
            entityBuilder.Property(x => x.fecha)
                .IsRequired()
                .HasColumnName("Fecha");
            entityBuilder.Property(x => x.tituloColumna1)
                .IsRequired(false)
                .HasColumnName("TituloColumna1");
            entityBuilder.Property(x => x.tituloColumna2)
              .IsRequired(false)
              .HasColumnName("TituloColumna2");
            entityBuilder.Property(x => x.tituloColumna3)
              .IsRequired(false)
              .HasColumnName("TituloColumna3");

            entityBuilder.Property(x => x.fila1)
             .IsRequired(false)
             .HasColumnName("Fila1")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            entityBuilder.Property(x => x.fila2)
                .IsRequired(false)
                .HasColumnName("Fila2")
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                )
                .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));

            entityBuilder.Property(x => x.fila3)
                .IsRequired(false)
                .HasColumnName("Fila3")
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                )
                .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));

            entityBuilder.Property(x => x.fila4)
                    .IsRequired(false)
                    .HasColumnName("Fila4")
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                    .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));

            entityBuilder.Property(x => x.fila5)
                    .IsRequired(false)
                    .HasColumnName("Fila5")
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                    .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));

            // Relaciones con Paciente
            entityBuilder.HasOne(x => x.paciente)
                .WithMany(p => p.planesDeGimnasio)
                .HasForeignKey(x => x.IdPaciente);
            

            entityBuilder.HasOne(p => p.lesion)
                .WithMany(l => l.planesDeGimnasioParaLesion)
                .HasForeignKey(p => p.IdLesion)
                .OnDelete(DeleteBehavior.Restrict); // Cambiado a Restrict

            entityBuilder.HasOne(p => p.kinesiologo)
                .WithMany(k => k.planesDeGimnasio)
                .HasForeignKey(p => p.IdKinesiologo)
                .OnDelete(DeleteBehavior.Restrict); // Cambiado a Restrict
        }
    }
}
