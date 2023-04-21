using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetDailyPlan;
public class GetDailyPlanQueryHandler : IRequestHandler<GetDailyPlanQuery, DailyPlan>
{
    private readonly IDailyPlanRepository _dailyPlanRepository;

    public GetDailyPlanQueryHandler(IDailyPlanRepository dailyPlanRepository)
    {
        _dailyPlanRepository = dailyPlanRepository;
    }

    public async Task<DailyPlan> Handle(GetDailyPlanQuery request, CancellationToken cancellationToken)
    {
        return await _dailyPlanRepository.GetByIdWithActivitiesAsync(request.Id);
    }
}
