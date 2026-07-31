// Services/Booking/Booking.Application/Commands/CreateBookingCommand.cs
using MediatR;

namespace Booking.Application.Commands;

public record CreateBookingCommand(
    Guid FlightId,
    string PassengerName,
    string SeatNumber,
    DateTime BookingDate) : IRequest<Guid>;