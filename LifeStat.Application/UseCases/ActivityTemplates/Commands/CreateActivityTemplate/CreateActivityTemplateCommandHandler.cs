using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.CreateActivityTemplate;
public class CreateActivityTemplateCommandHandler : IRequestHandler<CreateActivityTemplateCommand>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateActivityTemplateCommandHandler(IActivityTemplateRepository activityTemplateRepository, IUnitOfWork unitOfWork)
    {
        _activityTemplateRepository = activityTemplateRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateActivityTemplateCommand request, CancellationToken cancellationToken)
    {
        var activityTemplate = new ActivityTemplate() { 
            
            Name = request.Name, 
            Type = request.ActivityType 
        };

        _activityTemplateRepository.Add(activityTemplate, request.UserId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
