using System.Data.Common;
using MediatR;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.Accounts.Queries;

public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountDto>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.Get(request.Id, cancellationToken);

        AccountDto accountDto = new(){
            Id = account.Id,
            Description = account.Description,
            AccountType = account.AccountType?.Description ?? string.Empty,
            AccountTypeId = account.AccountTypeId,
            Bank = account.Bank?.Name ?? string.Empty,
            BankId = account.BankId,
            OpeningBalance = account.OpeningBalance,
            Status = account.Status
        };

        return accountDto;
    }
}