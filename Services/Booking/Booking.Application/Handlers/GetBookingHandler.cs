// Services/Booking/Booking.Application/Handlers/GetBookingQueryHandler.cs
using Booking.Application.Queries;
using Booking.Core.Repositories;
using MediatR;

namespace Booking.Application.Handlers;

public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, Booking.Core.Entities.Booking?>
{
    private readonly IBookingRepository _repository;

    public GetBookingQueryHandler(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Booking.Core.Entities.Booking?> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}