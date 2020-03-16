using Komodo.Lib.Compression;
using Komodo.Lib.Network;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Server
{  
    public class TCPServer
    {
        #region Constructors
        public TCPServer(int port)
        {
            Port = port;
            _routes = new ConcurrentDictionary<string, Action<Message>>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public int Port { get; set; }
        #endregion Public Members

        #region Protected Members
        public ConcurrentDictionary<string, Action<Message>> _routes;
        #endregion Protected Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void RegisterAction([NotNull] string endpoint, [NotNull] Action<Message> messageHandler)
        {
            _routes[endpoint] = messageHandler;
        }
        public void Run() => RunAsync().Wait();
        public async Task RunAsync()
        {
            await Task.Yield();
            var listener = new TcpListener(IPAddress.Any, Port);

            listener.Start();

            var cancellation = new CancellationTokenSource();
            cancellation.Token.Register(() => listener.Stop());
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for connection...");
                    var client = await Task.Run(
                        () => listener.AcceptTcpClientAsync(),
                        cancellation.Token
                    );
                    HandleConnection(client);
                }
            }
            finally
            {
                cancellation.Cancel();
            }
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        protected async void HandleConnection([NotNull] TcpClient client)
        {
            await Task.Yield();
            using (client)
            {
                Console.WriteLine("Connection accepted");
                using (var networkStream = client.GetStream())
                {
                    try
                    {
                        var tmp = new byte[1024];
                        var rawData = new List<byte>();
                        int bytesRead = 0;
                        do
                        {
                            bytesRead = networkStream.Read(tmp);
                            rawData.AddRange(tmp);
                        } while (networkStream.DataAvailable && bytesRead != 0);


                        var data = Brotli.Decompress(rawData.ToArray());
                        var message = System.Text.Json.JsonSerializer.Deserialize<Message>(Encoding.ASCII.GetString(data));
                        Route(message);
                        networkStream.Write(Brotli.Compress(data));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }

        protected void Route([NotNull] Message message)
        {
            Action<Message> action = null;
            bool isActionRegistered = _routes.TryGetValue(message.Endpoint, out action);
            if (isActionRegistered)
            {
                action(message);
            }
            else
            {
                Console.Error.WriteLine($"Endpoint '{message.Endpoint}' not registered");
            }
        }

        #endregion Protected Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Protected Static Methods
        #endregion Protected Static Methods

        #endregion Static Methods
    }
}