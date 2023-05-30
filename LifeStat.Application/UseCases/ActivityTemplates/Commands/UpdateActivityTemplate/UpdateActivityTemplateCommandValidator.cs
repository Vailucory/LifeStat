using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public class UpdateActivityTemplateCommandValidator : AbstractValidator<UpdateActivityTemplateCommand>
{
    public UpdateActivityTemplateCommandValidator()
    {
        RuleFor(x => x.ActivityTemplate).SetValidator(new ActivityTemplateValidator());
    }
}
