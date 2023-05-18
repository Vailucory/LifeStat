using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.Users.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.UserName)
            .NotEmpty()
            .Matches(ValidatorsConstants.USERNAME_REGEX)
            .Length(ValidatorsConstants.USERNAME_MIN_LENGTH, ValidatorsConstants.USERNAME_MAX_LENGTH);

        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(ValidatorsConstants.PASSWORD_MIN_LENGTH, ValidatorsConstants.PASSWORD_MAX_LENGTH)
            .Matches(ValidatorsConstants.PASSWORD_REGEX);
    }
}
