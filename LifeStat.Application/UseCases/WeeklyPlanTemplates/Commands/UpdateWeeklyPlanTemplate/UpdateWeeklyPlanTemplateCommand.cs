using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public record UpdateWeeklyPlanTemplateCommand(WeeklyPlanTemplate WeeklyPlanTemplate, int UserId) : ICommand
{
}
