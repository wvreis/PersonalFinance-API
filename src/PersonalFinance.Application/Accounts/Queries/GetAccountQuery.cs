using MediatR;

namespace PersonalFinance.Application.Accounts.Queries;

public class GetAccountQuery : IRequest<AccountDto>
{
    public int Id { get; set; }
}