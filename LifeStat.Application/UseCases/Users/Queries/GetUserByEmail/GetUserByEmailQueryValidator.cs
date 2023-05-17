using FluentValidation;

namespace LifeStat.Application.UseCases.Users.Queries.GetUserByEmail;
public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
