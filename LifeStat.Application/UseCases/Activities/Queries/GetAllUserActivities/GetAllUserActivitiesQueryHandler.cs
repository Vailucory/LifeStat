using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.Activities.Queries.GetAllUserActivities;
public class GetAllUserActivitiesQueryHandler : IRequestHandler<GetAllUserActivitiesQuery, List<Activity>>
{
    private readonly IActivityRepository _activityRepository;

    public GetAllUserActivitiesQueryHandler(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<List<Activity>> Handle(GetAllUserActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await _activityRepository.GetAllUserActivitiesAsync(request.UserId);
    }
}
