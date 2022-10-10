using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Extensions;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Infrastructure.Data;
using static SimpleAuthorization.Core.Enums.UserStatus;

namespace SimpleAuthorization.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями
/// </summary>
public class UserRepository : BaseRepository<User, long, ApplicationDbContext>, IUserRepository
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Коллекция сущностей - пользователь
    /// </summary>
    private readonly DbSet<User> _users;

    /// <summary>
    /// Создает новый экземпляр <see cref="UserRepository"/>
    /// </summary>
    /// <param name="dbContext">контекст базы данных</param>
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _users = dbContext.Users;
    }

    /// <summary>
    /// Получение пользователя по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    public override async Task<User?> GetAsync(long id)
    {
        var result = await _users.Include(it => it.Organization)
            .FirstOrDefaultAsync(it => it.Id == id);

        return result;
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
    /// <param name="dto">параметры фильтрации списка пользователей</param>
    /// <returns>список <see cref="User"/></returns>
    public async Task<List<UserDto>> GetUsersAsync(GetUsersQueryParamsDto dto)
    {
        var result = _users.Include(user => user.Organization)
            .AsQueryable();

        result = dto.OnlyActive switch
        {
            true => result.Where(user => user.UserStatus == Active),
            false => result.Where(user => user.UserStatus == Blocked),
            _ => result
        };

        if (dto.SearchString != null)
            result = result.Where(user =>
                user.Fio!.ToLower().Contains(dto.SearchString.ToLower()));


        return (await result.ToListAsync()).ToUserDtoList();
    }
}
