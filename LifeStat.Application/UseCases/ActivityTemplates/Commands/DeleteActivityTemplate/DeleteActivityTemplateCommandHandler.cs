using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.DeleteActivityTemplate;
public class DeleteActivityTemplateCommandHandler : IRequestHandler<DeleteActivityTemplateCommand>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteActivityTemplateCommandHandler(IActivityTemplateRepository activityTemplateRepository, IUnitOfWork unitOfWork)
    {
        _activityTemplateRepository = activityTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteActivityTemplateCommand request, CancellationToken cancellationToken)
    {
        //TODO: Handle properly cascade deletion and do not allow to delete if template used in DailyPlan templates 
        _activityTemplateRepository.Remove(new ActivityTemplate() { Id = request.ActivityTemplateId});

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
