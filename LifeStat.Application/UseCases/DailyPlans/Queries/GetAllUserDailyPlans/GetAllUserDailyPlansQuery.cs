using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetAllUserDailyPlans;
public record GetAllUserDailyPlansQuery(int UserId) : IRequest<List<DailyPlan>>
{
}
