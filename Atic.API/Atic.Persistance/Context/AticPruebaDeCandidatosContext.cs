using System;
using Atic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Atic.Persistance.Context
{
    public partial class AticPruebaDeCandidatosContext : DbContext
    {
        public AticPruebaDeCandidatosContext()
        {}

        public AticPruebaDeCandidatosContext(DbContextOptions<AticPruebaDeCandidatosContext> options) : base(options)
        {}

        public virtual DbSet<DataCandidatosA> DataCandidatosAs { get; set; }
        public virtual DbSet<DataCandidatosB> DataCandidatosBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<DataCandidatosA>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("data-candidatos_A");

                entity.Property(e => e.AnemometroTs231)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AnemometroTS231");

                entity.Property(e => e.DireccionVientoTs232)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DireccionVientoTS232");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HumedadRelativaTs251)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HumedadRelativaTS251");

                entity.Property(e => e.NivelVegapuls61)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NivelVEGAPULS61");

                entity.Property(e => e.PluviometroTs221)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PluviometroTS221");

                entity.Property(e => e.PresionAtmTs290)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PresionAtmTS290");

                entity.Property(e => e.TemperaturaTs251)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TemperaturaTS251");

                entity.Property(e => e.TensionBateria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoltajeMax5V)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DataCandidatosB>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("data-candidatos_B");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NivelBateria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_bateria");

                entity.Property(e => e.Temperatura)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
