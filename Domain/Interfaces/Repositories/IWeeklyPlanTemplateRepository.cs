using Domain.Models;
using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IWeeklyPlanTemplateRepository
{
    Result Add(WeeklyPlanTemplate weeklyPlanTemplate, int userId);

    Task<Result<WeeklyPlanTemplate>> GetByIdAsync(int id);

    Task<Result<WeeklyPlanTemplate>> GetByIdWithDailyPlanTemplatesAsync(int id);

    Task<Result<List<WeeklyPlanTemplate>>> GetAllUserWeeklyPlanTemplatesAsync(int userId);

    Result Update(WeeklyPlanTemplate weeklyPlanTemplate);

    Result Remove(WeeklyPlanTemplate weeklyPlanTemplate);
}
