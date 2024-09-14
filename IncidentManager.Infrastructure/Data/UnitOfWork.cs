using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Application.Common.Interfaces.Repositories;
using IncidentManager.Infrastructure.Data.Contexts;

namespace IncidentManager.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context,
        IAccountRepository accountRepository,
        IContactRepository contactRepository,
        IIncidentRepository incidentRepository)
    {
        _context = context;
        AccountRepository = accountRepository;
        ContactRepository = contactRepository;
        IncidentRepository = incidentRepository;
    }

    public IAccountRepository AccountRepository { get; }
    public IContactRepository ContactRepository { get; }
    public IIncidentRepository IncidentRepository { get; }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}