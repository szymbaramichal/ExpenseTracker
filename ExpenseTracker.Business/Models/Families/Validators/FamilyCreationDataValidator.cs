using System;
using FluentValidation;

namespace ExpenseTracker.Business.Models.Families.Validators;

public class FamilyCreationDataValidator : AbstractValidator<FamilyJoinCreationData>
{
    public FamilyCreationDataValidator()
    {
        RuleFor(x => x.FamilyCode)
            .Length(6).WithMessage("Invitation code must contain 6 chars.");

        RuleFor(x => x.FamilyName)
            .Length(5, 50).WithMessage("Family name must be between 3 and 50 characters.");

        RuleFor(x => x.FamilyDescription)
            .Length(10, 100).WithMessage("Family description must be between 10 and 100 characters.");
    }
}
