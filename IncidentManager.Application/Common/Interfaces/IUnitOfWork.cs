using IncidentManager.Application.Common.Interfaces.Repositories;

namespace IncidentManager.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IAccountRepository AccountRepository { get; }
    IContactRepository ContactRepository { get; }
    IIncidentRepository IncidentRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
