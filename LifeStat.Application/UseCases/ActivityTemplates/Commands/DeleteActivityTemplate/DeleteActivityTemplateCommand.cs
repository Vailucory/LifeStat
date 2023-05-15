using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.DeleteActivityTemplate;
public record DeleteActivityTemplateCommand(int ActivityTemplateId) : ICommand
{
}
