using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.UpdateActivityTemplate;
public record UpdateActivityTemplateCommand(ActivityTemplate ActivityTemplate) : ICommand
{
}
