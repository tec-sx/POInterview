using AutoMapper;
using FluentAssertions;
using NSubstitute;
using POInterview.Application.Contracts;
using POInterview.Application.Exceptions;
using POInterview.Application.Services;
using POInterview.Infrastructure.Data.Entities;
using POInterview.Infrastructure.Data.Repositories;
using POInterview.Infrastructure.MessageBrokers;

namespace POInterview.Application.UnitTests.Services;

public class BookingServiceTests
{
    private readonly IBookingService _sut;

    private readonly IRepository<Resource> _resourcesRepository;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IMapper _mapper;
    private readonly IMessagePublisher _emailPublisher;
    public BookingServiceTests()
    {
        _resourcesRepository = Substitute.For<IRepository<Resource>>();
        _bookingRepository = Substitute.For<IRepository<Booking>>();
        _mapper = Substitute.For<IMapper>();
        _emailPublisher = Substitute.For<IMessagePublisher>();

        _sut = new BookingService(_resourcesRepository, _bookingRepository, _mapper, _emailPublisher);
    }

    [Fact]
    public void ResourceIsAvailable_WhenNoOverlappingBookings_NotThrowsException()
    {
        // Arrange
        var resource = new Resource { Id = 1, Name = "Test Resource", Quantity = 10, Bookings = new List<Booking>() };

        // Act
        var result = () => _sut.ValidateBooking(
            new DateTime(2025, 3, 1),
            new DateTime(2025, 3, 5),
            5,
            resource);

        // Assert
        result.Should().NotThrow<InvalidBookingException>();
    }

    [Fact]
    public void ResourceIsAvailable_WhenOverlappingExceedsQuantity_ThrowsException()
    {
        // Arrange
        var existingBookings = new List<Booking>
        {
            new Booking { ResourceId = 1, DateFrom = new DateTime(2025, 2, 1), DateTo = new DateTime(2025, 4, 1), BookedQuantity = 6 }
        };

        var resource = new Resource { Id = 1, Name = "Test Resource", Quantity = 10, Bookings = existingBookings };

        // Act
        var result = () => _sut.ValidateBooking(
            new DateTime(2025, 3, 1),
            new DateTime(2025, 5, 1),
            5,
            resource);

        // Assert
        result.Should().Throw<InvalidBookingException>();
    }

    [Fact]
    public void ResourceIsAvailable_WhenOverlappingDoesNotExceedQuantity_NotThrowsException()
    {
        // Arrange
        var existingBookings = new List<Booking>
        {
            new Booking { ResourceId = 1, DateFrom = new DateTime(2025, 2, 1), DateTo = new DateTime(2025, 4, 1), BookedQuantity = 4 }
        };

        var resource = new Resource { Id = 1, Name = "Test Resource", Quantity = 10, Bookings = existingBookings };

        // Act
        var result = () => _sut.ValidateBooking(
            new DateTime(2025, 3, 1),
            new DateTime(2025, 5, 1),
            5,
            resource);

        // Assert
        result.Should().NotThrow<InvalidBookingException>();
    }

    [Fact]
    public void ResourceIsAvailable_QuantityZeroOrLess_ThrowsException()
    {
        // Arrange
        var resource = new Resource { Id = 1, Name = "Test Resource", Quantity = 10, Bookings = new List<Booking>() };
        var requestedQuantity = 0;

        // Act & Assert
        var result = () => _sut.ValidateBooking(
                new DateTime(2025, 3, 1),
                new DateTime(2025, 3, 5),
                requestedQuantity,
                resource);

        result.Should().Throw<ArgumentException>().WithMessage("Invalid booking request.");
    }

    [Fact]
    public void ResourceIsAvailable_WhenQuantityGreaterThanAvailable_ThrowsException()
    {
        // Arrange
        var resource = new Resource { Id = 1, Name = "Test Resource", Quantity = 10, Bookings = new List<Booking>() };
        var requestedQuantity = 11;

        // Act
        var result = () => _sut.ValidateBooking(
            new DateTime(2025, 3, 1),
            new DateTime(2025, 3, 5),
            requestedQuantity,
            resource);

        // Assert
        result.Should().Throw<ArgumentException>().WithMessage("Invalid booking request.");
    }
}