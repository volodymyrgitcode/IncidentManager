using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Incidents.Queries.GetIncident;

public class GetIncidentQueryHandler : IRequestHandler<GetIncidentQuery, IncidentDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetIncidentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IncidentDTO> Handle(GetIncidentQuery request, CancellationToken cancellationToken)
    {
        var incident = await _unitOfWork.IncidentRepository.GetByIncidentNameAsync(request.IncidentName) ?? throw new NotFoundException(nameof(Incident), request.IncidentName);

        return IncidentDTO.FromIncident(incident);
    }
}