using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlans;
public class GetAllUserWeeklyPlansQueryValidators : AbstractValidator<GetAllUserWeeklyPlansQuery>
{
    public GetAllUserWeeklyPlansQueryValidators()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
