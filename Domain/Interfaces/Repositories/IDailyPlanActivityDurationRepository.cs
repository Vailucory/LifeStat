using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanActivityDurationRepository
{
    Result Add(DailyPlanActivityDuration dailyPlanActivityDuration);

    Result AddRange(IEnumerable<DailyPlanActivityDuration> dailyPlanActivityDurations);

    Task<Result<DailyPlanActivityDuration>> GetByIdAsync(int id);

    Result Update(DailyPlanActivityDuration dailyPlanActivityDuration);

    Result Remove(DailyPlanActivityDuration dailyPlanActivityDuration);
}
