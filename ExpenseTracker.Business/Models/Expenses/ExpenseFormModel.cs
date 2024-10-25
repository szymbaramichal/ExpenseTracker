using System;

namespace ExpenseTracker.Business.Models.Expenses;

public class ExpenseFormModel
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Amount { get; set; }
    public int FamilyId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; } = 1;
}
