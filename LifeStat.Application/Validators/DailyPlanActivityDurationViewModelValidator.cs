using FluentValidation;
using LifeStat.Domain.ViewModels;

namespace LifeStat.Application.Validators;
public class DailyPlanActivityDurationViewModelValidator : AbstractValidator<DailyPlanActivityDurationViewModel>
{
    public DailyPlanActivityDurationViewModelValidator()
    {
        RuleFor(x => x.ActivityTemplateId).GreaterThan(0);

        RuleFor(x => x.Duration)
            .NotEmpty()
            .GreaterThan(TimeSpan.Zero)
            .LessThanOrEqualTo(TimeSpan.FromDays(1));
    }
}
