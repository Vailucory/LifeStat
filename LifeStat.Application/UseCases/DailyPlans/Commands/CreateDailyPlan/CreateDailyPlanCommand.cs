using Domain.Enums;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlans.Commands.CreateDailyPlan;
public record CreateDailyPlanCommand(
    int UserId,
    int DailyPlanTemplateId,
    PlanFulfillmentStatus FulfillmentStatus,
    DateTime DailyPlanStart ) : ICommand
{
}
