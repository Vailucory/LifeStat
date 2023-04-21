using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetDailyPlan;
public record GetDailyPlanQuery(int Id) : IRequest<DailyPlan>
{
}
