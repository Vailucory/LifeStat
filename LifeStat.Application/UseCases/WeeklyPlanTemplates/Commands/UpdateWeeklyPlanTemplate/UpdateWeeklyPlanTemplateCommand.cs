using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.UpdateWeeklyPlanTemplate;
public record UpdateWeeklyPlanTemplateCommand(WeeklyPlanTemplate WeeklyPlanTemplate) : ICommand
{
}
