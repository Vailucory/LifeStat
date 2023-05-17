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
            .Length();

        RuleFor(x => x.Password)
            .NotEmpty()
            .Matches(ValidatorsConstants.PASSWORD_REGEX);
    }
}
