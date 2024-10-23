using System;

namespace ExpenseTracker.Business.Models.Users;

public class UserInfoModel
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
}
