using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Extensions;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.Core.Services;

/// <summary>
/// Сервис для работы с орагнизациями
/// </summary>
public class OrganizationService : IOrganizationService
{
    /// <summary>
    /// Репозиторий для работы с организациями
    /// </summary>
    private readonly IOrganizationRepository _organizationRepository;

    /// <summary>
    /// Создает новый экземпляр <see cref="OrganizationService"/>
    /// </summary>
    /// <param name="organizationRepository">репозиторий для работы с организациями</param>
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
        var createdOrgId = await _organizationRepository.CreateAsync(new Organization()
        {
            Name = name
        });

        var createdOrg = await _organizationRepository.GetAsync(createdOrgId);
        
        return createdOrg!.ToOrganizationDto();
    }

    /// <summary>
    /// Метод получения организации по id
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    /// <returns><see cref="OrganizationDto"/></returns>
    public async Task<OrganizationDto> GetOrganizationByIdAsync(long id)
    {
        var org = await _organizationRepository.GetAsync(id);
        org.ThrowIfNotFound($"Организация с id = {id} не найдена.");
        return org!.ToOrganizationDto();
    }

    /// <summary>
    /// Метод получения списка организаций
    /// </summary>
    /// <returns>Список организаций <see cref="List{OrganizationDto}"/></returns>
    public async Task<List<OrganizationDto>> GetListOfOrganizationsAsync()
    {
        return await _organizationRepository.GetAllOrganizations();
    }

    /// <summary>
    /// Метод удаления орагнизации
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    public async Task DeleteOrganization(long id)
    {
        var org = await _organizationRepository.GetAsync(id);
        org.ThrowIfNotFound($"Организация с id = {id} не найдена.");
        await _organizationRepository.DeleteAsync(org!);
    }

    /// <summary>
    /// Метод обновления орагнизации
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    /// <param name="dto">дто обновления орагнизации</param>
    /// <returns><see cref="OrganizationDto"/></returns>
    public async Task<OrganizationDto> UpdateOrganizationAsync(long id, CreateOrganizationDto dto)
    {
        var org = await _organizationRepository.GetAsync(id);
        org.ThrowIfNotFound($"Организация с id = {id} не найдена.");

        org!.Name = dto.Name;

        await _organizationRepository.UpdateAsync(org);
        return org.ToOrganizationDto();
    }
}