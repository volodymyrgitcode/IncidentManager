using IncidentManager.Application.Common.Interfaces.Repositories;
using IncidentManager.Domain.Entities;
using IncidentManager.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IncidentManager.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Account?> GetByIdAsync(string id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await _context.Accounts
            .Include(a => a.Contacts)
            .ToListAsync();
    }

    public async Task AddAsync(Account entity)
    {
        await _context.Accounts.AddAsync(entity);
    }

    public Task UpdateAsync(Account entity)
    {
        _context.Accounts.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Account entity)
    {
        _context.Accounts.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<Account?> GetByNameAsync(string name)
    {
        return await _context.Accounts
            .Include(a => a.Contacts)
            .FirstOrDefaultAsync(a => a.Name == name);
    }
}
