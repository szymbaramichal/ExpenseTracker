using System;
using ExpenseTracker.Core.Shared;

namespace ExpenseTracker.Core.Entities;

public class Family : BaseEntity
{
    public string Description { get; set; } = default!;
    
    public ICollection<UserFamily> UserFamilies { get; set; } = default!;

}
