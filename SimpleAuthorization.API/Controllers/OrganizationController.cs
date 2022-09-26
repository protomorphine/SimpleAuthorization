using Microsoft.AspNetCore.Mvc;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Services.Interfaces;
using SQLitePCL;

namespace SimpleAuthorization.API.Controllers;

[ApiController]
[Route("api/org")]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpPost]
    public async Task<Organization> CreateNew([FromBody] CreateOrganizationDto dto)
    {
        return await _organizationService.CreateOrganizationAsync(dto.Name);
    }
}