using System;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories.FamilyRepository;

public class FamilyRepository(DataContext dataContext) : IFamilyRepository
{
    public async Task<ICollection<(string, int)>> GetFamilyNamesAndIds(int userId)
    {
        var families = await dataContext.UserFamilies
            .Include(x => x.Family).Where(x => x.UserId == userId)
            .Select(x => new {
                Id = x.Family.Id,
                Name = x.Family.Name
            }).ToListAsync();
        
        return families.Select(x => (x.Name, x.Id)).ToList();
    }
}
