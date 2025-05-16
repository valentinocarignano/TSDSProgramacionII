using CEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Contexts
{
    public partial class AlquilerBiciletasContext : DbContext
    {
        public AlquilerBiciletasContext()
        {
        }

        public AlquilerBiciletasContext(DbContextOptions<AlquilerBiciletasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquiler { get; set; }
        public virtual DbSet<Bicicleta> Bicicleta { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Estacion> Estacion { get; set; }
        public virtual DbSet<MarcaBicicleta> MarcaBicicleta { get; set; }
        public virtual DbSet<TipoBicicleta> TipoBicicleta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=AlquilerBicicletas;Integrated Security=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_ALQUILER");
            });

            modelBuilder.Entity<Bicicleta>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_BICICLETA");

                entity.HasMany(e => e.Alquileres)
                    .WithOne(e => e.Bicicleta)
                    .HasForeignKey("IdBicicleta")
                    .IsRequired();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_CLIENTE");

                entity.HasMany(e => e.Alquileres)
                    .WithOne(e => e.Cliente)
                    .HasForeignKey("IdCliente")
                    .IsRequired();
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_EMPLEADO");

                entity.HasMany(e => e.Alquileres)
                    .WithOne(e => e.Empleado)
                    .HasForeignKey("IdEmpleado")
                    .IsRequired();
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_ESTACION");

                entity.HasMany(e => e.AlquileresDestino)
                    .WithOne(e => e.EstacionDestino)
                    .HasForeignKey("IdEstacionDestino")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasMany(e => e.AlquileresOrigen)
                    .WithOne(e => e.EstacionOrigen)
                    .HasForeignKey("IdEstacionOrigen")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasMany(e => e.Bicicletas)
                    .WithOne(e => e.Estacion)
                    .HasForeignKey("IdEstacion")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            modelBuilder.Entity<MarcaBicicleta>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_MARCABICICLETA");

                entity.HasMany(e => e.Bicicletas)
                    .WithOne(e => e.MarcaBicicleta)
                    .HasForeignKey("IdBicicleta")
                    .IsRequired();
            });

            modelBuilder.Entity<TipoBicicleta>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_TIPOBICICLETA");

                entity.HasMany(e => e.Bicicletas)
                    .WithOne(e => e.TipoBicicleta)
                    .HasForeignKey("IdBicicleta")
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
