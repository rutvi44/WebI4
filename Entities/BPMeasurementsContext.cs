using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InClass4.Entities
{
    public partial class BPMeasurementsContext : DbContext
    {
        public BPMeasurementsContext()
        {
        }

        public BPMeasurementsContext(DbContextOptions<BPMeasurementsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bpmeasurement> Bpmeasurements { get; set; } = null!;
        public virtual DbSet<MeasurementPosition> MeasurementPositions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=InclassDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bpmeasurement>(entity =>
            {
                entity.HasOne(d => d.MeasurementPosition)
                    .WithMany(p => p.Bpmeasurements)
                    .HasForeignKey(d => d.MeasurementPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementPosition");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
