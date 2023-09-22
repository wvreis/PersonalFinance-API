using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;

namespace PersonalFinance.Infrastructure.Repositories;

public class BankRepository : BaseRepository<Bank>, IBankRepository
{
    public BankRepository(AppDbContext context) : base(context)
    {}
}