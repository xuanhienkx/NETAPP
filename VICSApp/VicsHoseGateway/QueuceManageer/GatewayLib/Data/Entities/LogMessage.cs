namespace GatewayLib.Data.Entities
{
    using System;

    public class LogMessage
    {
        private DateTime _date;
        private object _messageContent;
        private string _messageType;
        private bool _sentOrReceived;

        public DateTime Date
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }

        public object MessageContent
        {
            get
            {
                return this._messageContent;
            }
            set
            {
                this._messageContent = value;
            }
        }

        public string MessageType
        {
            get
            {
                return this._messageType;
            }
            set
            {
                this._messageType = value;
            }
        }

        public bool SentOrReceived
        {
            get
            {
                return this._sentOrReceived;
            }
            set
            {
                this._sentOrReceived = value;
            }
        }
    }
}

