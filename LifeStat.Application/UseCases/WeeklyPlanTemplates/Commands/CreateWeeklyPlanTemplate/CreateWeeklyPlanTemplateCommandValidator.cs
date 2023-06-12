using FluentValidation;
using LifeStat.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public class CreateWeeklyPlanTemplateCommandValidator : AbstractValidator<CreateWeeklyPlanTemplateCommand>
{
    public CreateWeeklyPlanTemplateCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(ValidatorsConstants.WEEKLY_PLAN_TEMPLATE_NAME_MIN_LENGTH, 
                ValidatorsConstants.WEEKLY_PLAN_TEMPLATE_NAME_MAX_LENGTH);

        RuleFor(x => x.DailyPlanTemplates)
            .NotNull()
            .NotEmpty()
            .Must(x => x.Count == 7)
            .WithMessage(a => $"You must provide 7 Daily Plan Templates instead of {a.DailyPlanTemplates.Count}")
            .ForEach(x => x
            .Must(x => x.Id > 0)
            .WithMessage("Daily Plan Template Id must be greater than '0'"));
    }
}
