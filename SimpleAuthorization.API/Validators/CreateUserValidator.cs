using FluentValidation;
using SimpleAuthorization.Core.Dtos;

namespace SimpleAuthorization.API.Validators;

/// <summary>
/// Валидатор создания и обновления пользователя
/// </summary>
public class CreateUserValidator : AbstractValidator<CreateAndUpdateUserDto>
{
    /// <summary>
    /// Создает новый экземпляр <see cref="CreateUserValidator"/>
    /// </summary>
    public CreateUserValidator()
    {
        RuleFor(dto => dto.Password)
            .MinimumLength(6);

        RuleFor(dto => dto.Fio)
            .Must(fio => fio.All(Char.IsLetter))
            .WithMessage("Поле {PropertyName} должно содержать только буквы!");

    }
}