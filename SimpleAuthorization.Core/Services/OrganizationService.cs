using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Extensions;
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

    public async Task<OrganizationDto> CreateOrganizationAsync(string name)
    {
        var org = await _organizationRepository.CreateOrganizationAsync(new Organization()
        {
            Name = name
        });
        return org;
    }

    public async Task<OrganizationDto> GetOrganizationByIdAsync(long id)
    {
        var org = await _organizationRepository.GetOrganizationByIdAsync(id);
        org.ThrowIfNotFound($"Организация с id = {id} не найдена.");
        return org!;
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