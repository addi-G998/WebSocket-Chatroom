using System;
using WebSocketSharp;

namespace WebSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string userId = "User1";
            using (var ws = new WebSocket("ws://<Host ip:host port>/Echo"))
            {
                ws.OnMessage += (sender, e) =>
                    Console.WriteLine("Received from server: " + e.Data);

                ws.Connect();
                Console.WriteLine("Connected to ws://<Host ip:host port>/Echo");

                string message;
                while ((message = Console.ReadLine()) != null)
                {
                    string payload = $"{userId}: {message}";
                    ws.Send(payload);
                }
            }
        }
    }
}
