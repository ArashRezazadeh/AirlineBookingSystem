
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Commands;

namespace Notification.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] SendNotificationCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}