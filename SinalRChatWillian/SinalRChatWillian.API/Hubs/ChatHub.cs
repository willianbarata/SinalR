using Microsoft.AspNetCore.SignalR;

namespace SinalRChatWillian.API.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string group, string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinGroup(string user, string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.Group(group).SendAsync("ReceiveMessage", 
                "Administrador", 
                $"{user} se juntou ao Group: {group}");
        }
    }
}
