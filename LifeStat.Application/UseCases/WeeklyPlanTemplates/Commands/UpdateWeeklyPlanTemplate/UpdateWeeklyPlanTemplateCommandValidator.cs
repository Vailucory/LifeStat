using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public class UpdateWeeklyPlanTemplateCommandValidator : AbstractValidator<UpdateWeeklyPlanTemplateCommand>
{
    public UpdateWeeklyPlanTemplateCommandValidator()
    {
        RuleFor(x => x.WeeklyPlanTemplate.Id).GreaterThan(0);

        RuleFor(x => x.WeeklyPlanTemplate.Name)
            .NotEmpty()
            .Length(ValidatorsConstants.WEEKLY_PLAN_TEMPLATE_NAME_MIN_LENGTH,
                ValidatorsConstants.WEEKLY_PLAN_TEMPLATE_NAME_MAX_LENGTH);

        RuleFor(x => x.WeeklyPlanTemplate.DailyPlansTemplates)
            .NotNull()
            .NotEmpty()
            .Must(x => x.Count == 7)
            .WithMessage(a => $"You must provide 7 Daily Plan Templates instead of {a.WeeklyPlanTemplate.DailyPlansTemplates.Count}")
            .ForEach(x => x
            .Must(x => x.Id > 0)
            .WithMessage("Daily Plan Template Id must be greater than '0'"));
    }
}
