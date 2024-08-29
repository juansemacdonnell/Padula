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
    internal class EvaluacionEntityConfig
    {
        internal static void SetEvaluacionEntityConfig(EntityTypeBuilder<Evaluacion> entityBuilder)
        {

            entityBuilder.HasKey(x => x.IdEvaluacion);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.nombre)
                .IsRequired()
                .HasColumnName("Nombre");
            entityBuilder.Property(x => x.observaciones)
              .IsRequired()
              .HasColumnName("Observaciones");
            entityBuilder.Property(x => x.fecha)
              .IsRequired()
              .HasColumnName("Fecha");

            // tabla 1
            entityBuilder.Property(x => x.nombreTabla1)
                .IsRequired(false)
                .HasColumnName("NombreTabla1");

            entityBuilder.Property(x => x.fila1Tabla1)
              .IsRequired(false)
              .HasColumnName("Fila1T1")
              .HasConversion(
                  v => string.Join(',', v),
                  v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
              )
              .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                  (c1, c2) => c1.SequenceEqual(c2),
                  c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                  c => c.ToList()));

            entityBuilder.Property(x => x.fila2Tabla1)
             .IsRequired(false)
             .HasColumnName("Fila2T1")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            entityBuilder.Property(x => x.fila3Tabla1)
             .IsRequired(false)
             .HasColumnName("Fila3T1")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            entityBuilder.Property(x => x.fila4Tabla1)
             .IsRequired(false)
             .HasColumnName("Fila4T1")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            entityBuilder.Property(x => x.fila5Tabla1)
             .IsRequired(false)
             .HasColumnName("Fila5T1")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            // tabla 2
            entityBuilder.Property(x => x.nombreTabla2)
                .IsRequired(false)
                .HasColumnName("NombreTabla2");

            entityBuilder.Property(x => x.fila1Tabla2)
              .IsRequired(false)
              .HasColumnName("Fila1T2")
              .HasConversion(
                  v => string.Join(',', v),
                  v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
              )
              .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                  (c1, c2) => c1.SequenceEqual(c2),
                  c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                  c => c.ToList()));

            entityBuilder.Property(x => x.fila2Tabla2)
             .IsRequired(false)
             .HasColumnName("Fila2T2")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            entityBuilder.Property(x => x.fila3Tabla2)
             .IsRequired(false)
             .HasColumnName("Fila3T2")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            entityBuilder.Property(x => x.fila4Tabla2)
             .IsRequired(false)
             .HasColumnName("Fila4T2")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            entityBuilder.Property(x => x.fila5Tabla2)
             .IsRequired(false)
             .HasColumnName("Fila5T2")
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
             )
             .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                 (c1, c2) => c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()));

            // Relaciones con otras clases:

            // Relaciones con Kinesiologo
            entityBuilder.HasOne(e => e.kinesiologo)
                .WithMany(k => k.evaluaciones)
                .HasForeignKey(e => e.IdKinesiologo);

            // Relaciones con Lesion
            entityBuilder.HasOne(e => e.lesion)
                .WithMany(l => l.evaluaciones)
                .HasForeignKey(e => e.IdLesion);
        }
    }
}
