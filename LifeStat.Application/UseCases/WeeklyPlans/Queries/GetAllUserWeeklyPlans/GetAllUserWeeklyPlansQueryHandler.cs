using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlans.Queries.GetAllUserWeeklyPlans;
public class GetAllUserWeeklyPlansQueryHandler : IRequestHandler<GetAllUserWeeklyPlansQuery, List<WeeklyPlan>>
{
    private readonly IWeeklyPlanRepository _weeklyPlanRepository;

    public GetAllUserWeeklyPlansQueryHandler(IWeeklyPlanRepository weeklyPlanRepository)
    {
        _weeklyPlanRepository = weeklyPlanRepository;
    }

    public async Task<List<WeeklyPlan>> Handle(GetAllUserWeeklyPlansQuery request, CancellationToken cancellationToken)
    {
        return await _weeklyPlanRepository.GetAllUserWeeklyPlansAsync(request.UserId);
    }
}
