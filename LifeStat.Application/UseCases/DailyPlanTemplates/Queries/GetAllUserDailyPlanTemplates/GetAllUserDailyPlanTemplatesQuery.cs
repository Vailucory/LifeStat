using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public record GetAllUserDailyPlanTemplatesQuery(int UserId) : IQuery<List<DailyPlanTemplate>>
{
}
