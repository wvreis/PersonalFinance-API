using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;

namespace PersonalFinance.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}