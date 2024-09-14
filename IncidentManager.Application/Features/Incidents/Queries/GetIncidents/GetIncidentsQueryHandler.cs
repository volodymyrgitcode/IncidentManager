using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Common.Interfaces;
using MediatR;

namespace IncidentManager.Application.Features.Incidents.Queries.GetIncidents;

public class GetIncidentsQueryHandler : IRequestHandler<GetIncidentsQuery, IEnumerable<IncidentDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetIncidentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<IncidentDTO>> Handle(GetIncidentsQuery request, CancellationToken cancellationToken)
    {
        var incidents = await _unitOfWork.IncidentRepository.GetAllAsync();

        return incidents.Select(IncidentDTO.FromIncident);
    }
}