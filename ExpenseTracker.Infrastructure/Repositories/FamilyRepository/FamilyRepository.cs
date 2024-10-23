using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Enums;
using ExpenseTracker.Infrastructure.Persistence;
using ExpenseTracker.Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories.FamilyRepository;

public class FamilyRepository(DataContext _dataContext) : BaseRepository<Family>(_dataContext), IFamilyRepository
{
    public async Task AddUserToFamily(UserFamily userFamily)
    {
        await _dataContext.UserFamilies.AddAsync(userFamily);
        await _dataContext.SaveChangesAsync();
    }

    public async Task CreateFamily(Family family, int userId)
    {
        using var dbTransaction = await _dataContext.Database.BeginTransactionAsync(); 

        try
        {
            await _dataContext.Families.AddAsync(family);
            await _dataContext.SaveChangesAsync();

            var userFamily = new UserFamily {
                FamilyId = family.Id,
                UserId = userId,
                FamilyRole = nameof(FamilyRoles.Owner)
            };

            await _dataContext.UserFamilies.AddAsync(userFamily);
            await _dataContext.SaveChangesAsync();
            await dbTransaction.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ICollection<(string, int)>> GetFamilyNamesAndIds(int userId)
    {
        var families = await _dataContext.UserFamilies
            .Include(x => x.Family).Where(x => x.UserId == userId)
            .Select(x => new {
                Id = x.Family.Id,
                Name = x.Family.Name
            }).ToListAsync();
        
        return families.Select(x => (x.Name, x.Id)).ToList();
    }

    public async Task<Family> GetFamilyWithUserIds(int familyId)
    {
        return await _dataContext.Families.Include(x => x.UserFamilies)
            .ThenInclude(x => x.User).AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Id == familyId);
    }

    public async Task<UserFamily> GetUserInfoForFamily(int familyId, int userId)
    {
        return await _dataContext.UserFamilies
            .FirstOrDefaultAsync(x => x.FamilyId == familyId && x.UserId == userId);
    }

    public async Task RemoveUserFromFamily(UserFamily userFamily)
    {
        _dataContext.Remove(userFamily);
        await _dataContext.SaveChangesAsync(); 
    }
}
