namespace POInterview.DataAccess.Entities;

public record Resource : EntityBase
{
    public string Name { get; init; }
    public int Quantity { get; init; }
}
