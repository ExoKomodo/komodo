using System;

namespace Komodo.Lib.Network
{
    public class Message
    {
        #region Public

        #region Constructors
        public Message()
        {
            Data = null;
            Endpoint = null;
            Id = Guid.Empty;
            TransactionId = Guid.Empty;
        }
        public Message(string data, string endpoint)
        {
            Data = data;
            Endpoint = endpoint;
            Id = Guid.NewGuid();
            TransactionId = Guid.Empty;
        }
        #endregion

        #region Members
        public string Data { get; set; }
        public string Endpoint { get; set; }
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        #endregion

        #endregion
    }
}