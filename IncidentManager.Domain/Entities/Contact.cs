namespace IncidentManager.Domain.Entities;

public class Contact
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string? AccountName { get; set; }
    public Account? Account { get; set; }
}