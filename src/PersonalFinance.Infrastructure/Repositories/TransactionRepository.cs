using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;

namespace PersonalFinance.Infrastructure.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext context) : base(context)
    {}

    public Task<List<Transaction>> GetTransactionsAsync(
        string? searchInfo,
        DateTime? startDate,
        DateTime? endDate,
        TransactionNature? nature,
        TransactionStatus? status,
        CancellationToken cancellationToken)
    {
        Expression<Func<Transaction, bool>> SearchByInfo = transaction =>
            string.IsNullOrEmpty(searchInfo) || transaction.Description.ToLower().Contains(searchInfo.ToLower());

        Expression<Func<Transaction, bool>> PeriodFilter = transaction =>
            transaction.Date.Date >= startDate.Value.Date &&
            transaction.Date.Date <= endDate.Value.Date;

        Expression<Func<Transaction, bool>> NatureFilter = transaction =>
            nature != null ? transaction.Nature == nature.Value : true;

        Expression<Func<Transaction, bool>> StatusFilter = transaction =>
            status != null ? transaction.Status == status.Value : true;

        var result = _context.Transactions
            .Where(SearchByInfo)
            .Where(PeriodFilter)
            .Where(NatureFilter)
            .Where(StatusFilter)
            .ToListAsync(cancellationToken);
        
        return result;
    }
}