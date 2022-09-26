using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Services.Interfaces;

public interface IOrganizationService
{
    Task<Organization> CreateOrganizationAsync(string name);

    Task GetOrganizationByIdAsync(long id);

    Task GetListOfOrganizations();

    Task DeleteOrganization(long id);
}