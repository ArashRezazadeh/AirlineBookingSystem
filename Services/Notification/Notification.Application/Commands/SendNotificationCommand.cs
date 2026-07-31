// Services/Notification/Notification.Application/Commands/SendNotificationCommand.cs
using MediatR;

namespace Notification.Application.Commands;

public record SendNotificationCommand(
    string Recipient,
    string Message,
    string Type) : IRequest;