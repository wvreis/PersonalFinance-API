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
        await UpdateDatabase(cancellationToken);
        await AddBanks(cancellationToken);
        await AddAccountTypes(cancellationToken);
        await AddTransactionTypeGroups(cancellationToken);
        await AddTransactionTypes(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    async Task UpdateDatabase(CancellationToken cancellationToken)
    {
        using (var scope = _scopeFactory.CreateAsyncScope()){
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await _context.Database.EnsureCreatedAsync(cancellationToken);
        }
    }

    async Task AddBanks(CancellationToken cancellationToken)
    {
        using (var scope = _scopeFactory.CreateScope()) {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var alreadyRegistered = _context.Banks.ToList();

            if (!alreadyRegistered.Any()) {
                await _context.Banks.AddRangeAsync(Banks.GetAll(), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

    async Task AddAccountTypes(CancellationToken cancellationToken)
    {
        using (var scope = _scopeFactory.CreateScope()) {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var alreadyRegistered = _context.AccountTypes.ToList();

            if (!alreadyRegistered.Any()) {
                await _context.AccountTypes.AddRangeAsync(AccountTypes.GetAll(), cancellationToken);  
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

    async Task AddTransactionTypeGroups(CancellationToken cancellationToken)
    {
        using (var scope = _scopeFactory.CreateScope()) {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var alreadyRegistered = _context.TransactionTypeGroups.ToList();

            if (!alreadyRegistered.Any()) {
                await _context.TransactionTypeGroups.AddRangeAsync(TransactionTypeGroups.GetAll(), cancellationToken);
                
                string sql = $"ALTER SEQUENCE \"{nameof(_context.TransactionTypeGroups)}_Id_seq\" RESTART WITH {TransactionTypeGroups.GetAll().Count};";

                _context.Database.ExecuteSqlRaw(sql);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

    async Task AddTransactionTypes(CancellationToken cancellationToken)
    {
        using (var scope = _scopeFactory.CreateScope()) {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var alreadyRegistered = _context.TransactionTypes.ToList();

            if (!alreadyRegistered.Any()) {
                await _context.TransactionTypes.AddRangeAsync(TransactionTypes.GetAll(), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

}