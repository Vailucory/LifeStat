using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanActivityDurationRepository
{
    Result Add(DailyPlanActivityDuration dailyPlanActivityDuration, int userId);

    Task<Result<DailyPlanActivityDuration>> GetByIdAsync(int id, int userId);

    Result Update(DailyPlanActivityDuration dailyPlanActivityDuration, int userId);

    Result Remove(DailyPlanActivityDuration dailyPlanActivityDuration, int userId);
}
