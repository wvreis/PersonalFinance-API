using MediatR;

namespace PersonalFinance.Application.TransactionTypes.Queries; 

public class GetAllTransactionTypeQuery : IRequest<List<TransactionTypeDto>>
{ 

}
