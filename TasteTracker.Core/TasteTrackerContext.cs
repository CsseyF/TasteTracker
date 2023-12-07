using Microsoft.EntityFrameworkCore;
using TasteTracker.Core.Entities;
using TasteTracker.Core.Entities.Interfaces;

namespace TasteTracker.Core
{
    public class TasteTrackerContext : DbContext
    {
        public TasteTrackerContext(DbContextOptions<TasteTrackerContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Feedback> Feedback { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Cliente>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Cliente>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.UpdatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Restaurante>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Restaurante>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Restaurante>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Restaurante>()
                .Property(x => x.UpdatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Feedback>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Feedback>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Feedback>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Feedback>()
                .Property(x => x.UpdatedAt)
                .HasDefaultValueSql("getdate()");

        }
    }
}
