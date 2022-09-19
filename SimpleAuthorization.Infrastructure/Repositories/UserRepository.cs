using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Infrastructure.Data;

namespace SimpleAuthorization.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<User> _users;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _users = dbContext.Users;
    }

    public async Task<User> CreateAsync(User entity)
    {
        await _users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public Task<User> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}
