using Microsoft.EntityFrameworkCore;
using VirtualSmartGarden.Core.Entities;

namespace VirtualSmartGarden.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SensorData> SensorData { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorData>(entity =>
            {
                entity.HasKey(e => e.Id);

               
                entity.Property(e => e.SensorType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Timestamp)
                    .IsRequired();
                               
                entity.Property(e => e.Group)
                    .HasDefaultValue(0);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
