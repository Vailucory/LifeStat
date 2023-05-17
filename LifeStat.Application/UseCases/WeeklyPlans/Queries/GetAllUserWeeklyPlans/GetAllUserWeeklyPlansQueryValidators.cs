using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlans.Queries.GetAllUserWeeklyPlans;
public class GetAllUserWeeklyPlansQueryValidators : AbstractValidator<GetAllUserWeeklyPlansQuery>
{
    public GetAllUserWeeklyPlansQueryValidators()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
