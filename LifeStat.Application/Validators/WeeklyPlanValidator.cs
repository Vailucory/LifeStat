using Domain.Models;
using FluentValidation;

namespace LifeStat.Application.Validators;
public class WeeklyPlanValidator : AbstractValidator<WeeklyPlan>
{
    public WeeklyPlanValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.WeeklyPlanTemplate).SetValidator(new WeeklyPlanTemplateValidator());

        RuleFor(x => x.FulfillmentStatus).IsInEnum();

        RuleFor(x => x.DailyPlans)
            .ForEach(x => x
            .SetValidator(new DailyPlanValidator()))
            .When(x => x.DailyPlans is not null);
        
    }
}
