using FluentValidation;

namespace LifeStat.Application.UseCases.Activities.Commands.CreateActivity;
public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
{
    public CreateActivityCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.ActivityTemplateId).GreaterThan(0);

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
