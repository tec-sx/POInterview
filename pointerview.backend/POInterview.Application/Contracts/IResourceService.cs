using POInterview.Application.Models;

namespace POInterview.Application.Contracts;

public interface IResourceService
{
    Task<List<ResourceInfoDto>> GetAllResourcesAsync();
    Task<ResourceDetailsDto> GetResourceByIdAsync(int id);
}
