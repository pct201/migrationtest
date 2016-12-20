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

namespace ERIMS_SonicUTraining_EmailScheduler
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
        DateTime quarterDate;
        public int quarterMonth = 0;
        public int quarterDay = 0;
        public DayOfWeek firstWeekDay;
        public DayOfWeek currentWeekDay;
        public DateTime nextMailSendDate;
        public string _strServiceRunTime = string.Empty;

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
        protected override void OnStart(string[] args)
        {
            ReadConfigSetting();
            //Make event log entry to indicate starting of service
            EventLog.WriteEntry("ERIMS Sonic U Training Email Scheduler Started at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Sonic U Training Email Scheduler Started", _strCsvPath, false);

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
            EventLog.WriteEntry("ERIMS Sonic U Training Email Scheduler Stopped at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Sonic U Training Email Scheduler Stopped ", _strCsvPath, false);
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
            try
            {
                WriteLog("Reading config file",_strCsvPath,false);

                _strCsvPath = ConfigurationSettings.AppSettings.Get("CSVPath");
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
                quarterDate = DateTime.Now;
                quarterMonth = quarterDate.Month;
                quarterDay = quarterDate.Day;
                _strServiceRunTime = ConfigurationSettings.AppSettings.Get("ServiceRunTime");
            }
            catch(Exception Ex)
            {
                WriteLog("Exception occurred while executing ReadConfigSetting() " + Ex.Message, _strCsvPath, false);
            }
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
                WriteLog("//////////////////////////////////Email Sending from SMTP server Starts Now ///////////////////////////////////////////////", _strCsvPath, false);

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
                    WriteLog("Total No of Database Connection String Found : " + ConfigurationManager.ConnectionStrings.Count.ToString(), _strCsvPath, false);

                    for (int i = 1; i < ConfigurationManager.ConnectionStrings.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[i].ConnectionString))
                        {
                            ReportSendMail.strConn = ConfigurationManager.ConnectionStrings[i].ConnectionString;
                                                        
                            if ((quarterDay == 1) && (quarterMonth == 1 || quarterMonth == 4 || quarterMonth == 7 || quarterMonth == 10))
                            {
                                //Send Email to the Employees having Training the the following Quarter
                                SendMailEveryQuarterToEmployees();
                            }

                            //For 1st and 2nd month of quarter send mail for first day of week
                            if (quarterMonth % 3 != 0)
                            {
                                var startDate = new DateTime(quarterDate.Year, quarterDate.Month, 1); //Fetch 1st date of current month
                                bool bSendMail = false;
                                int addDays = 7;
                                firstWeekDay = startDate.DayOfWeek;
                                if ((firstWeekDay == DayOfWeek.Sunday))
                                {
                                    addDays += 1;
                                }
                                else if ((firstWeekDay == DayOfWeek.Saturday))
                                {
                                    addDays += 2;
                                }

                                do
                                {
                                    if (startDate.Date.CompareTo(quarterDate.Date) == 0)
                                    {
                                        bSendMail = true;
                                        break;
                                    }
                                    startDate = startDate.AddDays(addDays);
                                }
                                while (startDate.Date.CompareTo(quarterDate) < 0);

                                if (bSendMail)
                                {
                                    SendMailToEarlyAlertLocationManagers();
                                    SendMailToRLCMLocationManagers();
                                }
                            }
                            //For 3rd month of quarter send mail for each weekday
                            else if (quarterDate.DayOfWeek != DayOfWeek.Saturday && quarterDate.DayOfWeek != DayOfWeek.Sunday)
                            {
                                SendMailToEarlyAlertLocationManagers();
                                SendMailToRLCMLocationManagers();
                            }

                            //Send Email to the Early Alert Location Manager having Training the the following Quarter
                            //if (quarterDay == 1 && (quarterMonth == 1 || quarterMonth == 4 || quarterMonth == 7 || quarterMonth == 10))
                            //{
                            //    SendMailToEarlyAlertLocationManagers();
                            //    SendMailToRLCMLocationManagers();
                            //}
                        }
                    }
                    flgSendEmail = false;
                }

                //Stop Process For 1 Hour to reduce CPU Utilization
                //Thread.Sleep(3600000);

                //service start at 9:00 AM everyday
                //get current date time and tomorrow date time with 9:00 am ::subtract that and get ms this is sleep time of thread
                if (string.IsNullOrEmpty(_strEvent_Run_Time_Interval)) _strEvent_Run_Time_Interval = "09:00:00";

                DateTime dtNextDateTime = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " " + _strServiceRunTime);
                DateTime dtCurrentDateTime = DateTime.Now;

                TimeSpan span = dtNextDateTime - dtCurrentDateTime;
                int ms = (int)span.TotalMilliseconds;

                if (ms > 0)
                {
                    EventLog.WriteEntry("Thread sleeps for next " + ms / 3600000 + " Hours");
                    Thread.Sleep(ms);
                    //dtSchduleDate = DateTime.Today;
                    flgSendEmail = true;
                }

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

                DataTable dtDepartFilter;

                System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                string strPrevDept, strPrevAssoName, strPrevJobTitle;
                strPrevDept = strPrevAssoName = strPrevJobTitle = "#";
                DataTable dtRptDataForCurLocAndDept, dtRptDataForCurLocAndDeptAndAssocName, dtRptDataForClass;
                DataTable dtUniqueDept, dtUniqueAssocName, dtUniqueJobTitle;

                foreach (DataRow drLocationID in dtLocationIDs.Rows) //Location wise
                {
                    WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                    sbRecorords.Clear();
                    try
                    {
                        if (dtReportData != null && dtReportData.Rows.Count > 0)
                        {
                            //Gets location detail
                            DataTable dtLocation = ReportSendMail.SelectByPK(Convert.ToDecimal(drLocationID["PK_LU_Location_ID"])).Tables[0];

                            //WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"] + " Report Data Rows Count : " + dtLocationWiseData.Length, _strCsvPath, false);
                            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
                            sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>Sonic U Training Report - Quarter " + ((quarterMonth - 1) / 3 + 1) + "</td></tr>");
                            sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(dtLocation.Rows[0]["Sonic_Location_Code"]) + " - " + Convert.ToString(dtLocation.Rows[0]["dba"]) + "</td></tr>");
                            sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(dtLocation.Rows[0]["City"]) + ", " + Convert.ToString(dtLocation.Rows[0]["StateName"]) + "</td></tr>");
                            sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr>&nbsp;</tr>");
                            sbRecorords.Append("<tr style='font-weight: bold;'><td><table border='1' cellspacing='0' cellpadding='0' style='border: black 0.5px solid'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25'>");
                            sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Department</td>");
                            sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Associate</td>");
                            sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Job Title</td>");
                            sbRecorords.Append("<td align='left' style='width=55%;font-size:9pt'>Remaining Training to be Taken</td></tr>");

                            string str = string.Empty;


                            //DataView dv = new DataView(dtReportData);
                            //DataTable distinctValues = dv.ToTable(true, "Department");

                            //DataRow[] dtTrainingData = dtReportData.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "' AND Department='" + dtDept.Rows[i]["Department"].ToString() + "' AND Associate_Name='" + dtDistinctData.Rows[i]["Associate_Name"].ToString() + "' AND Job_Title='" + dtDistinctData.Rows[i]["Job_Title"].ToString() + "'");

                            DataTable dtLocationData = dtReportData.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'").CopyToDataTable<DataRow>();
                            dtUniqueDept = dtLocationData.AsDataView().ToTable(true, "Department");
                            for (int i = 0; i < dtUniqueDept.Rows.Count; i++) //Fetches unique departments for the current Location
                            {
                                //sbRecorords.ToString().s
                                if (i % 2 != 0)
                                    str = "bgcolor=#eaeaea";
                                else
                                    str = "bgcolor=white";

                                if (strPrevDept != "#" && strPrevDept != dtUniqueDept.Rows[i]["Department"].ToString())
                                    sbRecorords.Append("<tr "+str +"><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

                                sbRecorords.Append("<tr align='left' style='width=15%;font-size:8.5pt' " + str + ">");
                                sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueDept.Rows[i]["Department"]) + "</td>");

                                //Fetch Data for current department and current location
                                dtRptDataForCurLocAndDept = dtLocationData.Select("Department='" + dtUniqueDept.Rows[i]["Department"].ToString() + "'").CopyToDataTable<DataRow>();

                                dtUniqueAssocName = dtRptDataForCurLocAndDept.AsDataView().ToTable(true, "Associate_Name");
                                for (int j = 0; j < dtUniqueAssocName.Rows.Count; j++) //Fetches unique associates for the current Location and department
                                {
                                    if (strPrevAssoName != "#" && strPrevAssoName != dtUniqueAssocName.Rows[j]["Associate_Name"].ToString()) //Add Blank row
                                        sbRecorords.Append("<tr " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

                                    if (j == 0)
                                        sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");
                                    else
                                        sbRecorords.Append("<tr " + str + "><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");

                                    //Fetch Data for current Associate_Name and current location and department
                                    dtRptDataForCurLocAndDeptAndAssocName = dtRptDataForCurLocAndDept.Select("Associate_Name='" + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString() + "'").CopyToDataTable<DataRow>();
                                    dtUniqueJobTitle = dtRptDataForCurLocAndDeptAndAssocName.AsDataView().ToTable(true, "Job_Title");
                                    for (int k = 0; k < dtUniqueJobTitle.Rows.Count; k++) //Fetches unique associates for the current Location and department
                                    {
                                        if (strPrevJobTitle != "#" && strPrevJobTitle != dtUniqueJobTitle.Rows[k]["Job_Title"].ToString()) //Add Blank row
                                            sbRecorords.Append("<tr " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

                                        if (k == 0)
                                            sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
                                        else
                                            sbRecorords.Append("<tr " + str + "><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
                                        //Fetches data for current location,Department,Associate_Name,Job title
                                        dtRptDataForClass = dtRptDataForCurLocAndDeptAndAssocName.Select("Job_Title='" + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString() + "'").CopyToDataTable<DataRow>();
                                        for (int m = 0; m < dtRptDataForClass.Rows.Count; m++)
                                        {
                                            if (m == 0)
                                                sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
                                            else
                                                sbRecorords.Append("<tr " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
                                        }
                                        //sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                        strPrevJobTitle = dtUniqueJobTitle.Rows[k]["Job_Title"].ToString();
                                    }
                                    strPrevJobTitle = "#";
                                    strPrevAssoName = dtUniqueAssocName.Rows[j]["Associate_Name"].ToString();
                                }
                                strPrevAssoName = "#";
                                strPrevDept = dtUniqueDept.Rows[i]["Department"].ToString();
                            }
                            strPrevDept = "#";
                        }
                        else
                        {
                            WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Exception occurred : " + ex.Message, _strCsvPath, false);
                        EventLog.WriteEntry("Error in function SendMailToEarlyAlertLocationManagers()" + ex.Message + ",Stack Trace:" + ex.StackTrace);
                    }
                    //Write HTML in to HtmlWriter
                    htmlWrite.WriteLine(sbRecorords.ToString());
                    DataRow[] drReceipientNew = dtReceipient.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'");
                    SendMailPDF("Sonic U Remaining Training Report", "Sonic_U Remaining_Training_Report.pdf", sbRecorords.ToString(), drReceipientNew);
                }
                WriteLog("Function SendMailToEarlyAlertLocationManagers executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in function SendMailToEarlyAlertLocationManagers()" + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Exception " + ex.Message + " occurred in SendMailToEarlyAlertLocationManagers", _strCsvPath, true);
                //event viewer
            }
        }

        //{
        //    try
        //    {
        //        WriteLog("Executing SendMailToEarlyAlertLocationManagers", _strCsvPath, false);

        //        DataSet dsReportData = ReportSendMail.GetEmployeeTrainingDataForReport();
        //        DataTable dtReportData = dsReportData.Tables[0];
        //        DataTable dtReceipient = dsReportData.Tables[1];
        //        DataTable dtLocationIDs = dsReportData.Tables[2];

        //        WriteLog("Report Data Count : " + dtReportData.Rows.Count, _strCsvPath, false);
        //        WriteLog("Recipient count : " + dtReceipient.Rows.Count, _strCsvPath, false);
        //        WriteLog("Location count : " + dtLocationIDs.Rows.Count, _strCsvPath, false);

        //        DataTable dtDepartFilter;

        //        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        //        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //        string strPrevDept, strPrevAssoName, strPrevJobTitle;
        //        strPrevDept = strPrevAssoName = strPrevJobTitle = "#";
        //        DataView dvRptDataForCurLocAndDept, dvRptDataForCurLocAndDeptAndAssocName, dvRptDataForClass, dvLocationData;
        //        DataTable dtUniqueDept, dtUniqueAssocName, dtUniqueJobTitle;       

        //        foreach (DataRow drLocationID in dtLocationIDs.Rows) //Location wise
        //        {
        //            WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
        //            sbRecorords.Clear();
        //            try
        //            {
        //                if (dtReportData != null && dtReportData.Rows.Count > 0)
        //                {
        //                    //Gets location detail
        //                    DataTable dtLocation = ReportSendMail.SelectByPK(Convert.ToDecimal(drLocationID["PK_LU_Location_ID"])).Tables[0];

        //                    //WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"] + " Report Data Rows Count : " + dtLocationWiseData.Length, _strCsvPath, false);
        //                    sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
        //                    sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>Sonic U Training Report - Quarter " + ((quarterMonth - 1) / 3 + 1) + "</td></tr>");
        //                    sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(dtLocation.Rows[0]["Sonic_Location_Code"]) + " - " + Convert.ToString(dtLocation.Rows[0]["dba"]) + "</td></tr>");
        //                    sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(dtLocation.Rows[0]["City"]) + ", " + Convert.ToString(dtLocation.Rows[0]["StateName"]) + "</td></tr>");
        //                    sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr>&nbsp;</tr>");
        //                    sbRecorords.Append("<tr style='font-weight: bold;'><td><table border='1' cellspacing='0' cellpadding='0' style='border: black 0.5px solid'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25'>");
        //                    sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Department</td>");
        //                    sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Associate</td>");
        //                    sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Job Title</td>");
        //                    sbRecorords.Append("<td align='left' style='width=55%;font-size:9pt'>Remaining Training to be Taken</td></tr>");

        //                    //DataView dv = new DataView(dtReportData);
        //                    //DataTable distinctValues = dv.ToTable(true, "Department");

        //                    //DataRow[] dtTrainingData = dtReportData.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "' AND Department='" + dtDept.Rows[i]["Department"].ToString() + "' AND Associate_Name='" + dtDistinctData.Rows[i]["Associate_Name"].ToString() + "' AND Job_Title='" + dtDistinctData.Rows[i]["Job_Title"].ToString() + "'");

        //                    //dvLocationData = dtReportData.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'").CopyToDataTable<DataRow>();
        //                    dvLocationData = new DataView(dtReportData, "PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'", "Department", DataViewRowState.CurrentRows);
        //                    dtUniqueDept = dvLocationData.ToTable(true, "Department");
        //                    for (int i = 0; i < dtUniqueDept.Rows.Count; i++) //Fetches unique departments for the current Location
        //                    {
        //                        if(i!=0 && dtUniqueDept.Rows.Count>1)
        //                            sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");                                                                        

        //                        if (strPrevDept != "#" && strPrevDept != dtUniqueDept.Rows[i]["Department"].ToString())
        //                            sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

        //                        sbRecorords.Append("<tr align='left'  style='width=15%;font-size:8.5pt' >");                                
        //                        sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueDept.Rows[i]["Department"]) + "</td>");

        //                        //Fetch Data for current department and current location
        //                        //dtRptDataForCurLocAndDept = dvLocationData.ToTable().Select("Department='" + dtUniqueDept.Rows[i]["Department"].ToString() + "'").CopyToDataTable<DataRow>();
        //                        dvRptDataForCurLocAndDept = new DataView(dvLocationData.ToTable(), "Department='" + dtUniqueDept.Rows[i]["Department"].ToString() + "'", "Associate_Name", DataViewRowState.CurrentRows);
        //                        dtUniqueAssocName = dvRptDataForCurLocAndDept.ToTable(true, "Associate_Name");

        //                        for (int j = 0; j < dtUniqueAssocName.Rows.Count; j++) //Fetches unique associates for the current Location and department
        //                        {
        //                            if(strPrevAssoName != "#" && strPrevAssoName != dtUniqueAssocName.Rows[j]["Associate_Name"].ToString()) //Add Blank row
        //                                sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

        //                            if(j==0)
        //                                sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");
        //                            else
        //                                sbRecorords.Append("<tr><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");

        //                            //Fetch Data for current Associate_Name and current location and department
        //                            dvRptDataForCurLocAndDeptAndAssocName = dtRptDataForCurLocAndDept.Select("Associate_Name='" + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString() + "'").CopyToDataTable<DataRow>();
        //                            dtUniqueJobTitle = dtRptDataForCurLocAndDeptAndAssocName.AsDataView().ToTable(true, "Job_Title");
        //                            for (int k = 0; k < dtUniqueJobTitle.Rows.Count; k++) //Fetches unique associates for the current Location and department
        //                            {
        //                                if (strPrevJobTitle!="#" && strPrevJobTitle != dtUniqueJobTitle.Rows[k]["Job_Title"].ToString()) //Add Blank row
        //                                    sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

        //                                if(k==0)
        //                                    sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
        //                                else
        //                                    sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
        //                                //Fetches data for current location,Department,Associate_Name,Job title
        //                                dtRptDataForClass = dtRptDataForCurLocAndDeptAndAssocName.Select("Job_Title='" + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString() + "'").CopyToDataTable<DataRow>();
        //                                for(int m=0;m<dtRptDataForClass.Rows.Count;m++)
        //                                {
        //                                    if(m==0)
        //                                        sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
        //                                    else
        //                                        sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
        //                                }
        //                                //sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");                                        
        //                                strPrevJobTitle = dtUniqueJobTitle.Rows[k]["Job_Title"].ToString();
        //                            }
        //                            strPrevJobTitle = "#";
        //                            strPrevAssoName = dtUniqueAssocName.Rows[j]["Associate_Name"].ToString();
        //                        }                                
        //                        strPrevAssoName = "#";
        //                        strPrevDept = dtUniqueDept.Rows[i]["Department"].ToString();                                
        //                    }
        //                    strPrevDept = "#";
        //                }
        //                else
        //                {
        //                    WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
        //                    sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
        //                    sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
        //                    sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
        //                }                        
        //            }
        //            catch (Exception ex)
        //            {
        //                WriteLog("Exception occurred : " + ex.Message, _strCsvPath, false);
        //                EventLog.WriteEntry("Error in function SendMailToEarlyAlertLocationManagers()" + ex.Message + ",Stack Trace:" + ex.StackTrace);
        //            }
        //            //Write HTML in to HtmlWriter
        //            htmlWrite.WriteLine(sbRecorords.ToString());
        //            DataRow[] drReceipientNew = dtReceipient.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'");
        //            SendMailPDF("Sonic U Remaining Training Report", "Sonic_U Remaining_Training_Report.pdf", sbRecorords.ToString(), drReceipientNew);
        //        }
        //        WriteLog("Function SendMailToEarlyAlertLocationManagers executed", _strCsvPath, false);
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("Error in function SendMailToEarlyAlertLocationManagers()" + ex.Message + ",Stack Trace:" + ex.StackTrace);
        //        WriteLog("Exception " + ex.Message + " occurred in SendMailToEarlyAlertLocationManagers", _strCsvPath, true);
        //        //event viewer
        //    }
        //}

        /// <summary>
        /// Send Mail To Location Managers(Associate Training Report)
        /// </summary>
        public void SendMailToRLCMLocationManagers()
        {
            try
            {
                WriteLog("Executing SendMailToLocationManagers", _strCsvPath, false);
                DataTable dtReportData = ReportSendMail.GetEmployeeTrainingDataForReport().Tables[0];
                //DataTable dtRLCMUsersWithLocation = ReportSendMail.GetRLCMUsers().Tables[0];
                DataTable dtRLCMUsers = ReportSendMail.GetRLCMUsers().Tables[0];

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
                        //Fetch Location for RLCM user
                        DataTable dtLocation = ReportSendMail.SelectLocation_By_RLCM(Convert.ToDecimal(drRLCM["FK_Employee_Id"])).Tables[0];

                        WriteLog("Location count : " + dtLocation.Rows.Count + " for RLCM user : " + drRLCM["FK_Employee_Id"], _strCsvPath, false);

                        if (dtLocation != null && dtLocation.Rows.Count > 0)
                        {
                            foreach (DataRow drLocationID in dtLocation.Rows) //Location wise
                            {
                                WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                                try
                                {
                                    if (dtReportData != null && dtReportData.Rows.Count > 0)
                                    {
                                        //Gets location detail
                                        //DataTable dtLocation = ReportSendMail.SelectByPK(Convert.ToDecimal(drLocationID["PK_LU_Location_ID"])).Tables[0];

                                        //WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"] + " Report Data Rows Count : " + dtLocationWiseData.Length, _strCsvPath, false);
                                        sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
                                        sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>Sonic U Training Report - Quarter " + ((quarterMonth - 1) / 3 + 1) + "</td></tr>");
                                        sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(drLocationID["dba1"]) + "</td></tr>");
                                        sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(drLocationID["City"]) + ", " + Convert.ToString(drLocationID["FLD_state"]) + "</td></tr>");
                                        sbRecorords.Append("<tr style='font-weight: bold;'><td align='left' style='font-size:9pt'  colspan='4'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr>&nbsp;</tr>");
                                        sbRecorords.Append("<tr style='font-weight: bold;'><td><table border='1' cellspacing='0' cellpadding='0' style='border: black 0.5px solid'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25'>");
                                        sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Department</td>");
                                        sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Associate</td>");
                                        sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>Job Title</td>");
                                        sbRecorords.Append("<td align='left' style='width=55%;font-size:9pt'>Remaining Training to be Taken</td></tr>");

                                        //DataView dv = new DataView(dtReportData);
                                        //DataTable distinctValues = dv.ToTable(true, "Department");

                                        //DataRow[] dtTrainingData = dtReportData.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "' AND Department='" + dtDept.Rows[i]["Department"].ToString() + "' AND Associate_Name='" + dtDistinctData.Rows[i]["Associate_Name"].ToString() + "' AND Job_Title='" + dtDistinctData.Rows[i]["Job_Title"].ToString() + "'");

                                        string strPrevDept, strPrevAssoName, strPrevJobTitle;
                                        strPrevDept = strPrevAssoName = strPrevJobTitle = "#";
                                        DataTable dtRptDataForCurLocAndDept, dtRptDataForCurLocAndDeptAndAssocName, dtRptDataForClass;
                                        DataTable dtUniqueDept, dtUniqueAssocName, dtUniqueJobTitle;

                                        DataTable dtLocationData = new DataView(dtReportData, "PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'", "", DataViewRowState.CurrentRows).ToTable();
                                        dtUniqueDept = dtLocationData.AsDataView().ToTable(true, "Department");

                                        for (int i = 0; i < dtUniqueDept.Rows.Count; i++) //Fetches unique departments for the current Location
                                        {
                                            if (strPrevDept != "#" && strPrevDept != dtUniqueDept.Rows[i]["Department"].ToString())
                                                sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

                                            sbRecorords.Append("<tr align='left'  style='width=15%;font-size:8.5pt'>");
                                            sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueDept.Rows[i]["Department"]) + "</td>");

                                            //Fetch Data for current department and current location
                                            dtRptDataForCurLocAndDept = dtLocationData.Select("Department='" + dtUniqueDept.Rows[i]["Department"].ToString() + "'").CopyToDataTable<DataRow>();

                                            dtUniqueAssocName = dtRptDataForCurLocAndDept.AsDataView().ToTable(true, "Associate_Name");
                                            for (int j = 0; j < dtUniqueAssocName.Rows.Count; j++) //Fetches unique associates for the current Location and department
                                            {
                                                if (strPrevAssoName != "#" && strPrevAssoName != dtUniqueAssocName.Rows[j]["Associate_Name"].ToString()) //Add Blank row
                                                    sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

                                                if (j == 0)
                                                    sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");
                                                else
                                                    sbRecorords.Append("<tr><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");

                                                //Fetch Data for current Associate_Name and current location and department
                                                dtRptDataForCurLocAndDeptAndAssocName = dtRptDataForCurLocAndDept.Select("Associate_Name='" + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString() + "'").CopyToDataTable<DataRow>();
                                                dtUniqueJobTitle = dtRptDataForCurLocAndDeptAndAssocName.AsDataView().ToTable(true, "Job_Title");
                                                for (int k = 0; k < dtUniqueJobTitle.Rows.Count; k++) //Fetches unique associates for the current Location and department
                                                {
                                                    if (strPrevJobTitle != "#" && strPrevJobTitle != dtUniqueJobTitle.Rows[k]["Job_Title"].ToString()) //Add Blank row
                                                        sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");

                                                    if (k == 0)
                                                        sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
                                                    else
                                                        sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
                                                    //Fetches data for current location,Department,Associate_Name,Job title
                                                    dtRptDataForClass = dtRptDataForCurLocAndDeptAndAssocName.Select("Job_Title='" + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString() + "'").CopyToDataTable<DataRow>();
                                                    for (int m = 0; m < dtRptDataForClass.Rows.Count; m++)
                                                    {
                                                        if (m == 0)
                                                            sbRecorords.Append("<td align='left' style='width=15%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
                                                        else
                                                            sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
                                                    }
                                                    sbRecorords.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                                    strPrevJobTitle = dtUniqueJobTitle.Rows[k]["Job_Title"].ToString();
                                                }
                                                strPrevJobTitle = "#";
                                                strPrevAssoName = dtUniqueAssocName.Rows[j]["Associate_Name"].ToString();
                                            }
                                            strPrevAssoName = "#";
                                            strPrevDept = dtUniqueDept.Rows[i]["Department"].ToString();
                                        }
                                        strPrevDept = "#";
                                    }
                                    else
                                    {
                                        WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                                        sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                                        sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                                        sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    WriteLog("Exception occurred : " + ex.Message, _strCsvPath, false);
                                }
                            }

                        }
                        else
                        {
                            WriteLog("No location exists for RLCM user : " + drRLCM["FK_Employee_Id"], _strCsvPath, false);
                        }

                    }
                    else
                    {
                        WriteLog("No training data found ", _strCsvPath, false);
                    }

                    //Write HTML in to HtmlWriter
                    //htmlWrite.WriteLine(sbRecorords.ToString());
                    //DataRow []test=drRLCM.ItemArray.
                    //SendMailPDFMAnager("Sonic U Remaining Training Report", "Sonic_U_Remaining_Training_Report.pdf", _strSMTPmailFrom, sbRecorords.ToString(), drRLCM);

                    //Write HTML in to HtmlWriter
                    htmlWrite.WriteLine(sbRecorords.ToString());
                    //DataRow[] drReceipientNew = dtReceipient.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'");
                    SendMailPDF("Sonic U Remaining Training Report", "Sonic_U Remaining_Training_Report.pdf", sbRecorords.ToString(), drRLCM);
                }
                WriteLog("function SendMailToLocationManagers() executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Exception occurred : " + ex.Message, _strCsvPath, false);
            }
        }

        /// <summary>
        /// Send Email To Each Employee for Remaining Quarterly Training
        /// </summary>
        /// <param name="strMailFrom"></param>
        /// <param name="dtRecipients"></param>
        private void SendMailEveryQuarterToEmployees()
        {
            try
            {
                WriteLog("Executing SendMailEveryQuarterToEmployees", _strCsvPath, false);

                DataTable dtTraining = ReportSendMail.GetEmployeeTrainingData().Tables[0];
                MemoryStream memorystream = new MemoryStream();
                MailMessage mail = new MailMessage();
                decimal Fk_Employee = -1;
                string strClassNameList="";

                DataTable temp = dtTraining.AsDataView().ToTable(true, "FK_Employee"); 

                WriteLog("No of employees having training in this Quarter : " + dtTraining.Rows.Count, _strCsvPath, false);

                mail.From = new MailAddress(_strSMTPmailFrom);
                mail.Subject = "Required Associated Sonic U Training This Quarter";
                mail.IsBodyHtml = true;                        

                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Port = Convert.ToInt16(_strPort);
                mSmtpClient.Host = _strSMTPServer;
                mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmailFrom, _strSMTPPwd);


                for (int i = 0; i < dtTraining.Rows.Count; i++)
                {
                    if (Fk_Employee!=-1 && Fk_Employee != Convert.ToDecimal(dtTraining.Rows[i]["FK_Employee"]))
                    {
                        mail.Body = "You are scheduled to take and complete the following training this quarter:" + strClassNameList;
                        if (i != 0)
                        {
                            try
                            {                               
                                mSmtpClient.Send(mail);
                                mail.To.Clear();
                                mail.Body = "";
                            }
                            catch(Exception Ex)
                            {
                                WriteLog("Exception occurred in SendMailEveryQuarterToEmployees while sending mail to : " + Ex.Message, _strCsvPath, false);
                            }
                           
                            strClassNameList = "";
                        }
                        strClassNameList += "<br/>" + (dtTraining.Rows[i]["Class_Name"].ToString()).Replace(",", "<br/>");
                        mail.To.Add(new MailAddress(dtTraining.Rows[i]["EmailTo"].ToString()));                        
                        Fk_Employee = Convert.ToDecimal(dtTraining.Rows[i]["FK_Employee"]);
                    }
                    else
                    {
                        strClassNameList += "<br/>" + (dtTraining.Rows[i]["Class_Name"].ToString()).Replace(",", "<br/>");
                        mail.To.Add(new MailAddress(dtTraining.Rows[i]["EmailTo"].ToString()));                        
                        Fk_Employee = Convert.ToDecimal(dtTraining.Rows[i]["FK_Employee"]);
                    }
                }
                WriteLog("Function SendMailEveryQuarterToEmployees executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                WriteLog("Exception occurred while executing SendMailEveryQuarterToEmployees " + ex.Message, _strCsvPath, false);
            }
        }

        /// <summary>
        /// Send Email To the Administrator for the list of Employees
        /// </summary>
        /// <param name="strMailFrom"></param>
        /// <param name="dtTraining"></param>
        /// <param name="dtRecipients"></param>
        private void SendMailToAdministratorForPrivateEmployeeEmails()
        {
            try
            {
                WriteLog("Executing SendMailToAdministrator()", _strCsvPath, true);

                DataTable dtTrainingAdministrator = ReportSendMail.GetEmployeeTrainingData().Tables[1];
                DataTable dtAdminRecepient = ReportSendMail.GetAdminList().Tables[0];

                WriteLog("Training Administrator Rows Count : " + dtTrainingAdministrator.Rows.Count, _strCsvPath, true);
                WriteLog("Admin recipient Rows Count : " + dtAdminRecepient.Rows.Count, _strCsvPath, true);

                MemoryStream memorystream = new MemoryStream();
                MailMessage mail = new MailMessage();
                SmtpClient mSmtpClient = new SmtpClient();

                mSmtpClient.Port = Convert.ToInt16(_strPort);
                mSmtpClient.Host = _strSMTPServer;
                mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmailFrom, _strSMTPPwd);

                if (dtAdminRecepient.Rows.Count > 0)
                {
                    mail.From = new MailAddress(_strSMTPmailFrom);
                    mail.Subject = "Potential Personal E-Mails in HR Data";

                    //Employee details having training in current quarter
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
                    //Send individual mail to each admin
                    foreach (DataRow dr in dtAdminRecepient.Rows)
                    {
                        try
                        {
                            mail.To.Add(new MailAddress(Convert.ToString(dr["Email"])));
                            mSmtpClient.Send(mail);

                            mail.To.Clear();
                            WriteLog("Email sent to", _strCsvPath, false);
                        }
                        catch (Exception ex)
                        {
                            EventLog.WriteEntry("Error in Sending Mail " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                            WriteLog("Exception : " + ex.Message, _strCsvPath, true);
                        }
                    }
                }
                else
                {
                    WriteLog("No administrator user exists", _strCsvPath, false);
                }
                WriteLog("Executed SendMailToAdministrator()", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for" + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Exception occurred " + ex.Message + " in SendMailToAdministrator()", _strCsvPath, true);
            }
        }

        ///// <summary>
        ///// Send Mail To System Administrator after importing the data for the Job Codes 
        ///// </summary>
        //public void SendMailToAdminFoNewJobCodes()
        //{
        //    DataTable dtAdminRecepient = ReportSendMail.GetAdminList().Tables[0];
        //    MemoryStream memorystream = new MemoryStream();
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress(_strSMTPmailFrom);
        //    mail.Subject = "Sonic eRIMS2 - New Employee Job Codes Added";

        //    SmtpClient mSmtpClient = new SmtpClient();
        //    mSmtpClient.Port = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings.Get("Port"));
        //    mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
        //    mSmtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPmail"], ConfigurationManager.AppSettings["SMTPPwd"]);

        //    try
        //    {
        //        foreach (DataRow dr in dtAdminRecepient.Rows)
        //        {
        //            mail.Body = "New Employee Job Codes were added during the Employee data import today that did not previously exist in the Sonic U Training Required Classes table. In order for eRIMS2 to assign classes properly, the Sonic U Training Required Classes table will need to be updated as soon as possible to keep training assignments current. Please edit the Required Classes table via the following Sonic eRIMS2 menu selection: Administrator, Lookup Table Maintenance, Sonic U Training, Required Classes and click on the 'Add Training for New Job Codes' button.";
        //            mail.IsBodyHtml = true;
        //            mail.To.Add(new MailAddress(Convert.ToString(dr["Email"])));
        //            mSmtpClient.Send(mail);
        //            mail.To.Clear();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("Error in Sending Mail for" + ex.Message + ",Stack Trace:" + ex.StackTrace);
        //    }
        //}

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
        protected void SendMailPDF(String strReportTitle, String strFileNameToSave, String sw, DataRow[] drRecipients)
        {
            try
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
                    mail.From = new MailAddress(_strSMTPmailFrom);
                    mail.Subject = "eRIMS :: " + strReportTitle;
                    memorystream = new MemoryStream(File.ReadAllBytes(strPath));
                    Attachment atts = new Attachment(memorystream, strFileNameToSave);
                    mail.Attachments.Add(atts);

                    SmtpClient mSmtpClient = new SmtpClient();
                    mSmtpClient.Host = _strSMTPServer;
                    mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmailFrom, _strSMTPPwd);

                    //for (int i = 0; i < dtRecipients.Rows.Count; i++)
                    //{
                    foreach (DataRow drRecipient in drRecipients)
                    {
                        try
                        {
                            mail.Body = drRecipient["First_Name"].ToString() + " " + drRecipient["Last_Name"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thankyou!<br />";
                            mail.Body += "<br /> This is system generated message. Please do not reply.";
                            mail.IsBodyHtml = true;
                            mail.To.Add(new MailAddress(drRecipient["Email"].ToString()));
                            mSmtpClient.Send(mail);
                            mail.To.Clear();
                        }
                        catch (Exception Ex)
                        {
                            EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + Ex.Message + ",Stack Trace:" + Ex.StackTrace);
                        }
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
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Exception occurred " + ex.Message + " in SendMailPDF()", _strCsvPath, true);
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
        protected void SendMailPDF(String strReportTitle, String strFileNameToSave, String sw, DataRow drRecipients)
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
                mail.From = new MailAddress(_strSMTPmailFrom);
                mail.Subject = "eRIMS :: " + strReportTitle;
                memorystream = new MemoryStream(File.ReadAllBytes(strPath));
                Attachment atts = new Attachment(memorystream, strFileNameToSave);
                mail.Attachments.Add(atts);

                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Host = _strSMTPServer;
                mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmailFrom, _strSMTPPwd);
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
