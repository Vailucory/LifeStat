using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Queries.GetWeeklyPlanTemplate;
public record GetWeeklyPlanTemplateQuery(int Id) : IQuery<WeeklyPlanTemplate>
{
}
