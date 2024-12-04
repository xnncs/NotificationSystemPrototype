namespace NotificationMicroservicePrototype.Services.Abstract;

using Models;

public interface INotificationService
{
    Task SendNotificationToAllAsync(Notification notification);
}