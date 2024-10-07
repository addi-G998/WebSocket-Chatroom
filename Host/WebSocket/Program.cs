using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSocketSharp;
using WebSocketSharp.Server;

namespace csharp_server
{
    public class Echo : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Received message from Echo client: " + e.Data);
            Sessions.Broadcast(e.Data);
            //Send(e.Data);
        }
    }

    public class EchoAll : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Received message from EchoAll client: " + e.Data);
            Sessions.Broadcast(e.Data);
        }
    }


    class Program
    {

       
        static void Main(string[] args)
        {
            WebSocketServer wssv = new WebSocketServer("ws://<Host Public IP:open Port>"); // like ws://77.120.35.134:8080

            wssv.AddWebSocketService<Echo>("/Broadcast");

            wssv.AddWebSocketService<Echo>("/Echo");
            wssv.AddWebSocketService<EchoAll>("/EchoAll");

            wssv.Start();
            Console.WriteLine("WS server started on ws://<Host Public IP:open Port>/Echo");
            Console.WriteLine("WS server started on ws://<Host Public IP:open Port>/EchoAll");

            Console.ReadKey();
            wssv.Stop();
        }
    }
}