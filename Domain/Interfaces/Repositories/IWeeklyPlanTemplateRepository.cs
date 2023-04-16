using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanTemplateRepository
{
    void Add(WeeklyPlanTemplate weeklyPlanTemplate);

    Task<WeeklyPlanTemplate> GetByIdAsync(int id);

    Task<WeeklyPlanTemplate> GetByIdWithDailyPlanTemplatesAsync(int id);

    void Update(WeeklyPlanTemplate weeklyPlanTemplate);

    void Remove(WeeklyPlanTemplate weeklyPlanTemplate);
}
