using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Infrastructure.Data.Configuration;

internal sealed class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.ToTable("Resources");

        builder
            .Property(r => r.Name)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder
            .Property(r => r.Quantity)
            .HasColumnType("integer")
            .IsRequired();

        builder
            .HasMany(r => r.Bookings)
            .WithOne(b => b.Resource)
            .HasForeignKey(b => b.ResourceId);

        builder.HasData(ResourceSeedData);
    }

    private Resource[] ResourceSeedData =
    [
        new Resource
        {
            Id = 1,
            Name = "Resource 1",
            Quantity = 4
        },
        new Resource
        {
            Id = 2,
            Name = "Resource 2",
            Quantity = 0
        },
        new Resource
        {
            Id = 3,
            Name = "Resource 3",
            Quantity = 2
        },
        new Resource
        {
            Id = 4,
            Name = "Resource 4",
            Quantity = 5
        },
        new Resource
        {
            Id = 5,
            Name = "Resource 5",
            Quantity = 1
        }
    ];
}
