using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.Activities.Commands.CreateActivity;
public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand>
{
    private readonly IActivityRepository _activityRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateActivityCommandHandler(IActivityRepository activityRepository, IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = new Activity()
        {
             Template = new ActivityTemplate() { Id = request.ActivityTemplateId },
             StartTimeUtc = request.StartTimeUtc,
             EndTimeUtc = request.EndTimeUtc,
             StartTimeLocal = request.StartTimeLocal,
             EndTimeLocal = request.EndTimeUtcLocal
        };

        _activityRepository.Add(activity, request.UserId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
