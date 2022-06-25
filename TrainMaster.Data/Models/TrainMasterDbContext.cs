using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainMaster.Data.Models
{
    public partial class TrainMasterDbContext : DbContext
    {
        public TrainMasterDbContext()
        {
        }

        public TrainMasterDbContext(DbContextOptions<TrainMasterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DaysSchedular> DaysSchedulars { get; set; } = null!;
        public virtual DbSet<TrainDetail> TrainDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-QM194TV4\\SQLEXPRESS;Database=TrainMasterDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaysSchedular>(entity =>
            {
                entity.HasKey(e => e.TrainNo);

                entity.ToTable("DaysSchedular");

                entity.Property(e => e.TrainNo).ValueGeneratedNever();

                entity.HasOne(d => d.TrainNoNavigation)
                    .WithOne(p => p.DaysSchedular)
                    .HasForeignKey<DaysSchedular>(d => d.TrainNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DaysSchedular_TrainDetails");
            });

            modelBuilder.Entity<TrainDetail>(entity =>
            {
                entity.HasKey(e => e.TrainNumber);

                entity.HasIndex(e => e.TrainNumber, "IX_TrainDetails")
                    .IsUnique();

                entity.Property(e => e.TrainNumber).ValueGeneratedNever();

                entity.Property(e => e.FromStation)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JourneyEtime)
                    .HasColumnType("datetime")
                    .HasColumnName("JourneyETime");

                entity.Property(e => e.JourneyStime)
                    .HasColumnType("datetime")
                    .HasColumnName("JourneySTime");

                entity.Property(e => e.ToStaion)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TrainName)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
