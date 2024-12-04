namespace NotificationMicroservicePrototype.Contracts.Notification.HttpRequests;

using NotificationDataTypes;

public class SendNotificationRequest
{
    public string Type { get; set; }
    public string Data { get; set; }
    public NotificationToData To { get; set; }
}