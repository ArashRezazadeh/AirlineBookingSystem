// Services/Notification/Notification.Application/Handlers/SendNotificationCommandHandler.cs
using Notification.Application.Commands;
using Notification.Core.Repositories;
using MediatR;
using Notification.Core.Services;

namespace Notification.Application.Handlers;

public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
{
    private readonly INotificationService _service;

    public SendNotificationCommandHandler(INotificationService service)
    {
        _service = service;
    }

    public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        await _service.SendNotificationAsync(request.Recipient, request.Message, request.Type);
    }
}