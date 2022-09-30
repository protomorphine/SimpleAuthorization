using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Infrastructure.Data;

/// <summary>
/// Контекст базы данных приложения
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Строка подключения к базе данных
    /// </summary>
    private readonly string? _connectionString;

    /// <summary>
    /// Коллекция сущностей - пользователь
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Коллекция сущностей - организация
    /// </summary>
    public DbSet<Organization> Organizations { get; set; }

    /// <summary>
    /// Создает новый экземпляр <see cref="ApplicationDbContext"/>
    /// </summary>
    /// <param name="options"><see cref="DbContextOptions"/></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Создает новый экземпляр <see cref="ApplicationDbContext"/>
    /// </summary>
    /// <param name="connectionString">Строка подключения к базе данных</param>
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
