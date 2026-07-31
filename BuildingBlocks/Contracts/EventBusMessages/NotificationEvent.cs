// BuildingBlocks/Contracts/EventBusMessages/NotificationEvent.cs
namespace BuildingBlocks.Contracts.EventBusMessages;

public record NotificationEvent(
    Guid NotificationId,
    string Recipient,
    string Message,
    string Type,
    DateTime SentAt);