using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanRepository
{
    Result Add(WeeklyPlan weeklyPlan, int userId);

    Task<Result<WeeklyPlan>> GetByIdAsync(int id);

    Task<Result<WeeklyPlan>> GetByIdWithDailyPlansAsync(int id);

    Task<Result<List<WeeklyPlan>>> GetAllUserWeeklyPlansAsync(int userId);

    Result Update(WeeklyPlan weeklyPlan);

    Result Remove(WeeklyPlan weeklyPlan);
}

