using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fleck;


namespace TRSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new WebSocketServer("ws://127.0.0.1:9090");
            var clientConnections = new List<IWebSocketConnection>();
            server.Start(con =>
            {
                con.OnMessage += s =>
                {
                    Console.WriteLine("Message received from client - {0}", s);
                    clientConnections.ForEach(c =>
                    {
                        if (c != con) 
                            c.Send(s);
                    });  
                };
                con.OnOpen += () =>
                {
                    Console.WriteLine("A new connection is established");
                    clientConnections.Add(con);
                };
                con.OnClose += () =>
                {
                    Console.WriteLine("An existing connection is closed");
                    clientConnections.Remove(con);
                };
            });
            Console.WriteLine("Server listening on port 9090.. Press ENTER key to shutdown..");
            Console.ReadLine();
        }
    }
}
