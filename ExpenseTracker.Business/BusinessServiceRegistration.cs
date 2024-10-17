using ExpenseTracker.Business.Models.Users;
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
        return services;
    }
}
