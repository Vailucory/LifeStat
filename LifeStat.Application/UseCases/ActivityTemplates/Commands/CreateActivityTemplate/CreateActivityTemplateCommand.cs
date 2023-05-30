using Domain.Enums;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public record CreateActivityTemplateCommand(int UserId, string Name, ActivityType ActivityType) : ICommand
{
}
