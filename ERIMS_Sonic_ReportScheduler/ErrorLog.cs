using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ERIMS_ACI_ReportScheduler
{
    class ErrorLog
    {
        public static void WriteLog(string sMessage, string Path, bool isError)
        {
            StreamWriter objSw = null;
            string sFolderName = string.Empty;
            string sFilePath = string.Empty;

            if (isError)
            {
                sFolderName = Path + @"\Error Logs\";
                sFilePath = sFolderName + "Error.log";
            }
            else
            {
                sFolderName = Path + @"\General Logs\";
                sFilePath = sFolderName + "GeneralInfo.log";
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
