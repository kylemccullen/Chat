using Chat.Models;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs;

public class MessageHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task SendMessage(Message message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
