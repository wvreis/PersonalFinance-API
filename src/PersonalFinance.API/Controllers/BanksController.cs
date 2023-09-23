using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Application.Bank.Queries;

namespace PersonalFinance.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BanksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BanksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<BankDto>>> GetAllBanks([FromQuery] GetAllBanksQuery query)
    {
        var result = await _mediator.Send(query);

        return result;
    }
}