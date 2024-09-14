using MediatR;

namespace IncidentManager.Application.Features.Incidents.Commands.UpdateIncident;

public record UpdateIncidentCommand : IRequest
{
    public string IncidentName { get; init; } = string.Empty;
    public string AccountName { get; init; } = string.Empty;
    public string ContactFirstName { get; init; } = string.Empty;
    public string ContactLastName { get; init; } = string.Empty;
    public string ContactEmail { get; init; } = string.Empty;
    public string IncidentDescription { get; init; } = string.Empty;
}