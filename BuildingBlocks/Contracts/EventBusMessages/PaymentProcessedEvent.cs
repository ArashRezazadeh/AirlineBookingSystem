// BuildingBlocks/Contracts/EventBusMessages/PaymentProcessedEvent.cs
namespace BuildingBlocks.Contracts.EventBusMessages;

public record PaymentProcessedEvent(
    Guid PaymentId,
    Guid BookingId,
    decimal Amount,
    DateTime PaymentDate);