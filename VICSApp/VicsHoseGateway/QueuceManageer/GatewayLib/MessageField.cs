namespace GatewayLib
{
    using System;

    public class MessageField
    {
        private string _fieldName;
        private string _fieldValue;

        public string FieldName
        {
            get
            {
                return this._fieldName;
            }
            set
            {
                this._fieldName = value;
            }
        }

        public string FieldValue
        {
            get
            {
                return this._fieldValue;
            }
            set
            {
                this._fieldValue = value;
            }
        }
    }
}

