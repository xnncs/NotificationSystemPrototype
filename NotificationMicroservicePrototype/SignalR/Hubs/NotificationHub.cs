namespace NotificationMicroservicePrototype.SignalR.Hubs;

using Microsoft.AspNetCore.SignalR;
using Models;

public class NotificationHub : Hub
{
    public async Task NotifyAll(Notification notification)
    {
        await Clients.All.SendAsync("ReceiveNotification", notification);
    }
}