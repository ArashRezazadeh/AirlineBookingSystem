// Services/Booking/Booking.Application/Consumers/NotificationEventConsumer.cs


using BuildingBlocks.Contracts.EventBusMessages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Consumers;

public class NotificationEventConsumer : IConsumer<NotificationEvent>
{
    private readonly ILogger<NotificationEventConsumer> _logger;

    public NotificationEventConsumer(ILogger<NotificationEventConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<NotificationEvent> context)
    {
        _logger.LogInformation("Received NotificationEvent: {@Notification}", context.Message);
        await Task.CompletedTask;
    }
}