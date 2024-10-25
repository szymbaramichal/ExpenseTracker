using System;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Infrastructure.Persistence;
using ExpenseTracker.Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories.ExpensesRepository;

public class ExpensesRepository(DataContext _dataContext) : BaseRepository<Expense>(_dataContext), IExpensesRepository
{
    public async Task<ICollection<Expense>> GetExpensesForFamily(int familyId)
    {
        return await _dataContext.Expenses.Include(x => x.User).Where(x => x.FamilyId == familyId).ToListAsync();
    }
}
