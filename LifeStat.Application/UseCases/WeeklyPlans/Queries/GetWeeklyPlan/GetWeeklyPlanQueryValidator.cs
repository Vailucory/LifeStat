using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlans.Queries.GetWeeklyPlan;
public class GetWeeklyPlanQueryValidator : AbstractValidator<GetWeeklyPlanQuery>
{
    public GetWeeklyPlanQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
