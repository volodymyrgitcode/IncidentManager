using IncidentManager.Application.Common.DTOs;
using MediatR;

namespace IncidentManager.Application.Features.Incidents.Queries.GetIncident;

public record GetIncidentQuery : IRequest<IncidentDTO>
{
    public required string IncidentName { get; init; }
}