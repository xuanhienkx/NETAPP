using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace InterStock
{
    public class Log
    {
        public Log()
        {
        }
        public Log(string filePath)
        {
            LogFilePath = filePath;
        }
        private string mLogFilePath;
        public string LogFilePath
        {
            get { return mLogFilePath; }
            set { mLogFilePath = value; }
        }
        public void writeLog(string message)
        {
            if (LogFilePath == null) return;
            FileInfo oFileInfo = new FileInfo(LogFilePath);
            DirectoryInfo oDirInfo = new DirectoryInfo(oFileInfo.DirectoryName);
            if (!oDirInfo.Exists)
                oDirInfo.Create();
            if (!oFileInfo.Exists)
            {
                StreamWriter w = oFileInfo.CreateText();
                w.Write("{0} -- ", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                w.WriteLine("{0}", message);
                w.Flush();
                w.Close();
            }
            else
            {
                lock (oFileInfo)
                {
                    FileStream fs = oFileInfo.Open(FileMode.Append, FileAccess.Write, System.IO.FileShare.Read);
                    StreamWriter w = new StreamWriter(fs);
                    w.Write("{0} -- ", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    w.WriteLine("{0}", message);
                    w.Flush();
                    w.Close();
                }
            }
        }
        public void writeLogFile(string message, string LogFilePath)
        {
            FileInfo oFileInfo = new FileInfo(LogFilePath);
            DirectoryInfo oDirInfo = new DirectoryInfo(oFileInfo.DirectoryName);
            if (!oDirInfo.Exists)
                oDirInfo.Create();
            if (!oFileInfo.Exists)
            {
                StreamWriter w = oFileInfo.CreateText();
                w.Write("{0} -- ", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                w.WriteLine("{0}", message);
                w.Flush();
                w.Close();
            }
            else
            {
                lock (oFileInfo)
                {
                    FileStream fs = oFileInfo.Open(FileMode.Append, FileAccess.Write, System.IO.FileShare.Read);
                    StreamWriter w = new StreamWriter(fs);
                    w.Write("{0} -- ", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    w.WriteLine("{0}", message);
                    w.Flush();
                    w.Close();
                }
            }
        }
    }
}
