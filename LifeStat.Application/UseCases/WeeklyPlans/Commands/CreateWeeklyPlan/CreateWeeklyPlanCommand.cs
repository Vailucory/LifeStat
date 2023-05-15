using Domain.Enums;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlans.Commands.CreateWeeklyPlan;
public record CreateWeeklyPlanCommand(
    int UserId,
    int WeeklyPlanTemplateId,
    PlanFulfillmentStatus FulfillmentStatus) : ICommand
{
}
