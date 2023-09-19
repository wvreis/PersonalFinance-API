using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalFinance.Infrastructure.Persistence.SeedLists;

namespace PersonalFinance.Infrastructure.Persistence;

public class AppDbContextSeedDatabase : IHostedService
{
    readonly IServiceScopeFactory _scopeFactory;

    public  AppDbContextSeedDatabase(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await AddBanks();
        await AddAccountTypes();
        await AddTransactionTypeGroups();
        await AddTransactionTypes();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    async Task AddBanks()
    {
        using (var scope = _scopeFactory.CreateScope()) {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var alreadyRegistered = _context.Banks.ToList();

            if (!alreadyRegistered.Any()) {
                await _context.Banks.AddRangeAsync(Banks.GetAll());
                await _context.SaveChangesAsync();
            }
        }
    }

    async Task AddAccountTypes()
    {
        using (var scope = _scopeFactory.CreateScope()) {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var alreadyRegistered = _context.AccountTypes.ToList();

            if (!alreadyRegistered.Any()) {
                await _context.AccountTypes.AddRangeAsync(AccountTypes.GetAll());  
                await _context.SaveChangesAsync();
            }
        }
    }

    async Task AddTransactionTypeGroups()
    {
        using (var scope = _scopeFactory.CreateScope()) {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var alreadyRegistered = _context.TransactionTypeGroups.ToList();

            if (!alreadyRegistered.Any()) {
                await _context.TransactionTypeGroups.AddRangeAsync(TransactionTypeGroups.GetAll());
                
                string sql = $"ALTER SEQUENCE \"{nameof(_context.TransactionTypeGroups)}_Id_seq\" RESTART WITH {TransactionTypeGroups.GetAll().Count};";

                _context.Database.ExecuteSqlRaw(sql);

                await _context.SaveChangesAsync();
            }
        }
    }

    async Task AddTransactionTypes()
    {
        using (var scope = _scopeFactory.CreateScope()) {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var alreadyRegistered = _context.TransactionTypes.ToList();

            if (!alreadyRegistered.Any()) {
                await _context.TransactionTypes.AddRangeAsync(TransactionTypes.GetAll());
                await _context.SaveChangesAsync();
            }
        }
    }

}