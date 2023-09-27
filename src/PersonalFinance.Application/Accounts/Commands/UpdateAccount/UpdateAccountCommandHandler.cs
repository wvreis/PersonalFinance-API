using MediatR;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, int>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _accountRepository.Get(request.Id, cancellationToken);

        entity.Update(
            status: request.Status,
            description: request.Description,
            openingBalance: request.OpeningBalance,
            bankId: request.BankId,
            accountTypeId: request.AccountTypeId
        );

        _accountRepository.Update(entity);
        await _unitOfWork.CommitAsync(cancellationToken);

        return entity.Id;
    }
}