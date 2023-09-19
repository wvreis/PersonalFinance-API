using MediatR;

namespace PersonalFinance.Application.Accounts.Queries;

public class GetAccountsQuery : IRequest<List<AccountDto>>
{
    public string? SearchInfo { get; set; } = string.Empty; 
}