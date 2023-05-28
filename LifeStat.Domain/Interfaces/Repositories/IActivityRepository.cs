using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityRepository
{
    Result Add(Activity activity, int userId);

    Task<Result<Activity>> GetByIdAsync(int id);

    Task<Result<List<Activity>>> GetAllUserActivitiesAsync(int userId);

    Task<Result<List<Activity>>> GetAllUserActivitiesFromTimeAsync(int userId, DateTime fromTime);

    Task<Result<List<Activity>>> GetActivitiesByTemplateIdAsync(int templateId);

    Result Update(Activity activity);

    Result Remove(Activity activity);
}
