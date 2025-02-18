using Microsoft.EntityFrameworkCore;
using POInterview.Infrastructure.Data.Configuration;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<int>("Id")
                    .HasColumnType("integer")
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime>("CreatedAt")
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("date('now')")
                    .IsRequired();
            }
        }

        modelBuilder.ApplyConfiguration(new ResourceConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
    }
}
