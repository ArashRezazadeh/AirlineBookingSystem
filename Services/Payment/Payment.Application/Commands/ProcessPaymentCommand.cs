// Services/Payment/Payment.Application/Commands/ProcessPaymentCommand.cs
using MediatR;

namespace Payment.Application.Commands;

public record ProcessPaymentCommand(
    Guid BookingId,
    decimal Amount) : IRequest<Guid>; 