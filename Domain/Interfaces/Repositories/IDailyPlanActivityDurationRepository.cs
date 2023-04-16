using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanActivityDurationRepository
{
    Task AddAsync(DailyPlanActivityDuration dailyPlanActivityDuration);

    Task AddRangeAsync(IEnumerable<DailyPlanActivityDuration> dailyPlanActivityDurations);

    Task<DailyPlanActivityDuration> GetByIdAsync(int id);

    Task UpdateAsync(DailyPlanActivityDuration dailyPlanActivityDuration);

    Task RemoveAsync(DailyPlanActivityDuration dailyPlanActivityDuration);
}
