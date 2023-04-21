using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Queries.GetAllUserActivityTemplates;
public class GetAllUserActivityTemplatesQueryHandler : IRequestHandler<GetAllUserActivityTemplatesQuery, List<ActivityTemplate>>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    public GetAllUserActivityTemplatesQueryHandler(IActivityTemplateRepository activityTemplateRepository)
    {
        _activityTemplateRepository = activityTemplateRepository;
    }

    public async Task<List<ActivityTemplate>> Handle(GetAllUserActivityTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _activityTemplateRepository.GetAllUserActivityTemplatesAsync(request.UserId);
    }
}
