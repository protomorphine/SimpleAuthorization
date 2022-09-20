using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Infrastructure.Data.Config;

namespace SimpleAuthorization.Infrastructure.Data;

/// <summary>
/// Контекст базы данных приложения
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Строка подключения к базе данных
    /// </summary>
    private readonly string _connectionString;

    /// <summary>
    /// Коллекция сущностей - пользователь
    /// </summary>
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
