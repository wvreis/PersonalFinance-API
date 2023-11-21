using PersonalFinance.Domain.Enums;

namespace PersonalFinance.Shared.Dtos;

public class TransactionDto
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public TransactionStatus Status { get; set; }
    public TransactionNature Nature { get; set; }
    public int AccountId { get; set; }
    public string Account { get; set; } = string.Empty;
    public int TransactionTypeId { get; set; }
    public string TransactionType { get; set; } = string.Empty;
}