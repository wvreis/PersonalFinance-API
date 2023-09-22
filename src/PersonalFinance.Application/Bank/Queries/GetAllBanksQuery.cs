using MediatR;

namespace PersonalFinance.Application.Bank.Queries;

public class GetAllBanksQuery : IRequest<List<BankDto>>
{
    
}