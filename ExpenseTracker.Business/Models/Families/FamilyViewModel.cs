using System;
using System.Data.Common;
using ExpenseTracker.Business.Models.Expenses;
using ExpenseTracker.Business.Models.Users;

namespace ExpenseTracker.Business.Models.Families;

public class FamilyViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public bool IsUserOwner { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string FamilyInvitationCode { get; set; } = default!;
    public ICollection<UserInfoModel> FamilyUsers { get; set; } = default!;

    public ICollection<ExpenseViewModel> Expenses { get; set; } = default!;
}
