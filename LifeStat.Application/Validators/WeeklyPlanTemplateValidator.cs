using Domain.Models;
using FluentValidation;

namespace LifeStat.Application.Validators;
public class WeeklyPlanTemplateValidator : AbstractValidator<WeeklyPlanTemplate>
{
    private const int DAYS_IN_WEEK = 7;
    public WeeklyPlanTemplateValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(ValidatorsConstants.WEEKLY_PLAN_TEMPLATE_NAME_MIN_LENGTH, 
                ValidatorsConstants.WEEKLY_PLAN_TEMPLATE_NAME_MAX_LENGTH);

        RuleFor(x => x.DailyPlansTemplates)
            .Must(x => x.Count == DAYS_IN_WEEK)
            .ForEach(x => x
            .SetValidator(new DailyPlanTemplateValidator()))
            .When(x => x.DailyPlansTemplates is not null);
    }
}
