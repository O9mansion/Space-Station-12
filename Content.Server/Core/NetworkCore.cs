using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

// Simple WebSocket server to handle player connections and player requests TODO: add a verification system
namespace Content.Server.Core
{
    public class NetworkCore
    {
        private HttpListener _listener;

        public NetworkCore()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://+:5000/ws/");
        }

        public async Task Start()
        {
            _listener.Start();
            Console.WriteLine("WebSocket server listening on ws://localhost:5000/ws/");

            while (true)
            {
                var context = await _listener.GetContextAsync();

                if (context.Request.IsWebSocketRequest)
                {
                    var wsContext = await context.AcceptWebSocketAsync(null);
                    _ = HandleClient(wsContext.WebSocket);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        private async Task HandleClient(WebSocket socket)
        {
            var buffer = new byte[1024];

            int tickRate = 20;
            TimeSpan tickInterval = TimeSpan.FromMilliseconds(1000.0 / tickRate);

            while (socket.State == WebSocketState.Open)
            {
                var receiveTask = socket.ReceiveAsync(buffer, System.Threading.CancellationToken.None);
                var delayTask = Task.Delay(tickInterval);
                await Task.WhenAny(receiveTask, delayTask);

                var completedTask = await Task.WhenAny(receiveTask, Task.Delay(tickInterval));
                if (completedTask == receiveTask)
                {
                    var result = await receiveTask;

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", System.Threading.CancellationToken.None);
                    }
                    else
                    {
                        var msg = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        Console.WriteLine($"Received: {msg}");

                        if (msg.StartsWith("Join"))
                        {
                            var name = msg.Substring(5);
                            var random = new Random();
                            int playerId = random.Next(100000, 999999);
                            var playerEntity = Managers.EntityManager.CreateEntity("Player", name, 0, 0);

                            var response = $"{{\"entityId\": {playerEntity.Id}, \"playerId\": {playerId}}}";
                            var responseBytes = Encoding.UTF8.GetBytes(response);
                            await socket.SendAsync(responseBytes, WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);
                        }
                    }
                }
            }
        }
    }
}
