using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Features.Incidents.Commands.AddIncident;
using IncidentManager.Application.Features.Incidents.Commands.DeleteIncident;
using IncidentManager.Application.Features.Incidents.Commands.UpdateIncident;
using IncidentManager.Application.Features.Incidents.Queries.GetIncident;
using IncidentManager.Application.Features.Incidents.Queries.GetIncidents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IncidentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public IncidentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IncidentDTO>>> Get()
    {
        var incidents = await _mediator.Send(new GetIncidentsQuery());
        return Ok(incidents);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IncidentDTO>> GetIncident([FromRoute] string id)
    {
        var incident = await _mediator.Send(new GetIncidentQuery() { IncidentName = id});
        return Ok(incident);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddIncidentCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _mediator.Send(new DeleteIncidentCommand() { IncidentName = id });
        return NoContent();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateIncidentCommand command, [FromRoute] string id)
    {
        if (id != command.IncidentName)
        {
            return BadRequest("IncidentName in the route and command must match.");
        }
        await _mediator.Send(command);
        return NoContent();
    }
}
