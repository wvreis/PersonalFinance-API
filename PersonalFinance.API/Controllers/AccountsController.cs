using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Accounts.Commands;
using PersonalFinance.Application.Accounts.Queries;

namespace PersonalFinance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<AccountDto>>> GetAccounts([FromQuery] GetAccountsQuery query)
    {
        var result = await _mediator.Send(query);
        
        return result;
    }

    [HttpPost]
    public async Task<ActionResult> PostAccount(AddAccountCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}