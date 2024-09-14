using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IncidentManager.Domain.Entities;

namespace IncidentManager.Infrastructure.Data.Configurations;

public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> entity)
    {
        entity.HasKey(i => i.IncidentName);
        entity.Property(i => i.IncidentName)
            .ValueGeneratedOnAdd();

        entity.HasMany(i => i.Accounts)
           .WithOne(a => a.Incident)
           .HasForeignKey(a => a.IncidentName)
           .OnDelete(DeleteBehavior.SetNull);
    }
}