using MediatR;
using PersonalFinance.Domain.Entities;
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
        var accounts = await _accountRepository.GetAccountsAsync(request.SeachInfo, cancellationToken);

        List<AccountDto> accountsDtos = new();

        accounts.ForEach(acc => {
            accountsDtos.Add(new(){
                Id = acc.Id,
                Description = acc.Description,
                AccountType = acc.AccountType?.Description ?? string.Empty,
                AccountTypeId = acc.AccountTypeId,
                Bank = acc.Bank?.Name ?? string.Empty,
                BankId = acc.BankId,
                OpeningBalance = acc.OpeningBalance,
                Status = acc.Status
            });
        });

        return accountsDtos;
    }
}