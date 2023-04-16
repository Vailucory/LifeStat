using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanTemplateRepository
{
    Task AddAsync(DailyPlanTemplate dailyPlanTemplate);

    Task<DailyPlanTemplate> GetByIdAsync(int id);

    Task<DailyPlanTemplate> GetByIdWithDailyPlansAsync(int id);

    Task<DailyPlanTemplate> GetByIdWithActivityDurationsAsync(int id);

    Task UpdateAsync(DailyPlanTemplate dailyPlanTemplate);

    Task RemoveAsync(DailyPlanTemplate dailyPlanTemplate);
}
