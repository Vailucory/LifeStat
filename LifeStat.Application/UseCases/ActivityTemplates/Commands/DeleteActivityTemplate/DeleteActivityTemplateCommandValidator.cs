using FluentValidation;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public class DeleteActivityTemplateCommandValidator : AbstractValidator<DeleteActivityTemplateCommand>
{
    public DeleteActivityTemplateCommandValidator()
    {
        RuleFor(x => x.ActivityTemplateId).GreaterThan(0);
    }
}
