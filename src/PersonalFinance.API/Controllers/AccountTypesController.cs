using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.AccountTypes.Queries;
using PersonalFinance.Shared.Dtos;

namespace PersonalFinance.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccountTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<AccountTypeDto>>> GetAllAccountsTypes([FromQuery] GetAllAccountTypesQuery query)
    {
        var result = await _mediator.Send(query);

        return result;
    }
}