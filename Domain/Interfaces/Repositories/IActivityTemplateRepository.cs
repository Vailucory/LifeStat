using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityTemplateRepository
{
    Result Add(ActivityTemplate activityTemplate, int userId);

    Task<Result<ActivityTemplate>> GetByIdAsync(int id);

    Task<Result<ActivityTemplate>> GetByIdWithActivitiesAsync(int id);

    Task<Result<List<ActivityTemplate>>> GetAllUserActivityTemplatesAsync(int userId);

    Result Update(ActivityTemplate activityTemplate);

    Result Remove(ActivityTemplate activityTemplate);
}
