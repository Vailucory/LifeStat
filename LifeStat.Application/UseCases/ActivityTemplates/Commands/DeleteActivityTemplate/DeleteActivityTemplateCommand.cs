using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.DeleteActivityTemplate;
public record DeleteActivityTemplateCommand(int ActivityTemplateId) : IRequest
{
}
