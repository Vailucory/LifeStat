using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanRepository
{
    void Add(DailyPlan dailyPlan, int userId);

    Task<DailyPlan> GetByIdAsync(int id);

    Task<DailyPlan> GetByIdWithActivitiesAsync(int id);

    Task<List<DailyPlan>> GetAllUserDailyPlansAsync(int userId);

    void Update(DailyPlan dailyPlan);

    void Remove(DailyPlan dailyPlan);
}
