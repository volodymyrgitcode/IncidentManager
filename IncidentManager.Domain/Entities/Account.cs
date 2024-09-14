namespace IncidentManager.Domain.Entities;

public class Account
{
    public string Name { get; set; } = string.Empty;
    public List<Contact> Contacts { get; set; } = [];

    public string? IncidentName { get; set; }
    public Incident? Incident { get; set; }
}