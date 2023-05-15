using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.WeeklyPlans.Queries.GetAllUserWeeklyPlans;
public class GetAllUserWeeklyPlansQueryHandler : IQueryHandler<GetAllUserWeeklyPlansQuery, List<WeeklyPlan>>
{
    private readonly IWeeklyPlanRepository _weeklyPlanRepository;

    public GetAllUserWeeklyPlansQueryHandler(IWeeklyPlanRepository weeklyPlanRepository)
    {
        _weeklyPlanRepository = weeklyPlanRepository;
    }

    public async Task<Result<List<WeeklyPlan>>> Handle(GetAllUserWeeklyPlansQuery request, CancellationToken cancellationToken)
    {
        return await _weeklyPlanRepository.GetAllUserWeeklyPlansAsync(request.UserId);
    }
}
