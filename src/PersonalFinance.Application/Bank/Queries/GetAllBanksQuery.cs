using MediatR;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.Application.Bank.Queries;

public class GetAllBanksQuery : IRequest<List<BankDto>>
{
    
}