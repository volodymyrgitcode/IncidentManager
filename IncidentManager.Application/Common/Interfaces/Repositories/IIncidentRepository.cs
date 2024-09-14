using IncidentManager.Domain.Entities;

namespace IncidentManager.Application.Common.Interfaces.Repositories;

public interface IIncidentRepository : IRepository<Incident, string>
{
    Task<Incident?> GetByIncidentNameAsync(string incidentName);
}