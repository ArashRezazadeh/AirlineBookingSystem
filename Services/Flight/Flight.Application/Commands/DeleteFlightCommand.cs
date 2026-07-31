// Services/Flight/Flight.Application/Commands/DeleteFlightCommand.cs
using MediatR;

namespace Flight.Application.Commands;

public record DeleteFlightCommand(Guid Id) : IRequest<bool>;