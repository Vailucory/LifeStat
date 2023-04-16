using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityTemplateRepository
{
    void Add(ActivityTemplate activityTemplate);

    Task<ActivityTemplate> GetByIdAsync(int id);

    Task<ActivityTemplate> GetByIdWithActivitiesAsync(int id);

    void Update(ActivityTemplate activityTemplate);

    void Remove(ActivityTemplate activityTemplate);
}
