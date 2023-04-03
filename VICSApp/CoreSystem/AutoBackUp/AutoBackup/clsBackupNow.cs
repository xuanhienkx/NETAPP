using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Threading;

namespace AutoBackup
{
   public class clsBackUpNow
   {

      private string strCon = ConfigurationSettings.AppSettings["SQLConnection"];
      private string DBNames = ConfigurationSettings.AppSettings["DBName"];
      private string strDBName;
      private string strSavePath = ConfigurationSettings.AppSettings["SavePath"];
      private string strZipPath = ConfigurationSettings.AppSettings["ZipPath"];
      private string strDayToKeepFile = ConfigurationSettings.AppSettings["DayToKeepFile"];
      private FTPConfiguration FTPServer = new FTPConfiguration().GetConfig();
      private string strCurrentFolder;

      //string ftpServer = ConfigurationSettings.AppSettings["ftpServer"];
      //string ftpFolderName = ConfigurationSettings.AppSettings["ftpFolderName"];
      //string ftpUserID = ConfigurationSettings.AppSettings["ftpUsername"];
      //string ftpPassword = ConfigurationSettings.AppSettings["ftpPassword"];



      private SqlConnection DBConnection;
      private List<string> lstDBBackUpSussesed = new List<string>();
      private List<string> lstFileCompressSussesed = new List<string>();

      public clsBackUpNow()
      {

         try
         {
            DBConnection = new SqlConnection(strCon);
            strDBName = genDBNames(DBNames);
            strCurrentFolder = "Backup" + DateTime.Now.ToString("ddMMyyyy");
            strSavePath += strCurrentFolder;
            //strZipPath += strCurrentFolder;
         }
         catch (SqlException ex)
         {
            Console.WriteLine(ex.Message);
         }
      }


      private string genDBNames(string DBNames)
      {
         string str = "";
         string[] arrDBName = DBNames.Split(';');
         foreach (string name in arrDBName)
         {
            str += "'" + name + "',";
         }
         return str.TrimEnd(',');
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name=""></param>
      /// <returns></returns>

      #region BackupMethod



      public void ProcessBackup()
      {
         try
         {
            MyLogManager.Write("---------------------------------");
            MyLogManager.Write("Begin session");

            this.BackupDatabase();

            this.CompressFile();

            MyLogManager.Info("Starting upload file");
            for (int i = 0; i < FTPServer.ftpSettings.Count; i++)
            {
               if (FTPServer.ftpSettings[i].isActive == "1")
               {
                  this.UploadToServer(FTPServer.ftpSettings[i].serverAddress, FTPServer.ftpSettings[i].FolderName,
                     FTPServer.ftpSettings[i].Username, FTPServer.ftpSettings[i].Password);
               }
            }
            MyLogManager.Info("Upload file passed");

            //xoa cac file cu 
            this.DeleteOldFile();

            MyLogManager.Write("End session");
            Thread.Sleep(5000);

         }
         catch (Exception ex)
         {
            Console.WriteLine("Error: " + ex.Message);
            MyLogManager.Error("Session error:" + ex.Message);
         }
      }

      private void BackupDatabase()
      {
         MyLogManager.Info("Starting Backup");
         try
         {
            Directory.CreateDirectory(strSavePath);
            SqlCommand comSQL = new SqlCommand("select name from sysdatabases where name in(" + strDBName + ")",
               new SqlConnection(strCon)); // need to specify here which databases you do want to back up.
            comSQL.Connection.Open();
            SqlDataReader dr = comSQL.ExecuteReader();

            while (dr.Read())
            {
               MyLogManager.Info("Backing Up Database - " + (string) dr["name"]);
               FileInfo fn =
                  new FileInfo(strSavePath + "\\" + (string) dr["name"] + "_full_" +
                               DateTime.Now.ToString("ddMMyyyy_hhmm") + ".Bak");
               if (File.Exists(fn.FullName))
               {
                  MyLogManager.Warn("Deleting Backup Because it Already Exists.");
                  File.Delete(fn.FullName);
               }
               SqlCommand comSQL2 = new SqlCommand("BACKUP DATABASE @db TO DISK = @fn;", new SqlConnection(strCon));
               comSQL2.CommandTimeout = 3600;
               comSQL2.Connection.Open();
               comSQL2.Parameters.AddWithValue("@db", (string) dr["name"]);
               comSQL2.Parameters.AddWithValue("@fn", fn.FullName);
               try
               {
                  comSQL2.ExecuteNonQuery();
                  lstDBBackUpSussesed.Add(fn.FullName);
                  MyLogManager.Info("Backup database: " + (string) dr["name"] + " succeeded");
               }
               catch (Exception ex)
               {
                  Console.WriteLine("Error: " + ex.Message);
                  MyLogManager.Info("Error while Backup database: " + (string) dr["name"] + " Error detail:" +
                                    ex.Message);
               }
               finally
               {
                  comSQL2.Connection.Close();
               }

            }
            MyLogManager.Info("Backup passed");
            comSQL.Connection.Close();
         }
         catch (Exception ex)
         {
            Console.WriteLine("Error: " + ex.Message);
            MyLogManager.Info("Error while backup database processes: " + ex.Message);
         }
         finally
         {

         }
      }

      private void CompressFile()
      {
         MyLogManager.Info("Starting compress file");
         try
         {
            //string[] fileEntries = Directory.GetFiles(strSavePath);
            Directory.CreateDirectory(strZipPath);
            //foreach (string fullFileName in fileEntries)
            foreach (string fullFileName in lstDBBackUpSussesed)
            {
               string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\"),
                  fullFileName.Length - fullFileName.LastIndexOf("\\"));
               //MessageBox.Show(fullFileName);
               //MessageBox.Show(fileName);
               try
               {
                  MyLogManager.Info("Compressing file " + strZipPath + "\\" + fileName + ".zip");
                  FileInfo fn = new FileInfo(fullFileName);
                  if (fn.Exists)
                  {
                     ZipHelp.Zip(fullFileName, strZipPath + "\\" + fileName + ".zip", 4096);
                     lstFileCompressSussesed.Add(strZipPath + "\\" + fileName + ".zip");
                     MyLogManager.Info("File " + strZipPath + "\\" + fileName + ".zip" + " compress sussessful");
                  }
               }
               catch (ZipException zex)
               {
                  MyLogManager.Error("Error in zip file: " + fileName + " .Error descripton:" + zex.Message);
               }
            }
         }
         catch (Exception ex)
         {
            MyLogManager.Error("Error in zip process: " + ex.Message);
         }
         MyLogManager.Info("Compress file passed");
      }

