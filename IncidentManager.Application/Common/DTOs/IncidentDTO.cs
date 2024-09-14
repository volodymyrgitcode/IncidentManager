using IncidentManager.Domain.Entities;

namespace IncidentManager.Application.Common.DTOs;

public class IncidentDTO
{
    public string IncidentName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<AccountDTO> Accounts { get; set; } = [];

    public static IncidentDTO FromIncident(Incident incident)
    {
        return new IncidentDTO
        {
            IncidentName = incident.IncidentName,
            Description = incident.Description,
            Accounts = incident.Accounts.Select(a => AccountDTO.FromAccount(a)).ToList()
        };
    }
}