// Services/Booking/Booking.Application/Queries/GetBookingQuery.cs
using MediatR;

namespace Booking.Application.Queries;

public record GetBookingQuery(Guid Id) : IRequest<Booking.Core.Entities.Booking?>;