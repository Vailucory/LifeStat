using Domain.Models;
using FluentValidation;

namespace LifeStat.Application.Validators;
public class DailyPlanValidator : AbstractValidator<DailyPlan>
{
    public DailyPlanValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.FulfillmentStatus).IsInEnum();

        RuleFor(x => x.DailyPlanTemplate).SetValidator(new DailyPlanTemplateValidator());

        RuleFor(x => x.Activities)
            .ForEach(x => x
            .SetValidator(new ActivityValidator()))
            .When(x => x.Activities is not null);
    }
}
