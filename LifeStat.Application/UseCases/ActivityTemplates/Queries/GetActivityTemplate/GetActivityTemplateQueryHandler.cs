using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public class GetActivityTemplateQueryHandler : IQueryHandler<GetActivityTemplateQuery, ActivityTemplate>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    public GetActivityTemplateQueryHandler(IActivityTemplateRepository activityTemplateRepository)
    {
        _activityTemplateRepository = activityTemplateRepository;
    }

    public async Task<Result<ActivityTemplate>> Handle(GetActivityTemplateQuery request, CancellationToken cancellationToken)
    {
        return await _activityTemplateRepository.GetByIdAsync(request.Id, request.UserId);
    }
}
