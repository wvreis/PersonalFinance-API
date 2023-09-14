namespace PersonalFinance.Domain.Entities; 

public class Account : BaseEntity 
{
    public string Description { get; private set; } = string.Empty;
    public double OpeningBalance { get; private set; }
    public bool Status { get; private set; } = true;
    public int BankId { get; private set; }
    public Bank? Bank { get; set; }
    public int AccountTypeId { get; private set; }
    public AccountType? AccountType { get; private set; }
    public List<Transaction> Transactions { get; private set; } = new();

    public Account()
    {
        
    }

    public Account(
        string description,
        double openingBalance,
        int bankId,
        int accountTypeId)
    {
        Description = description;
        OpeningBalance = openingBalance;
        BankId = bankId;
        AccountTypeId = accountTypeId;
    }

    public Account(
        string description,
        double openingBalance,
        bool status,
        int bankId,
        int accountTypeId,
        AccountType accountType,
        Bank bank)
    {
        Description = description;
        OpeningBalance = openingBalance;
        Status = status;
        BankId = bankId;
        AccountTypeId = accountTypeId;
        AccountType = accountType;
        Bank = bank;
    }
}
