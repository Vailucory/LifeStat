using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlans;
public class GetWeeklyPlanQueryValidator : AbstractValidator<GetWeeklyPlanQuery>
{
    public GetWeeklyPlanQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
