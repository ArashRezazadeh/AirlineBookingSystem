// Services/Payment/Payment.Application/Handlers/ProcessPaymentCommandHandler.cs
using Payment.Application.Commands;

using Payment.Core.Repositories;
using MediatR;
using MassTransit;
using BuildingBlocks.Contracts.EventBusMessages;

namespace Payment.Application.Handlers;

public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, Guid>
{
    private readonly IPaymentRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;

    public ProcessPaymentCommandHandler(IPaymentRepository repository, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payment.Core.Entities.Payment
        {
            Id = Guid.NewGuid(),
            BookingId = request.BookingId,
            Amount = request.Amount,
            PaymentDate = DateTime.UtcNow
        };

        await _repository.AddAsync(payment);

        await _publishEndpoint.Publish(new PaymentProcessedEvent(
            payment.Id,
            payment.BookingId.Value,
            payment.Amount.Value,
            payment.PaymentDate.Value
        ), cancellationToken);

        return payment.Id;
    }
}