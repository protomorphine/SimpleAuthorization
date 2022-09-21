﻿using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
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

    /// <summary>
    /// Создает новый экземпляр <see cref="UserRepository"/>
    /// </summary>
    /// <param name="dbContext">контекст базы данных</param>
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _users = dbContext.Users;
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
        return (await _users.FirstOrDefaultAsync(it => it.Id == id))?.ToUserDto();
    }

    public async Task<User?> GetByLoginAsync(string login)
    {
        return await _users.FirstOrDefaultAsync(it => it.Login == login);
    }

    /// <summary>
    /// Получение списка всех пользователей
    /// </summary>
    /// <returns>список <see cref="User"/></returns>
    public async Task<List<User>> GetUsersAsync()
    {
        return await _users.ToListAsync();
    }
}
