using MediatR;

namespace PersonalFinance.Application.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public double OpeningBalance { get; set; }
    public bool Status { get; set; }
    public int BankId { get; set; }
    public int AccountTypeId { get; set; }
}