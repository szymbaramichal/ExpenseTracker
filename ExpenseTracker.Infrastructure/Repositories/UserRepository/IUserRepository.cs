using ExpenseTracker.Core.Entities;
using ExpenseTracker.Infrastructure.Repositories.BaseRepository;

namespace ExpenseTracker.Infrastructure.Repositories.UserRepository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsUserNameTaken(string userName);
    Task<User> GetUserByUserName(string userName);
}
