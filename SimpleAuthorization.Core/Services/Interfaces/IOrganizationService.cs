using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Services.Interfaces;

public interface IOrganizationService
{
    Task<OrganizationDto> CreateOrganizationAsync(string name);

    Task<OrganizationDto> GetOrganizationByIdAsync(long id);

    Task GetListOfOrganizations();

    Task DeleteOrganization(long id);
}