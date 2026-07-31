// BuildingBlocks/Common/EventBusConstants.cs
namespace BuildingBlocks.Common;

public static class EventBusConstants
{
    // Flight Service Queues
    public const string FlightCreatedQueue = "flight-created-queue";
    public const string FlightUpdatedQueue = "flight-updated-queue";
    public const string FlightDeletedQueue = "flight-deleted-queue";

    // Booking Service Queues
    public const string BookingCreatedQueue = "booking-created-queue";
    public const string BookingUpdatedQueue = "booking-updated-queue";
    public const string BookingCancelledQueue = "booking-cancelled-queue";

    // Payment Service Queues
    public const string PaymentProcessedQueue = "payment-processed-queue";
    public const string PaymentRefundedQueue = "payment-refunded-queue";

    // Notification Service Queues
    public const string NotificationSentQueue = "notification-sent-queue";

    // Exchange Names
    public const string FlightExchange = "flight-exchange";
    public const string BookingExchange = "booking-exchange";
    public const string PaymentExchange = "payment-exchange";
    public const string NotificationExchange = "notification-exchange";

    // Routing Keys
    public const string FlightCreatedRoutingKey = "flight.created";
    public const string FlightUpdatedRoutingKey = "flight.updated";
    public const string FlightDeletedRoutingKey = "flight.deleted";

    public const string BookingCreatedRoutingKey = "booking.created";
    public const string BookingUpdatedRoutingKey = "booking.updated";
    public const string BookingCancelledRoutingKey = "booking.cancelled";

    public const string PaymentProcessedRoutingKey = "payment.processed";
    public const string PaymentRefundedRoutingKey = "payment.refunded";

    public const string NotificationSentRoutingKey = "notification.sent";
}