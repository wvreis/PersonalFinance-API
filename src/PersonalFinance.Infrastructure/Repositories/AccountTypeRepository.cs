using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;

namespace PersonalFinance.Infrastructure.Repositories;

public class AccountTypeRepository : BaseRepository<AccountType>, IAccountTypeRepository
{
    public AccountTypeRepository(AppDbContext context) : base(context)
    {}
}