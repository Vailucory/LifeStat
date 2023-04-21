using MediatR;

namespace LifeStat.Application.UseCases.Activities.Commands.CreateActivity;
public record CreateActivityCommand(
    int UserId,
    int ActivityTemplateId,
    DateTime StartTimeUtc,
    DateTime EndTimeUtc,
    DateTime StartTimeLocal,
    DateTime EndTimeUtcLocal
    ) : IRequest
{
}
