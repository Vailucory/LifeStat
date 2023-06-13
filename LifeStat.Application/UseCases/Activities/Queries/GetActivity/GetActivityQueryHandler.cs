using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.Activities;
public class GetActivityQueryHandler : IQueryHandler<GetActivityQuery, Activity>
{
    private readonly IActivityRepository _activityRepository;

    public GetActivityQueryHandler(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<Result<Activity>> Handle(GetActivityQuery request, CancellationToken cancellationToken)
    {
        return await _activityRepository.GetByIdAsync(request.Id, request.UserId);
    }
}
