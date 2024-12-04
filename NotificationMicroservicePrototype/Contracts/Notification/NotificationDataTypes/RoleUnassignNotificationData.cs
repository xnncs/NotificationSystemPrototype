namespace NotificationMicroservicePrototype.Contracts.Notification.NotificationDataTypes;

using System.Text.Json.Serialization;

public class RoleUnassignNotificationData : BaseNotificationData
{
    [JsonPropertyName("role")]
    public string Role { get; set; }

    public override string GenerateMessage()
    {
        return $"Вы были сняты с роли {Role}";
    }
}