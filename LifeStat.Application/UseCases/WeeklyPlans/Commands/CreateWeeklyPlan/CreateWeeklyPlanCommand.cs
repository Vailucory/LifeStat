using Domain.Enums;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlans.Commands.CreateWeeklyPlan;
public record CreateWeeklyPlanCommand(
    int UserId,
    int WeeklyPlanTemplateId,
    PlanFulfillmentStatus FulfillmentStatus) : IRequest
{
}
