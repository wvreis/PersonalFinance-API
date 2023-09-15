using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Repositories;
using System.Reflection;

namespace PersonalFinance.Application;
public static class DependencyInjection {
    public static void AddCommands(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IAccountRepository, AccountRepository>();
    }
}
