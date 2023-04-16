using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityTemplateRepository
{
    Task AddAsync(ActivityTemplate activityTemplate);

    Task<ActivityTemplate> GetByIdAsync(int id);

    Task<ActivityTemplate> GetByIdWithActivitiesAsync(int id);

    Task UpdateAsync(ActivityTemplate activityTemplate);

    Task RemoveAsync(ActivityTemplate activityTemplate);
}
