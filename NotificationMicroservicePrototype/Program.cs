using NotificationMicroservicePrototype.Endpoints;
using NotificationMicroservicePrototype.Services.Abstract;
using NotificationMicroservicePrototype.Services.Implementation;
using NotificationMicroservicePrototype.SignalR.Hubs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddScoped<INotificationService, NotificationService>();

services.AddOpenApi();

const string frontendUrl = "http://localhost:5001";
services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins(frontendUrl)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

services.AddSignalR();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.MapNotificationEndpoints();
app.MapHub<NotificationHub>("notificationHub");

app.Run();
