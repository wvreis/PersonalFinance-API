using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Accounts.Commands.AddAccount;
using PersonalFinance.Application.Accounts.Commands.UpdateAccount;
using PersonalFinance.Application.Accounts.Queries;

namespace PersonalFinance.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccountsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region GET
    [HttpGet]
    public async Task<ActionResult<AccountDto>> GetAccount([FromQuery] GetAccountQuery query)
    {
        var result = await _mediator.Send(query);

        return result;
    }

    [HttpGet]
    public async Task<ActionResult<List<AccountDto>>> GetAccounts([FromQuery] GetAccountsQuery query)
    {
        var result = await _mediator.Send(query);
        
        return result;
    }    
    #endregion

    [HttpPost]
    public async Task<ActionResult> PostAccount([FromBody] AddAccountCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> PutAccount([FromBody]  UpdateAccountCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}