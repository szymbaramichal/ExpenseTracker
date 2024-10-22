using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExpenseTracker.Business.Models.Families;

public class FamilyJoinCreationData
{
    [ValidateNever]
    public string FamilyName { get; set; }
    
    [ValidateNever]
    public string FamilyDescription { get; set; }

    [ValidateNever]
    public string FamilyCode { get; set; }
}
