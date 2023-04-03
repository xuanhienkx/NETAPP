using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace AutoBackup
{
    class FtpHelp
    {

        private string _ftpServer = "";
        private string _ftpFolderName = "";
        private string _ftpUserID = "";
        private string _ftpPassword = "";
        //private string _ftpServer = "";
        //private string _ftpServer = "";
        public string ftpServer { 
            get{return _ftpServer;}
            set { _ftpServer = value; }
        }
        public string ftpFolderName
        {
            get { return _ftpFolderName; }
            set { _ftpFolderName = value; }
        }

        public string ftpUserID
        {
            get { return _ftpUserID; }
            set { _ftpUserID = value; }
        }
        public string ftpPassword
        {
            get { return _ftpPassword; }
            set { _ftpPassword = value; }
        }

        public FtpHelp()
        {

        }
        public FtpHelp(string _ftpServer, string _ftpFolderName, string _ftpUserID, string _ftpPassword)
        {
            ftpServer = _ftpServer;
            ftpFolderName = _ftpFolderName;
            ftpUserID = _ftpUserID;
            ftpPassword = _ftpPassword;
        }

        public string UploadFileToServer(string strDir, FileInfo fn)
        {
            FTPDeleteFile(new Uri("ftp://" + ftpServer + "/" + ftpFolderName + "/" + strDir + "/" + fn.Name), new NetworkCredential(ftpUserID, ftpPassword));
            if (FTPUploadFile("ftp://" + ftpServer + "/" + ftpFolderName + "/" + strDir + "/", fn.Name, fn, new NetworkCredential(ftpUserID, ftpPassword)))
            {
                //WriteLog("Upload Succeeded", fnLog);
                //if upload ok then delete zip file to respace driver
                return "Upload file "+ fn.Name +" succeeded";

            }
            else
            {
                return "Upload "+  fn.Name +" failed";
                //WriteLog("Upload Failed", fnLog);
            }
        }

        private bool FTPDeleteFile(Uri serverUri, NetworkCredential Cred)
        {
            bool retVal = true;
            FtpWebResponse response = null;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = Cred;
                response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message != "The remote server returned an error: (550) File unavailable (e.g., file not found, no access).")
                {
                    //Console.WriteLine("Error in FTPDeleteFile - " + ex.Message);
                    if (response != null)
                    {
                        response.Close();
                    }
                    retVal = false;
                }
                //MyLogManager.Error("Error in FTPDeleteFile - " + ex.Message);
            }
            return retVal;
        }

        private bool FTPUploadFile(String serverPath, String serverFile, FileInfo LocalFile, NetworkCredential Cred)
        {
            bool retVal = true;
            FtpWebResponse response = null;
            try
            {
                FTPMakeDir(new Uri(serverPath + "/"), Cred);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverPath + serverFile);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = Cred;
                byte[] buffer = new byte[10240];    // Read/write 10kb   
                using (FileStream sourceStream = new FileStream(LocalFile.ToString(), FileMode.Open))
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        int bytesRead;
                        do
                        {
                            bytesRead = sourceStream.Read(buffer, 0, buffer.Length);
                            requestStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead > 0);
                    }
                    response = (FtpWebResponse)request.GetResponse();
                    response.Close();

                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error in FTPUploadFile - " + ex.Message);
                MyLogManager.Error("Error in FTPUploadFile - " + ex.Message);
                if (response != null)
                {
                    response.Close();
                }
                retVal = false;
            }
            return retVal;
        }

        private bool FTPMakeDir(Uri serverUri, NetworkCredential Cred)
        {
            bool retVal = false;
            FtpWebResponse response = null;
            try
            {
                string[] ar = serverUri.ToString().Split('/');
                string makeDirUri = ar[0] + "//" + ar[2] + "/";
                for (int i = 3; i < ar.GetUpperBound(0); i++)
                {
                    makeDirUri += ar[i] + "/";
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(makeDirUri));
                    request.KeepAlive = true;
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    request.Credentials = Cred;
                    try
                    {
                        response = (FtpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message != "The remote server returned an error: (550) File unavailable (e.g., file not found, no access).")
                        {
                            retVal = false;
                        }
                        //MyLogManager.Error(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error in FTPMakeDir - " + ex.Message);
                retVal = false;
                MyLogManager.Error("Error in FTPMakeDir - " + ex.Message);
                if (response != null)
                {
                    response.Close();
                }
            }
            return retVal;
        }

    }
}
