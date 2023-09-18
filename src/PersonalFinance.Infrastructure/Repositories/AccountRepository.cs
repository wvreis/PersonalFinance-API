using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;

namespace PersonalFinance.Infrastructure.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {}

    public Task<List<Account>> GetAccountsAsync(string? searchInfo, CancellationToken cancellationToken)
    {
        Expression<Func<Account, bool>> Search = account =>
            string.IsNullOrEmpty(searchInfo) || account.Description.ToLower().Contains(searchInfo.ToLower());

        var result = _context.Accounts
            .Include(x => x.Bank)
            .Where(Search)
            .ToListAsync(cancellationToken);

        return result;
    }
}