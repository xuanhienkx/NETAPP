namespace HoseContinentialGT.Messaages
{ 
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct Message_3D
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public char[] messageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public char[] firm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public char[] confirmNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=1)]
        public char[] replyCode;
        public int offset;
        public string Time
        {
            get
            {
                return new string(this.time).Trim();
            }
        }
        public int Firm
        {
            get
            {
                return Convert.ToInt32(new string(this.firm).Trim());
            }
        }
        public string ConfirmNumber
        {
            get
            {
                return new string(this.confirmNumber).Trim();
            }
        }
        public string ReplyCode
        {
            get
            {
                return new string(this.replyCode).Trim();
            }
        }
    }
}
