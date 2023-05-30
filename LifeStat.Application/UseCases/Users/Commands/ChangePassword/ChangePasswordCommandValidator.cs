using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.Users;
public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.CurrentPassword)
            .NotEmpty()
            .Length(ValidatorsConstants.PASSWORD_MIN_LENGTH, ValidatorsConstants.PASSWORD_MAX_LENGTH)
            .Matches(ValidatorsConstants.PASSWORD_REGEX);

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .Length(ValidatorsConstants.PASSWORD_MIN_LENGTH, ValidatorsConstants.PASSWORD_MAX_LENGTH)
            .Matches(ValidatorsConstants.PASSWORD_REGEX);
    }
}
