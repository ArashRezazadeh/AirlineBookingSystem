// Services/Flight/Flight.Application/Handlers/DeleteFlightCommandHandler.cs
using Flight.Application.Commands;
using Flight.Core.Repositories;
using MediatR;

namespace Flight.Application.Handlers;

public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, bool>
{
    private readonly IFlightRepository _repository;

    public DeleteFlightCommandHandler(IFlightRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = await _repository.GetByIdAsync(request.Id);
        if (flight == null)
            return false;

        await _repository.DeleteAsync(request.Id);
        return true;
    }
}