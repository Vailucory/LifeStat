using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.UpdateActivityTemplate;
public record UpdateActivityTemplateCommand(ActivityTemplate ActivityTemplate) : IRequest
{
}
