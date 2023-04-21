using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Queries.GetAllUserDailyPlanTemplates;
public class GetAllUserDailyPlanTemplatesQueryHandler : IRequestHandler<GetAllUserDailyPlanTemplatesQuery, List<DailyPlanTemplate>>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    public GetAllUserDailyPlanTemplatesQueryHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
    }

    public async Task<List<DailyPlanTemplate>> Handle(GetAllUserDailyPlanTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _dailyPlanTemplateRepository.GetAllUserDailyPlanTemplatesAsync(request.UserId);
    }
}
