using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Features.Contacts.Commands.AddContact;
using IncidentManager.Application.Features.Contacts.Commands.DeleteContact;
using IncidentManager.Application.Features.Contacts.Commands.UpdateContact;
using IncidentManager.Application.Features.Contacts.Queries.GetContact;
using IncidentManager.Application.Features.Contacts.Queries.GetContacts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactDTO>>> Get()
    {
        var contacts = await _mediator.Send(new GetContactsQuery());
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactDTO>> GetIncident([FromRoute] string id)
    {
        var contact = await _mediator.Send(new GetContactQuery() { Email = id });
        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddContactCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _mediator.Send(new DeleteContactCommand() { Email = id });
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateContactCommand command, [FromRoute] string id)
    {
        if (id != command.Email)
        {
            return BadRequest("Email in the route and command must match.");
        }
        await _mediator.Send(command);
        return NoContent();
    }
}