// Services/Flight/Flight.Application/Handlers/CreateFlightCommandHandler.cs
using Flight.Application.Commands;

using Flight.Core.Repositories;
using MediatR;

namespace Flight.Application.Handlers;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, Guid>
{
    private readonly IFlightRepository _repository;

    public CreateFlightCommandHandler(IFlightRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = new Flight.Core.Entities.Flight
        {
            Id = Guid.NewGuid(),
            FlightNumber = request.FlightNumber,
            Origin = request.Origin,
            Destination = request.Destination,
            DepartureTime = request.DepartureTime,
            ArrivalTime = request.ArrivalTime
        };

        await _repository.AddAsync(flight);
        return flight.Id;
    }
}


