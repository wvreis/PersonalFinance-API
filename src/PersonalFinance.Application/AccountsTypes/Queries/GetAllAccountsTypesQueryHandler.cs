using MediatR;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.AccountsTypes.Queries;

public class GetAllAccountsTypesQueryHandler : IRequestHandler<GetAllAccountsTypesQuery, List<AccountTypeDto>>
{
    private readonly IAccountTypeRepository _accountTypeRepository;

    public GetAllAccountsTypesQueryHandler(IAccountTypeRepository accountTypeRepository)
    {
        _accountTypeRepository = accountTypeRepository;
    }

    public async Task<List<AccountTypeDto>> Handle(GetAllAccountsTypesQuery request, CancellationToken cancellationToken)
    {
         var accountsTypes = await _accountTypeRepository.GetAll(cancellationToken);

        List<AccountTypeDto> accountsTypesDto = new();

        accountsTypes.ForEach(at => {
            accountsTypesDto.Add(new(){
                Id = at.Id,
                Description = at.Description
            });
        });

        return accountsTypesDto;
    }
}