using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quiz_4Minh_Nguyen.Entities;

public partial class BpmeasurementsContext : DbContext
{
    public BpmeasurementsContext()
    {
    }

    public BpmeasurementsContext(DbContextOptions<BpmeasurementsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bpmeasurement> Bpmeasurements { get; set; }

    public virtual DbSet<MeasurementPosition> MeasurementPositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Connection_DB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bpmeasurement>(entity =>
        {
            entity.ToTable("BPMeasurements");

            entity.Property(e => e.BpmeasurementId).HasColumnName("BPMeasurementId");
            entity.Property(e => e.MeasurementPositionId).HasMaxLength(450);

            entity.HasOne(d => d.MeasurementPosition).WithMany(p => p.Bpmeasurements)
                .HasForeignKey(d => d.MeasurementPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MeasurementPosition");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
