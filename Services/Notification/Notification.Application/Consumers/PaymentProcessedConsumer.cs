using BuildingBlocks.Contracts.EventBusMessages;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using Notification.Application.Commands;

namespace Notification.Application.Consumers
{
    public class PaymentProcessedConsumer : IConsumer<PaymentProcessedEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PaymentProcessedConsumer> _logger;

        public PaymentProcessedConsumer(IMediator mediator, ILogger<PaymentProcessedConsumer> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
        {
            _logger.LogInformation("Payment processed for BookingId: {BookingId}, Amount: {Amount}",
                context.Message.BookingId, context.Message.Amount);

            var command = new SendNotificationCommand(
                $"Customer_{context.Message.BookingId}",
                $"Your payment of {context.Message.Amount:C} for booking {context.Message.BookingId} has been processed successfully.",
                "PaymentConfirmation"
            );

            await _mediator.Send(command);
        }
    }
}