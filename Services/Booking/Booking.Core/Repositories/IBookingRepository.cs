// Services/Booking/Booking.Core/Repositories/IBookingRepository.cs
namespace Booking.Core.Repositories;

public interface IBookingRepository
{
    Task<Entities.Booking?> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.Booking>> GetAllAsync();
    Task<IEnumerable<Entities.Booking>> GetByFlightIdAsync(Guid flightId);
    Task<IEnumerable<Entities.Booking>> GetByPassengerNameAsync(string passengerName);
    Task AddAsync(Entities.Booking booking);
    Task UpdateAsync(Entities.Booking booking);
    Task DeleteAsync(Guid id);
}