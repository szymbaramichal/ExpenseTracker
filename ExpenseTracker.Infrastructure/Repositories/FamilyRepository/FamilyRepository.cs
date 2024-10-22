using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Enums;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories.FamilyRepository;

public class FamilyRepository(DataContext dataContext) : IFamilyRepository
{
    public async Task Create(Family family, int userId)
    {
        using var dbTransaction = await dataContext.Database.BeginTransactionAsync(); 

        try
        {
            await dataContext.Families.AddAsync(family);
            await dataContext.SaveChangesAsync();

            var userFamily = new UserFamily {
                FamilyId = family.Id,
                UserId = userId,
                FamilyRole = nameof(FamilyRoles.Owner)
            };

            await dataContext.UserFamilies.AddAsync(userFamily);
            await dataContext.SaveChangesAsync();
            await dbTransaction.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

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
