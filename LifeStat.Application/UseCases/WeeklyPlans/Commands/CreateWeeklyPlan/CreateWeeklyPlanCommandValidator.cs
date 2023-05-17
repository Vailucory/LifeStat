using FluentValidation;

namespace LifeStat.Application.UseCases.WeeklyPlans.Commands.CreateWeeklyPlan;
public class CreateWeeklyPlanCommandValidator : AbstractValidator<CreateWeeklyPlanCommand>
{
    public CreateWeeklyPlanCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.WeeklyPlanTemplateId).GreaterThan(0);

        RuleFor(x => x.FulfillmentStatus).IsInEnum();
    }
}
