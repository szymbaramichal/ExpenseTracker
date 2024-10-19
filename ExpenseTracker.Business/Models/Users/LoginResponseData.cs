using System;

namespace ExpenseTracker.Business.Models.Users;

public class LoginResponseData
{
    public string Token { get; set; }
    public UserViewModel Model { get; set; }
}
