using POInterview.Application.Models;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Application.Contracts;

public interface IBookingService
{
    Task BookResourceAsync(BookingDto booking);

    void ValidateBooking(
        DateTime requestedStart,
        DateTime requestedEnd,
        int requestedQuantity,
        Resource resource);
}
