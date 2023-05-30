using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlans;
public class GetDailyPlanQueryValidator : AbstractValidator<GetDailyPlanQuery>
{
    public GetDailyPlanQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
