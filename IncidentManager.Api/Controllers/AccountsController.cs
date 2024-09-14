using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Features.Accounts.Commands.AddAccount;
using IncidentManager.Application.Features.Accounts.Commands.DeleteAccount;
using IncidentManager.Application.Features.Accounts.Commands.UpdateAccount;
using IncidentManager.Application.Features.Accounts.Queries.GetAccount;
using IncidentManager.Application.Features.Accounts.Queries.GetAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountDTO>>> Get()
    {
        var accounts = await _mediator.Send(new GetAccountsQuery());
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AccountDTO>> GetIncident([FromRoute] string id)
    {
        var account = await _mediator.Send(new GetAccountQuery() { Name = id });
        return Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddAccountCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _mediator.Send(new DeleteAccountCommand() { Name = id });
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCommand command, [FromRoute] string id)
    {
        if (id != command.Name)
        {
            return BadRequest("Name in the route and command must match.");
        }
        await _mediator.Send(command);
        return NoContent();
    }
}