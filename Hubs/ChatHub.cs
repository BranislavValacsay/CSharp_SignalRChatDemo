using Microsoft.AspNetCore.SignalR;
using SignalRChat.Helpers;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {/*
        public readonly PSRun _runMe;
        public ChatHub(PSRun runMe)
        {
            _runMe = runMe;
        }*/
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            //_runMe.StartPS("$psversiontable");
        }
    }
}