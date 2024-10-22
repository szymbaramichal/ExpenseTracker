using System;
using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Infrastructure.Repositories.FamilyRepository;

public interface IFamilyRepository
{
    Task<ICollection<(string, int)>> GetFamilyNamesAndIds(int userId);
    Task Create(Family family, int userId);
}
