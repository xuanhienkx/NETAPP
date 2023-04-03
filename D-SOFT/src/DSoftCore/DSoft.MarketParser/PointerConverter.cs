using System.Runtime.InteropServices;

namespace DSoft.MarketParser
{
    public static class PointerConverter
    {
        public static long ToLong(this IntPtr mem1)
        {
            if (mem1 != IntPtr.Zero)
            {
                byte[] ba = new byte[sizeof(long)];

                for (int i = 0; i < ba.Length; i++)
                    ba[i] = Marshal.ReadByte(mem1, i);
                long v = BitConverter.ToInt64(ba, 0);
                return v;
            }
            return 0;
        }

        public static int ToInt32(this IntPtr mem1)
        {
            if (mem1 != IntPtr.Zero)
            {
                byte[] ba = new byte[sizeof(int)];

                for (int i = 0; i < ba.Length; i++)
                    ba[i] = Marshal.ReadByte(mem1, i);
                int v = BitConverter.ToInt32(ba, 0);
                return v;
            }
            return 0;
        }

        public static double ToDouble(this IntPtr mem1)
        {
            if (mem1 != IntPtr.Zero)
            {
                byte[] ba = new byte[sizeof(double)];

                for (int i = 0; i < ba.Length; i++)
                    ba[i] = Marshal.ReadByte(mem1, i);
                double v = BitConverter.ToDouble(ba, 0);
                return v;
            }
            return 0;
        }

        public static IntPtr ToPtr(double val)
        {
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(double));

            byte[] byteDouble = BitConverter.GetBytes(val);
            Marshal.Copy(byteDouble, 0, ptr, byteDouble.Length);
            return ptr;
        }

        public static IntPtr ToPtr(int val)
        {
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(int));

            byte[] byteVal = BitConverter.GetBytes(val);
            Marshal.Copy(byteVal, 0, ptr, byteVal.Length);
            return ptr;
        }
    }
}
