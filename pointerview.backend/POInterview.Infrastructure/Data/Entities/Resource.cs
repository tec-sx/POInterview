﻿namespace POInterview.Infrastructure.Data.Entities;

public record Resource : EntityBase
{
    public string Name { get; init; }
    public int Quantity { get; init; }
    public ICollection<Booking> Bookings { get; init; } = new List<Booking>();
}
