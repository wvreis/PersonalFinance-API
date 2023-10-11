using MediatR;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.Transactions.Commands.AddTransaction;

public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, int>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
    {
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Transaction(
            amount: request.Amount,
            date: request.Date,
            description: request.Description,
            status: request.Status,
            nature: request.Nature,
            accountId: request.AccountId,
            transactionTypeId: request.TransactionTypeId
        );

        await _transactionRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return entity.Id;
    }
}