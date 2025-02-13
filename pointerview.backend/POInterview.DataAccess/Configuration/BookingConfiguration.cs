﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POInterview.DataAccess.Entities;

namespace POInterview.DataAccess.Configuration;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.Property(b => b.Id)
            .HasColumnType("integer")
            .IsRequired()
            .ValueGeneratedOnAdd();

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
