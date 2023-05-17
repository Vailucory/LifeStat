using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Queries.GetAllUserDailyPlanTemplates;
public class GetAllUserDailyPlanTemplatesQueryValidator : AbstractValidator<GetAllUserDailyPlanTemplatesQuery>
{
    public GetAllUserDailyPlanTemplatesQueryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
