using ExpenseTracker.Core.Entities;
using ExpenseTracker.Infrastructure.Persistence;
using ExpenseTracker.Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories.UserRepository;

public class UserRepository(DataContext dataContext) : BaseRepository<User>(dataContext), IUserRepository
{
    public async Task<User> GetUserByUserName(string userName)
    {
        return await dataContext.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());
    }

    public async Task<bool> IsUserNameTaken(string userName)
    {
        return await dataContext.Users.AnyAsync(x => x.UserName.ToLower() == userName.ToLower());
    }
}
