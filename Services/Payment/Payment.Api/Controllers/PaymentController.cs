// Services/Payment/Payment.Api/Controllers/PaymentController.cs
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Commands;

namespace Payment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("process")]
    public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { PaymentId = result, Message = "Payment processed successfully" });
    }

    [HttpPost("refund/{paymentId}")]
    public async Task<IActionResult> RefundPayment(Guid paymentId)
    {
        var command = new RefundPaymentCommand(paymentId);
        var result = await _mediator.Send(command);
        
        if (!result)
            return NotFound(new { Message = "Payment not found" });
            
        return Ok(new { Message = "Payment refunded successfully" });
    }
}