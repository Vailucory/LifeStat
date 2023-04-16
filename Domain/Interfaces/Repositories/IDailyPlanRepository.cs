using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanRepository
{
    Task AddAsync(DailyPlan dailyPlan);

    Task<DailyPlan> GetByIdAsync(int id);

    Task<DailyPlan> GetByIdWithActivitiesAsync(int id);

    Task UpdateAsync(DailyPlan dailyPlan);

    Task RemoveAsync(DailyPlan dailyPlan);
}
