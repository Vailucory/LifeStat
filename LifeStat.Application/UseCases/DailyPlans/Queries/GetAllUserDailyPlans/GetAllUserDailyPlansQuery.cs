using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetAllUserDailyPlans;
public record GetAllUserDailyPlansQuery(int UserId) : IQuery<List<DailyPlan>>
{
}
