using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Infrastructure.Data;

namespace SimpleAuthorization.Infrastructure.Repositories;

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

    public async Task<OrganizationDto> CreateOrganizationAsync(Organization entity)
    {
        await _organizations.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.ToOrganizationDto();
    }

    public async Task<OrganizationDto> GetOrganizationByIdAsync(long id)
    {
        var org = await _organizations.FirstOrDefaultAsync(org => org.Id == id);
        return org?.ToOrganizationDto();
    }
}