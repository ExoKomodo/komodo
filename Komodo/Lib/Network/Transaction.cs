using System;

namespace Komodo.Lib.Network
{
    public sealed class Transaction
    {
        #region Constructors
        public Transaction() 
        {
            Id = Guid.NewGuid();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public readonly Guid Id;
        public Message Request
        {
            get
            {
                return _request;
            }
            set
            {
                _request = value;
                if (_request != null)
                {
                    _request.TransactionId = Id;
                }
            }
        }
        public Message Response
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;
                if (_response != null)
                {
                    _response.TransactionId = Id;
                }
            }
        }
        #endregion Public Members

        #region Private Members
        private Message _request;
        private Message _response;
        #endregion Private Members

        #endregion Members
    }
}