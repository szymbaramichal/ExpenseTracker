using System;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Persistence;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserFamily> UserFamilies { get; set; }
    
    public override int SaveChanges()
    {
        SetCreatedDate();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetCreatedDate();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetCreatedDate()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added && e.Entity is BaseEntity);

        foreach (var entry in entries)
        {
            ((BaseEntity)entry.Entity).CreatedDateUtc = DateTime.UtcNow;
        }
    }
}
