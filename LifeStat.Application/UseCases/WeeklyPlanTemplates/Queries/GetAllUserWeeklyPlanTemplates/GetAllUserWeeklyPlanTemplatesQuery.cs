using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public record GetAllUserWeeklyPlanTemplatesQuery(int UserId) : IQuery<List<WeeklyPlanTemplate>>
{
}
