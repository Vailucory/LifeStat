using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.WeeklyPlans;
public class GetWeeklyPlanQueryHandler : IQueryHandler<GetWeeklyPlanQuery, WeeklyPlan>
{
    private readonly IWeeklyPlanRepository _weeklyPlanRepository;

    public GetWeeklyPlanQueryHandler(IWeeklyPlanRepository weeklyPlanRepository)
    {
        _weeklyPlanRepository = weeklyPlanRepository;
    }

    public async Task<Result<WeeklyPlan>> Handle(GetWeeklyPlanQuery request, CancellationToken cancellationToken)
    {
        return await _weeklyPlanRepository.GetByIdWithDailyPlansAsync(request.Id, request.UserId);
    }
}
