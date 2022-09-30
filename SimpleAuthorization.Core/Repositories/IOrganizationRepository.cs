using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Repositories;

/// <summary>
/// Репозиторий для работы с организациями
/// </summary>
public interface IOrganizationRepository : IBaseRepository<Organization, long>
{
    /// <summary>
    /// Метод получения списка организаций
    /// </summary>
    /// <returns>список дто организаций</returns>
    Task<List<OrganizationDto>> GetAllOrganizations();
}