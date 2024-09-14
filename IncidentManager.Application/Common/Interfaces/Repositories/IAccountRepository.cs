using IncidentManager.Domain.Entities;

namespace IncidentManager.Application.Common.Interfaces.Repositories;

public interface IAccountRepository : IRepository<Account, string>
{
    Task<Account?> GetByNameAsync(string name);
}
