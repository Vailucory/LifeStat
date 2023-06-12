using Domain.Models;
using LifeStat.Domain.Shared;
using LifeStat.Domain.ViewModels;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IDailyPlanTemplateRepository
{
    Result Add(string dailyPlanTemplateName, List<DailyPlanActivityDurationViewModel> activities, int userId);

    Task<Result<DailyPlanTemplate>> GetByIdAsync(int id);

    Task<Result<DailyPlanTemplate>> GetByIdWithDailyPlansAsync(int id);

    Task<Result<DailyPlanTemplate>> GetByIdWithActivityDurationsAsync(int id);

    Task<Result<List<DailyPlanTemplate>>> GetAllUserDailyPlanTemplatesAsync(int userId);

    Result Update(DailyPlanTemplate dailyPlanTemplate);

    Result Remove(DailyPlanTemplate dailyPlanTemplate);
}
