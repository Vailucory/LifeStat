using FluentValidation;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.DeleteActivityTemplate;
public class DeleteActivityTemplateCommandValidator : AbstractValidator<DeleteActivityTemplateCommand>
{
    public DeleteActivityTemplateCommandValidator()
    {
        RuleFor(x => x.ActivityTemplateId).GreaterThan(0);
    }
}
