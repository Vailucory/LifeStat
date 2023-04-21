using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Queries.GetAllUserWeeklyPlanTemplates;
public class GetAllUserWeeklyPlanTemplatesQueryHandler : IRequestHandler<GetAllUserWeeklyPlanTemplatesQuery, List<WeeklyPlanTemplate>>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    public GetAllUserWeeklyPlanTemplatesQueryHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
    }

    public async Task<List<WeeklyPlanTemplate>> Handle(GetAllUserWeeklyPlanTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _weeklyPlanTemplateRepository.GetAllUserWeeklyPlanTemplatesAsync(request.UserId);
    }
}
