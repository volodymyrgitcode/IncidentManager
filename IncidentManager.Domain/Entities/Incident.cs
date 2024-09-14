namespace IncidentManager.Domain.Entities;

public class Incident
{
    public string IncidentName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Account> Accounts { get; set; } = [];
}
