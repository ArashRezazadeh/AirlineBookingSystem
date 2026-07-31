// Services/Flight/Flight.Core/Repositories/IFlightRepository.cs
namespace Flight.Core.Repositories;

public interface IFlightRepository
{
    Task<Entities.Flight?> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.Flight>> GetAllAsync();
    Task<IEnumerable<Entities.Flight>> GetByOriginDestinationAsync(string origin, string destination);
    Task AddAsync(Entities.Flight flight);
    Task UpdateAsync(Entities.Flight flight);
    Task DeleteAsync(Guid id);
}