using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlans;
public class GetAllUserDailyPlansQueryValidator : AbstractValidator<GetAllUserDailyPlansQuery>
{
    public GetAllUserDailyPlansQueryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
