using Microsoft.EntityFrameworkCore;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Infrastructure.Data.Repositories;

public sealed class ResourceRepository : IRepository<Resource>
{
    private readonly ApplicationDbContext _ctx;
    public ResourceRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public Task<Resource> AddAsync(Resource entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var resourceToDelete = await _ctx.Resources.FirstAsync(r => r.Id == id && r.DeletedAt == null);

        resourceToDelete.DeletedAt = DateTime.Now;

        await _ctx.SaveChangesAsync();
    }

    public Task<List<Resource>> GetAllAsync()
    {
        return _ctx.Resources
            .Where(r => r.DeletedAt == null)
            .ToListAsync();
    }

    public Task<Resource> GetByIdAsync(int id)
    {
        return _ctx.Resources
            .Include(r => r.Bookings)
            .FirstAsync(r => r.Id == id && r.DeletedAt == null);
    }
}
