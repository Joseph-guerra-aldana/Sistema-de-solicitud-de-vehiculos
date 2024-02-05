using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTecnica.Models
{
    public partial class ExamenAnalistaProgramdorContext : DbContext
    {


        public ExamenAnalistaProgramdorContext(DbContextOptions<ExamenAnalistaProgramdorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Conductore> Conductores { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.DireccionCarga)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionEntregaCarga)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentacionCarga)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PatenteComercio)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeCargo).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.VehiculoAsignado)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("FK_Clientes_Vehiculos");
            });

            modelBuilder.Entity<Conductore>(entity =>
            {
                entity.Property(e => e.Dpi)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GastosRequeridos).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.NoLicencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ViaticosEquipo).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Conductores)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conductores_Vehiculos");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.Property(e => e.Combustible)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Depreciacion).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Marca)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Placas)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCarga)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
