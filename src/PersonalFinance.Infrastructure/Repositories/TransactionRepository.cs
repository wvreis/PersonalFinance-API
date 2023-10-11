using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;

namespace PersonalFinance.Infrastructure.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext context) : base(context)
    {}

    public Task<List<Transaction>> GetTransactionsAsync(string? searchInfo, CancellationToken cancellationToken)
    {
        Expression<Func<Transaction, bool>> Search = transaction =>
            string.IsNullOrEmpty(searchInfo) || transaction.Description.ToLower().Contains(searchInfo.ToLower());

        var result = _context.Transactions
            .Include(x => x.TransactionType)
            .Include(x => x.Account)
            .Where(Search)
            .ToListAsync(cancellationToken);
        
        return result;
    }
}