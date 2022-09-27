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

    /// <summary>
    /// Метод создания новой организации
    /// </summary>
    /// <param name="name">имя организации</param>
    /// <returns><see cref="OrganizationDto"/></returns>
    public async Task<OrganizationDto> CreateOrganizationAsync(string name)
    {
        var org = await _organizationRepository.CreateOrganizationAsync(new Organization()
        {
            Name = name
        });
        return org;
    }

    /// <summary>
    /// Метод получения организации по id
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    /// <returns><see cref="OrganizationDto"/></returns>
    public async Task<OrganizationDto> GetOrganizationByIdAsync(long id)
    {
        var org = await _organizationRepository.GetOrganizationByIdAsync(id);
        org.ThrowIfNotFound($"Организация с id = {id} не найдена.");
        return org!.ToOrganizationDto();
    }

    public async Task<List<OrganizationDto>> GetListOfOrganizationsAsync()
    {
        return await _organizationRepository.GetAllOrganizations();
    }

    public async Task DeleteOrganization(long id)
    {
        await _organizationRepository.DeleteOrganization(id);
    }

    public async Task<OrganizationDto> UpdateOrganizationAsync(long id, CreateOrganizationDto dto)
    {
        var org = await _organizationRepository.GetOrganizationByIdAsync(id);
        org.ThrowIfNotFound($"Организация с id = {id} не найдена.");

        org.Name = dto.Name;

        await _organizationRepository.UpdateOrganizationAsync(org);
        return org.ToOrganizationDto();
    }
}