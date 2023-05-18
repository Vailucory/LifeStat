﻿using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.UpdateWeeklyPlanTemplate;
public class UpdateWeeklyPlanTemplateCommandValidator : AbstractValidator<UpdateWeeklyPlanTemplateCommand>
{
    public UpdateWeeklyPlanTemplateCommandValidator()
    {
        RuleFor(x => x.WeeklyPlanTemplate).SetValidator(new WeeklyPlanTemplateValidator());
    }
}