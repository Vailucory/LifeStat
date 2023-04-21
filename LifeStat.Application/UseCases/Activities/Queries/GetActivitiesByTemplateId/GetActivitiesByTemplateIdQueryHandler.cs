using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.Activities.Queries.GetActivitiesByTemplateId;
public class GetActivitiesByTemplateIdQueryHandler : IRequestHandler<GetActivitiesByTemplateIdQuery, List<Activity>>
{
    private readonly IActivityRepository _activityRepository;

    public GetActivitiesByTemplateIdQueryHandler(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<List<Activity>> Handle(GetActivitiesByTemplateIdQuery request, CancellationToken cancellationToken)
    {
        return await _activityRepository.GetActivitiesByTemplateIdAsync(request.TemplateId);
    }
}
