using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Infrastructure.Data.Configuration;

internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");

        builder.Property(b => b.DateFrom)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(b => b.DateTo)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(b => b.BookedQuantity)
            .HasColumnType("integer")
            .IsRequired();
    }
}
