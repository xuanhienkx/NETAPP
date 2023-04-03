using System.Runtime.InteropServices;

namespace HoseContinentialGT.Messaages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DataPath
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        internal char[] Date;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        internal char[] BackupName; 
        internal string FolderName
        {
            get
            {
                return new string(BackupName).Trim();
            }
        }

        internal string OrderDate
        {
            get
            {
                return new string(this.Date).Trim();
            }
        }
    }
}