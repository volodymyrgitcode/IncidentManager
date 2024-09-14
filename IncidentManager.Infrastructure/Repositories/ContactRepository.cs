using IncidentManager.Application.Common.Interfaces.Repositories;
using IncidentManager.Domain.Entities;
using IncidentManager.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IncidentManager.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Contact?> GetByIdAsync(string id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task AddAsync(Contact entity)
    {
        await _context.Contacts.AddAsync(entity); 
    }

    public Task UpdateAsync(Contact entity)
    {
        _context.Contacts.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Contact entity)
    {
        _context.Contacts.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<Contact?> GetByEmailAsync(string email)
    {
        return await _context.Contacts.FirstOrDefaultAsync(c => c.Email == email);
    }
}
