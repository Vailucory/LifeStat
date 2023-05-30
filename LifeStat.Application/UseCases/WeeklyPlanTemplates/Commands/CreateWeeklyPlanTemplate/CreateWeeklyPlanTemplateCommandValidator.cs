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
            .ForEach(x => x
            .SetValidator(new DailyPlanTemplateValidator()));
    }
}
