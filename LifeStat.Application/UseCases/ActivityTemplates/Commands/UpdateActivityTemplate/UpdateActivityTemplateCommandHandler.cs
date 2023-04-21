using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Commands.UpdateActivityTemplate;
public class UpdateActivityTemplateCommandHandler : IRequestHandler<UpdateActivityTemplateCommand>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateActivityTemplateCommandHandler(IActivityTemplateRepository activityTemplateRepository, IUnitOfWork unitOfWork)
    {
        _activityTemplateRepository = activityTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateActivityTemplateCommand request, CancellationToken cancellationToken)
    {
        _activityTemplateRepository.Update(request.ActivityTemplate);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
