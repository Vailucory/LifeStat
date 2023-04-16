using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanTemplateRepository
{
    Task AddAsync(WeeklyPlanTemplate weeklyPlanTemplate);

    Task<WeeklyPlanTemplate> GetByIdAsync(int id);

    Task<WeeklyPlanTemplate> GetByIdWithActivitiesAsync(int id);

    Task UpdateAsync(WeeklyPlanTemplate weeklyPlanTemplate);

    Task RemoveAsync(WeeklyPlanTemplate weeklyPlanTemplate);
}
