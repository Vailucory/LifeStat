using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlans.Queries.GetWeeklyPlan;
public record GetWeeklyPlanQuery(int Id) : IRequest<WeeklyPlan>
{
}
