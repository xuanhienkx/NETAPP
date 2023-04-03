using System.IO;
using System.Runtime.InteropServices;
using Console.App;

namespace HoseStockTrader
{
    public class MessageLoader<T> where T : struct
    {
        private readonly string fileName;

        private BinaryReader reader;
        private long currentLength;
        private long lastVisitLength = 0L;

        public MessageLoader(string ctciPath, string messageFlag, string filePrefix)
        {
            this.fileName = Path.Combine(ctciPath, messageFlag, filePrefix + "_data.dat");
        }
        public MessageLoader(string prsPath, string file)
        {
            this.fileName = Path.Combine(prsPath, file);
        }

        public bool Open(long lastSize = 0)
        {
            if (!File.Exists(fileName))
            {
                Logger.Log("File {0} not found", fileName);
                Logger.ConsoleLog("File {0} not found", fileName);
                return false;
            }

            var input = new FileStream(this.fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            this.Length = input.Length;

            if (lastSize > 0 && lastVisitLength == 0)
                lastVisitLength = this.Length - lastSize;
            // reach to the last visit
            if (input.CanSeek || lastVisitLength > 0)
                input.Seek(lastVisitLength, SeekOrigin.Begin);
            else
                lastVisitLength = 0L;

            // doc lai security
            if (this.fileName.EndsWith("SECURITY.DAT") && lastVisitLength == this.Length)
            {
                lastVisitLength = 0L;
            }
            this.reader = new BinaryReader(input);
            this.currentLength = lastVisitLength;
            this.IsOpen = true;
            return IsOpen;
        }

        public void Close()
        {
            this.IsOpen = false;
            this.reader.Close();
            this.reader = null;
        }

        public bool Read(out T message)
        {
            if (IsEof)
            {
                message = default(T);
                return false;
            }

            var messageLength = Marshal.SizeOf(typeof(T));
            byte[] buffer = reader.ReadBytes(messageLength);
            if ((buffer.Length <= 0))
            {
                message = default(T);
                return false;
            }
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            message = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            currentLength += messageLength;
            lastVisitLength += messageLength;

            return true;
        }

        // Properties
        private bool IsEof
        {
            get
            {
                if (this.IsOpen)
                {
                    return (this.currentLength >= this.Length);
                }
                return true;
            }
        }

        public bool IsOpen { get; private set; }

        private long Length { get; set; }

        public int NumberOfRecords
        {
            get { return (int)(Length / ((long)Marshal.SizeOf(typeof(T)))); }
        }
    }
}
