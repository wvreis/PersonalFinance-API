using MediatR;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application.Accounts.Queries;

public class GetAccountsQuery : IRequest<List<AccountDto>>
{
    public string SeachInfo { get; set; } = string.Empty; 
}