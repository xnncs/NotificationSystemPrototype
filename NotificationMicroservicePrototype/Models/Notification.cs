namespace NotificationMicroservicePrototype.Models;

public class Notification
{
    public static Notification CreateByMessage(string message) => new Notification()
    {
        Message = message,
        Date = DateTime.UtcNow
    };
    
    
    public string Message { get; set; }
    public DateTime Date { get; set; }
}