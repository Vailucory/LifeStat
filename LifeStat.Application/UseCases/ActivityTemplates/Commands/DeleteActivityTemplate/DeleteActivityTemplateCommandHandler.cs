using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.DeleteActivityTemplate;
public class DeleteActivityTemplateCommandHandler : ICommandHandler<DeleteActivityTemplateCommand>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteActivityTemplateCommandHandler(IActivityTemplateRepository activityTemplateRepository, IUnitOfWork unitOfWork)
    {
        _activityTemplateRepository = activityTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteActivityTemplateCommand request, CancellationToken cancellationToken)
    {
        //TODO: Handle properly cascade deletion and do not allow to delete if template used in DailyPlan templates 
        return _activityTemplateRepository.Remove(new ActivityTemplate() { Id = request.ActivityTemplateId})
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
