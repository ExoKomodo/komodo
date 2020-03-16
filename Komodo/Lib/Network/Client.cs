using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Komodo.Lib.Compression;

namespace Komodo.Lib.Network
{
    public class Client
    {
        #region Constructors
        public Client(string serverName, int port, SocketAsyncEventArgs socketArgs = null)
        {
            Port = port;
            try
            {
                var ipAddresses = Dns.GetHostAddresses(serverName);
                if (ipAddresses.Length == 0)
                {
                    throw new Exception("Host or server did not resolve to an IP");
                }
                IP = ipAddresses[0];
            }
            catch (Exception ex)
            {
                throw new Exception($"Client could not figure out the host address: {ex}");
            }
            _transactions = new ConcurrentDictionary<Guid, Transaction>();
            _socketArguments = socketArgs == null ? new SocketAsyncEventArgs() : socketArgs;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public IPAddress IP;
        public int Port { get; set; }
        #endregion Public Members

        #region Protected Members
        protected ConcurrentDictionary<Guid, Transaction> _transactions { get; set; }
        protected SocketAsyncEventArgs _socketArguments { get; set; }
        #endregion Protected Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public Transaction Send<T>(T data, string endpoint) => SendAsync(data, endpoint).Result;
        public Transaction Send(string data, string endpoint) => SendAsync(data, endpoint).Result;
        public async Task<Transaction> SendAsync<T>(T data, string endpoint) => await SendAsync(JsonSerializer.Serialize<T>(data), endpoint);
        public async Task<Transaction> SendAsync(string data, string endpoint)
        {
            Transaction transaction = new Transaction();
            Message request = null;
            Message response = null;
            try
            {
                using (var clientSocket = new TcpClient())
                {
                    request = new Message(data, endpoint);
                    request.TransactionId = transaction.Id;

                    // Send request
                    var serializedObj = JsonSerializer.Serialize(request);
                    var socketData = Brotli.Compress(serializedObj);
                    await clientSocket.ConnectAsync(IP, Port);
                    var stream = clientSocket.GetStream();
                    await stream.WriteAsync(socketData);

                    // Read response
                    var tmp = new byte[1024];
                    var rawResponseData = new List<byte>();
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = await stream.ReadAsync(tmp);
                        rawResponseData.AddRange(tmp);
                    }
                    while (stream.DataAvailable && bytesRead != 0);
                    var responseData = Brotli.Decompress(rawResponseData.ToArray());

                    var responseString = Encoding.ASCII.GetString(responseData);
                    response = JsonSerializer.Deserialize<Message>(responseString);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return null;
            }
            transaction.Request = request;
            if (response != null)
            {
                transaction.Response = response;
            }
            _transactions[transaction.Id] = transaction;
            return transaction;
        }
        #endregion Public Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Protected Static Methods
        
        #endregion Protected Static Methods

        #endregion Static Methods
    }
}