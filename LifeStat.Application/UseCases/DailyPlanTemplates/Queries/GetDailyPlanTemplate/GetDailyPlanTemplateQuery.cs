using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public record GetDailyPlanTemplateQuery(int Id) : IQuery<DailyPlanTemplate>
{
}
