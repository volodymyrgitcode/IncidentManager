using IncidentManager.Domain.Entities;

namespace IncidentManager.Application.Common.Interfaces.Repositories;

public interface IContactRepository : IRepository<Contact, string>
{
    Task<Contact?> GetByEmailAsync(string email);
}
