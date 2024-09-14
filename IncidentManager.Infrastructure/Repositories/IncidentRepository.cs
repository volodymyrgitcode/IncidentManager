using IncidentManager.Application.Common.Interfaces.Repositories;
using IncidentManager.Domain.Entities;
using IncidentManager.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IncidentManager.Infrastructure.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly ApplicationDbContext _context;

    public IncidentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Incident entity)
    {
        await _context.Incidents.AddAsync(entity);
    }

    public Task DeleteAsync(Incident entity)
    {
        _context.Incidents.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Incident>> GetAllAsync()
    {
        return await _context.Incidents
            .Include(i => i.Accounts)
                .ThenInclude(a => a.Contacts)
            .ToListAsync();
    }

    public async Task<Incident?> GetByIdAsync(string id)
    {
        return await _context.Incidents.FindAsync(id);
    }

    public async Task<Incident?> GetByIncidentNameAsync(string incidentName)
    {
        return await _context.Incidents
            .Include(i => i.Accounts)
                .ThenInclude(a => a.Contacts)
                .FirstOrDefaultAsync(i => i.IncidentName == incidentName);
    }

    public Task UpdateAsync(Incident entity)
    {
        _context.Incidents.Update(entity);
        return Task.CompletedTask;
    }
}
