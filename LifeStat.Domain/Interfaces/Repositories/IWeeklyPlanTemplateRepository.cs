using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanTemplateRepository
{
    Result Add(WeeklyPlanTemplate weeklyPlanTemplate, int userId);

    Task<Result<WeeklyPlanTemplate>> GetByIdAsync(int id, int userId);

    Task<Result<WeeklyPlanTemplate>> GetByIdWithDailyPlanTemplatesAsync(int id, int userId);

    Task<Result<List<WeeklyPlanTemplate>>> GetAllUserWeeklyPlanTemplatesAsync(int userId);

    Result Update(WeeklyPlanTemplate weeklyPlanTemplate, int userId);

    Result Remove(WeeklyPlanTemplate weeklyPlanTemplate, int userId);
}
