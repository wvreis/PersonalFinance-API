using MediatR;

namespace PersonalFinance.Application.AccountsTypes.Queries;

public class GetAllAccountsTypesQuery : IRequest<List<AccountTypeDto>>
{
    
}