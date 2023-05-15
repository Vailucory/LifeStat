using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetDailyPlan;
public class GetDailyPlanQueryHandler : IQueryHandler<GetDailyPlanQuery, DailyPlan>
{
    private readonly IDailyPlanRepository _dailyPlanRepository;

    public GetDailyPlanQueryHandler(IDailyPlanRepository dailyPlanRepository)
    {
        _dailyPlanRepository = dailyPlanRepository;
    }

    public async Task<Result<DailyPlan>> Handle(GetDailyPlanQuery request, CancellationToken cancellationToken)
    {
        return await _dailyPlanRepository.GetByIdWithActivitiesAsync(request.Id);
    }
}
