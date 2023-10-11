using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Domain.Interfaces;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    Task<List<Transaction>> GetTransactionsAsync(string? searchInfo, CancellationToken cancellationToken);
}