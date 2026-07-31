// Services/Flight/Flight.Infrastructure/Repositories/FlightRepository.cs
using Dapper;
using FlightEntity = Flight.Core.Entities.Flight;
using Flight.Core.Repositories;
using System.Data;

namespace Flight.Infrastructure.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly IDbConnection _connection;

    public FlightRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<FlightEntity?> GetByIdAsync(Guid id)
    {
        const string sql = "SELECT * FROM Flights WHERE Id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<FlightEntity>(sql, new { Id = id });
    }

    public async Task<IEnumerable<FlightEntity>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Flights";
        return await _connection.QueryAsync<FlightEntity>(sql);
    }

    public async Task<IEnumerable<FlightEntity>> GetByOriginDestinationAsync(string origin, string destination)
    {
        const string sql = "SELECT * FROM Flights WHERE Origin = @Origin AND Destination = @Destination";
        return await _connection.QueryAsync<FlightEntity>(sql, new { Origin = origin, Destination = destination });
    }

    public async Task AddAsync(FlightEntity flight)
    {
        const string sql = @"
            INSERT INTO Flights (Id, FlightNumber, Origin, Destination, DepartureTime, ArrivalTime)
            VALUES (@Id, @FlightNumber, @Origin, @Destination, @DepartureTime, @ArrivalTime)";
        await _connection.ExecuteAsync(sql, flight);
    }

    public async Task UpdateAsync(FlightEntity flight)
    {
        const string sql = @"
            UPDATE Flights 
            SET FlightNumber = @FlightNumber, Origin = @Origin, Destination = @Destination, 
                DepartureTime = @DepartureTime, ArrivalTime = @ArrivalTime
            WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, flight);
    }

    public async Task DeleteAsync(Guid id)
    {
        const string sql = "DELETE FROM Flights WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, new { Id = id });
    }
}