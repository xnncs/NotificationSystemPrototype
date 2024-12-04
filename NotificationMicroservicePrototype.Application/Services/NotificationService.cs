namespace NotificationMicroservicePrototype.Application.Services;

using Abstract;
using Microsoft.AspNetCore.SignalR;
using Models;
using SignalR.Hubs;

public class NotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotificationToAllAsync(Notification notification)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
    }
}