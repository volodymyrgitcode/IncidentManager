using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Incidents.Commands.DeleteIncident;

public class DeleteIncidentCommandHandler : IRequestHandler<DeleteIncidentCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIncidentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteIncidentCommand request, CancellationToken cancellationToken)
    {
        var incident = await _unitOfWork.IncidentRepository.GetByIdAsync(request.IncidentName) ?? throw new NotFoundException(nameof(Incident), request.IncidentName);

        await _unitOfWork.IncidentRepository.DeleteAsync(incident);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}