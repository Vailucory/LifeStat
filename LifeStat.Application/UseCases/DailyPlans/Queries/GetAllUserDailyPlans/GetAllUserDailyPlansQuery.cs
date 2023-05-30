using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlans;
public record GetAllUserDailyPlansQuery(int UserId) : IQuery<List<DailyPlan>>
{
}
