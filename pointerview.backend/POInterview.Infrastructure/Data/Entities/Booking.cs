namespace POInterview.Infrastructure.Data.Entities;

public sealed record Booking : EntityBase
{
    public DateTime DateFrom { get; init; }
    public DateTime DateTo { get; init; }
    public int BookedQuantity { get; init; }
    public int ResourceId { get; init; }
    public Resource Resource { get; init; } = null!;
}
