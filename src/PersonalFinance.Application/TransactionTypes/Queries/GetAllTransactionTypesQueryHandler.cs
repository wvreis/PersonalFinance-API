using MediatR;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.Application.TransactionTypes.Queries;
public class GetAllTransactionTypesQueryHandler : IRequestHandler<GetAllTransactionTypeQuery, List<TransactionTypeDto>> {
    private readonly ITransactionTypeRepository _transactionTypeRepository;

    public GetAllTransactionTypesQueryHandler(ITransactionTypeRepository transactionTypeRepository)
    {
        _transactionTypeRepository = transactionTypeRepository;
    }

    public async Task<List<TransactionTypeDto>> Handle(GetAllTransactionTypeQuery request, CancellationToken cancellationToken)
    {
        var transactionTypes = await _transactionTypeRepository.GetAll(cancellationToken);

        List<TransactionTypeDto> transactionTypeDtos = new List<TransactionTypeDto>();

        transactionTypes.ForEach(transactionType =>  {
            transactionTypeDtos.Add(new TransactionTypeDto() {
                Id = transactionType.Id,
                Description = transactionType.Description,
                Nature = transactionType.Nature,
                TransactionTypeGroup = transactionType.TransactionTypeGroup?.Description ?? string.Empty,
                TransactionTypeGroupId = transactionType.TransactionTypeGroupId,
            });
        });

        return transactionTypeDtos;
    }
}
