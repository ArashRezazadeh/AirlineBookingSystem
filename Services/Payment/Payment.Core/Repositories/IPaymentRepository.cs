// Services/Payment/Payment.Core/Repositories/IPaymentRepository.cs
namespace Payment.Core.Repositories;

public interface IPaymentRepository
{
    Task<Entities.Payment?> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.Payment>> GetAllAsync();
    Task<IEnumerable<Entities.Payment>> GetByBookingIdAsync(Guid bookingId);
    Task AddAsync(Entities.Payment payment);
    Task UpdateAsync(Entities.Payment payment);
    Task DeleteAsync(Guid id);

    Task getItems (Guid id);
}