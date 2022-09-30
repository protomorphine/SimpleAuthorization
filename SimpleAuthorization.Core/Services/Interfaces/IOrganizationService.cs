using System.Collections.Generic;
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

    /// <summary>
    /// Метод получения списка организаций
    /// </summary>
    /// <returns>Список организаций <see cref="List{OrganizationDto}"/></returns>
    Task<List<OrganizationDto>> GetListOfOrganizationsAsync();

    /// <summary>
    /// Метод удаления орагнизации
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    /// <returns></returns>
    Task DeleteOrganization(long id);

    /// <summary>
    /// Метод обновления орагнизации
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    /// <param name="dto">дто обновления орагнизации</param>
    /// <returns><see cref="OrganizationDto"/></returns>
    Task<OrganizationDto> UpdateOrganizationAsync(long id, CreateOrganizationDto dto);
}