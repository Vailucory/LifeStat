using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public class UpdateDailyPlanTemplateCommandValidator : AbstractValidator<UpdateDailyPlanTemplateCommand>
{
    public UpdateDailyPlanTemplateCommandValidator()
    {
        RuleFor(x => x.DailyPlanTemplate).SetValidator(new DailyPlanTemplateValidator());
    }
}
