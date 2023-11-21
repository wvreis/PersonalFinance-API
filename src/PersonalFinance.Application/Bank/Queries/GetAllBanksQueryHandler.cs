 using MediatR;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.Application.Bank.Queries;

public class GetAllBanksQueryHandler : IRequestHandler<GetAllBanksQuery, List<BankDto>>
{
    private readonly IBankRepository _bankRepository;

    public GetAllBanksQueryHandler(IBankRepository bankRepository)
    {
        _bankRepository = bankRepository;
    }

    public async Task<List<BankDto>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
    {
        var banks = await _bankRepository.GetAll(cancellationToken);

        List<BankDto> banksDto = new();

        banks.ForEach(b => {
            banksDto.Add(new(){
                Id = b.Id,
                Name = b.Name,
                Number = b.Number
            });
        });

        return banksDto;
    }
}