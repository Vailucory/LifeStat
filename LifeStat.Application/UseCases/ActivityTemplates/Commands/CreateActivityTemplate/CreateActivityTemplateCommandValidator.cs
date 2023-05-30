using FluentValidation;
using LifeStat.Application.Validators;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public class CreateActivityTemplateCommandValidator : AbstractValidator<CreateActivityTemplateCommand>
{
    public CreateActivityTemplateCommandValidator()
    {
        RuleFor(x => x.ActivityType).IsInEnum();

        RuleFor(x => x.UserId).GreaterThan(0);
            
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(ValidatorsConstants.ACTIVITY_TEMPLATE_NAME_MIN_LENGTH,
                ValidatorsConstants.ACTIVITY_TEMPLATE_NAME_MAX_LENGTH);
    }
}
