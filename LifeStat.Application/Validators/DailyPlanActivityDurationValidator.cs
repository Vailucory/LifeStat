using Domain.Models;
using FluentValidation;

namespace LifeStat.Application.Validators;
public class DailyPlanActivityDurationValidator : AbstractValidator<DailyPlanActivityDuration>
{
    public DailyPlanActivityDurationValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.DailyPlanTemplate).SetValidator(new DailyPlanTemplateValidator());

        RuleFor(x => x.ActivityTemplate).SetValidator(new ActivityTemplateValidator());

        RuleFor(x => x.Duration)
            .NotEmpty()
            .GreaterThan(TimeSpan.Zero);
    }
}
