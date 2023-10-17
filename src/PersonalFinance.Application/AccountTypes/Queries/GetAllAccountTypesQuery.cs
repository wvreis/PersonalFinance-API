using MediatR;

namespace PersonalFinance.Application.AccountTypes.Queries;

public class GetAllAccountTypesQuery : IRequest<List<AccountTypeDto>>
{
    
}