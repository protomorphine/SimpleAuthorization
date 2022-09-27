using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.Core.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;

    public OrganizationService(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task<Organization> CreateOrganizationAsync(string name)
    {
        var org = await _organizationRepository.CreateOrganizationAsync(new Organization()
        {
            Name = name
        });
        return org;
    }

    public Task GetOrganizationByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task GetListOfOrganizations()
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrganization(long id)
    {
        throw new NotImplementedException();
    }
}