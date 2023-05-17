using FluentValidation;
using LifeStat.Application.UseCases.Users.Queries.GetUser;

namespace LifeStat.Application.UseCases.Users.Queries.GetUserById;
public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}
