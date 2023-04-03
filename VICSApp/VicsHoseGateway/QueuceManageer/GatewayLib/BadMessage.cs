namespace GatewayLib
{
    using System;

    public class BadMessage
    {
        private object _Content;
        private string _id;
        private string _Label;

        public object Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                this._Content = value;
            }
        }

        public string ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string Label
        {
            get
            {
                return this._Label;
            }
            set
            {
                this._Label = value;
            }
        }
    }
}

