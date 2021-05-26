using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiRest.Models
{
    public partial class VehiculoDBCTX : DbContext
    {
        public VehiculoDBCTX()
        {
        }

        public VehiculoDBCTX(DbContextOptions<VehiculoDBCTX> options)
            : base(options)
        {
        }

        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=VehiculoDB;ConnectRetryCount=0; User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.NombreTipoVeh).IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.Property(e => e.Modelo).IsUnicode(false);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Marca");

                entity.HasOne(d => d.TipoVehiculo)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.TipoVehiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_TipoVehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
