using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanActivityDurationRepository
{
    void Add(DailyPlanActivityDuration dailyPlanActivityDuration);

    void AddRange(IEnumerable<DailyPlanActivityDuration> dailyPlanActivityDurations);

    Task<DailyPlanActivityDuration> GetByIdAsync(int id);

    void Update(DailyPlanActivityDuration dailyPlanActivityDuration);

    void Remove(DailyPlanActivityDuration dailyPlanActivityDuration);
}
