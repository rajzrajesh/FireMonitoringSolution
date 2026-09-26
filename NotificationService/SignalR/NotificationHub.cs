using Microsoft.AspNetCore.SignalR;

namespace NotificationService.SignalR;

public class NotificationHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine(
            $"User Connected : {Context.ConnectionId}");

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(
        Exception? exception)
    {
        Console.WriteLine(
            $"User Disconnected : {Context.ConnectionId}");

        await base.OnDisconnectedAsync(exception);
    }
}