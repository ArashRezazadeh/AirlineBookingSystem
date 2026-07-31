// Services/Flight/Flight.Api/Controllers/FlightController.cs
using Flight.Application.Commands;
using Flight.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlightController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetFlights()
    {
        var query = new GetAllFlightsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetFlights), new { id = result }, result);
    }

    [HttpDelete] 
    public async Task<IActionResult> DeleteFlight (Guid id)
    {
        await _mediator.Send(new DeleteFlightCommand(id));
        return NoContent();
    }
}