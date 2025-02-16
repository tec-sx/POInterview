using POInterview.Application.Contracts;
using POInterview.Application.Models;
using POInterview.Infrastructure.Data;

namespace POInterview.Application.Services;

public sealed class ResourceService : IResourceService
{
    private readonly ApplicationDbContext _context;
    public ResourceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IReadOnlyCollection<ResourceDto> GetAllResources()
    {
        return _context.Resources.Select(r => new ResourceDto
        {
            Id = r.Id,
            Name = r.Name
        }).ToList();
    }
}
