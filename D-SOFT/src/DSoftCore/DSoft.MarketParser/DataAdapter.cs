using DSoft.MarketParser.Common;

namespace DSoft.MarketParser
{
    internal class DataAdapter
    {
        private byte[] _buffer;
        private int _currentRecord;
        private string _filePath = string.Empty;
        private string _statusFile = string.Empty;
        private bool _isOpenned;
        private int _length;
        private string _tableName = string.Empty;
        private string _type = string.Empty;
        private string _recognitionPattern = string.Empty;
        private DateTime _currentDate = DateTime.MinValue.Date;
        private string _recognition = string.Empty;
        private bool _incremental;
        private List<Part> _fieldList = new List<Part>();
        private string _insertStatement = string.Empty;
        public bool Fetch()
        {
            if ((this._buffer == null) || !this._isOpenned)
            {
                return false;
            }
            if ((this._currentRecord + (this._length * 2)) > this._buffer.Length)
            {
                return false;
            }
            this._currentRecord += this._length;
            if (this._incremental)
            {
                int num = this._currentRecord / this._length;
                //new PrivateProfile(this._statusFile).WriteString(.(-213499323), this._type, num.ToString());
            }
            return true;
        }
    }
}
