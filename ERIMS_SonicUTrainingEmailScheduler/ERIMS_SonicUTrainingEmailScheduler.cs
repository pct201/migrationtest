using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Web;
using Winnovative.WnvHtmlConvert;

namespace ERIMS_SonicUTrainingEmailScheduler
{
    //*****************************************************//
    // This is a window service to send the scheduled report and Mail
    // Report will be sent to the recipient selected quarterly
    // Service is continuously running on system and invoke function
    //*****************************************************//

    public partial class ERIMS_SonicUTrainingEmailScheduler : ServiceBase
    {
        #region Public Variables

        bool flgSendEmail = true;
        bool _bStartMailReading = true;
        public string _strCsvPath = string.Empty;
        public string _strEvent_Run_Time_Interval = string.Empty;
        public string _strEvent_Run_Current_Date_Diff = string.Empty;
        public string _strStartDate = string.Empty;
        public string _strEndDate = string.Empty;
        public string _strFormatDateToDisplay = string.Empty;
        public string _strSMTPServer = string.Empty;
        public string _strSMTPmail = string.Empty;
        public string _strSMTPPwd = string.Empty;
        public string _strPort = string.Empty;
        public string _strSentMailSubjectFrmt = string.Empty;
        public string _strSMTPmailFrom = string.Empty;
        public int _ReadMailCount = -1;
        //public Imap4Client objImap4Client;
        public bool _First_Run = true;
        DateTime quarterDate = DateTime.Now;
        int quarterMonth;
        int quarterDay;

