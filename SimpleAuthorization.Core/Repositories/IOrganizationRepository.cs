using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Repositories;

public interface IOrganizationRepository
{
    Task<Organization> CreateOrganizationAsync(Organization entity);

    Task GetOrganizationByIdAsync(long id);
}