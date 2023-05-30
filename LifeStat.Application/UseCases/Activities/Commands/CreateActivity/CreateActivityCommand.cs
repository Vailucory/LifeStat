using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Activities;
public record CreateActivityCommand(
    int UserId,
    int ActivityTemplateId,
    DateTime StartTimeUtc,
    DateTime EndTimeUtc,
    DateTime StartTimeLocal,
    DateTime EndTimeLocal
    ) : ICommand
{
}
