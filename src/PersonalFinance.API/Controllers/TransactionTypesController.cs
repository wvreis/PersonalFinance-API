using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.TransactionTypes.Queries;

namespace PersonalFinance.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TransactionTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<TransactionTypeDto>> GetAllTransactionTypes([FromQuery] GetAllTransactionTypeQuery query)
    {
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
}
