using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanRepository
{
    void Add(DailyPlan dailyPlan);

    Task<DailyPlan> GetByIdAsync(int id);

    Task<DailyPlan> GetByIdWithActivitiesAsync(int id);

    void Update(DailyPlan dailyPlan);

    void Remove(DailyPlan dailyPlan);
}
