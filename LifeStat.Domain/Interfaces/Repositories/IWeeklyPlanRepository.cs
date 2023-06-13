using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanRepository
{
    Result Add(WeeklyPlan weeklyPlan, int userId);

    Task<Result<WeeklyPlan>> GetByIdAsync(int id, int userId);

    Task<Result<WeeklyPlan>> GetByIdWithDailyPlansAsync(int id, int userId);

    Task<Result<List<WeeklyPlan>>> GetAllUserWeeklyPlansAsync(int userId);

    Result Update(WeeklyPlan weeklyPlan, int userId);

    Result Remove(WeeklyPlan weeklyPlan, int userId);
}

