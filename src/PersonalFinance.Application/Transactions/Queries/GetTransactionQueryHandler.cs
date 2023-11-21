using MediatR;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.Application.Transactions.Queries;

public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, TransactionDto>
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTransactionQueryHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<TransactionDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.Get(request.Id, cancellationToken);

        TransactionDto transactionDto = new(){
            Id = transaction.Id,
            Amount = transaction.Amount,
            Date = transaction.Date,
            Description = transaction.Description,
            Status = transaction.Status,
            Nature = transaction.Nature,
            AccountId = transaction.AccountId,
            Account = transaction.Account?.Description ?? string.Empty,
            TransactionTypeId = transaction.TransactionTypeId,
            TransactionType = transaction.TransactionType?.Description ?? string.Empty
        };

        return transactionDto;
    }
}