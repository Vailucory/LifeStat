using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityTemplateRepository
{
    void Add(ActivityTemplate activityTemplate, int userId);

    Task<ActivityTemplate> GetByIdAsync(int id);

    Task<ActivityTemplate> GetByIdWithActivitiesAsync(int id);

    Task<List<ActivityTemplate>> GetAllUserActivityTemplatesAsync(int userId);

    void Update(ActivityTemplate activityTemplate);

    void Remove(ActivityTemplate activityTemplate);
}
