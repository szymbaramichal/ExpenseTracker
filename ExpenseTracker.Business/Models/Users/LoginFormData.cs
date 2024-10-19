using System;

namespace ExpenseTracker.Business.Models.Users;

public class LoginFormData
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}
