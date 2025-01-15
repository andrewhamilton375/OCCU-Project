using Microsoft.AspNetCore.SignalR;
using OCCU_Assessment.Models;

namespace OCCU_Assessment.Hubs
{
    public class StatusHub : Hub
    {
        public async Task SendStatusUpdate(Status status)
        {
            await Clients.All.SendAsync("ReceiveStatusUpdate", status);
        }
    }
}
