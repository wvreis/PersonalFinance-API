namespace PersonalFinance.Application.Accounts.Queries;

public class AccountDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public double OpeningBalance { get; set; }
    public bool Status { get; set; }
    public int BankId { get; set; }
    public string Bank { get; set; } = string.Empty;
    public int AccountTypeId { get; set; }
    public string AccountType { get; set; } = string.Empty;
}