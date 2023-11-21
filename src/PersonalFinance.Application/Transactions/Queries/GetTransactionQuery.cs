using MediatR;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.Application.Transactions.Queries;

public class GetTransactionQuery : IRequest<TransactionDto>
{
    public int Id { get; set; }
}