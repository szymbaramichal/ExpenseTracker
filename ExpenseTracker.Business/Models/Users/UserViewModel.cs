using System;
using ExpenseTracker.Core.Enums;

namespace ExpenseTracker.Business.Models.Users;

public class UserViewModel
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;    
    public string Description { get; set; } = string.Empty;
    public string Role { get; set; } = nameof(ApplicationRoles.User);
}
