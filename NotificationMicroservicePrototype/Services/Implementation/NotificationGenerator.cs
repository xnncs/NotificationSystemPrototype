namespace NotificationMicroservicePrototype.Services.Implementation;

using System.Text.Json;
using Abstract;
using Contracts.Notification.NotificationDataTypes;
using Models;

public class NotificationGenerator : INotificationGenerator
{
    private readonly ILogger<NotificationGenerator> _logger;

    public NotificationGenerator(ILogger<NotificationGenerator> logger)
    {
        _logger = logger;
    }

    public Notification GenerateNotification(string type, string data)
    {
        return Notification.CreateByMessage(
            GenerateNotificationMessage(type, data));
    }

    private string GenerateNotificationMessage(string type, string data)
    {
        switch (type)
        {
            case "role-assign":
                try
                {
                    RoleAssignNotificationData notificationData =
                        JsonSerializer.Deserialize<RoleAssignNotificationData>(data)!;
                    return notificationData.GenerateMessage();
                }
                catch (Exception exception)
                {
                    _logger.LogError("Received exception while trying to box data to role-assign message, {0}", exception.Message);
                    throw;
                }
            case "role-unassign":
                try
                {
                    RoleUnassignNotificationData notificationData =
                        JsonSerializer.Deserialize<RoleUnassignNotificationData>(data)!;
                    return notificationData.GenerateMessage();
                }
                catch (Exception exception)
                {
                    _logger.LogError("Received exception while trying to box data to role-unassign message, {0}", exception.Message);
                    throw;
                }
            default:
                throw new Exception($"Unknown notification type {type}");
        }
    }
}