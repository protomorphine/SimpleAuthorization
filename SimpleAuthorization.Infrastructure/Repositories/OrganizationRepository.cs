using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Extensions;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Infrastructure.Data;

namespace SimpleAuthorization.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для работы с организациями
/// </summary>
public class OrganizationRepository : IOrganizationRepository
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Коллекция сущностей - пользователь
    /// </summary>
    private readonly DbSet<Organization> _organizations;

    /// <summary>
    /// Создает новый экземпляр <see cref="OrganizationRepository"/>
    /// </summary>
    /// <param name="dbContext">контекст базы данных</param>
    public OrganizationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _organizations = dbContext.Organizations;
    }

    /// <summary>
    /// Метод создания организации
    /// </summary>
    /// <param name="entity">сущность - организация</param>
    /// <returns></returns>
    public async Task<OrganizationDto> CreateOrganizationAsync(Organization entity)
    {
        await _organizations.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.ToOrganizationDto();
    }

    /// <summary>
    /// Меод получения организации по идентификатору
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>сущность - орагнизация</returns>
    public async Task<Organization> GetOrganizationByIdAsync(long id)
    {
        var org = await _organizations.FirstOrDefaultAsync(org => org.Id == id);
        return org;
    }

    /// <summary>
    /// Метод удаления организации по идентфиикатору
    /// </summary>
    /// <param name="id">идентификатор организации</param>
    public async Task DeleteOrganization(long id)
    {
        var org = await _organizations.FirstOrDefaultAsync(org => org.Id == id);
        _organizations.Remove(org);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Метод обновления организации
    /// </summary>
    /// <param name="entity">сущность - организация</param>
    public async Task UpdateOrganizationAsync(Organization entity)
    {
        _organizations.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Метод получения списка организаций
    /// </summary>
    /// <returns>список дто организаций</returns>
    public async Task<List<OrganizationDto>> GetAllOrganizations()
    {
        var orgList = await _organizations.ToListAsync();
        return orgList.ToOrganizationDtoList();
    }
}