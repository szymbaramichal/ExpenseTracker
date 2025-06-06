using ExpenseTracker.Infrastructure.Persistence;
using ExpenseTracker.Infrastructure.Repositories.ExpensesRepository;
using ExpenseTracker.Infrastructure.Repositories.FamilyRepository;
using ExpenseTracker.Infrastructure.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultDatabase");
        services.AddDbContext<DataContext>(opt => {
            opt.UseSqlite(connectionString);
        });

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IFamilyRepository, FamilyRepository>();
        services.AddTransient<IExpensesRepository, ExpensesRepository>();

        return services;
    }
}
