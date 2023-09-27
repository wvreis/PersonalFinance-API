using MediatR;

namespace PersonalFinance.Application.Accounts.Commands.AddAccount;

public class AddAccountCommand : IRequest<int>
{    
    public string Description { get; set; } = string.Empty;
    public double OpeningBalance { get; set; }
    public int BankId { get; set; }
    public int AccountTypeId { get; set; }
}