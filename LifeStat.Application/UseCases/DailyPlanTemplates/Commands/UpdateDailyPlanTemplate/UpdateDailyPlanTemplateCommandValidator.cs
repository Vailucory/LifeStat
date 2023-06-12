using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public class UpdateDailyPlanTemplateCommandValidator : AbstractValidator<UpdateDailyPlanTemplateCommand>
{
    public UpdateDailyPlanTemplateCommandValidator()
    {
        RuleFor(x => x.DailyPlanTemplateId).GreaterThan(0);

        RuleFor(x => x.DailyPlanTemplateName)
            .NotEmpty()
            .Length(ValidatorsConstants.DAILY_PLAN_TEMPLATE_NAME_MIN_LENGTH,
                ValidatorsConstants.DAILY_PLAN_TEMPLATE_NAME_MAX_LENGTH);

        RuleFor(x => x.Activities)
            .ForEach(x => x
            .SetValidator(new DailyPlanActivityDurationViewModelValidator())
            .When(x => x is not null));
    }
}
