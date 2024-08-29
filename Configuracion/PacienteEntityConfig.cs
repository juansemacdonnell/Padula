using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaKinesiologia.Clases;

namespace SistemaKinesiologia.Configuracion
{
    internal class PacienteEntityConfig
    {
        internal static void SetPacienteEntityConfig(EntityTypeBuilder<Paciente> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPaciente);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.nombre)
                .IsRequired()
                .HasColumnName("Nombre");
            entityBuilder.Property(x => x.edad)
                .IsRequired()
                .HasColumnName("Edad");
            entityBuilder.Property(x => x.telefono)
                .IsRequired(false)
                .HasColumnName("Telefono");
            entityBuilder.Property(x => x.antecedentes)
                .IsRequired(false)
                .HasColumnName("Antecedente");
            entityBuilder.Property(x => x.documento)
                .IsRequired(false)
                 .HasColumnName("Documento");
            entityBuilder.Property(x => x.obraSocial)
                .IsRequired(false)
                .HasColumnName("ObraSocial");

            // Relaciones con PlanDeGimnasio
            entityBuilder.HasMany(x => x.planesDeGimnasio)
                .WithOne(p => p.paciente)
                .HasForeignKey(p => p.IdPaciente);
            
            // Relaciones con Lesion
            entityBuilder.HasMany(x => x.lesiones)
                .WithOne(l => l.paciente)
                .HasForeignKey(l => l.IdPaciente);

            // Relaciones con Sesion
            entityBuilder.HasMany(x => x.sesiones)
                .WithOne(s => s.paciente)
                .HasForeignKey(s => s.IdPaciente);
        }
    }
}
