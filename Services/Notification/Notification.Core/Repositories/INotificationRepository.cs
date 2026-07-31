// Services/Notification/Notification.Core/Repositories/INotificationRepository.cs
namespace Notification.Core.Repositories;

public interface INotificationRepository
{
    Task<Entities.Notification?> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.Notification>> GetAllAsync();
    Task<IEnumerable<Entities.Notification>> GetByRecipientAsync(string recipient);
    Task<IEnumerable<Entities.Notification>> GetByTypeAsync(string type);
    Task AddAsync(Entities.Notification notification);
    Task UpdateAsync(Entities.Notification notification);
    Task DeleteAsync(Guid id);
}