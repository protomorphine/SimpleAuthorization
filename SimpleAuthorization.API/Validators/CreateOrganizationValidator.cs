using FluentValidation;
using SimpleAuthorization.Core.Dtos;

namespace SimpleAuthorization.API.Validators;

/// <summary>
/// Валидатор создания орагнизации
/// </summary>
public class CreateOrganizationValidator : AbstractValidator<CreateOrganizationDto>
{
    /// <summary>
    /// Создает новый экземпляр <see cref="CreateOrganizationValidator"/>
    /// </summary>
    public CreateOrganizationValidator()
    {
        RuleFor(org => org.Name).NotEmpty();
        RuleFor(org => org.CreatorId).GreaterThan(0);
    }
}