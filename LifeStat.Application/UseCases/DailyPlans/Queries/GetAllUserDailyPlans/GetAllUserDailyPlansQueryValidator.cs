using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetAllUserDailyPlans;
public class GetAllUserDailyPlansQueryValidator : AbstractValidator<GetAllUserDailyPlansQuery>
{
    public GetAllUserDailyPlansQueryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
