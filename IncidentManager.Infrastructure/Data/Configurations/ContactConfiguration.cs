using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IncidentManager.Domain.Entities;

namespace IncidentManager.Infrastructure.Data.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> entity)
    {
        entity.HasKey(c => c.Email);
        entity.HasIndex(c => c.Email)
            .IsUnique();
    }
}
