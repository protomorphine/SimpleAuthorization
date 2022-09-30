using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleAuthorization.Core.Enums;

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

        builder.Property(user => user.UserStatus)
            .HasDefaultValue(UserStatus.Active)
            .HasConversion<string>();

        builder.HasOne(user => user.Organization)
            .WithMany(org => org.Users)
            .HasForeignKey(user => user.OrganizationId);
    }
}
