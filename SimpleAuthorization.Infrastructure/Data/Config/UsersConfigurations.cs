using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleAuthorization.Infrastructure.Data.Config;

/// <summary>
/// Конфигурация сущности - пользователь
/// </summary>
internal class UsersConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);

        builder.HasOne(user => user.Organization)
            .WithMany(org => org.Users)
            .HasForeignKey(user => user.OrganizationId);
    }
}
