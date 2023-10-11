namespace PersonalFinance.Domain.Entities;

public class Transaction : BaseEntity
{
    public double Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public TransactionStatus Status { get; private set; }
    public TransactionNature Nature { get; private set; }
    public int AccountId { get; private set; }
    public Account? Account { get; private set; }
    public int TransactionTypeId { get; private set; }
    public TransactionType? TransactionType { get; private set; }

    public Transaction()
    {
        
    }

    public Transaction(
        double amount,
        DateTime date,
        string description,
        TransactionStatus status,
        TransactionNature nature,
        int accountId,
        int transactionTypeId)
    {
        Amount = amount;
        Date = date;
        Description = description;
        Status = status;
        Nature = nature;
        AccountId = accountId;
        TransactionTypeId = transactionTypeId;
    }

    public Transaction(
        double amount,
        DateTime date,
        string description,
        TransactionStatus status,
        TransactionNature nature,
        int accountId,
        int transactionTypeId,
        TransactionType transactionType,
        Account account)
    {
        Amount = amount;
        Date = date;
        Description = description;
        Status = status;
        Nature = nature;
        AccountId = accountId;
        TransactionTypeId = transactionTypeId;
        TransactionType = transactionType;
        Account = account;
    }

    public void Update(
        double? amount,
        DateTime? date = null,
        string? description = null,
        TransactionStatus? status = null,
        TransactionNature? nature = null,
        int? accountId = null,
        int? transactionTypeId = null)
    {
        if (amount.HasValue)
            Amount = amount.Value;

        if (date.HasValue) 
            Date = date.Value;

        if (!string.IsNullOrEmpty(description))
            Description = description;
        
        if (status.HasValue)
            Status = status.Value;

        if (nature.HasValue)
            Nature = nature.Value;

        if (accountId.HasValue) 
            AccountId = accountId.Value;

        if (transactionTypeId.HasValue)
            TransactionTypeId = transactionTypeId.Value;
    }   
}
