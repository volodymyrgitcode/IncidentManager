using MediatR;

namespace IncidentManager.Application.Features.Incidents.Commands.DeleteIncident;

public record DeleteIncidentCommand : IRequest
{
    public required string IncidentName { get; init; }
}