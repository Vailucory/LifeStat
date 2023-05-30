using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public record UpdateActivityTemplateCommand(ActivityTemplate ActivityTemplate) : ICommand
{
}
