using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public class CreateDailyPlanTemplateCommandValidator : AbstractValidator<CreateDailyPlanTemplateCommand>
{
    public CreateDailyPlanTemplateCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(ValidatorsConstants.DAILY_PLAN_TEMPLATE_NAME_MIN_LENGTH,
                ValidatorsConstants.DAILY_PLAN_TEMPLATE_NAME_MAX_LENGTH);

        RuleFor(x => x.ActivityDurations)
            .ForEach(x => x
            .SetValidator(new DailyPlanActivityDurationValidator()))
            .When(x => x.ActivityDurations is not null);
    }
}
