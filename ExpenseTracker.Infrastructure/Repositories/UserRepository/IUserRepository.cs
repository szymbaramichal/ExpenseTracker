using System;
using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Infrastructure.Repositories.UserRepository;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User> GetUser(int id);
    Task<User> GetUser(string userName);
    Task EditUser(User user);
    Task DeleteUser(User user);

}
