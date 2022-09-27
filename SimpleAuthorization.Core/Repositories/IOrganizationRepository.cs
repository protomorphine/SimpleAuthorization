using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Repositories;

public interface IOrganizationRepository
{
    Task<OrganizationDto> CreateOrganizationAsync(Organization entity);

    Task<OrganizationDto> GetOrganizationByIdAsync(long id);
}