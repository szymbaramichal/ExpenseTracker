using System;
using ExpenseTracker.Business.Models.Users;
using ExpenseTracker.Core.Shared;

namespace ExpenseTracker.Business.Services.UserService;

public interface IUserService
{
    Task<bool> IsUserNameTaken(string userName);

    Task<Result<LoginResponseData>> RegisterUser(LoginFormData loginFormData);
    Task<Result<LoginResponseData>> LoginUser(LoginFormData loginFormData);
}
