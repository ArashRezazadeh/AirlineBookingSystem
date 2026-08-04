using BuildingBlocks.Contracts.EventBusMessages;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using Payment.Application.Commands;

namespace Payment.Application.Consumers
{
    public class BookingCreatedConsumer : IConsumer<FlightBookedEvent>
    {
        private readonly ILogger<BookingCreatedConsumer> _logger;
        private readonly IMediator _mediator;

        public BookingCreatedConsumer(ILogger<BookingCreatedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<FlightBookedEvent> context)
        {
            _logger.LogInformation("Received FlightBookedEvent for BookingId: {BookingId}", context.Message.BookingId);
            var flightBookEvent = context.Message;
            var command = new ProcessPaymentCommand(flightBookEvent.BookingId, 200.00m);    
            await _mediator.Send(command);
            await Task.CompletedTask;
        }
    }
}