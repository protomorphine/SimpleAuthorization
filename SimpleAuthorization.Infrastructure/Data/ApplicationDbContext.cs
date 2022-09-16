using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;

    DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
    }
}
