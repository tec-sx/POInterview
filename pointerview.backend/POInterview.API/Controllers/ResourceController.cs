using Microsoft.AspNetCore.Mvc;
using POInterview.Application.Contracts;
using POInterview.Application.Models;

namespace POInterview.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ResourceController : ControllerBase
{
    private readonly IResourceService _resourceService;

    public ResourceController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet(Name = "GetResources")]
    public IActionResult Get()
    {
        IReadOnlyCollection<ResourceDto> resources = _resourceService.GetAllResources();

        return Ok(resources);
    }
}
