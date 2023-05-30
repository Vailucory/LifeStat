using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public class GetAllUserDailyPlanTemplatesQueryValidator : AbstractValidator<GetAllUserDailyPlanTemplatesQuery>
{
    public GetAllUserDailyPlanTemplatesQueryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
