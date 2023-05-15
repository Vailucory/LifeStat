using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Queries.GetAllUserWeeklyPlanTemplates;
public class GetAllUserWeeklyPlanTemplatesQueryHandler : IQueryHandler<GetAllUserWeeklyPlanTemplatesQuery, List<WeeklyPlanTemplate>>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    public GetAllUserWeeklyPlanTemplatesQueryHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
    }

    public async Task<Result<List<WeeklyPlanTemplate>>> Handle(GetAllUserWeeklyPlanTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _weeklyPlanTemplateRepository.GetAllUserWeeklyPlanTemplatesAsync(request.UserId);
    }
}
