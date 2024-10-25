using ExpenseTracker.Business.Models.Users;
using ExpenseTracker.Business.Services.ExpensesService;
using ExpenseTracker.Business.Services.FamilyService;
using ExpenseTracker.Business.Services.TokenService;
using ExpenseTracker.Business.Services.UserService;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
    {
        // TODO: remove deprecated methods
        services.AddFluentValidation(fv => 
                    fv.RegisterValidatorsFromAssemblyContaining<LoginFormData>());

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IFamilyService, FamilyService>();
        services.AddTransient<IExpensesService, ExpensesService>();

        return services;
    }
}
