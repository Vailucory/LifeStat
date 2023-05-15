using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanRepository
{
    Result Add(DailyPlan dailyPlan, int userId);

    Task<Result<DailyPlan>> GetByIdAsync(int id);

    Task<Result<DailyPlan>> GetByIdWithActivitiesAsync(int id);

    Task<Result<List<DailyPlan>>> GetAllUserDailyPlansAsync(int userId);

    Result Update(DailyPlan dailyPlan);

    Result Remove(DailyPlan dailyPlan);
}
