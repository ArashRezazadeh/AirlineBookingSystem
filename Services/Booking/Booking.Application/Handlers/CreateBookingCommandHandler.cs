// Services/Booking/Booking.Application/Handlers/CreateBookingCommandHandler.cs
using Booking.Application.Commands;

using Booking.Core.Repositories;
using BuildingBlocks.Contracts.EventBusMessages;
using MassTransit;
using MediatR;

namespace Booking.Application.Handlers;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IBookingRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateBookingCommandHandler(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = new Booking.Core.Entities.Booking
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            PassengerName = request.PassengerName,
            SeatNumber = request.SeatNumber,
            BookingDate = DateTime.UtcNow
        };

        await _repository.AddAsync(booking);

                // Publish event
        await _publishEndpoint.Publish(new FlightBookedEvent(
            booking.Id,
            booking.FlightId.Value,
            booking.PassengerName,
            booking.SeatNumber,
            booking.BookingDate.Value
        ), cancellationToken);
        
        return booking.Id;
    }
}