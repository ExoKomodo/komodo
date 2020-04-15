using System;
using Komodo.Lib.Network;

namespace Server
{
    class Program
    {
        static void Main(string[] _)
        {
            var server = new TCPServer(5000);
            server.RegisterAction(
                "a",
                delegate(Message message) {
                    Console.WriteLine($"Something with endpoint A: {message.Id}");
                }
            );
            server.Run();
        }
    }
}
