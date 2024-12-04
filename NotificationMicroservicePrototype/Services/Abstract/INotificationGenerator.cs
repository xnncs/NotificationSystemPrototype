namespace NotificationMicroservicePrototype.Services.Abstract;

using Contracts.Notification.NotificationDataTypes;
using Models;

public interface INotificationGenerator
{
    public Notification GenerateNotification(string type, string data);
}