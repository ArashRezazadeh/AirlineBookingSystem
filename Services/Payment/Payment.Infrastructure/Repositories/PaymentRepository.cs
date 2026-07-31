// Services/Payment/Payment.Infrastructure/Repositories/PaymentRepository.cs
using Dapper;
using PaymentEntity = Payment.Core.Entities.Payment;
using Payment.Core.Repositories;
using System.Data;

namespace Payment.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly IDbConnection _connection;

    public PaymentRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<PaymentEntity?> GetByIdAsync(Guid id)
    {
        const string sql = "SELECT * FROM Payments WHERE Id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<PaymentEntity>(sql, new { Id = id });
    }

    public async Task<IEnumerable<PaymentEntity>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Payments";
        return await _connection.QueryAsync<PaymentEntity>(sql);
    }

    public async Task<IEnumerable<PaymentEntity>> GetByBookingIdAsync(Guid bookingId)
    {
        const string sql = "SELECT * FROM Payments WHERE BookingId = @BookingId";
        return await _connection.QueryAsync<PaymentEntity>(sql, new { BookingId = bookingId });
    }

    public async Task AddAsync(PaymentEntity payment)
    {
        const string sql = @"
            INSERT INTO Payments (Id, BookingId, Amount, PaymentDate)
            VALUES (@Id, @BookingId, @Amount, @PaymentDate)";
        await _connection.ExecuteAsync(sql, payment);
    }

    public async Task UpdateAsync(PaymentEntity payment)
    {
        const string sql = @"
            UPDATE Payments 
            SET BookingId = @BookingId, Amount = @Amount, PaymentDate = @PaymentDate
            WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, payment);
    }

    public async Task DeleteAsync(Guid id)
    {
        const string sql = "DELETE FROM Payments WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, new { Id = id });
    }

    public Task getItems(Guid id)
    {
        throw new NotImplementedException();
    }
}