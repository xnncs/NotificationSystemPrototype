namespace NotificationMicroservicePrototype.Contracts.Notification.NotificationDataTypes;

using System.Text.Json.Serialization;

public class RoleAssignNotificationData : BaseNotificationData
{
    [JsonPropertyName("role")]
    public string Role { get; set; }

    public override string GenerateMessage()
    {
        return $"Поздравляем! Вы были приняты на роль {Role}";
    }
}