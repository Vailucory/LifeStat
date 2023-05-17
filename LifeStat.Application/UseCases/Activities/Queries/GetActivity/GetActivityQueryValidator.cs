using FluentValidation;

namespace LifeStat.Application.UseCases.Activities.Queries.GetActivity;
public class GetActivityQueryValidator : AbstractValidator<GetActivityQuery>
{
    public GetActivityQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
