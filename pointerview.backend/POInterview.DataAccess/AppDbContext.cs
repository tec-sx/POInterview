using Microsoft.EntityFrameworkCore;
using POInterview.DataAccess.Configuration;
using POInterview.DataAccess.Entities;

namespace POInterview.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Resource> Resources;
    public DbSet<Booking> Bookings;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ResourceConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
    }
}
