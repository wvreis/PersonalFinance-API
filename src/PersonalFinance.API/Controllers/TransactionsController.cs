using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Transactions.Commands.AddTransaction;
using PersonalFinance.Application.Transactions.Commands.UpdateTransaction;
using PersonalFinance.Application.Transactions.Queries;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TransactionsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region GET
    [HttpGet]
    public async Task<ActionResult<TransactionDto>> GetTransaction([FromQuery] GetTransactionQuery query)
    {
        var result = await _mediator.Send(query);

        return result;
    }

    [HttpGet]
    public async Task<ActionResult<List<TransactionDto>>> GetTransactions([FromQuery] GetTransactionsQuery query)
    {
        var result = await _mediator.Send(query);

        return result;
    }
    #endregion

    [HttpPost]
    public async Task<ActionResult<int>> PostTransaction([FromBody] AddTransactionCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<int>> PutTransaction([FromBody] UpdateTransactionCommand command)
    {
        var result = await Mediator.Send(command);
        
        return Ok(result);
    }
}