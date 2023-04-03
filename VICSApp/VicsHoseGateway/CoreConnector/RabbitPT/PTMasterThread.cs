using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using InterStock;

namespace HOGW_PT_Dealer
{
    class PTMasterThread
    {
        static Log log = new Log();
        public static void writeLog(string text)
        {
            lock (log)
            {
                log.writeLog(text);
            }
        }
        static public void setLogPath(string path)
        {
            log.LogFilePath = path;
        }
        private List<Thread> lstThread = new List<Thread>();

        public List<Thread> LstThread
        {
            get { return lstThread; }
            set { lstThread = value; }
        }
        public void StopThreads()
        {
            try
            {
                writeLog("Wait for shutting down the threads...");
                if (lstThread != null)
                {
                    foreach (Thread thread in lstThread)
                    {
                        if (thread != null)
                            thread.Abort();
                    }
                    lstThread.Clear();
                }
                writeLog("All threads have just been stopped!");
            }
            catch (ThreadAbortException ex)
            {
                string err = ex.Message + "; Inner Exception: " + ex.InnerException.Message;
                writeLog(err);
            }
        }
        public void AddThread(Thread thread)
        {
            lstThread.Add(thread);
        }
        public int CountThread
        {
            get { return lstThread.Count; }
        }
    }
}
