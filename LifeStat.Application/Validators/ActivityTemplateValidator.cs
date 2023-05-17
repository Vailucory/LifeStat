using Domain.Models;
using FluentValidation;

namespace LifeStat.Application.Validators;
public class ActivityTemplateValidator : AbstractValidator<ActivityTemplate>
{
    public ActivityTemplateValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(ValidatorsConstants.ACTIVITY_TEMPLATE_NAME_MIN_LENGTH, 
                ValidatorsConstants.ACTIVITY_TEMPLATE_NAME_MAX_LENGTH);

        RuleFor(x => x.Type).IsInEnum();
    }
}
