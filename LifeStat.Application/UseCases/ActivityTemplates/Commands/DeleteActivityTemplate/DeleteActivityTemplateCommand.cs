using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public record DeleteActivityTemplateCommand(int ActivityTemplateId) : ICommand
{
}
