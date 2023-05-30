using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlans;
public record GetAllUserWeeklyPlansQuery(int UserId) : IQuery<List<WeeklyPlan>>
{
}
