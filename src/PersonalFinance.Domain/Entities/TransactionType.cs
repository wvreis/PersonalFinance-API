namespace PersonalFinance.Domain.Entities; 

public class TransactionType : BaseEntity
{
    public string Description { get; private set; } = string.Empty;
    public TransactionNature Nature { get; private set; }
    public int TransactionTypeGroupId { get; private set; }
    public TransactionTypeGroup? TransactionTypeGroup { get; private set; }
    public List<Transaction> Transactions { get; private set; } = new();

    public TransactionType()
    {
        
    }

    public TransactionType(
        string description,
        TransactionNature nature,
        int transactionTypeGroupId,
        TransactionTypeGroup? transactionTypeGroup,
        List<Transaction> transactions)
    {
        Description = description;
        Nature = nature;
        TransactionTypeGroupId = transactionTypeGroupId;
        TransactionTypeGroup = transactionTypeGroup;
        Transactions = transactions;
    }
}
