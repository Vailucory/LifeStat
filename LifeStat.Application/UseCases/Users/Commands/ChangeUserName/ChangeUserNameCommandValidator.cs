using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.Users.Commands.ChangeUserName;
public class ChangeUserNameCommandValidator : AbstractValidator<ChangeUserNameCommand>
{
    public ChangeUserNameCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotEqual(Guid.Empty); ;

        RuleFor(x => x.NewUserName)
            .NotEmpty()
            .Matches(ValidatorsConstants.USERNAME_REGEX)
            .Length(ValidatorsConstants.USERNAME_MIN_LENGTH, ValidatorsConstants.USERNAME_MAX_LENGTH);
    }
}
