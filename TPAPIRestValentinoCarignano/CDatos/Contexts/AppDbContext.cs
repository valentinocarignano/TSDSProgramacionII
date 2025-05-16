using CEntidades.Entities;
using Microsoft.EntityFrameworkCore;

namespace CDatos.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Animal> Animales { get; set; }
        public DbSet<Atencion> Atenciones { get; set; }
        public DbSet<Duenio> Duenios { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=SistemaAdministracionVeterinaria;Integrated Security=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_ANIMAL");

                entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

                entity.HasMany(e => e.Atenciones)
                    .WithOne(e => e.Animal)
                    .HasForeignKey("IdAnimal")
                    .IsRequired();
            });

            modelBuilder.Entity<Atencion>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_ATENCION");

                entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Duenio>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_DUENIO");

                entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

                entity.HasMany(e => e.Animales)
                    .WithOne(e => e.Duenio)
                    .HasForeignKey("IdDuenio")
                    .IsRequired(false);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ID_TIPO");

                entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

                entity.HasMany(e => e.Animales)
                    .WithOne(e => e.Tipo)
                    .HasForeignKey("IdTipo")
                    .IsRequired();
            });
        }

        public override int SaveChanges()
        {
            this.DoCustomEntityPreparations();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.DoCustomEntityPreparations();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
        )
        {
            this.DoCustomEntityPreparations();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void DoCustomEntityPreparations()
        {
            var modifiedEntitiesWithTrackDate = this
                .ChangeTracker.Entries()
                .Where(c => c.State == EntityState.Modified);
            foreach (var entityEntry in modifiedEntitiesWithTrackDate)
            {
                if (entityEntry.Properties.Any(c => c.Metadata.Name == "UpdatedDate"))
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }
        }
    }
}
