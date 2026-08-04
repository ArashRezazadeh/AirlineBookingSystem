// Services/Notification/Notification.Infrastructure/Services/NotificationService.cs
using BuildingBlocks.Contracts.EventBusMessages;
using MassTransit;
using Notification.Core.Repositories;
using Notification.Core.Services;

namespace Notification.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;
    public NotificationService(INotificationRepository repository, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task SendNotificationAsync(string recipient, string message, string type)
    {
       Console.WriteLine($"Notification sent to {recipient}: {message}");
       var notificationEvent = new NotificationEvent(recipient, message, type);
       await _publishEndpoint.Publish(notificationEvent);
    }
}