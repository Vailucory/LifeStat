using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.Activities;
public class CreateActivityCommandHandler : ICommandHandler<CreateActivityCommand>
{
    private readonly IActivityRepository _activityRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateActivityCommandHandler(IActivityRepository activityRepository, IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = new Activity()
        {
             Template = new ActivityTemplate() { Id = request.ActivityTemplateId },
             StartTimeUtc = request.StartTimeUtc,
             EndTimeUtc = request.EndTimeUtc,
             StartTimeLocal = request.StartTimeLocal,
             EndTimeLocal = request.EndTimeLocal
        };

        return _activityRepository.Add(activity, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
