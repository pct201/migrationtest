using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace ERIMS_Sonic_EmailScheduler
{
    class clsGeneral
    {
        public static string strCsvPath = string.Empty;
        public static string strSMTPServer = string.Empty;
        public static string strSMTPmail = string.Empty;
        public static string strSMTPPwd = string.Empty;
        public static string strPort = string.Empty;
        public static string strSentMailSubjectFrmt = string.Empty;
        public static string strMailAttachmentStorePath = string.Empty;
        public static string strMailServerType = string.Empty;
        public static int ReadMailCount = -1;
        public clsGeneral()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Files should be placed in folder respective to year and month
        public static void WriteLog(string sMessage, bool isError)
        {
            StreamWriter objSw = null;
            string sFolderName = string.Empty;
            string sFilePath = string.Empty;

            if (isError)
            {
                sFolderName = strCsvPath + @"\Error Logs\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\";
                sFilePath = sFolderName + "Error.log";
            }
            else
            {
                sFolderName = strCsvPath + @"\General Logs\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\";
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


        public static string ExtractEmailReply(string text, string address)
        {
            var regexes = new List<Regex>() { new Regex("From:\\s*" + Regex.Escape(address), RegexOptions.IgnoreCase),                        
                        new Regex("\\n.*On.*(\\r\\n)?wrote:\\r\\n", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                        new Regex("-+original\\s+message-+\\s*$", RegexOptions.IgnoreCase),
                        new Regex("-+Original\\s+Message-+\\s*$", RegexOptions.IgnoreCase),
                        new Regex("from:\\s*$", RegexOptions.IgnoreCase),
                        new Regex("^>.*$", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                        new Regex("\\n.*On.*<(\\r\\n)?" + Regex.Escape(address) + "(\\r\\n)?>", RegexOptions.IgnoreCase),
                        new Regex("From:.*" + Regex.Escape(address), RegexOptions.IgnoreCase),
                        new Regex("\\n\\n.*On.*(\\r\\n)?" + Regex.Escape(address) + "(\\r\\n)?", RegexOptions.IgnoreCase),
                        new Regex("<" + Regex.Escape(address) + ">", RegexOptions.IgnoreCase),
                        new Regex(Regex.Escape(address) + "\\s+wrote:", RegexOptions.IgnoreCase)
                    };

            var index = text.Length;

            foreach (var regex in regexes)
            {
                var match = regex.Match(text);

                if (match.Success && match.Index < index)
                    index = match.Index;
            }

            return text.Substring(0, index).Trim();
        }


        public static DataSet SelectAuthorByEmail(string strEmailId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecuritySelectByEmail");

            db.AddInParameter(dbCommand, "EmailId", DbType.String, strEmailId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Facility_Construction_Maintenance_Item table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFacilityConstructionMaintenanceItemByItemNumber(string Item_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemSelectByItem_Number");

            db.AddInParameter(dbCommand, "Item_Number", DbType.String, Item_Number);

            return db.ExecuteDataSet(dbCommand);
        }

    }
}
