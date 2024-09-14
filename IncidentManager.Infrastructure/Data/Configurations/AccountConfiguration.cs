using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IncidentManager.Domain.Entities;
using System.Reflection.Emit;

namespace IncidentManager.Infrastructure.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> entity)
    {
        entity.HasKey(a => a.Name);
        entity.HasIndex(a => a.Name)
            .IsUnique();

        entity.HasMany(a => a.Contacts)
            .WithOne(c => c.Account)
            .HasForeignKey(c => c.AccountName)
            .OnDelete(DeleteBehavior.SetNull);
    }
}