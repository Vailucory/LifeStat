using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlans.Queries.GetAllUserWeeklyPlans;
public record GetAllUserWeeklyPlansQuery(int UserId) : IQuery<List<WeeklyPlan>>
{
}
