using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Queries.GetWeeklyPlanTemplate;
public class GetWeeklyPlanTemplateQueryValidator : AbstractValidator<GetWeeklyPlanTemplateQuery>
{
    public GetWeeklyPlanTemplateQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
