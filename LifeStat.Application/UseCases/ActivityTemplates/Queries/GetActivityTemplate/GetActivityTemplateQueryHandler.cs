using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Queries.GetActivityTemplate;
public class GetActivityTemplateQueryhandler : IRequestHandler<GetActivityTemplateQuery, ActivityTemplate>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    public GetActivityTemplateQueryhandler(IActivityTemplateRepository activityTemplateRepository)
    {
        _activityTemplateRepository = activityTemplateRepository;
    }

    public async Task<ActivityTemplate> Handle(GetActivityTemplateQuery request, CancellationToken cancellationToken)
    {
        return await _activityTemplateRepository.GetByIdAsync(request.Id);
    }
}
