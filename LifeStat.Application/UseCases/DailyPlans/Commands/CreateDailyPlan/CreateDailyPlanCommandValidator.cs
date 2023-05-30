using FluentValidation;

namespace LifeStat.Application.UseCases.DailyPlans;
public class CreateDailyPlanCommandValidator : AbstractValidator<CreateDailyPlanCommand>
{
    public CreateDailyPlanCommandValidator()
    {
        RuleFor(x => x.DailyPlanTemplateId).GreaterThan(0);

        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.DailyPlanTemplateId).GreaterThan(0);

        RuleFor(x => x.DailyPlanStart).NotEmpty();
    }
}
