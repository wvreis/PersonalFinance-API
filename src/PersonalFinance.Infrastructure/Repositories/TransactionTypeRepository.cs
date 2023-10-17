using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Infrastructure.Persistence;

namespace PersonalFinance.Infrastructure.Repositories;
public class TransactionTypeRepository : BaseRepository<TransactionType>, ITransactionTypeRepository {
    public TransactionTypeRepository(AppDbContext context) : base(context)
    {}
}
