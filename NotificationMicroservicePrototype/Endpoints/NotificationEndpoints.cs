namespace NotificationMicroservicePrototype.Endpoints;

using Contracts;
using Contracts.Notification.HttpRequests;
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

    private static async Task<Ok> PostAsync(SendNotificationRequest request, INotificationService notificationService, INotificationGenerator notificationGenerator)
    {
        Notification notification = notificationGenerator.GenerateNotification(request.Type, request.Data);
        
        // TODO: Should be logic here
        if (request.To.Browser != null)
        {
            await notificationService.SendNotificationToAllAsync(notification);
        }
        
        return TypedResults.Ok();
    }
}