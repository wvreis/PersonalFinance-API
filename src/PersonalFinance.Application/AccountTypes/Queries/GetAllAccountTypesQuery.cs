using MediatR;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.Application.AccountTypes.Queries;

public class GetAllAccountTypesQuery : IRequest<List<AccountTypeDto>>
{
    
}