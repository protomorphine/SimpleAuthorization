using Microsoft.AspNetCore.Mvc;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Services.Interfaces;
using SQLitePCL;

namespace SimpleAuthorization.API.Controllers;

/// <summary>
/// Контроллер организаций
/// </summary>
[ApiController]
[Route("api/org")]
public class OrganizationController : ControllerBase
{
    /// <summary>
    /// Сервис для работы с организациями
    /// </summary>
    private readonly IOrganizationService _organizationService;

    /// <summary>
    /// Создает новый экземпляр <see cref="OrganizationController"/>
    /// </summary>
    /// <param name="organizationService">Сервис для работы с орагнизациями</param>
    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }
    
    /// <summary>
    /// Метод создания организации
    /// </summary>
    /// <param name="dto">Дто создания организации</param>
    /// <returns>Дто созданной организации</returns>
    [HttpPost("create")]
    public async Task<OrganizationDto> CreateNew([FromBody] CreateOrganizationDto dto)
    {
        return await _organizationService.CreateOrganizationAsync(dto.Name);
    }
    
    /// <summary>
    /// Метод получения организации по id
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    /// <returns>Дто организации</returns>
    [HttpGet("{id:long}")]
    public async Task<OrganizationDto> GetById(long id)
    {
        return await _organizationService.GetOrganizationByIdAsync(id);
    }

}