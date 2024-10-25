using System;

namespace ExpenseTracker.Business.Models.Expenses;

public class ExpenseViewModel
{
    public string Item { get; set; }
    
    public decimal Amount { get; set; }
    
    public DateOnly Date { get; set; }
    
    public string UserName { get; set; }
}
