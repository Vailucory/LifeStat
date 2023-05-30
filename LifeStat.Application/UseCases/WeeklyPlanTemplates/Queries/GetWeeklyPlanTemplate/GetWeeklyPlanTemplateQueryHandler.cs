using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public class GetWeeklyPlanTemplateQueryHandler : IQueryHandler<GetWeeklyPlanTemplateQuery, WeeklyPlanTemplate>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    public GetWeeklyPlanTemplateQueryHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
    }

    public async Task<Result<WeeklyPlanTemplate>> Handle(GetWeeklyPlanTemplateQuery request, CancellationToken cancellationToken)
    {
        return await _weeklyPlanTemplateRepository.GetByIdWithDailyPlanTemplatesAsync(request.Id);
    }
}
