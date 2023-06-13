using Domain.Models;
using LifeStat.Domain.Shared;
using LifeStat.Domain.ViewModels;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanTemplateRepository
{
    Result Add(string dailyPlanTemplateName, List<DailyPlanActivityDurationViewModel> activities, int userId);

    Task<Result<DailyPlanTemplate>> GetByIdAsync(int id, int userId);

    Task<Result<DailyPlanTemplate>> GetByIdWithDailyPlansAsync(int id, int userId);

    Task<Result<DailyPlanTemplate>> GetByIdWithActivityDurationsAsync(int id, int userId);

    Task<Result<List<DailyPlanTemplate>>> GetAllUserDailyPlanTemplatesAsync(int userId);

    Result Update(DailyPlanTemplate dailyPlanTemplate, int userId);

    Result Remove(DailyPlanTemplate dailyPlanTemplate, int userId);
}
