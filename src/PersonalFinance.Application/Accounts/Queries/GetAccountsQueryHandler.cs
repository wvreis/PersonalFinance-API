using MediatR;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.Accounts.Queries;

public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<AccountDto>>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountsQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<List<AccountDto>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        var accounts = await _accountRepository.GetAccountsAsync(request.SearchInfo, cancellationToken);

        List<AccountDto> accountsDto = new();

        accounts.ForEach(acc => {
            accountsDto.Add(new(){
                Id = acc.Id,
                Description = acc.Description,
                AccountType = acc.AccountType?.Description ?? string.Empty,
                AccountTypeId = acc.AccountTypeId,
                Bank = acc.Bank?.Name ?? string.Empty,
                BankId = acc.Bank?.Number ?? 0,
                OpeningBalance = acc.OpeningBalance,
                Status = acc.Status
            });
        });

        return accountsDto;
    }
}