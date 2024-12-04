namespace NotificationMicroservicePrototype.Application.Abstract;

using Models;

public interface INotificationService
{
    Task SendNotificationToAllAsync(Notification notification);
}