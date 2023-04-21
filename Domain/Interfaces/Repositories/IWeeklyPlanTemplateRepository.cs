using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanTemplateRepository
{
    void Add(WeeklyPlanTemplate weeklyPlanTemplate, int userId);

    Task<WeeklyPlanTemplate> GetByIdAsync(int id);

    Task<WeeklyPlanTemplate> GetByIdWithDailyPlanTemplatesAsync(int id);

    Task<List<WeeklyPlanTemplate>> GetAllUserWeeklyPlanTemplatesAsync(int userId);

    void Update(WeeklyPlanTemplate weeklyPlanTemplate);

    void Remove(WeeklyPlanTemplate weeklyPlanTemplate);
}
