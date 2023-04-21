using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Queries.GetWeeklyPlanTemplate;
public class GetWeeklyPlanTemplateQueryHandler : IRequestHandler<GetWeeklyPlanTemplateQuery, WeeklyPlanTemplate>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    public GetWeeklyPlanTemplateQueryHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
    }

    public async Task<WeeklyPlanTemplate> Handle(GetWeeklyPlanTemplateQuery request, CancellationToken cancellationToken)
    {
        return await _weeklyPlanTemplateRepository.GetByIdWithDailyPlanTemplatesAsync(request.Id);
    }
}
