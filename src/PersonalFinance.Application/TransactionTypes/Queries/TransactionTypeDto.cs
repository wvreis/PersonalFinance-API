using PersonalFinance.Domain.Enums;

namespace PersonalFinance.Application.TransactionTypes.Queries; 
public class TransactionTypeDto {
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public TransactionNature Nature { get; set; }
    public int TransactionTypeGroupId { get; set; }
    public string TransactionTypeGroup { get; set; } = string.Empty;
}
