// BuildingBlocks/Contracts/EventBusMessages/NotificationEvent.cs
namespace BuildingBlocks.Contracts.EventBusMessages;

public record NotificationEvent(
    string Recipient,
    string Message,
    string Type);