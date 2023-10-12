using MediatR;

namespace PersonalFinance.Application.Transactions.Queries;

public class GetTransactionsQuery : IRequest<List<TransactionDto>>
{
    public string? SearchInfo { get; set; } = string.Empty;
}