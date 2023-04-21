using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Queries.GetDailyPlanTemplate;
public class GetDailyPlanTemplateQueryHandler : IRequestHandler<GetDailyPlanTemplateQuery, DailyPlanTemplate>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    public GetDailyPlanTemplateQueryHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
    }

    public async Task<DailyPlanTemplate> Handle(GetDailyPlanTemplateQuery request, CancellationToken cancellationToken)
    {
        return await _dailyPlanTemplateRepository.GetByIdAsync(request.Id);
    }
}
