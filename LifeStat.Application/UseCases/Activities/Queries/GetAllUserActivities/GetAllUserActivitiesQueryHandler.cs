using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.Activities;
public class GetAllUserActivitiesQueryHandler : IQueryHandler<GetAllUserActivitiesQuery, List<Activity>>
{
    private readonly IActivityRepository _activityRepository;

    public GetAllUserActivitiesQueryHandler(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<Result<List<Activity>>> Handle(GetAllUserActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await _activityRepository.GetAllUserActivitiesAsync(request.UserId);
    }
}
