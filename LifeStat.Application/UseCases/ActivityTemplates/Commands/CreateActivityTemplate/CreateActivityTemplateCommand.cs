using Domain.Enums;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.CreateActivityTemplate;
public record CreateActivityTemplateCommand(int UserId, string Name, ActivityType ActivityType) : IRequest
{
}
