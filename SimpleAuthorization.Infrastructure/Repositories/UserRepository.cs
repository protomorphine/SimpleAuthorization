using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Extensions;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Infrastructure.Data;

namespace SimpleAuthorization.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями
/// </summary>
public class UserRepository : IUserRepository
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    private readonly ApplicationDbContext _dbContext;
    
    /// <summary>
    /// Коллекция сущностей - пользователь
    /// </summary>
    private readonly DbSet<User> _users;

    private readonly DbSet<Organization> _organizations;

    /// <summary>
    /// Создает новый экземпляр <see cref="UserRepository"/>
    /// </summary>
    /// <param name="dbContext">контекст базы данных</param>
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _users = dbContext.Users;
        _organizations = dbContext.Organizations;
    }

    /// <summary>
    /// Создание нового пользователя
    /// </summary>
    /// <param name="entity">сущность - пользователь</param>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto> CreateAsync(User entity)
    {
        await _users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.ToUserDto();
    }

    /// <summary>
    /// Получение пользователя по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto?> GetByIdAsync(long id)
    {
        var result = await _users.Include(it => it.Organization)
            .FirstOrDefaultAsync(it => it.Id == id);

        return result?.ToUserDto();
    }

    /// <summary>
    /// Получение информации о пользователе по логину
    /// </summary>
    /// <param name="login">логин пользователя</param>
    /// <returns><see cref="User"/></returns>
    public async Task<User?> GetByLoginAsync(string login)
    {
        return await _users.FirstOrDefaultAsync(it => it.Login == login);
    }

    /// <summary>
    /// Получение списка всех пользователей
    /// </summary>
    /// <returns>список <see cref="User"/></returns>
    public async Task<List<UserDto>> GetUsersAsync()
    {
        return (await _users.Include(it => it.Organization)
            .ToListAsync())
            .ToUserDtoList();
    }
}
