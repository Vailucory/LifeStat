using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanTemplateRepository
{
    void Add(DailyPlanTemplate dailyPlanTemplate, int userId);

    Task<DailyPlanTemplate> GetByIdAsync(int id);

    Task<DailyPlanTemplate> GetByIdWithDailyPlansAsync(int id);

    Task<DailyPlanTemplate> GetByIdWithActivityDurationsAsync(int id);

    Task<List<DailyPlanTemplate>> GetAllUserDailyPlanTemplatesAsync(int userId);

    void Update(DailyPlanTemplate dailyPlanTemplate);

    void Remove(DailyPlanTemplate dailyPlanTemplate);
}
