using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Queries.GetDailyPlanTemplate;
public class GetDailyPlanTemplateQueryValidator : AbstractValidator<GetDailyPlanTemplateQuery>
{
    public GetDailyPlanTemplateQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
