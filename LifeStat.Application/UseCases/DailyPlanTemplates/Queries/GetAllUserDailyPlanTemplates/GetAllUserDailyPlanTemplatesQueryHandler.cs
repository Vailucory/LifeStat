using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public class GetAllUserDailyPlanTemplatesQueryHandler : IQueryHandler<GetAllUserDailyPlanTemplatesQuery, List<DailyPlanTemplate>>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    public GetAllUserDailyPlanTemplatesQueryHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
    }

    public async Task<Result<List<DailyPlanTemplate>>> Handle(GetAllUserDailyPlanTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _dailyPlanTemplateRepository.GetAllUserDailyPlanTemplatesAsync(request.UserId);
    }
}
