using MediatR;

namespace IncidentManager.Application.Features.Incidents.Commands.AddIncident;

public record AddIncidentCommand : IRequest
{
    public string AccountName { get; set; } = string.Empty;
    public string ContactFirstName { get; set; } = string.Empty;
    public string ContactLastName { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public string IncidentDescription { get; set; } = string.Empty;
}