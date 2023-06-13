using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlans;
public record GetDailyPlanQuery(int Id, int UserId) : IQuery<DailyPlan>
{
}
