using FluentValidation;

namespace ExpenseTracker.Business.Models.Users.Validators;

public class LoginFormDataValidator : AbstractValidator<LoginFormData>
{
    public LoginFormDataValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}