      private void UploadToServer(string Server, string FolderName, string UserID, string Password)
      {

         try
         {
            //string[] fileEntries = Directory.GetFiles(strZipPath);
            //foreach (string fullFileName in fileEntries){
            //Thread sendTH;
            FtpHelp objFTPHelp = new FtpHelp(Server, FolderName, UserID, Password);
            foreach (string fullFileName in lstFileCompressSussesed)
            {
               try
               {

                  FileInfo fn = new FileInfo(fullFileName);
                  if (File.Exists(fn.FullName))
                  {
                     MyLogManager.Info("Uploading file " + fn.FullName + " to " + Server + "\\" + FolderName);
                     MyLogManager.Write(objFTPHelp.UploadFileToServer(strCurrentFolder, fn));
                  }
                  else
                  {
                     MyLogManager.Warn("File " + fn.FullName + " not exits, can not upload.");
                  }
               }
               catch (Exception ex)
               {
                  MyLogManager.Error("Error in upload file: " + fullFileName + " .Error descripton:" + ex.Message);
               }
            }


         }
         catch (Exception ex)
         {
            MyLogManager.Error("Error in upload process: " + ex.Message);
         }
      }

      private void DeleteOldFile()
      {
         MyLogManager.Info("Checking delete old file");

         try
         {
            int intDayToKeepFile = Convert.ToInt16(strDayToKeepFile);
            if (intDayToKeepFile <= 1) intDayToKeepFile = 2;
            //delete old bak file
            string[] fileEntries = Directory.GetFiles(strSavePath);
            foreach (string fullFileName in fileEntries)
            {
               FileInfo fi = new FileInfo(fullFileName);
               if ((DateTime.Now - fi.CreationTime).Days > intDayToKeepFile)
               {
                  MyLogManager.Info("Delete file " + fi.Name);
                  fi.Delete();
               }
            }

            //Xoa cac file zip
            //string[] zipfileEntries = Directory.GetFiles(strZipPath);
            //foreach (string fullFileName in zipfileEntries)
            //{
            //    FileInfo fi = new FileInfo(fullFileName);
            //        fi.Delete();
            //}


         }
         catch (Exception ex)
         {
            MyLogManager.Error("Error when delete file. " + ex.ToString());
         }
      }


      #endregion

   }
}
