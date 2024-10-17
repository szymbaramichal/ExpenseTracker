using System;
using ExpenseTracker.Core.Shared;

namespace ExpenseTracker.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Color { get; set; } = default!;
}
