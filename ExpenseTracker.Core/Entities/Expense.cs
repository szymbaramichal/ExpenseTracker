using System.Drawing;
using ExpenseTracker.Core.Shared;

namespace ExpenseTracker.Core.Entities;

public class Expense : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Amount { get; set; }
    
    public int FamilyId { get; set; }
    public Family Family { get; set; } = default!;
    
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
