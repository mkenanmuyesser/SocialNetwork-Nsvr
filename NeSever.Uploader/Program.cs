using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace NeSever.Uploader
{
    class Program
    {
        const string ftpServerURI = "212.68.42.101";
        const string ftpUserID = "nesever";
        const string ftpPassword = "6otOrNMC,KHh";
        const string strCon = "Data Source=.;Initial Catalog=NeSeverCoreProjectDB_Prod;Persist Security Info=True;Integrated Security=True;MultipleActiveResultSets=True;";
        const string drive = "D"; // The local drive to save the backups to 
        const string LogFile = "C:\\Backup\\Logs\\SQLBackup.log"; // The location on the local Drive of the log files.
        const int DaysToKeep = 31;
        const DayOfWeek DayOfWeekToKeep = DayOfWeek.Sunday;

        private static string fnLog;
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            string filePath = @"D:\Backup";
            watcher.Path = filePath;
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.Created += Watcher_Created;
            new System.Threading.AutoResetEvent(false).WaitOne();

            //fnLog = RotateLog(new FileInfo(LogFile), DaysToKeep);
            //WriteLog("Starting Weekly Backup.", fnLog);
            //Backup();
            //WriteLog("Daily Backup Finished.", fnLog);
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                FileInfo fn = new FileInfo(e.FullPath);
                bool sonuc = FTPUploadFile("ftp://" + ftpServerURI + "/Backup/_" + DateTime.Now.Date.ToString("yyyyMMdd"), "/" + e.Name, fn, new NetworkCredential(ftpUserID, ftpPassword));
              
                if (sonuc)
                    WriteLog("Upload Succeeded", fnLog);
                else
                    Watcher_Created(sender, e);
            }
            catch (Exception)
            {
                Watcher_Created(sender, e);
            }
        }

        static void Backup()
        {
            SqlCommand comSQL = new SqlCommand("select name from sysdatabases where name not in('master','model','msdb','tempdb') order by name ASC", new SqlConnection(strCon));
            comSQL.Connection.Open();
            SqlDataReader dr = comSQL.ExecuteReader();
            while (dr.Read())
            {
                WriteLog("Backing Up Database - " + (string)dr["name"], fnLog);
                DriveInfo d = new DriveInfo("D");
                FileInfo oldfn;
                if (DateTime.Now.DayOfWeek != DayOfWeekToKeep)
                {
                    WriteLog("Deleting Backup from " + DaysToKeep.ToString() + " days ago", fnLog);
                    oldfn = new FileInfo(d.ToString() + "Backup\\" + (string)dr["name"] + "\\" + (string)dr["name"] + "_full_" + DateTime.Now.Subtract(TimeSpan.FromDays(14)).ToString("yyyyMMdd") + ".Bak");
                    FTPDeleteFile(new Uri("ftp://" + ftpServerURI + "/" + (string)dr["name"] + "/" + oldfn.Name), new NetworkCredential(ftpUserID, ftpPassword));
                }
                else
                {
                    WriteLog("Keeping Weekly Backup.", fnLog);
                }
                FileInfo fn = new FileInfo(d.ToString() + "Backup\\" + (string)dr["name"] + "\\" + (string)dr["name"] + "_full_" + DateTime.Now.ToString("yyyyMMdd") + ".Bak");
                if (File.Exists(fn.FullName))
                {
                    WriteLog("Deleting Backup Because it Already Exists.", fnLog);
                    File.Delete(fn.FullName);
                }
                Directory.CreateDirectory(fn.DirectoryName);
                SqlCommand comSQL2 = new SqlCommand("BACKUP DATABASE @db TO DISK = @fn;", new SqlConnection(strCon));
                comSQL2.CommandTimeout = 360;
                comSQL2.Connection.Open();
                comSQL2.Parameters.AddWithValue("@db", (string)dr["name"]);
                comSQL2.Parameters.AddWithValue("@fn", fn.FullName);
                WriteLog("Starting Backup", fnLog);
                comSQL2.ExecuteNonQuery();
                WriteLog("Backup Succeeded.", fnLog);
                WriteLog("Uploading Backup to FTP server", fnLog);
                FTPDeleteFile(new Uri("ftp://" + ftpServerURI + "/SQLBackup/" + (string)dr["name"] + "/" + fn.Name), new NetworkCredential(ftpUserID, ftpPassword));
                if (FTPUploadFile("ftp://" + ftpServerURI + "/SQLBackup/" + (string)dr["name"], "/" + fn.Name, fn, new NetworkCredential(ftpUserID, ftpPassword)))
                {
                    WriteLog("Upload Succeeded", fnLog);
                }
                else
                {
                    WriteLog("Upload Failed", fnLog);
                }
                comSQL2.Connection.Close();
            }
            comSQL.Connection.Close();
        }

        private static bool FTPDeleteFile(Uri serverUri, NetworkCredential Cred)
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
                    Console.WriteLine("Error in FTPDeleteFile - " + ex.Message);
                    if (response != null)
                    {
                        response.Close();
                    }
                    retVal = false;
                }
            }
            return retVal;
        }

        private static bool FTPUploadFile(String serverPath, String serverFile, FileInfo LocalFile, NetworkCredential Cred)
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
                Console.WriteLine("Error in FTPUploadFile - " + ex.Message);
                if (response != null)
                {
                    response.Close();
                }
                retVal = false;
            }
            return retVal;
        }

        private static bool FTPMakeDir(Uri serverUri, NetworkCredential Cred)
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
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in FTPMakeDir - " + ex.Message);
                retVal = false;
                if (response != null)
                {
                    response.Close();
                }
            }
            return retVal;
        }

        private static string RotateLog(FileInfo LogFileName, int Days)
        {
            string fNew = LogFileName.Directory.ToString() + DateTime.Now.ToString("\\\\yyyyMMdd_") + LogFileName.Name;
            string fOld = LogFileName.Directory.ToString() + DateTime.Now.Subtract(System.TimeSpan.FromDays(Days)).ToString("\\\\yyyyMMdd_") + LogFileName.Name;
            string fOldRecycler = "C:\\RECYCLER\\" + DateTime.Now.Subtract(System.TimeSpan.FromDays(Days)).ToString("yyyyMMdd_") + LogFileName.Name;
            if (File.Exists(fOld))
            {
                WriteLog("Deleting LogFile - " + fOld + " because it is over " + Days.ToString() + " Days old", "D:\\Backup\\Logs\\BackupLog");
                File.Move(fOld, fOldRecycler);
            }
            return fNew;
        }

        private static void WriteLog(string s, string fn)
        {
            Console.WriteLine(fn + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:ffff") + " - " + s);
            //File.AppendAllText(fn, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:ffff") + " - " + s + Environment.NewLine);
        }
    }
}
