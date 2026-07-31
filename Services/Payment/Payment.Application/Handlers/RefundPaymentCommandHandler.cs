// Services/Payment/Payment.Application/Handlers/RefundPaymentCommandHandler.cs
using Payment.Application.Commands;
using Payment.Core.Repositories;
using MediatR;

namespace Payment.Application.Handlers;

public class RefundPaymentCommandHandler : IRequestHandler<RefundPaymentCommand, bool>
{
    private readonly IPaymentRepository _repository;

    public RefundPaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.PaymentId);
        if (payment == null)
            return false;

        await _repository.DeleteAsync(request.PaymentId);
        return true;
    }
}