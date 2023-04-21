using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlans.Queries.GetAllUserWeeklyPlans;
public record GetAllUserWeeklyPlansQuery(int UserId) : IRequest<List<WeeklyPlan>>
{
}
