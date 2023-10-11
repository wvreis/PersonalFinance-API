using MediatR;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.Transactions.Commands.UpdateTransaction;

public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, int>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
    {
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _transactionRepository.Get(request.Id, cancellationToken);

        if (entity == null) {
            throw new NullReferenceException();
        }

        entity.Update(
            amount: request.Amount, 
            date: request.Date,
            description: request.Description,
            status: request.Status,
            nature: request.Nature,
            accountId: request.AccountId,
            transactionTypeId: request.TransactionTypeId
        );

        _transactionRepository.Update(entity);
        await _unitOfWork.CommitAsync(cancellationToken);

        return entity.Id;
    }
}