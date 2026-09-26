using Microsoft.AspNetCore.SignalR;
using NotificationService.Models;
using NotificationService.SignalR;

public class NotificationManager
{
    private readonly IHubContext<NotificationHub>
        _hubContext;

    public NotificationManager(
        IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotificationAsync(
        Notification notification)
    {
        await _hubContext.Clients.All.SendAsync(
            "ReceiveNotification",
            notification);
    }
}