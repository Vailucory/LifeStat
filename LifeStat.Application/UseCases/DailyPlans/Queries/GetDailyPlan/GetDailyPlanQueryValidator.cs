using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetDailyPlan;
public class GetDailyPlanQueryValidator : AbstractValidator<GetDailyPlanQuery>
{
    public GetDailyPlanQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
