namespace PersonalFinance.Domain.Entities; 

public class TransactionTypeGroup : BaseEntity
{
    public string Description { get; private set; } = string.Empty;
    public List<TransactionType> TransactionTypes { get; private set; } = new();

    public TransactionTypeGroup()
    {
        
    }

    public TransactionTypeGroup(string description)
    {
        Description = description;
    }

    public TransactionTypeGroup(int id, string description) : this(description)
    {
        Id = id;
    }
    
}
