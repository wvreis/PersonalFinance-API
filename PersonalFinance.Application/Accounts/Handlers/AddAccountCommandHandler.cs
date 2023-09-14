using MediatR;
using PersonalFinance.Application.Accounts.Commands;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.Accounts.Handlers;

public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, int>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddAccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(AddAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = new Account(
            description: request.Description,
            openingBalance: request.OpeningBalance,
            bankId: request.BankId,
            accountTypeId: request.AccountTypeId
        );

        await _accountRepository.AddAsync(entity, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return entity.Id;
    }
}