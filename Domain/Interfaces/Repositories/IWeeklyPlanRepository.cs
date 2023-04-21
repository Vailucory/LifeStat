using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanRepository
{
    void Add(WeeklyPlan weeklyPlan, int userId);

    Task<WeeklyPlan> GetByIdAsync(int id);

    Task<WeeklyPlan> GetByIdWithDailyPlansAsync(int id);

    Task<List<WeeklyPlan>> GetAllUserWeeklyPlansAsync(int userId);

    void Update(WeeklyPlan weeklyPlan);

    void Remove(WeeklyPlan weeklyPlan);
}

