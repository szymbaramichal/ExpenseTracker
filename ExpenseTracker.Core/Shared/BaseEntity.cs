using System;

namespace ExpenseTracker.Core.Shared;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDateUtc { get; set; }
}
