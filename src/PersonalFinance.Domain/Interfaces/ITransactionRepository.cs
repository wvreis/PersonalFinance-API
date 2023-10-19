using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Domain.Interfaces;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    Task<List<Transaction>> GetTransactionsAsync(
        string? searchInfo,
        DateTime? startDate,
        DateTime? endDate,
        TransactionNature? transactionNature,
        TransactionStatus? transactionStatus,
        CancellationToken cancellationToken);
}