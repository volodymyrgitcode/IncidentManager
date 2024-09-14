using IncidentManager.Application.Common.DTOs;
using MediatR;

namespace IncidentManager.Application.Features.Incidents.Queries.GetIncidents;

public record GetIncidentsQuery : IRequest<IEnumerable<IncidentDTO>>
{
}
