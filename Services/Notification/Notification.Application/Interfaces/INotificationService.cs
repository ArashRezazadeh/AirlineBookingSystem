// Services/Notification/Notification.Core/Services/INotificationService.cs
namespace Notification.Core.Services;

public interface INotificationService
{
    Task SendNotificationAsync(string recipient, string message, string type);
}