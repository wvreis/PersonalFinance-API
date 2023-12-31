﻿using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Repositories;
using System.Reflection;

namespace PersonalFinance.Application;
public static class DependencyInjection {
    public static void AddApplicationDI(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped<IBankRepository, BankRepository>(); 
        services.AddScoped<IAccountRepository, AccountRepository>();  
        services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        services.AddFluentValidationAutoValidation(); 
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());    
    }
}
