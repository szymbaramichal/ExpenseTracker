using System.Net;
using ExpenseTracker.Business.Helpers;
using ExpenseTracker.Business.Models.Users;
using ExpenseTracker.Business.Services.TokenService;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Shared;
using ExpenseTracker.Infrastructure.Repositories.UserRepository;

namespace ExpenseTracker.Business.Services.UserService;

public class UserService(IUserRepository userRepository, ITokenService tokenService) : IUserService
{
    public async Task<bool> IsUserNameTaken(string userName)
    {
        return await userRepository.IsUserNameTaken(userName);
    }

    public async Task<Result<LoginResponseData>> LoginUser(LoginFormData loginFormData)
    {
        var user = await userRepository.GetUserByUserName(loginFormData.UserName);

        if(user is null)
            return new Result<LoginResponseData>("Invalid login or password.", HttpStatusCode.BadRequest);

        if(!PasswordHasher.IsPasswordValid(loginFormData.Password, user.PasswordHash, user.PasswordSalt))
            return new Result<LoginResponseData>("Invalid login or password.", HttpStatusCode.BadRequest);

        var token = tokenService.GenerateJwtToken(loginFormData.UserName);

        var returnModel = new LoginResponseData{
            Model = new UserViewModel {
                Description = user.Description,
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName
            },
            Token = token
        };

        return new Result<LoginResponseData>(returnModel);
    }

    public async Task<Result<LoginResponseData>> RegisterUser(LoginFormData loginFormData)
    {
        var user = await userRepository.GetUserByUserName(loginFormData.UserName);

        if(user is not null)
            return new Result<LoginResponseData>("Login already taken.", HttpStatusCode.BadRequest);

        var hashAndSalt = PasswordHasher.GeneratePasswordHashAndSalt(loginFormData.Password);

        var newUser = new User {
            UserName = loginFormData.UserName,
            PasswordHash = hashAndSalt.Item1,
            PasswordSalt = hashAndSalt.Item2
        };

        await userRepository.AddAsync(newUser);

        var token = tokenService.GenerateJwtToken(loginFormData.UserName);
        
        var returnModel = new LoginResponseData{
            Model = new UserViewModel {
                Description = newUser.Description,
                Email = newUser.Email,
                Id = newUser.Id,
                UserName = newUser.UserName
            },
            Token = token
        };
    
        return new Result<LoginResponseData>(returnModel);
    }
}
