using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetDailyPlan;
public record GetDailyPlanQuery(int Id) : IQuery<DailyPlan>
{
}
