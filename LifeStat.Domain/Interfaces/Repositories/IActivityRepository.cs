using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityRepository
{
    Result Add(Activity activity, int userId);

    Task<Result<Activity>> GetByIdAsync(int id, int userId);

    Task<Result<List<Activity>>> GetAllUserActivitiesAsync(int userId);

    Task<Result<List<Activity>>> GetAllUserActivitiesFromTimeAsync(int userId, DateTime fromTime);

    Task<Result<List<Activity>>> GetActivitiesByTemplateIdAsync(int templateId, int userId);

    Result Update(Activity activity, int userId);

    Result Remove(Activity activity, int userId);
}