        public static string PDFLicenseKey
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["LicenseKey"]);
            }
        }

        #endregion

        public ERIMS_SonicUTrainingEmailScheduler()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Being Executed when Scheduler service starts
        /// </summary>
        /// <param name="args"></param>
        public void OnStart()
        {
            ReadConfigSetting();
            //Make event log entry to indicate starting of service
            EventLog.WriteEntry("ERIMS Sonic Mail Scheduler Started at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Sonic Mail Scheduler Started", _strCsvPath, false);

            //Create a thread for the function which send email
            Thread TSendMail = default(Thread);
            TSendMail = new System.Threading.Thread(SendReportAsAttachment);
            //Start the thread
            TSendMail.Start();
            TSendMail.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        /// <summary>
        /// Being Executed when Scheduler service stops
        /// </summary>
        protected override void OnStop()
        {
            EventLog.WriteEntry("ERIMS Sonic Mail Scheduler Stopped at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Sonic Mail Scheduler Stopped ", _strCsvPath, false);
        }

        //Files should be placed in folder respective to year and month
        public static void WriteLog(string sMessage, string Path, bool isError)
        {
            StreamWriter objSw = null;
            string sFolderName = string.Empty;
            string sFilePath = string.Empty;

            if (isError)
            {
                sFolderName = Path + @"\Error Logs\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\";
                sFilePath = sFolderName + "Error.log";
            }
            else
            {
                sFolderName = Path + @"\General Logs\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\";
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

        private void ReadConfigSetting()
        {
            _strCsvPath = ConfigurationSettings.AppSettings.Get("CSVPath");
            _strEvent_Run_Time_Interval = ConfigurationSettings.AppSettings.Get("Event_Run_Time_Interval");
            _strEvent_Run_Time_Interval = ConfigurationSettings.AppSettings.Get("Event_Run_Current_Date_Diff");
            _strStartDate = ConfigurationSettings.AppSettings.Get("StartDate");
            _strEndDate = ConfigurationSettings.AppSettings.Get("EndDate");
            _strFormatDateToDisplay = ConfigurationSettings.AppSettings.Get("DisplayDateFormat");
            _strSMTPServer = ConfigurationSettings.AppSettings.Get("SMTPServer");
            _strSMTPmail = ConfigurationSettings.AppSettings.Get("SMTPmail");
            _strSMTPPwd = ConfigurationSettings.AppSettings.Get("SMTPPwd");
            _strPort = ConfigurationSettings.AppSettings.Get("Port");
            _strSentMailSubjectFrmt = ConfigurationSettings.AppSettings.Get("SentMailSubjectFrmt");
            _ReadMailCount = Convert.ToInt32(ConfigurationSettings.AppSettings.Get("MailCount"));
            _strSMTPmailFrom = ConfigurationSettings.AppSettings.Get("SMTPmailFrom");
            _First_Run = true;
        }

        #region Private Methods

        /// <summary>
        /// Main Function which contains infinite loop and send report when date changed
        /// </summary>
        public void SendReportAsAttachment()
        {
            Thread.Sleep(1000);
            //Thread.Sleep(3600000);
            while (true)
            {
                object objMailSending = ConfigurationManager.AppSettings.Get("AllowMailSending");
                bool _bAllowMailSending = false;
                bool bOutMail;
                if (bool.TryParse(Convert.ToString(objMailSending), out bOutMail))
                    _bAllowMailSending = bOutMail;
                else
                    _bAllowMailSending = false;

                //Check send mail status for today
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"temp\"))
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"temp\");

                if (flgSendEmail && _bAllowMailSending)
                {
                    EventLog.WriteEntry("Total No of Database Connection String Found : " + ConfigurationManager.ConnectionStrings.Count.ToString());

                    for (int i = 1; i < ConfigurationManager.ConnectionStrings.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[i].ConnectionString))
                        {
                            ReportSendMail.strConn = ConfigurationManager.ConnectionStrings[i].ConnectionString;

                            //Send Email to the Employees having Training the the following Quarter
                            if (quarterDay == 1 && (quarterMonth == 1 || quarterMonth == 4 || quarterMonth == 7 || quarterMonth == 10))
                            {
                                SendMailEmployeesForRemainingTraining();

                            }

                            //Send Email to the Early Alert Location Manager having Training the the following Quarter
                            if (quarterDay == 1 && (quarterMonth == 1 || quarterMonth == 4 || quarterMonth == 7 || quarterMonth == 10))
                            {
                                SendMailToEarlyAlertLocationManagers();
                                SendMailToRLCMLocationManagers();
                            }
                        }
                    }
                    flgSendEmail = false;
                }

                //Stop Process For 1 Hour to reduce CPU Utilization
                Thread.Sleep(3600000);

                //service start at 9:00 AM everyday
                //get current date time and tomorrow date time with 9:00 am ::subtract that and get ms this is sleep time of thread

                //if (string.IsNullOrEmpty(_strEvent_Run_Time_Interval)) _strEvent_Run_Time_Interval = "09:00:00";

                //DateTime dtNextDateTime = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " " + _strServiceRunTime);
                //DateTime dtCurrentDateTime = DateTime.Now;

                //TimeSpan span = dtNextDateTime - dtCurrentDateTime;
                //int ms = (int)span.TotalMilliseconds;

                //if (ms > 0)
                //{
                //    EventLog.WriteEntry("Thread sleeps for next " + ms / 3600000 + " Hours");
                //    Thread.Sleep(ms);
                //    dtSchduleDate = DateTime.Today;
                //    flgSendEmail = true;
                //}

                ////if date changes set schedule date to today's date(new schedule date)
                //if (dtSchduleDate.Date < DateTime.Today.Date)
                //{
                //    dtSchduleDate = DateTime.Today;
                //    flgSendEmail = true;
                //}
            }
        }


        /// <summary>
        /// Send Mail To Early Alert Location Managers
        /// </summary>
        public void SendMailToEarlyAlertLocationManagers()
        {
            try
            {
                WriteLog("Executing SendMailToEarlyAlertLocationManagers", _strCsvPath, false);

                DataSet dsReportData = ReportSendMail.GetEmployeeTrainingDataForReport();
                DataTable dtReportData = dsReportData.Tables[0];
                DataTable dtReceipient = dsReportData.Tables[1];
                DataTable dtLocationIDs = dsReportData.Tables[2];

                WriteLog("Report Data Count : " + dtReportData.Rows.Count, _strCsvPath, false);
                WriteLog("Recipient count : " + dtReceipient.Rows.Count, _strCsvPath, false);
                WriteLog("Location count : " + dtLocationIDs.Rows.Count, _strCsvPath, false);

                System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                foreach (DataRow drLocationID in dtLocationIDs.Rows)
                {
                    WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                    sbRecorords.Clear();
                    if (dtReportData != null && dtReportData.Rows.Count > 0)
                    {
                        // DataRow[] drDetails = dtDetails.Select("Region='" + drRegion["Region"].ToString() + "'");
                        DataRow[] dtReportDataNew = ReportSendMail.GetEmployeeTrainingDataForReport().Tables[0].Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'");
                        DataTable dtLocation = ReportSendMail.SelectByPK(Convert.ToDecimal(drLocationID["PK_LU_Location_ID"])).Tables[0];

                        WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"] + " Data Rows : " + dtReportDataNew.Length, _strCsvPath, false);

                        sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
                        sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>Sonic U Training Report - " + 3 + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(dtLocation.Rows[0]["Sonic_Location_Code"]) + " - " + Convert.ToString(dtLocation.Rows[0]["dba"]) + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(dtLocation.Rows[0]["City"]) + ", " + Convert.ToString(dtLocation.Rows[0]["StateName"]) + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr>&nbsp;</tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;'><td><table border='1' cellspacing='0' cellpadding='0' style='border: black 0.5px solid'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25'>");
                        sbRecorords.Append("<td align='left' style='font-size:9pt'>Department</td>");
                        sbRecorords.Append("<td align='left' style='font-size:9pt'>Associate</td>");
                        sbRecorords.Append("<td align='left' style='font-size:9pt'>Job Title</td>");
                        sbRecorords.Append("<td align='left' style='font-size:9pt'>Remaining Training to be Taken</td></tr>");
                        //sbRecorords.Append("<tr><td><table border='1' style='border: black 0.5px solid'>");

                        foreach (DataRow dr in dtReportDataNew)
                        {
                            sbRecorords.Append("<tr align='left'  style='font-size:8.5pt'>");
                            sbRecorords.Append("<td align='left' style='font-size:9pt'>" + Convert.ToString(dr["Department"]) + "</td>");
                            sbRecorords.Append("<td align='left' style='font-size:9pt'>" + Convert.ToString(dr["Associate_Name"]) + "</td>");
                            sbRecorords.Append("<td align='left' style='font-size:9pt'>" + Convert.ToString(dr["Job_Title"]) + "</td>");
                            //sbRecorords.Append("<td align='left' style='font-size:9pt'>" + Convert.ToString(dr["Class_Name"]).Replace(",", "\n") + "</td></tr>");

                            if (Convert.ToString(dr["Class_Name"]).Contains(","))
                            {
                                string[] strClassName = Convert.ToString(dr["Class_Name"]).Split(',');
                                if (strClassName.Length > 0)
                                {
                                    sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt'>" + strClassName[0] + "</td></tr>");
                                }
                                for (int i = 1; i < strClassName.Length; i++)
                                {
                                    sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + strClassName[i] + "</td></tr>");
                                }
                            }
                            else
                            {
                                sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dr["Class_Name"]).Replace(",", "\n") + "</td></tr>");
                            }
                            sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

                        }
                        sbRecorords.Append("</table></td></tr></table>");
                    }
                    else
                    {
                        WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                        sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                        sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                        sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                    }

                    //Write HTML in to HtmlWriter
                    htmlWrite.WriteLine(sbRecorords.ToString());
                    DataRow[] drReceipientNew = ReportSendMail.GetEmployeeTrainingDataForReport().Tables[1].Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'");
                    SendMailPDF("Sonic U Remaining Training Report", "Sonic_U Remaining_Training_Report.pdf", _strSMTPmailFrom, sbRecorords.ToString(), drReceipientNew);
                }
            }
            catch(Exception ex)
            {
                WriteLog("Exception occurred : " + ex.Message, _strCsvPath, true);
                //event viewer
            }
        }

        /// <summary>
        /// Send Mail To Location Managers(Associate Training Report)
        /// </summary>
        public void SendMailToRLCMLocationManagers()
        {
            WriteLog("Executing SendMailToLocationManagers", _strCsvPath, false);
            DataTable dtReportData = ReportSendMail.GetEmployeeTrainingDataForReport().Tables[0];
            //DataTable dtRLCMUsersWithLocation = ReportSendMail.GetRLCMUsers().Tables[0];
            DataTable dtRLCMUsers = ReportSendMail.GetRLCMUsers().Tables[1];

            System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

            WriteLog("RLCM users count : " + dtRLCMUsers.Rows.Count, _strCsvPath, false);
            WriteLog("Total Report Data  : " + dtReportData.Rows.Count, _strCsvPath, false);

            foreach (DataRow drRLCM in dtRLCMUsers.Rows)
            {
                WriteLog("RLCM user Employee Id : " + drRLCM["FK_Employee_Id"], _strCsvPath, false);
                sbRecorords.Clear();
                if (dtReportData != null && dtReportData.Rows.Count > 0)
                {
                    DataTable dtLocation = ReportSendMail.SelectLocation_By_RLCM(Convert.ToDecimal(drRLCM["FK_Employee_Id"])).Tables[0];

                    WriteLog("Location count : " + dtLocation.Rows.Count + " for RLCM user : " + drRLCM["FK_Employee_Id"], _strCsvPath, false);
                    //DataTable dtLocation = ReportSendMail.SelectLocation_By_RLCM(Convert.ToDecimal(22746)).Tables[0];

                    if (dtLocation != null && dtLocation.Rows.Count > 0)
                    {
                        foreach (DataRow drLoc in dtLocation.Rows)
                        {
                            WriteLog("Location ID: " + drLoc["PK_LU_Location_ID"], _strCsvPath, false);
                            
                            DataTable dtDept = ReportSendMail.SelectAllDepartment().Tables[0];
                            foreach (DataRow drDept in dtDept.Rows)
                            {                                
                                //DataRow[] dtReportNew = ReportSendMail.GetEmployeeTrainingDataForReport().Tables[0].Select("PK_LU_Location_ID = '" + drLoc["PK_LU_Location_ID"].ToString() + "' and Department='" + drDept["Department"].ToString() + "'");
                                DataRow[] dtReportNew = dtReportData.Select("PK_LU_Location_ID = '" + drLoc["PK_LU_Location_ID"].ToString() + "' and Department='" + drDept["Department"].ToString() + "'");
                                WriteLog("RLCM user : " + drRLCM["FK_Employee_Id"] + " and Location ID: " + drLoc["PK_LU_Location_ID"] + " and Department ID : " + drDept["Department"]+" and Rows : "+dtReportNew.Length, _strCsvPath, false);

                                sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
                                sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>Sonic U Training Report - " + 3 + "</td></tr>");
                                sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(drLoc["dba1"]) + "</td></tr>");
                                sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(drLoc["City"]) + ", " + Convert.ToString(drLoc["FLD_state"]) + "</td></tr>");
                                sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr>&nbsp;</tr>");
                                sbRecorords.Append("<tr style='font-weight: bold;'><td><table border='1' cellspacing='0' cellpadding='0' style='border: black 0.5px solid'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25'>");
                                sbRecorords.Append("<td align='left' style='font-size:9pt'>Department</td>");
                                sbRecorords.Append("<td align='left' style='font-size:9pt'>Associate</td>");
                                sbRecorords.Append("<td align='left' style='font-size:9pt'>Job Title</td>");
                                sbRecorords.Append("<td align='left' style='font-size:9pt'>Remaining Training to be Taken</td></tr>");
                                //sbRecorords.Append("<tr><td><table border='1' style='border: black 0.5px solid'>");
                                if (dtReportNew.Length > 0)
                                {
                                    foreach (DataRow dr in dtReportNew)
                                    {
                                        sbRecorords.Append("<tr align='left'  style='font-size:8.5pt'>");
                                        sbRecorords.Append("<td align='left' style='font-size:9pt'>" + Convert.ToString(dr["Department"]) + "</td>");
                                        sbRecorords.Append("<td align='left' style='font-size:9pt'>" + Convert.ToString(dr["Associate_Name"]) + "</td>");
                                        sbRecorords.Append("<td align='left' style='font-size:9pt'>" + Convert.ToString(dr["Job_Title"]) + "</td>");
                                        //sbRecorords.Append("<td align='left' style='font-size:9pt'>" + Convert.ToString(dr["Class_Name"]).Replace(",", "\n") + "</td></tr>");

                                        if (Convert.ToString(dr["Class_Name"]).Contains(","))
                                        {
                                            string[] strClassName = Convert.ToString(dr["Class_Name"]).Split(',');
                                            if (strClassName.Length > 0)
                                            {
                                                sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt'>" + strClassName[0] + "</td></tr>");
                                            }
                                            for (int i = 1; i < strClassName.Length; i++)
                                            {
                                                sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + strClassName[i] + "</td></tr>");
                                            }
                                        }
                                        else
                                        {
                                            sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dr["Class_Name"]).Replace(",", "\n") + "</td></tr>");
                                        }
                                        sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                    }
                                    sbRecorords.Append("</table></td></tr></table>");
                                }
                                else
                                {
                                    sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                                    sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                                    sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");

                                    WriteLog("No data exists for Location ID: " + drLoc["PK_LU_Location_ID"] + "and Department ID : " + drDept["Department"], _strCsvPath, false);
                                }
                            }

                        }
                    }
                    else
                    {
                        WriteLog("No location exists for RLCM user : " + drRLCM["FK_Employee_Id"], _strCsvPath, false);
                    }
                    //Write HTML in to HtmlWriter
                    htmlWrite.WriteLine(sbRecorords.ToString());
                    //DataRow []test=drRLCM.ItemArray.

                    SendMailPDFMAnager("Sonic U Remaining Training Report", "Sonic_U_Remaining_Training_Report.pdf", _strSMTPmailFrom, sbRecorords.ToString(), drRLCM);
                }
                else
                {
                    WriteLog("No data found ", _strCsvPath, false);
                }


            }
        }

        /// <summary>
        /// Send Mail To System Administrator after importing the data for the Job Codes 
        /// </summary>
        public void SendMailToAdminFoNewJobCodes()
        {
            DataTable dtAdminRecepient = ReportSendMail.GetAdminList().Tables[0];
            MemoryStream memorystream = new MemoryStream();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_strSMTPmailFrom);
            mail.Subject = "Sonic eRIMS2 - New Employee Job Codes Added";

            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.Port = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings.Get("Port"));
            mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
            mSmtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPmail"], ConfigurationManager.AppSettings["SMTPPwd"]);

            try
            {
                foreach (DataRow dr in dtAdminRecepient.Rows)
                {
                    mail.Body = "New Employee Job Codes were added during the Employee data import today that did not previously exist in the Sonic U Training Required Classes table. In order for eRIMS2 to assign classes properly, the Sonic U Training Required Classes table will need to be updated as soon as possible to keep training assignments current. Please edit the Required Classes table via the following Sonic eRIMS2 menu selection: Administrator, Lookup Table Maintenance, Sonic U Training, Required Classes and click on the 'Add Training for New Job Codes' button.";
                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(Convert.ToString(dr["Email"])));
                    mSmtpClient.Send(mail);
                    mail.To.Clear();
                }
            }

            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for" + ex.Message + ",Stack Trace:" + ex.StackTrace);
            }
        }


        #region Mail Send Method

        //private void SendMail(String strReportTitle, String strFileNameToSave, String strFirstName, String strLastName, String strMailFrom, StringWriter sw, DataTable dtRecipients)
        //{

        //    string strPath = AppDomain.CurrentDomain.BaseDirectory + @"temp\" + strFileNameToSave.Replace(".xls", "") + System.DateTime.Now.ToString("MMddyyhhmmss") + ".xls";

        //    File.WriteAllText(strPath, sw.ToString());

        //    bool blnHTML2Excel = false;
        //    string outputFiles = string.Empty;
        //    if (File.Exists(strPath))
        //    {
        //        string data = File.ReadAllText(strPath);
        //        data = data.Trim();
        //        HTML2Excel objHtml2Excel = new HTML2Excel(data);
        //        outputFiles = Path.GetFullPath(strPath).Replace(".xls", ".xlsx");
        //        objHtml2Excel.isGrid = isGrid;
        //        objHtml2Excel.overwriteBorder = false;
        //        blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
        //    }

        //    MemoryStream memorystream = new MemoryStream();
        //    //byte[] _bytes = Encoding.UTF8.GetBytes(sw.ToString());
        //    //memorystream.Write(_bytes, 0, _bytes.Length);
        //    //memorystream.Seek(0, SeekOrigin.Begin);

        //    //HTML2Excel objHtml2Excel = new HTML2Excel(data);
        //    //strMailFrom = "kunal.dobaria@server1.com";
        //    if (blnHTML2Excel)
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.From = new MailAddress(strMailFrom);
        //        mail.Subject = "eRIMS :: " + strReportTitle;
        //        memorystream = new MemoryStream(File.ReadAllBytes(outputFiles));
        //        Attachment atts = new Attachment(memorystream, strFileNameToSave.Replace(".xls", ".xlsx"));
        //        mail.Attachments.Add(atts);

        //        SmtpClient mSmtpClient = new SmtpClient();
        //        mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
        //        mSmtpClient.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings.Get("SMTPmail"), System.Configuration.ConfigurationManager.AppSettings.Get("SMTPPwd"));
        //        try
        //        {
        //            for (int i = 0; i < dtRecipients.Rows.Count; i++)
        //            {
        //                mail.Body = dtRecipients.Rows[i]["FirstName"].ToString() + " " + dtRecipients.Rows[i]["LastName"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thankyou!<br />" + strFirstName + " " + strLastName;
        //                mail.Body += "<br /> This is system generated message. Please do not reply.";
        //                mail.IsBodyHtml = true;
        //                mail.To.Add(new MailAddress(dtRecipients.Rows[i]["Email"].ToString()));
        //                mSmtpClient.Send(mail);
        //                mail.To.Clear();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
        //        }
        //        atts.Dispose();

        //        //if (File.Exists(strPath))
        //        //    File.Delete(strPath);
        //        //if (File.Exists(outputFiles))
        //        //    File.Delete(outputFiles);
        //    }
        //    else
        //    {
        //        EventLog.WriteEntry("Error in converting Report to excel for " + strReportTitle);
        //    }
        //}

        /// <summary>
        /// Send Email To Each Employee for Remaining Quarterly Training
        /// </summary>
        /// <param name="strMailFrom"></param>
        /// <param name="dtRecipients"></param>
        private void SendMailEmployeesForRemainingTraining()
        {
            WriteLog("Executing SendMailEmployeeswithoutAttachment", _strCsvPath, false);

            DataTable dtTraining = ReportSendMail.GetEmployeeTrainingData().Tables[0];
            MemoryStream memorystream = new MemoryStream();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_strSMTPmailFrom);
            mail.Subject = "Required Associated Sonic U Training This Quarter";

            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.Port = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings.Get("Port"));
            mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
            mSmtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPmail"], ConfigurationManager.AppSettings["SMTPPwd"]);

            try
            {
                for (int i = 0; i < dtTraining.Rows.Count; i++)
                {
                    WriteLog("Sending email to : " + dtTraining.Rows[i]["EmailTo"], _strCsvPath, true);
                    mail.Body = "You are scheduled to take and complete the following training this quarter:";
                    mail.Body += "<br/>" + (dtTraining.Rows[i]["Class_Name"].ToString()).Replace(",", "");
                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(dtTraining.Rows[i]["EmailTo"].ToString()));
                    try
                    {
                        mSmtpClient.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error in sending email to : " + dtTraining.Rows[i]["EmailTo"], _strCsvPath, true);
                    }
                    mail.To.Clear();
                }
            }

            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for" + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Executed SendMailEmployeeswithoutAttachment", _strCsvPath, true);
            }
            WriteLog("Executed SendMailEmployeeswithoutAttachment", _strCsvPath, false);
        }

        /// <summary>
        /// Send Email To the Administrator for the list of Employees
        /// </summary>
        /// <param name="strMailFrom"></param>
        /// <param name="dtTraining"></param>
        /// <param name="dtRecipients"></param>
        private void SendMailToAdministratorForPrivateEmployeeEmails()
        {
            WriteLog("Executing SendMailToAdministrator()", _strCsvPath, true);

            DataTable dtTrainingAdministrator = ReportSendMail.GetEmployeeTrainingData().Tables[1];
            DataTable dtAdminRecepient = ReportSendMail.GetAdminList().Tables[0];

            WriteLog("Training Administrator Rows Count : "+dtTrainingAdministrator.Rows.Count, _strCsvPath, true);
            WriteLog("Admin recipient Rows Count : " + dtAdminRecepient.Rows.Count, _strCsvPath, true);

            MemoryStream memorystream = new MemoryStream();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_strSMTPmailFrom);
            mail.Subject = "Potential Personal E-Mails in HR Data";

            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.Port = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings.Get("Port"));
            mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
            mSmtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPmail"], ConfigurationManager.AppSettings["SMTPPwd"]);

            try
            {
                foreach (DataRow dr in dtAdminRecepient.Rows)
                {
                    try
                    {
                        if (dtTrainingAdministrator.Rows.Count > 0)
                        {
                            mail.Body = "The following employees may have personal e-mails in their HR data:";
                            for (int i = 0; i < dtTrainingAdministrator.Rows.Count; i++)
                            {
                                mail.Body += "<br/>" + (dtTrainingAdministrator.Rows[i]["Email_Administrator"].ToString()).Replace(",", "");
                                mail.IsBodyHtml = true;
                            }
                        }
                        else
                        {
                            mail.Body = "There are not any employees having personal e-mails in their HR data:";
                        }

                        mail.To.Add(new MailAddress(Convert.ToString(dr["Email"])));
                        mSmtpClient.Send(mail);

                        mail.To.Clear();
                        WriteLog("Email sent to", _strCsvPath, false);
                    }
                    catch(Exception ex)
                    {                        
                        EventLog.WriteEntry("Error in Sending Mail "+ ex.Message + ",Stack Trace:" + ex.StackTrace);
                        WriteLog("Exception : " + ex.Message, _strCsvPath, true);
                    }
                }
            }

            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for" + ex.Message + ",Stack Trace:" + ex.StackTrace);
            }
            WriteLog("Executed SendMailToAdministrator()", _strCsvPath, true);
        }

        ///// <summary>
        ///// Send Mail Function
        ///// </summary>
        ///// <param name="strReportTitle"></param>
        ///// <param name="strFileNameToSave"></param>
        ///// <param name="strFirstName"></param>
        ///// <param name="strLastName"></param>
        ///// <param name="strMailFrom"></param>
        ///// <param name="strFilePath"></param>
        ///// <param name="dtRecipients"></param>
        ///// <param name="FK_Security_Id"></param>
        //private void SendMail(String strReportTitle, String strFileNameToSave, String strFirstName, String strLastName, String strMailFrom, string strFilePath, DataTable dtRecipients, decimal FK_Security_Id)
        //{
        //    DataTable dtTemp = null;
        //    MemoryStream memorystream = new MemoryStream();
        //    //strMailFrom = "kunal.dobaria@server1.com";

        //    bool blnHTML2Excel = false;
        //    string outputFiles = string.Empty;
        //    if (File.Exists(strFilePath))
        //    {
        //        string data = File.ReadAllText(strFilePath);
        //        data = data.Trim();
        //        HTML2Excel objHtml2Excel = new HTML2Excel(data);
        //        outputFiles = Path.GetFullPath(strFilePath).Replace(".xls", ".xlsx");
        //        objHtml2Excel.isGrid = isGrid;
        //        blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
        //    }

        //    if (blnHTML2Excel)
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.From = new MailAddress(strMailFrom);
        //        mail.Subject = "eRIMS Sonic :: " + strReportTitle;
        //        memorystream = new MemoryStream(File.ReadAllBytes(outputFiles));
        //        Attachment att = new Attachment(memorystream, strFileNameToSave.Replace(".xls", ".xlsx"));
        //        mail.Attachments.Add(att);

        //        SmtpClient mSmtpClient = new SmtpClient();
        //        mSmtpClient.Port = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings.Get("Port"));
        //        mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
        //        mSmtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPmail"], ConfigurationManager.AppSettings["SMTPPwd"]);
        //        try
        //        {
        //            dtTemp = dtRecipients.Copy();
        //            //dtTemp.DefaultView.RowFilter = "ISNULL(Use_Folder,0) = 0";
        //            DataTable dtRecipientMails = dtTemp.DefaultView.ToTable();

        //            for (int i = 0; i < dtRecipientMails.Rows.Count; i++)
        //            {
        //                mail.Body = dtRecipientMails.Rows[i]["FirstName"].ToString() + " " + dtRecipientMails.Rows[i]["LastName"].ToString() + ",<br /><br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thank You!<br />" + strFirstName + " " + strLastName;
        //                mail.Body += "<br /><br /> This is system generated message. Please do not reply.";
        //                mail.IsBodyHtml = true;
        //                mail.To.Add(new MailAddress(dtRecipientMails.Rows[i]["Email"].ToString()));
        //                mSmtpClient.Send(mail);
        //                mail.To.Clear();
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
        //        }
        //        att.Dispose();
        //    }
        //    else
        //    {
        //        EventLog.WriteEntry("Error in converting Report to excel for " + strReportTitle);
        //    }
        //}

        /// <summary>
        /// Send Mail PDF
        /// </summary>
        /// <param name="strReportTitle"></param>
        /// <param name="strFileNameToSave"></param>
        /// <param name="strFirstName"></param>
        /// <param name="strLastName"></param>
        /// <param name="strMailFrom"></param>
        /// <param name="sw"></param>
        /// <param name="dtRecipients"></param>
        protected void SendMailPDF(String strReportTitle, String strFileNameToSave, String strMailFrom, String sw, DataRow[] drRecipients)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + @"temp\" + strFileNameToSave.Replace(".pdf", "") + System.DateTime.Now.ToString("MMddyyhhmmss") + ".pdf";

            bool blnHTML2PDF = false;
            Byte[] pdfByte = null;

            PdfConverter objPdf = new PdfConverter();
            //string _strHtmltoPDFConverterKey = "5M/VxNXE0NPE0srUxNfVytXWyt3d3d0=";
            objPdf.LicenseKey = PDFLicenseKey;
            objPdf.PdfDocumentOptions.TopMargin = 20;
            objPdf.PdfDocumentOptions.LeftMargin = 20;
            objPdf.PdfDocumentOptions.RightMargin = 20;
            objPdf.PdfDocumentOptions.BottomMargin = 20;
            objPdf.PdfDocumentOptions.ShowHeader = false;
            objPdf.PdfDocumentOptions.ShowFooter = false;
            objPdf.PdfDocumentOptions.EmbedFonts = false;
            objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
            objPdf.RightToLeftEnabled = false;
            objPdf.PdfSecurityOptions.CanPrint = true;
            objPdf.PdfSecurityOptions.CanEditContent = true;
            objPdf.PdfSecurityOptions.UserPassword = "";
            objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Landscape;
            objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
            objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";
            pdfByte = objPdf.GetPdfBytesFromHtmlString(sw.ToString());

            System.IO.File.WriteAllBytes(strPath, pdfByte);

            if (File.Exists(strPath))
            {
                blnHTML2PDF = true;
            }

            MemoryStream memorystream = new MemoryStream();

            if (blnHTML2PDF)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(strMailFrom);
                mail.Subject = "eRIMS :: " + strReportTitle;
                memorystream = new MemoryStream(File.ReadAllBytes(strPath));
                Attachment atts = new Attachment(memorystream, strFileNameToSave);
                mail.Attachments.Add(atts);

                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
                mSmtpClient.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings.Get("SMTPmail"), System.Configuration.ConfigurationManager.AppSettings.Get("SMTPPwd"));
                try
                {
                    //for (int i = 0; i < dtRecipients.Rows.Count; i++)
                    //{
                    foreach (DataRow drRecipient in drRecipients)
                    {
                        mail.Body = drRecipient["First_Name"].ToString() + " " + drRecipient["Last_Name"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thankyou!<br />";
                        mail.Body += "<br /> This is system generated message. Please do not reply.";
                        mail.IsBodyHtml = true;
                        mail.To.Add(new MailAddress(drRecipient["Email"].ToString()));
                        mSmtpClient.Send(mail);
                        mail.To.Clear();
                    }
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                }
                atts.Dispose();

                if (File.Exists(strPath))
                    File.Delete(strPath);
            }
            else
            {
                EventLog.WriteEntry("Error in converting Report to PDF for " + strReportTitle);
            }
        }

        /// <summary>
        /// Send Mail PDF
        /// </summary>
        /// <param name="strReportTitle"></param>
        /// <param name="strFileNameToSave"></param>
        /// <param name="strFirstName"></param>
        /// <param name="strLastName"></param>
        /// <param name="strMailFrom"></param>
        /// <param name="sw"></param>
        /// <param name="dtRecipients"></param>
        protected void SendMailPDFMAnager(String strReportTitle, String strFileNameToSave, String strMailFrom, String sw, DataRow drRecipients)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + @"temp\" + strFileNameToSave.Replace(".pdf", "") + System.DateTime.Now.ToString("MMddyyhhmmss") + ".pdf";

            bool blnHTML2PDF = false;
            Byte[] pdfByte = null;

            PdfConverter objPdf = new PdfConverter();
            //string _strHtmltoPDFConverterKey = "5M/VxNXE0NPE0srUxNfVytXWyt3d3d0=";
            objPdf.LicenseKey = PDFLicenseKey;
            objPdf.PdfDocumentOptions.TopMargin = 20;
            objPdf.PdfDocumentOptions.LeftMargin = 20;
            objPdf.PdfDocumentOptions.RightMargin = 20;
            objPdf.PdfDocumentOptions.BottomMargin = 20;
            objPdf.PdfDocumentOptions.ShowHeader = false;
            objPdf.PdfDocumentOptions.ShowFooter = false;
            objPdf.PdfDocumentOptions.EmbedFonts = false;
            objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
            objPdf.RightToLeftEnabled = false;
            objPdf.PdfSecurityOptions.CanPrint = true;
            objPdf.PdfSecurityOptions.CanEditContent = true;
            objPdf.PdfSecurityOptions.UserPassword = "";
            objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Landscape;
            objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
            objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";
            pdfByte = objPdf.GetPdfBytesFromHtmlString(sw.ToString());

            System.IO.File.WriteAllBytes(strPath, pdfByte);

            if (File.Exists(strPath))
            {
                blnHTML2PDF = true;
            }

            MemoryStream memorystream = new MemoryStream();

            if (blnHTML2PDF)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(strMailFrom);
                mail.Subject = "eRIMS :: " + strReportTitle;
                memorystream = new MemoryStream(File.ReadAllBytes(strPath));
                Attachment atts = new Attachment(memorystream, strFileNameToSave);
                mail.Attachments.Add(atts);

                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
                mSmtpClient.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings.Get("SMTPmail"), System.Configuration.ConfigurationManager.AppSettings.Get("SMTPPwd"));
                try
                {
                    //for (int i = 0; i < dtRecipients.Rows.Count; i++)
                    //{
                    // foreach (DataRow drRecipient in drRecipients)
                    //{
                    mail.Body = drRecipients["First_Name"].ToString() + " " + drRecipients["Last_Name"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thankyou!<br />";
                    mail.Body += "<br /> This is system generated message. Please do not reply.";
                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(drRecipients["Email"].ToString()));
                    mSmtpClient.Send(mail);
                    mail.To.Clear();
                    //}
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                }
                atts.Dispose();

                if (File.Exists(strPath))
                    File.Delete(strPath);
            }
            else
            {
                EventLog.WriteEntry("Error in converting Report to PDF for " + strReportTitle);
            }
        }
        #endregion
        #endregion
    }
}
