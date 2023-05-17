using Domain.Models;
using FluentValidation;

namespace LifeStat.Application.Validators;
public class DailyPlanTemplateValidator : AbstractValidator<DailyPlanTemplate>
{
    public DailyPlanTemplateValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(ValidatorsConstants.DAILY_PLAN_TEMPLATE_NAME_MIN_LENGTH, 
                ValidatorsConstants.DAILY_PLAN_TEMPLATE_NAME_MAX_LENGTH);

        RuleFor(x => x.Activities)
            .ForEach(x => x
            .SetValidator(new DailyPlanActivityDurationValidator()))
            .When(x => x.Activities is not null);
    }
}
