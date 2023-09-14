using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Accounts.Commands;

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

    [HttpPost]
    public async Task<ActionResult> PostAccount(AddAccountCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}