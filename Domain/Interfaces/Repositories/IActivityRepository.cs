using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityRepository
{
    void Add(Activity activity, int userId);

    Task<Activity> GetByIdAsync(int id);

    Task<List<Activity>> GetAllUserActivitiesAsync(int userId);

    Task<List<Activity>> GetAllUserActivitiesFromTimeAsync(int userId, DateTime fromTime);

    Task<List<Activity>> GetActivitiesByTemplateIdAsync(int templateId);

    void Update(Activity activity);

    void Remove(Activity activity);
}
