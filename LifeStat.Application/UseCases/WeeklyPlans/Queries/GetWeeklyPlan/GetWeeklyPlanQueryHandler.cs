using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlans.Queries.GetWeeklyPlan;
public class GetWeeklyPlanQueryHandler : IRequestHandler<GetWeeklyPlanQuery, WeeklyPlan>
{
    private readonly IWeeklyPlanRepository _weeklyPlanRepository;

    public GetWeeklyPlanQueryHandler(IWeeklyPlanRepository weeklyPlanRepository)
    {
        _weeklyPlanRepository = weeklyPlanRepository;
    }

    public async Task<WeeklyPlan> Handle(GetWeeklyPlanQuery request, CancellationToken cancellationToken)
    {
        return await _weeklyPlanRepository.GetByIdWithDailyPlansAsync(request.Id);
    }
}
