using System;
using ExpenseTracker.Business.Models.Expenses;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Infrastructure.Repositories.ExpensesRepository;

namespace ExpenseTracker.Business.Services.ExpensesService;

public class ExpensesService(IExpensesRepository expensesRepository) : IExpensesService
{
    public async Task AddExpenseToFamily(ExpenseFormModel expenseFormData)
    {
        Expense expense = new() {
            Amount = expenseFormData.Amount,
            CategoryId = expenseFormData.CategoryId,
            CreatedDateUtc = DateTime.UtcNow,
            Description = expenseFormData.Description,
            FamilyId = expenseFormData.FamilyId,
            Name = expenseFormData.Name,
            UserId = expenseFormData.UserId
        };

        await expensesRepository.AddAsync(expense);
    }

    public async Task<ICollection<ExpenseViewModel>> GetExpensesForFamily(int familyId)
    {
        var expenses = await expensesRepository.GetExpensesForFamily(familyId);

        var listOfViewModels = new List<ExpenseViewModel>();

        foreach (var expense in expenses)
        {
            listOfViewModels.Add(new ExpenseViewModel {
                Amount = expense.Amount,
                Date = DateOnly.FromDateTime(expense.CreatedDateUtc),
                Item = expense.Name,
                UserName = expense.User.UserName
            });
        } 

        return listOfViewModels;
    }
}
