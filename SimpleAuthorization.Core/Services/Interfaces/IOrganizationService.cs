using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Services.Interfaces;

/// <summary>
/// Сервис для работы с организациями
/// </summary>
public interface IOrganizationService
{
    /// <summary>
    /// Метод создания новой организации
    /// </summary>
    /// <param name="name">имя организации</param>
    /// <returns><see cref="OrganizationDto"/></returns>
    Task<OrganizationDto> CreateOrganizationAsync(string name);

    /// <summary>
    /// Метод получения организации по id
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    /// <returns><see cref="OrganizationDto"/></returns>
    Task<OrganizationDto> GetOrganizationByIdAsync(long id);

    Task<List<OrganizationDto>> GetListOfOrganizationsAsync();

    Task DeleteOrganization(long id);

    Task<OrganizationDto> UpdateOrganizationAsync(long id, CreateOrganizationDto dto);
}