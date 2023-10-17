using MediatR;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.AccountTypes.Queries;

public class GetAllAccountTypesQueryHandler : IRequestHandler<GetAllAccountTypesQuery, List<AccountTypeDto>>
{
    private readonly IAccountTypeRepository _accountTypeRepository;

    public GetAllAccountTypesQueryHandler(IAccountTypeRepository accountTypeRepository)
    {
        _accountTypeRepository = accountTypeRepository;
    }

    public async Task<List<AccountTypeDto>> Handle(GetAllAccountTypesQuery request, CancellationToken cancellationToken)
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