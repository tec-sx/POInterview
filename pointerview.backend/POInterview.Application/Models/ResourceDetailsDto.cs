namespace POInterview.Application.Models;

public record ResourceDetailsDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int Quantity { get; init; }
    public List<BookingDto> Bookings { get; init; } = new();

}
