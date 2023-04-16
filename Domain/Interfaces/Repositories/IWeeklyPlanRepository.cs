using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanRepository
{
    Task AddAsync(WeeklyPlan weeklyPlan);

    Task<WeeklyPlan> GetByIdAsync(int id);

    Task<WeeklyPlan> GetByIdWithDailyPlansAsync(int id);

    Task UpdateAsync(WeeklyPlan weeklyPlan);

    Task RemoveAsync(WeeklyPlan weeklyPlan);
}

