using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Tamir.SharpSsh;
using Tamir.SharpSsh.java.io;
using System.Configuration;
using System.Collections;

namespace DownloadSFTP
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

            bool Is_Success = false;

            WriteLog("Event file Downloading Process Started", _strSFTPLogPath, false);
            Is_Success = DownloadFile(_strSFTP_Path, _strSFTPSourceFileName, _strSFTP_LocalPath, _strSFTPDestiFileName);
            WriteLog("Event file Downloading Process Ended", _strSFTPLogPath, false);
        }

        public static bool DownloadFile(string ftpDirectory, string FileName, string LocalDirectory, string NewLocalFileName)
        {
            Sftp oSftp = new Sftp(_strSFTP_Url, _strSFTP_UserName, _strSFTP_Password);

            try
            {
                WriteLog("SFTP sever connection established", _strSFTPLogPath, false);
                oSftp.Connect(_strSFTP_Port);
                WriteLog("SFTP sever Connected", _strSFTPLogPath, false);

                List<string> lst = new List<string>();
                lst = DirectoryList(_strSFTP_Path);

                List<string> strFilterFile = lst.Where(item => item.StartsWith(_strSFTPSourceFileName)).ToList<string>();
                if (strFilterFile.Count > 0)
                {
                    WriteLog("Copying file from SFTP Server", _strSFTPLogPath, false);
                    oSftp.Get("/" + ftpDirectory + "/" + FileName, LocalDirectory + "/" + NewLocalFileName);
                    WriteLog("File Copied", _strSFTPLogPath, false);
                }
                else
                {
                    WriteLog("No File for Download", _strSFTPLogPath, false);
                }

                oSftp.Close();
                WriteLog("SFTP sever connection Closed", _strSFTPLogPath, false);
                return true;
            }
            catch (Exception ex)
            {
                WriteLog("Error while SFTP sever Connection", _strSFTPLogPath, false);
                return false;
                throw ex;
            }
            finally
            {
                oSftp.Close();
            }

        }

        /* List Directory Contents File/Folder Name Only */
        public static List<string> DirectoryList(string directory)
        {
            Sftp oSftp = new Sftp(_strSFTP_Url, _strSFTP_UserName, _strSFTP_Password);
            try
            {
                oSftp.Connect(_strSFTP_Port);

                ArrayList FileList = oSftp.GetFileList(directory);

                oSftp.Close();

                List<string> list = FileList.Cast<string>().ToList();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                oSftp.Close();
            }
            /* Return an Empty string Array if an Exception Occurs */
            return new List<string>();
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
