﻿using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Queries.GetDailyPlanTemplate;
public class GetDailyPlanTemplateQueryHandler : IQueryHandler<GetDailyPlanTemplateQuery, DailyPlanTemplate>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    public GetDailyPlanTemplateQueryHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
    }

    public async Task<Result<DailyPlanTemplate>> Handle(GetDailyPlanTemplateQuery request, CancellationToken cancellationToken)
    {
        return await _dailyPlanTemplateRepository.GetByIdAsync(request.Id);
    }
}
