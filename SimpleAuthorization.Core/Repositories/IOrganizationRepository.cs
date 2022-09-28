using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Repositories;

/// <summary>
/// Репозиторий для работы с организациями
/// </summary>
public interface IOrganizationRepository
{
    /// <summary>
    /// Метод создания организации
    /// </summary>
    /// <param name="entity">сущность - организация</param>
    /// <returns></returns>
    Task<OrganizationDto> CreateOrganizationAsync(Organization entity);

    /// <summary>
    /// Меод получения организации по идентификатору
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>сущность - орагнизация</returns>
    Task<Organization?> GetOrganizationByIdAsync(long id);

    /// <summary>
    /// Метод удаления организации по идентфиикатору
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    Task DeleteOrganization(long id);

    /// <summary>
    /// Метод обновления организации
    /// </summary>
    /// <param name="entity">сущность - организация</param>
    Task UpdateOrganizationAsync(Organization entity);

    /// <summary>
    /// Метод получения списка организаций
    /// </summary>
    /// <returns>список дто организаций</returns>
    Task<List<OrganizationDto>> GetAllOrganizations();
}