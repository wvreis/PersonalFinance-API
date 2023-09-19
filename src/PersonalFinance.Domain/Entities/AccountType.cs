namespace PersonalFinance.Domain.Entities; 

public class AccountType : BaseEntity
{
    public string Description { get; private set; } = string.Empty;
    public bool Status { get; private set; } = true;
    public List<Account>? Accounts { get; private set; }

    public AccountType(string description)
    {
        Description = description;
    }

    public AccountType()
    {
    }
}
