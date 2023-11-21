using MediatR;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.Application.TransactionTypes.Queries; 

public class GetAllTransactionTypeQuery : IRequest<List<TransactionTypeDto>>
{ 

}
