// Services/Flight/Flight.Application/Queries/GetAllFlightsQuery.cs
using MediatR;


namespace Flight.Application.Queries;

public record GetAllFlightsQuery() : IRequest<IEnumerable<Flight.Core.Entities.Flight>>;