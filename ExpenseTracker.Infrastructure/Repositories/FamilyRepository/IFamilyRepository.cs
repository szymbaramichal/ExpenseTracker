using System;

namespace ExpenseTracker.Infrastructure.Repositories.FamilyRepository;

public interface IFamilyRepository
{
    Task<ICollection<(string, int)>> GetFamilyNamesAndIds(int userId);
}
