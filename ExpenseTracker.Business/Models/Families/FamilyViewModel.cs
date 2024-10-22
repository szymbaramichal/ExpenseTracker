using System;

namespace ExpenseTracker.Business.Models.Families;

public class FamilyViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsUserOwner { get; set; }
    public string Description { get; set; }
}
