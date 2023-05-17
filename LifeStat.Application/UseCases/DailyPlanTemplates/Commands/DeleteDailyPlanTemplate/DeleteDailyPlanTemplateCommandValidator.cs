using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.DeleteDailyPlanTemplate;
public class DeleteDailyPlanTemplateCommandValidator : AbstractValidator<DeleteDailyPlanTemplateCommand>
{
    public DeleteDailyPlanTemplateCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
