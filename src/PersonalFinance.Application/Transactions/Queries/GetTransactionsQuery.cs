using MediatR;
using PersonalFinance.Domain.Enums;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.Application.Transactions.Queries;

public class GetTransactionsQuery : IRequest<List<TransactionDto>>
{
    public string? SearchInfo { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; } = DateTime.MinValue;
    public DateTime? EndDate { get; set; } = DateTime.MaxValue;
    public TransactionNature? Nature { get; set; }
    public TransactionStatus? Status { get; set; }
}