using System;
using ExpenseTracker.Business.Models.Expenses;

namespace ExpenseTracker.Business.Services.ExpensesService;

public interface IExpensesService
{
    Task<ICollection<ExpenseViewModel>> GetExpensesForFamily(int familyId);
    Task AddExpenseToFamily(ExpenseFormModel expenseFormData);
}
