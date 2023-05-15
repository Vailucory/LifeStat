using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.ActivityTemplates.Queries.GetAllUserActivityTemplates;
public class GetAllUserActivityTemplatesQueryHandler : IQueryHandler<GetAllUserActivityTemplatesQuery, List<ActivityTemplate>>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    public GetAllUserActivityTemplatesQueryHandler(IActivityTemplateRepository activityTemplateRepository)
    {
        _activityTemplateRepository = activityTemplateRepository;
    }

    public async Task<Result<List<ActivityTemplate>>> Handle(GetAllUserActivityTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _activityTemplateRepository.GetAllUserActivityTemplatesAsync(request.UserId);
    }
}
