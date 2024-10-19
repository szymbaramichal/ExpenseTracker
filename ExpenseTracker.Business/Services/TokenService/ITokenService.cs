using System;

namespace ExpenseTracker.Business.Services.TokenService;

public interface ITokenService
{
    string GenerateJwtToken(string userName);
}
