using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlans;
public record GetWeeklyPlanQuery(int Id, int UserId) : IQuery<WeeklyPlan>
{
}
