// Services/Notification/Notification.Infrastructure/Services/NotificationService.cs
using Notification.Core.Repositories;
using Notification.Core.Services;

namespace Notification.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _repository;

    public NotificationService(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task SendNotificationAsync(string recipient, string message, string type)
    {
       Console.WriteLine($"Notification sent to {recipient}: {message}");
    }
}