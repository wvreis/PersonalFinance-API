namespace PersonalFinance.Domain.Entities; 

public class TransactionTypeGroup : BaseEntity
{
    public string Description { get; private set; } = string.Empty;
    public List<TransactionType> TransactionTypes { get; private set; } = new();

    public TransactionTypeGroup()
    {
        
    }

    public TransactionTypeGroup(string description, List<TransactionType> transactionTypes)
    {
        Description = description;
        TransactionTypes = transactionTypes;
    }
}
