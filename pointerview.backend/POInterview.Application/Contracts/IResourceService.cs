using POInterview.Application.Models;

namespace POInterview.Application.Contracts;

public interface IResourceService
{
    IReadOnlyCollection<ResourceDto> GetAllResources();
}
