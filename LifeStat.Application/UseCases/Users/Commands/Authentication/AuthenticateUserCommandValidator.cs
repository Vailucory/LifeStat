using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.Users;
public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserCommandValidator()
    {
        RuleFor(x => x.Email)
          .NotEmpty()
          .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(ValidatorsConstants.PASSWORD_MIN_LENGTH, ValidatorsConstants.PASSWORD_MAX_LENGTH)
            .Matches(ValidatorsConstants.PASSWORD_REGEX);
    }
}
