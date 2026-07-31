// Services/Flight/Flight.Application/Handlers/GetAllFlightsQueryHandler.cs
using Flight.Application.Queries;

using Flight.Core.Repositories;
using MediatR;

namespace Flight.Application.Handlers;

public class GetAllFlightsQueryHandler : IRequestHandler<GetAllFlightsQuery, IEnumerable<Flight.Core.Entities.Flight>>
{
    private readonly IFlightRepository _repository;

    public GetAllFlightsQueryHandler(IFlightRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Flight.Core.Entities.Flight>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}