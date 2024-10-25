using System;
using FluentValidation;

namespace ExpenseTracker.Business.Models.Expenses.Validators;

public class ExpenseFormModelValidator : AbstractValidator<ExpenseFormModel>
{
    public ExpenseFormModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name must be included.");

        RuleFor(x => x.Description)
            .Length(5, 100).WithMessage("Family description must be between 10 and 100 characters.");

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0.01m).WithMessage("Amount has to be greater than 0.01.");
    }
}
