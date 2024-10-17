using System;
using ExpenseTracker.Core.Shared;

namespace ExpenseTracker.Core.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;    
    public byte[] PasswordHash { get; set; } = default!;
    public string Description { get; set; } = string.Empty;

    public ICollection<UserFamily> UserFamilies { get; set; } = default!;
}


