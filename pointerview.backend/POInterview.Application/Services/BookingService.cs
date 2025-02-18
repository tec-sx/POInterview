using AutoMapper;
using POInterview.Application.Contracts;
using POInterview.Application.Exceptions;
using POInterview.Application.Models;
using POInterview.Infrastructure.Data.Entities;
using POInterview.Infrastructure.Data.Repositories;
using POInterview.Infrastructure.MessageBrokers;

namespace POInterview.Application.Services;

public sealed class BookingService : IBookingService
{
    private readonly IRepository<Resource> _resourcesRepository;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IMapper _mapper;
    private readonly IMessagePublisher _emailPublisher;

    public BookingService(
        IRepository<Resource> resourcesRepository,
        IRepository<Booking> bookingRepository,
        IMapper mapper,
        IMessagePublisher emailPublisher)
    {
        _resourcesRepository = resourcesRepository;
        _bookingRepository = bookingRepository;
        _mapper = mapper;
        _emailPublisher = emailPublisher;
    }

    public async Task BookResourceAsync(BookingDto booking)
    {
        var resource = await _resourcesRepository.GetByIdAsync(booking.ResourceId);

        ValidateBooking(booking.DateFrom, booking.DateTo, booking.BookedQuantity, resource);
        
        var bookingEntity = _mapper.Map<Booking>(booking);
        await _bookingRepository.AddAsync(bookingEntity);
        await Task.Run(async () => 
            await _emailPublisher.PublishMessage($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {resource.Id}"));
    }

    public void ValidateBooking(
        DateTime requestedStart,
        DateTime requestedEnd,
        int requestedQuantity,
        Resource resource)
    {
        if (resource == null ||
            resource.Bookings == null ||
            requestedQuantity <= 0 ||
            requestedQuantity > resource.Quantity ||
            requestedEnd.Date < requestedStart.AddDays(1).Date)
        {
            throw new ArgumentException("Invalid booking request.");
        }

        var overlappingBookings = resource.Bookings
            .Where(b => requestedStart.Date < b.DateTo.Date && requestedEnd.Date > b.DateFrom.Date)
            .ToList();

        for (var date = requestedStart.Date; date <= requestedEnd.Date; date = date.AddDays(1))
        {
            int totalBookedOnDate = overlappingBookings
                .Where(b => b.DateFrom.Date <= date && b.DateTo.Date >= date)
                .Sum(b => b.BookedQuantity);

            if (totalBookedOnDate + requestedQuantity > resource.Quantity)
            {
                throw new InvalidBookingException();
            }
        }
    }
}
