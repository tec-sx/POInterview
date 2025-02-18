using Microsoft.EntityFrameworkCore;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Infrastructure.Data.Repositories;

public sealed class BookingRepository : IRepository<Booking>
{
    private readonly ApplicationDbContext _ctx;

    public BookingRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Booking> AddAsync(Booking entity)
    {
        var booking = await _ctx.Bookings.AddAsync(entity);
        await _ctx.SaveChangesAsync();

        return booking.Entity;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var bookingToDelete = await _ctx.Bookings.FirstAsync(r => r.Id == id && r.DeletedAt == null);

        bookingToDelete.DeletedAt = DateTime.Now;

        await _ctx.SaveChangesAsync();
    }

    public Task<List<Booking>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Booking> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
