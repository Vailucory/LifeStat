using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanRepository
{
    void Add(WeeklyPlan weeklyPlan);

    Task<WeeklyPlan> GetByIdAsync(int id);

    Task<WeeklyPlan> GetByIdWithDailyPlansAsync(int id);

    void Update(WeeklyPlan weeklyPlan);

    void Remove(WeeklyPlan weeklyPlan);
}

