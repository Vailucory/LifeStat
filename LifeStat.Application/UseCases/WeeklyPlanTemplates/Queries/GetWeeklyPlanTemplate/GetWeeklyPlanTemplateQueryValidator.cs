using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public class GetWeeklyPlanTemplateQueryValidator : AbstractValidator<GetWeeklyPlanTemplateQuery>
{
    public GetWeeklyPlanTemplateQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
