using Domain.Enums;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.CreateActivityTemplate;
public record CreateActivityTemplateCommand(int UserId, string Name, ActivityType ActivityType) : ICommand
{
}
