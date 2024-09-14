using IncidentManager.Domain.Entities;

namespace IncidentManager.Application.Common.DTOs;

public class AccountDTO
{
    public string Name { get; set; } = string.Empty;
    public List<ContactDTO> Contacts { get; set; } = [];

    public static AccountDTO FromAccount(Account account)
    {
        return new AccountDTO
        {
            Name = account.Name,
            Contacts = account.Contacts.Select(c => ContactDTO.FromContact(c)).ToList()
        };
    }
}
