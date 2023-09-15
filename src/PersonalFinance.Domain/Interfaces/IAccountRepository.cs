using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Domain.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<List<Account>> GetAccountsAsync(string? searchInfo, CancellationToken cancellationToken);
}