using Microsoft.AspNetCore.SignalR;

namespace MiGatoBoard.Hubs
{
    public class GatoHub:Hub
    {
        public GatoHub()
        {
            Console.WriteLine("Julio => Hub created");
        }
        public async Task JoinGame(string gameId)
        {
            Console.WriteLine("Julio => Join game");
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
        }

        public async Task SendMove(string gameId, int row, int col)
        {
            Console.WriteLine("Julio => Send move");
            await Clients.OthersInGroup(gameId).SendAsync("ReceiveMove", row, col);
        }

        public async Task SendMessage(string gameId, string message)
        {
            await Clients.OthersInGroup(gameId).SendAsync("ReceiveMessage",message);
        }
    }
}
