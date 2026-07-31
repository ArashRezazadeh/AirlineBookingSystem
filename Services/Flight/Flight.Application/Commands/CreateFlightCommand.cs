// Services/Flight/Flight.Application/Commands/CreateFlightCommand.cs
using MediatR;

namespace Flight.Application.Commands;

public record CreateFlightCommand(
    string FlightNumber,
    string Origin,
    string Destination,
    DateTime DepartureTime,
    DateTime ArrivalTime) : IRequest<Guid>;