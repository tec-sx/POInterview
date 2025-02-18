using Microsoft.AspNetCore.Mvc;
using POInterview.Application.Contracts;
using POInterview.Application.Models;

namespace POInterview.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ResourcesController : ControllerBase
{
    private readonly IResourceService _resourceService;

    public ResourcesController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet(Name = "GetAllResources")]
    public async Task<IActionResult> GetAllAsync()
    {
        List<ResourceInfoDto> resources = await _resourceService.GetAllResourcesAsync();
        return Ok(resources);
    }

    [HttpGet("{id}", Name = "GetResourceById")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        ResourceDetailsDto resource = await _resourceService.GetResourceByIdAsync(id);
        return Ok(resource);
    }
}
