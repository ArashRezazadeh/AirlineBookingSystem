// Services/Booking/Booking.Infrastructure/Repositories/BookingRepository.cs
using Dapper;
using BookingEntity = Booking.Core.Entities.Booking;
using Booking.Core.Repositories;
using System.Data;

namespace Booking.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly IDbConnection _connection;

    public BookingRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<BookingEntity?> GetByIdAsync(Guid id)
    {
        const string sql = "SELECT * FROM Bookings WHERE Id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<BookingEntity>(sql, new { Id = id });
    }

    public async Task<IEnumerable<BookingEntity>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Bookings";
        return await _connection.QueryAsync<BookingEntity>(sql);
    }

    public async Task<IEnumerable<BookingEntity>> GetByFlightIdAsync(Guid flightId)
    {
        const string sql = "SELECT * FROM Bookings WHERE FlightId = @FlightId";
        return await _connection.QueryAsync<BookingEntity>(sql, new { FlightId = flightId });
    }

    public async Task<IEnumerable<BookingEntity>> GetByPassengerNameAsync(string passengerName)
    {
        const string sql = "SELECT * FROM Bookings WHERE PassengerName LIKE @PassengerName";
        return await _connection.QueryAsync<BookingEntity>(sql, new { PassengerName = $"%{passengerName}%" });
    }

    public async Task AddAsync(BookingEntity booking)
    {
        const string sql = @"
            INSERT INTO Bookings (Id, FlightId, PassengerName, SeatNumber, BookingDate)
            VALUES (@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)";
        await _connection.ExecuteAsync(sql, booking);
    }

    public async Task UpdateAsync(BookingEntity booking)
    {
        const string sql = @"
            UPDATE Bookings 
            SET FlightId = @FlightId, PassengerName = @PassengerName, 
                SeatNumber = @SeatNumber, BookingDate = @BookingDate
            WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, booking);
    }

    public async Task DeleteAsync(Guid id)
    {
        const string sql = "DELETE FROM Bookings WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, new { Id = id });
    }
}