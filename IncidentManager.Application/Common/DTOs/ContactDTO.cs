using IncidentManager.Domain.Entities;

namespace IncidentManager.Application.Common.DTOs;

public class ContactDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public static ContactDTO FromContact(Contact contact)
    {
        return new ContactDTO 
        {
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
        };
    }
}