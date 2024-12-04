namespace NotificationMicroservicePrototype.Endpoints;

using Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Models;
using Services.Abstract;

public static class NotificationsEndpoints
{
    public static IEndpointRouteBuilder MapNotificationEndpoints(this IEndpointRouteBuilder app)
    {
        IEndpointRouteBuilder endpoints = app.MapGroup("api/notifications");

        endpoints.MapPost("", PostAsync);
        
        return endpoints;
    }

    private static async Task<Ok> PostAsync(SendNotificationRequest request, INotificationService notificationService)
    {
        Notification notification = Notification.Create(request.Message);
        await notificationService.SendNotificationToAllAsync(notification);
        
        return TypedResults.Ok();
    }
}