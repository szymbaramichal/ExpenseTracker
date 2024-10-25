using System;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Infrastructure.Repositories.BaseRepository;

namespace ExpenseTracker.Infrastructure.Repositories.ExpensesRepository;

public interface IExpensesRepository : IBaseRepository<Expense>
{
    Task<ICollection<Expense>> GetExpensesForFamily(int familyId);
}
