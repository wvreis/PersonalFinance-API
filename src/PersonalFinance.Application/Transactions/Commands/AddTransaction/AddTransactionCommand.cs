using MediatR;
using PersonalFinance.Domain.Enums;

namespace PersonalFinance.Application.Transactions.Commands.AddTransaction;

public class AddTransactionCommand : IRequest<int>
{
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public TransactionStatus Status { get; set; }
    public TransactionNature Nature { get; set; }
    public int AccountId { get; set; }
    public int TransactionTypeId { get; set; }

}