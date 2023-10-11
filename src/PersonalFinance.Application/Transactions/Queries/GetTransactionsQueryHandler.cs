using MediatR;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Application.Transactions.Queries;

public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, List<TransactionDto>>
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTransactionsQueryHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<List<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository.GetTransactionsAsync(request.SearchInfo, cancellationToken);

        List<TransactionDto> transactionDto = new();

        transactions.ForEach(transaction => {
            transactionDto.Add(new(){
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
                });
        });

        return transactionDto;
    }
}