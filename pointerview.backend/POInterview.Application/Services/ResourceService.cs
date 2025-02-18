using AutoMapper;
using POInterview.Application.Contracts;
using POInterview.Application.Models;
using POInterview.Infrastructure.Data.Entities;
using POInterview.Infrastructure.Data.Repositories;

namespace POInterview.Application.Services;

public sealed class ResourceService : IResourceService
{
    private readonly IRepository<Resource> _resourcesRepository;
    private readonly IMapper _mapper;

    public ResourceService(IRepository<Resource> resourcesRepository, IMapper mapper)
    {
        _resourcesRepository = resourcesRepository;
        _mapper = mapper;
    }

    public async Task<List<ResourceInfoDto>> GetAllResourcesAsync()
    {
        var resources = await _resourcesRepository.GetAllAsync();

        return _mapper.Map<List<ResourceInfoDto>>(resources);
    }

    public async Task<ResourceDetailsDto> GetResourceByIdAsync(int id)
    {
        var resource = await _resourcesRepository.GetByIdAsync(id);

        return _mapper.Map<ResourceDetailsDto>(resource);
    }
}
