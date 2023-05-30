using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public class DeleteWeeklyPlanTemplateCommandValidator : AbstractValidator<DeleteWeeklyPlanTemplateCommand>
{
    public DeleteWeeklyPlanTemplateCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
