using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.Activities.Queries.GetActivity;
public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, Activity>
{
    private readonly IActivityRepository _activityRepository;

    public GetActivityQueryHandler(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<Activity> Handle(GetActivityQuery request, CancellationToken cancellationToken)
    {
        return await _activityRepository.GetByIdAsync(request.Id);
    }
}
