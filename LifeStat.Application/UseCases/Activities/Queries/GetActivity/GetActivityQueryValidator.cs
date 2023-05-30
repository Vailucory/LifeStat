using FluentValidation;

namespace LifeStat.Application.UseCases.Activities;
public class GetActivityQueryValidator : AbstractValidator<GetActivityQuery>
{
    public GetActivityQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
