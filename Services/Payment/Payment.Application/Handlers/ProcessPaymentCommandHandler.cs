// Services/Payment/Payment.Application/Handlers/ProcessPaymentCommandHandler.cs
using Payment.Application.Commands;

using Payment.Core.Repositories;
using MediatR;

namespace Payment.Application.Handlers;

public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, Guid>
{
    private readonly IPaymentRepository _repository;

    public ProcessPaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payment.Core.Entities.Payment
        {
            Id = Guid.NewGuid(),
            BookingId = request.BookingId,
            Amount = request.Amount,
            PaymentDate = DateTime.UtcNow
        };

        await _repository.AddAsync(payment);
        return payment.Id;
    }
}