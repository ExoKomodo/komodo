using System;

namespace Komodo.Lib.Network
{
    public sealed class Transaction
    {
        #region Public

        #region Constructors
        public Transaction() 
        {
            Id = Guid.NewGuid();
        }
        #endregion

        #region Members
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
        #endregion

        #endregion

        #region Private

        #region Members
        private Message _request;
        private Message _response;
        #endregion

        #endregion
    }
}