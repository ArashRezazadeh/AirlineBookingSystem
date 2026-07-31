// Services/Payment/Payment.Application/Commands/RefundPaymentCommand.cs
using MediatR;

namespace Payment.Application.Commands;

public record RefundPaymentCommand(Guid PaymentId) : IRequest<bool>;