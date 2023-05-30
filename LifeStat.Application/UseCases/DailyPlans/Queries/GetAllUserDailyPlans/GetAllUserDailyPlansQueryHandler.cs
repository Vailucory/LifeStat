using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.DailyPlans;
public class GetAllUserDailyPlansQueryHandler : IQueryHandler<GetAllUserDailyPlansQuery, List<DailyPlan>>
{
    private readonly IDailyPlanRepository _dailyPlanRepository;

    public GetAllUserDailyPlansQueryHandler(IDailyPlanRepository dailyPlanRepository)
    {
        _dailyPlanRepository = dailyPlanRepository;
    }

    public async Task<Result<List<DailyPlan>>> Handle(GetAllUserDailyPlansQuery request, CancellationToken cancellationToken)
    {
        return await _dailyPlanRepository.GetAllUserDailyPlansAsync(request.UserId);
    }
}
