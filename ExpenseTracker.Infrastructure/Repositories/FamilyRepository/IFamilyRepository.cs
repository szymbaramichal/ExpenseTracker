using ExpenseTracker.Core.Entities;
using ExpenseTracker.Infrastructure.Repositories.BaseRepository;

namespace ExpenseTracker.Infrastructure.Repositories.FamilyRepository;

public interface IFamilyRepository : IBaseRepository<Family>
{
    Task<ICollection<(string, int)>> GetFamilyNamesAndIds(int userId);
    Task<UserFamily> GetUserInfoForFamily(int familyId, int userId);
    Task<Family> GetFamilyWithUserIds(int familyId);
    Task CreateFamily(Family family, int userId);
    Task AddUserToFamily(UserFamily userFamily);
}
