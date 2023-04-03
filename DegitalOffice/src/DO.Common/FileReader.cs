using System.Runtime.InteropServices;

namespace DO.Common;

public abstract class FileReader
{
    // Fields
    protected bool IsOpen;
    protected BinaryReader Reader;
    protected string FileName;
    protected long FileLength;

    // Methods
    protected FileReader(string sFileName)
    {
        this.FileName = sFileName;
    }

    public void Open()
    {
        var input = new FileStream(this.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        this.Reader = new BinaryReader(input);
        this.FileLength = input.Length;
        this.Length = 0L;
        this.IsOpen = true;
    }

    public void Close()
    {
        this.IsOpen = false;
        this.Reader.Close();
        this.Reader = null;
    }

    public abstract bool Read();

    // Properties
    public bool Eof
    {
        get
        {
            if (this.IsOpen)
            {
                return (this.Length >= this.FileLength);
            }
            return true;
        }
    }

    public long Length { get; set; }

    public abstract int NumberOfRecords { get; }
}

public class Reader<T> : FileReader where T : struct
{
    public Reader(string sFileName) : base(sFileName)
    {
    }


    public override bool Read()
    {
        if (base.Eof) return false;
        GCHandle handle = GCHandle.Alloc(base.Reader.ReadBytes(Marshal.SizeOf(typeof(T))), GCHandleType.Pinned);
        this.Data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
        base.Length += Marshal.SizeOf(typeof(T));
        handle.Free();
        return true;

    }


    // Properties
    public T Data { get; private set; }
    public override int NumberOfRecords => (int)(base.Length / ((long)Marshal.SizeOf(typeof(T))));

}