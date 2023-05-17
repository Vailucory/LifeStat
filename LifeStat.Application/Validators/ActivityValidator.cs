using Domain.Models;
using FluentValidation;

namespace LifeStat.Application.Validators;
public class ActivityValidator : AbstractValidator<Activity>
{
    public ActivityValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.Template).SetValidator(new ActivityTemplateValidator());

        RuleFor(x => x.StartTimeLocal)
            .NotEmpty()
            .GreaterThan(x => x.EndTimeLocal)
            .GreaterThanOrEqualTo(x => x.StartTimeUtc);

        RuleFor(x => x.StartTimeUtc)
            .NotEmpty()
            .GreaterThan(x => x.EndTimeUtc)
            .GreaterThanOrEqualTo(x => x.StartTimeUtc);

        RuleFor(x => x.EndTimeLocal)
            .NotEmpty()
            .GreaterThanOrEqualTo(x => x.EndTimeUtc);

        RuleFor(x => x.EndTimeUtc).NotEmpty();


    }
}
