using Domain.Enums;
using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlans.Commands.CreateDailyPlan;
public record CreateDailyPlanCommand(
    int UserId,
    int DailyPlanTemplateId,
    PlanFulfillmentStatus FulfillmentStatus,
    DateTime DailyPlanStart ) : IRequest
{
}
