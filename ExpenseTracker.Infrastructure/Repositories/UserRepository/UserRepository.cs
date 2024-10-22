using System;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories.UserRepository;

public class UserRepository(DataContext dataContext) : IUserRepository
{
    public async Task AddUser(User user)
    {
        await dataContext.AddAsync(user);
        await dataContext.SaveChangesAsync();
    }

    /// <returns>0 - something went wrong, 1 - ok</returns>
    public async Task DeleteUser(User user)
    {
        dataContext.Remove(user);
        await dataContext.SaveChangesAsync();
    }

    public async Task EditUser(User user)
    {
        await dataContext.SaveChangesAsync();
    }

    public async Task<User> GetUser(int id)
    {
        var user = await dataContext.Users.FindAsync(id);
        
        return user!;
    }

    public async Task<User> GetUser(string userName)
    {
        var user = await dataContext.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());

        return user!;
    }
}
