using Microsoft.EntityFrameworkCore;
using POInterview.Infrastructure.Data.Configuration;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Resource> Resources;
    public DbSet<Booking> Bookings;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ResourceConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
    }
}
