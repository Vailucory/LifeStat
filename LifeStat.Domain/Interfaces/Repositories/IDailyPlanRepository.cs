using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanRepository
{
    Result Add(DailyPlan dailyPlan, int userId);

    Task<Result<DailyPlan>> GetByIdAsync(int id, int userId);

    Task<Result<DailyPlan>> GetByIdWithActivitiesAsync(int id, int userId);

    Task<Result<List<DailyPlan>>> GetAllUserDailyPlansAsync(int userId);

    Result Update(DailyPlan dailyPlan, int userId);

    Result Remove(DailyPlan dailyPlan, int userId);
}
