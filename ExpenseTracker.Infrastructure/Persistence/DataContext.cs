using System;
using ExpenseTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Persistence;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserFamily> UserFamilies { get; set; }
    
    
}
