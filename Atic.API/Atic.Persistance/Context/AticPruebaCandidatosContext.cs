using System;
using Atic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Atic.Persistance.Entities
{
    public partial class AticPruebaCandidatosContext : DbContext
    {
        public AticPruebaCandidatosContext()
        {}

        public AticPruebaCandidatosContext(DbContextOptions<AticPruebaCandidatosContext> options) : base(options)
        {}

        public virtual DbSet<DataCandidatosA> DataCandidatosAs { get; set; }
        public virtual DbSet<DataCandidatosB> DataCandidatosBs { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=AticPruebaCandidatos; Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<DataCandidatosA>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("data-candidatos_A");

                entity.Property(e => e.AnemometroTs231MS)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"Anemometro TS231  m s \"");

                entity.Property(e => e.DirecciÃNVientoTs232Âº)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"DirecciÃ³n Viento TS232  Âº \"");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"fecha\"");

                entity.Property(e => e.HumedadRelativaTs251)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"Humedad Relativa TS251  % \"");

                entity.Property(e => e.NivelVegapuls61M)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"Nivel VEGAPULS61  m \"");

                entity.Property(e => e.PluviometroTs221Mm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"Pluviometro TS221  mm \"");

                entity.Property(e => e.PresionAtmTs290Hpa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"Presion atm TS290  hpa \"");

                entity.Property(e => e.TemperaturaTs251ÂºC)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"Temperatura TS251  ÂºC \"");

                entity.Property(e => e.TensionBateriaV)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"Tension Bateria  V \"");

                entity.Property(e => e.VoltajeMax5VV)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"Voltaje max5V  V \"");
            });

            modelBuilder.Entity<DataCandidatosB>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("data-candidatos_B");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"fecha\"");

                entity.Property(e => e.Nivel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"nivel\"");

                entity.Property(e => e.NivelBateria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"nivel_bateria\"");

                entity.Property(e => e.Temperatura)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("\"temperatura\"");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
