using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Cursus.LMS.Service.Hubs;

[Authorize]
public class NotificationHub : Hub
{
    private static readonly Dictionary<string, string> _connections = new Dictionary<string, string>();

    public override Task OnConnectedAsync()
    {
        string userId = Context.UserIdentifier;
        if (userId != null)
        {
            _connections[userId] = Context.ConnectionId;
        }
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        string userId = Context.UserIdentifier;
        if (userId != null)
        {
            _connections.Remove(userId);
        }
        return base.OnDisconnectedAsync(exception);
    }

    public Task SendMessageToUser(string userId, string message)
    {
        if (_connections.TryGetValue(userId, out var connectionId))
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }
        return Task.CompletedTask;
    }
}