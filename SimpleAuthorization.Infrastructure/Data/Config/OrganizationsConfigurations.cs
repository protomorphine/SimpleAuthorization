using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Infrastructure.Data.Config;

/// <summary>
/// Конфигурация сущности - Организация
/// </summary>
public class OrganizationsConfigurations : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("organizations");

        builder.HasKey(it => it.Id);
    }
}