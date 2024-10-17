using System;
using ExpenseTracker.Core.Shared;

namespace ExpenseTracker.Core.Entities;

public class UserFamily : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    
    public int FamilyId { get; set; }
    public Family Family { get; set; } = default!;
    
    public string FamilyRole { get; set; } = default!;
}
