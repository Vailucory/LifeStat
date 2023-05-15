using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.Activities.Queries.GetActivitiesByTemplateId;
public class GetActivitiesByTemplateIdQueryHandler : IQueryHandler<GetActivitiesByTemplateIdQuery, List<Activity>>
{
    private readonly IActivityRepository _activityRepository;

    public GetActivitiesByTemplateIdQueryHandler(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<Result<List<Activity>>> Handle(GetActivitiesByTemplateIdQuery request, CancellationToken cancellationToken)
    {
        return await _activityRepository.GetActivitiesByTemplateIdAsync(request.TemplateId);
    }
}
