using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlans.Queries.GetAllUserDailyPlans;
public class GetAllUserDailyPlansQueryHandler : IRequestHandler<GetAllUserDailyPlansQuery, List<DailyPlan>>
{
    private readonly IDailyPlanRepository _dailyPlanRepository;

    public GetAllUserDailyPlansQueryHandler(IDailyPlanRepository dailyPlanRepository)
    {
        _dailyPlanRepository = dailyPlanRepository;
    }

    public async Task<List<DailyPlan>> Handle(GetAllUserDailyPlansQuery request, CancellationToken cancellationToken)
    {
        return await _dailyPlanRepository.GetAllUserDailyPlansAsync(request.UserId);
    }
}
