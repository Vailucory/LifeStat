using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Queries.GetAllUserWeeklyPlanTemplates;
public class GetAllUserWeeklyPlanTemplatesQueryValidator : AbstractValidator<GetAllUserWeeklyPlanTemplatesQuery>
{
    public GetAllUserWeeklyPlanTemplatesQueryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
