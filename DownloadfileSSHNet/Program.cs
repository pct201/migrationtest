using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadfileSSHNet
{
    class Program
    {
        public static string _strSFTP_Url = string.Empty;
        public static string _strSFTP_UserName = string.Empty;
        public static string _strSFTP_Password = string.Empty;
        public static int _strSFTP_Port = 22;
        public static string _strSFTP_Path = string.Empty;
        public static string _strSFTP_LocalPath = string.Empty;
        public static string _strSFTPLogPath = string.Empty;
        public static string _strSFTPSourceFileName = string.Empty;
        public static string _strSFTPDestiFileName = string.Empty;
        public static string _strSFTPArchivePath = string.Empty;

        static void Main(string[] args)
        {
            _strSFTP_Url = args[0];
            _strSFTP_UserName = args[1];
            _strSFTP_Password = args[2];
            _strSFTP_Port = Convert.ToInt32(args[3]);
            _strSFTP_Path = args[4];
            _strSFTP_LocalPath = args[5];
            _strSFTPLogPath = args[6];
            _strSFTPSourceFileName = args[7];
            _strSFTPDestiFileName = args[8];
            _strSFTPArchivePath = "Archive";

            //_strSFTP_Url = "192.168.1.120";
            //_strSFTP_UserName = "mrunal";
            //_strSFTP_Password = "tatva123";
            //_strSFTP_Port = 22;
            //_strSFTP_Path = "\\";
            //_strSFTP_LocalPath = "D:\\eRIMS2 Applications\\dev\\sonic\\Documents\\Downloads";
            //_strSFTPLogPath = "D:\\eRIMS2 Applications\\dev\\sonic\\Documents\\Downloads";
            //_strSFTPSourceFileName = "export.xls";
            //_strSFTPDestiFileName = "export.xls";
            //_strSFTPArchivePath = "Archive";

            try
            {

                if (!Directory.Exists(_strSFTP_LocalPath + "/" + _strSFTPArchivePath))
                    Directory.CreateDirectory(_strSFTP_LocalPath + "/" + _strSFTPArchivePath);

                if (File.Exists(_strSFTP_LocalPath + "/" + _strSFTPDestiFileName))
                {
                    File.Copy(_strSFTP_LocalPath + "/" + _strSFTPDestiFileName, _strSFTP_LocalPath + "/" + _strSFTPArchivePath + "/" + System.DateTime.Now.ToString("MMddyyhhmmss") + _strSFTPDestiFileName);
                }
            }
            catch (Exception ex)
            {
                WriteLog("Error While Copying File to Archive Folder", _strSFTPLogPath, false);
            }

            bool Is_Success = false;

            WriteLog("Event file Downloading Process Started", _strSFTPLogPath, false);
            Is_Success = DownloadFile(_strSFTP_Path, _strSFTPSourceFileName, _strSFTP_LocalPath, _strSFTPDestiFileName);
            WriteLog("Event file Downloading Process Ended", _strSFTPLogPath, false);

            if (Is_Success)
            {
                try
                {
                    WriteLog("Copying file To Archive Folder SFTP Server", _strSFTPLogPath, false);

                    UploadFile(_strSFTPArchivePath, _strSFTPDestiFileName, _strSFTPDestiFileName, _strSFTP_LocalPath);

                    WriteLog("File Copied Successfully ", _strSFTPLogPath, false);
                    //MoveFolderToArchive(_strSFTPArchivePath, _strSFTPDestiFileName, _strSFTPDestiFileName, _strSFTP_LocalPath);

                    //WriteLog("Deleting SFTP file from SFTP Server", _strSFTPLogPath, false);
                    //WriteLog(_strSFTP_Path + "/" + _strSFTPSourceFileName, _strSFTPLogPath, false);
                    //DeleteFile(_strSFTP_Path, _strSFTPSourceFileName);
                }
                catch (Exception ex)
                {
                    WriteLog("Error while Copying File", _strSFTPLogPath, false);
                    WriteLog("Error while Copying File :" + ex, _strSFTPLogPath, false);
                    throw ex;
                }
            }
        }

        //private static void DownloadFile(SftpClient client, SftpFile file, string directory)
        //{
        //    Console.WriteLine("Downloading {0}", file.FullName);
        //    using (Stream fileStream = File.OpenWrite(Path.Combine(directory, file.Name)))
        //    {
        //        client.DownloadFile(file.FullName, fileStream);
        //    }
        //}

        public static bool DownloadFile(string ftpDirectory, string FileName, string LocalDirectory, string NewLocalFileName)
        {
            var client = new SftpClient(_strSFTP_Url, _strSFTP_Port, _strSFTP_UserName, _strSFTP_Password);

            try
            {
                using (var myFile = File.Create(LocalDirectory + "/" + NewLocalFileName))
                {
                    myFile.Close();
                }

                WriteLog("SFTP sever connection established", _strSFTPLogPath, false);
                client.Connect();
                WriteLog("SFTP sever Connected", _strSFTPLogPath, false);

                WriteLog("Copying file from SFTP Server", _strSFTPLogPath, false);
                
                using (MemoryStream ms = new MemoryStream())
                {
                    var file = LocalDirectory + "/" + NewLocalFileName;
                    client.DownloadFile("/" + ftpDirectory + "/" + FileName, ms);
                    File.WriteAllBytes(file, ms.ToArray());
                }
                client.Disconnect();
                WriteLog("SFTP sever connection Closed", _strSFTPLogPath, false);

                
                File.WriteAllText(LocalDirectory + "/" + "temp.txt","Dummy");

                return true;
            }
            catch (Exception ex)
            {
                WriteLog("Error while SFTP sever Connection" + ex, _strSFTPLogPath, false);
                return false;
                throw ex;
            }
            finally
            {
                client.Disconnect();
            }

        }

        public static void UploadFile(string ftpDirectory, string SourceFileName, string DestiFileName, string LocalDirectory)
        {
            var client = new SftpClient(_strSFTP_Url, _strSFTP_Port, _strSFTP_UserName, _strSFTP_Password);

            try
            {
                client.Connect();
                var files = Directory.GetFiles(LocalDirectory, "export.xls");

                foreach (var file in files)
                {
                    using (MemoryStream file1 = new MemoryStream(File.ReadAllBytes(file)))
                    {
                        client.UploadFile(file1, ftpDirectory + "/" + System.DateTime.Now.ToString("MMddyyhhmmss") + DestiFileName, null);                        
                    }                    
                }                
                client.Disconnect();
            }
            catch (Exception ex)
            {
                WriteLog("Error while Moving File" + ex, _strSFTPLogPath, false);
                throw ex;
            }
            finally
            {
                client.Disconnect();
            }
        }

        public static void MoveFolderToArchive(string ftpDirectory, string SourceFileName, string DestiFileName, string LocalDirectory)
        {
            SftpClient client = new SftpClient(_strSFTP_Url, _strSFTP_Port, _strSFTP_UserName, _strSFTP_Password);
            client.Connect();

            try
            {
                //SftpFile file = client.Get(DestiFileName);
                //string eachFileNameInArchive = DestiFileName + "_" + DateTime.Now.ToString("MMddyyyy_HHmmss");//Change file name if the file already exists
                //file.MoveTo(_strSFTPArchivePath + "/" + eachFileNameInArchive);
                SftpFile eachRemoteFile = client.Get(DestiFileName);//Get first file in the Directory        

                if (eachRemoteFile.IsRegularFile)//Move only file
                {
                    bool eachFileExistsInArchive = CheckIfRemoteFileExists(client, ftpDirectory, eachRemoteFile.Name);

                    //MoveTo will result in error if filename alredy exists in the target folder. Prevent that error by cheking if File name exists
                    string eachFileNameInArchive = eachRemoteFile.Name;

                    if (eachFileExistsInArchive)
                    {
                        eachFileNameInArchive = eachFileNameInArchive + "_" + DateTime.Now.ToString("MMddyyyy_HHmmss");//Change file name if the file already exists
                    }
                    eachRemoteFile.MoveTo(ftpDirectory + eachFileNameInArchive);
                }

                client.Disconnect();
            }
            catch (Exception ex)
            {
                WriteLog("Error while Moving File" + ex, _strSFTPLogPath, false);
            }
            finally
            {
                client.Disconnect();
            }

        }

        /// <summary>
        /// Checks if Remote folder contains the given file name
        /// </summary>
        public static bool CheckIfRemoteFileExists(SftpClient sftpClient, string remoteFolderName, string remotefileName)
        {
            bool isFileExists = sftpClient
                                .ListDirectory(remoteFolderName)
                                .Any(
                                        f => f.IsRegularFile &&
                                        f.Name.ToLower() == remotefileName.ToLower()
                                    );
            return isFileExists;
        }

        private static bool SFtpDirectoryExists(string directory)
        {
            bool IsExists = true;
            var client = new SftpClient(_strSFTP_Url, _strSFTP_Port, _strSFTP_UserName, _strSFTP_Password);

            try
            {
                client.Connect();
                IsExists = client.Exists(directory);
                client.Disconnect();
            }
            catch (Exception ex)
            {
                IsExists = false;
            }
            finally
            {
                client.Disconnect();
            }

            return IsExists;
        }


        public static void WriteLog(string sMessage, string Path, bool isError)
        {
            StreamWriter objSw = null;
            string sFolderName = string.Empty;
            string sFilePath = string.Empty;



            if (isError)
            {
                sFolderName = Path + @"\Error Logs\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\";
                sFilePath = sFolderName + "EmailNotificationError.log";
            }
            else
            {
                sFolderName = Path + @"\General Log\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\";
                sFilePath = sFolderName + "Console.log";
            }

            try
            {
                if (!Directory.Exists(sFolderName))
                    Directory.CreateDirectory(sFolderName);

                objSw = new StreamWriter(sFilePath, true);
                objSw.WriteLine(DateTime.Now.ToString() + " :- " + sMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                objSw = new StreamWriter(sFilePath, true);
                objSw.WriteLine("Error While Writing the Log :-" + DateTime.Now.ToString() + " :- " + ex.Message + Environment.NewLine);
            }
            finally
            {
                if (objSw != null)
                {
                    objSw.Flush();
                    objSw.Dispose();
                    objSw = null;
                }
            }
        }
    }
}
