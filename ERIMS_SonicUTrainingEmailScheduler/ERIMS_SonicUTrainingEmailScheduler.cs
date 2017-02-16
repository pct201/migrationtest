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
using System.Collections;

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
        public string _strCsvPath = string.Empty;
        public string _strEvent_Run_Time_Interval = string.Empty;
        public string _strFormatDateToDisplay = string.Empty;
        public string _strSMTPServer = string.Empty;
        public string _strSMTPPwd = string.Empty;
        public string _strPort = string.Empty;
        public string _strSentMailSubjectFrmt = string.Empty;
        public string _strSMTPmailFrom = string.Empty;
        DateTime quarterDate;
        public int quarterMonth = 0;
        public int quarterDay = 0;
        public DayOfWeek firstWeekDay;
        public DayOfWeek currentWeekDay;
        public DateTime nextMailSendDate;
        public string _strServiceRunTime = string.Empty;
        public bool _isTesting = false;
        public bool _isTestingReport = false;

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
            EventLog.WriteEntry("ERIMS Safety Training Email Scheduler Started at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Safety Training Email Scheduler Started", _strCsvPath, false);

            //Create a thread for the function which send email
            Thread TSendMail = default(Thread);
            TSendMail = new System.Threading.Thread(SendReportAsAttachment);
            //Start the thread
            TSendMail.Start();
            TSendMail.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        }

        public void OnStartTest()
        {
            ReadConfigSetting();
            //Make event log entry to indicate starting of service
            EventLog.WriteEntry("ERIMS Safety Training Email Scheduler Started at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Safety Training Email Scheduler Started", _strCsvPath, false);

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
            EventLog.WriteEntry("ERIMS Safety Training Email Scheduler Stopped at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Safety Training Email Scheduler Stopped ", _strCsvPath, false);
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
                WriteLog("Reading config file", _strCsvPath, false);
                _strCsvPath = ConfigurationSettings.AppSettings.Get("CSVPath");
                _strFormatDateToDisplay = ConfigurationSettings.AppSettings.Get("DisplayDateFormat");
                _strSMTPServer = ConfigurationSettings.AppSettings.Get("SMTPServer");
                //_strSMTPmail = ConfigurationSettings.AppSettings.Get("SMTPmail");
                _strSMTPPwd = ConfigurationSettings.AppSettings.Get("SMTPPwd");
                _strPort = ConfigurationSettings.AppSettings.Get("Port");
                _strSMTPmailFrom = ConfigurationSettings.AppSettings.Get("SMTPmailFrom");
                _isTesting = Convert.ToBoolean(ConfigurationSettings.AppSettings.Get("IsTesting"));
                _isTestingReport = Convert.ToBoolean(ConfigurationSettings.AppSettings.Get("IsTestingReport"));
                quarterDate = DateTime.Now;
                quarterMonth = quarterDate.Month;
                quarterDay = quarterDate.Day;
                _strServiceRunTime = ConfigurationSettings.AppSettings.Get("ServiceRunTime");
            }
            catch (Exception Ex)
            {
                WriteLog("Exception occurred while executing ReadConfigSetting() " + Ex.Message + ", Stack Trace:" + Ex.StackTrace, _strCsvPath, true);
            }
        }

        #region Private Methods

        /// <summary>
        /// Check whether first day of week or not
        /// </summary>
        /// <param name="blnSendMail"></param>
        /// <returns></returns>
        private bool CheckFirstDayOfWeek(bool blnSendMail)
        {
            var startDate = new DateTime(quarterDate.Year, quarterDate.Month, 1); //Fetch 1st date of current month
            bool bSendMail = blnSendMail;
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

            return bSendMail;
        }

        /// <summary>
        /// Main Function which contains infinite loop and send report when date changed
        /// </summary>
        public void SendReportAsAttachment()
        {
            //Thread.Sleep(1000);            
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
                    EventLog.WriteEntry("Total No of Database Connection String Found : " + ConfigurationManager.ConnectionStrings.Count.ToString());

                    for (int i = 1; i < ConfigurationManager.ConnectionStrings.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[i].ConnectionString))
                        {
                            ReportSendMail.strConn = ConfigurationManager.ConnectionStrings[i].ConnectionString;

                            bool bSendMailWeekly = false;
                            bSendMailWeekly = CheckFirstDayOfWeek(false);

                            SendMailForPayrollTrainingReport();

                            if (bSendMailWeekly || _isTesting)
                            {
                                //Send Weekly Mail To the Associate For Remaining Training
                                SendMailForWeeklyReminderOfRemainingTrainingToEmployees();
                            }

                            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                            {
                                //Send Payroll training and percent recap report out every Monday
                                SendMailForPayrollTrainingReport();

                                SendMailForPercentageRecap();
                            }

                            //Send Mail for Testing if _isTesting True
                            if (_isTesting && (!_isTestingReport))
                            {
                                SendMailEveryQuarterToEmployees();
                                SendMailToEarlyAlertLocationManagers();
                                SendMailToRLCMLocationManagers();

                            }

                            //Send Mail for Testing Reports if _isTestingReport True
                            if (_isTestingReport && _isTesting)
                            {
                                //Mail for Safety Remaining Training Report
                                SendMailToEarlyAlertLocationManagers();
                                //Mail for Associate Training Report
                                SendMailToRLCMLocationManagers();
                                //Percent Recap report
                                SendMailForPercentageRecap();
                                //Payroll training report
                                SendMailForPayrollTrainingReport();
                            }

                            if ((quarterDay == 1) && (quarterMonth == 1 || quarterMonth == 4 || quarterMonth == 7 || quarterMonth == 10))
                            {
                                //Send Email to the Employees having Training the the following Quarter
                                SendMailEveryQuarterToEmployees();
                            }

                            //For 1st and 2nd month of quarter send mail for first day of week
                            if (quarterMonth % 3 != 0)
                            {
                                bool bSendMail = false;
                                bSendMail = CheckFirstDayOfWeek(false);

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
                        }
                    }
                    flgSendEmail = false;
                }

                //Stop Process For 1 Hour to reduce CPU Utilization
                //Thread.Sleep(3600000);

                //service start at 9:00 AM everyday
                //get current date time and tomorrow date time with 9:00 am ::subtract that and get ms this is sleep time of thread
                //if (string.IsNullOrEmpty(_strEvent_Run_Time_Interval)) _strEvent_Run_Time_Interval = "09:00:00";

                DateTime dtNextDateTime = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " " + _strServiceRunTime);
                DateTime dtCurrentDateTime = DateTime.Now;

                TimeSpan span = dtNextDateTime - dtCurrentDateTime;
                int ms = (int)span.TotalMilliseconds;

                if (ms > 0)
                {
                    EventLog.WriteEntry("Thread sleeps for next " + ms / 3600000 + " Hours");
                    WriteLog("Thread sleeps for next " + ms / 3600000 + " Hours", _strCsvPath, false);
                    Thread.Sleep(ms);
                    //dtSchduleDate = DateTime.Today;
                    flgSendEmail = true;
                }
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
                DataTable dtReportCompletedData = dsReportData.Tables[3];
                DataTable dtReceipient = dsReportData.Tables[1];
                DataTable dtLocationIDs = dsReportData.Tables[2];

                WriteLog("Report Data Count : " + dtReportData.Rows.Count, _strCsvPath, false);
                WriteLog("Recipient count : " + dtReceipient.Rows.Count, _strCsvPath, false);
                WriteLog("Location count : " + dtLocationIDs.Rows.Count, _strCsvPath, false);

                DataTable dtDepartFilter;

                System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
                System.Text.StringBuilder sbRecorordsCompleted = new System.Text.StringBuilder("");
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                //string strPrevDept, strPrevAssoName, strPrevJobTitle;
                //strPrevDept = strPrevAssoName = strPrevJobTitle = "#";
                //DataTable dtRptDataForCurLocAndDept, dtRptDataForCurLocAndDeptAndAssocName, dtRptDataForClass;
                //DataTable dtUniqueDept, dtUniqueAssocName, dtUniqueJobTitle;
                //DataView dvReportData;

                foreach (DataRow drLocationID in dtLocationIDs.Rows) //Location wise
                {
                    sbRecorords.Clear();
                    sbRecorordsCompleted.Clear();
                    try
                    {
                        sbRecorords = GenerateReportEarlyAlertLocationManagers(dtReportData, drLocationID, sbRecorords, false, "Safety Remaining Training Report");
                        sbRecorordsCompleted = GenerateReportEarlyAlertLocationManagers(dtReportCompletedData, drLocationID, sbRecorordsCompleted, true, "Safety Completed Training Report");
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Exception occurred  for Location ID: " + Convert.ToDecimal(drLocationID["PK_LU_Location_ID"]) + ", Exception Message :" + ex.Message + ", Stack Trace:" + ex.StackTrace, _strCsvPath, true);
                        EventLog.WriteEntry("Error in function SendMailToEarlyAlertLocationManagers()" + ex.Message + ",Stack Trace:" + ex.StackTrace);
                    }
                    //Write HTML in to HtmlWriter
                    htmlWrite.WriteLine(sbRecorords.ToString());
                    DataRow[] drReceipientNew = dtReceipient.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'");
                    //SendMailPDF("Safety Remaining Training Report", "Safety Remaining Training Report.pdf", sbRecorords.ToString(), drReceipientNew);
                    SendMail("Safety Remaining Training Report", "Safety Remaining Training Report.xls", sbRecorords.ToString(), drReceipientNew, sbRecorordsCompleted.ToString(), "Safety Completed Training Report", "Safety Completed Training Report.xls", "Safety Remaining Training Report and Safety Completed Training Report");
                }
                WriteLog("Function SendMailToEarlyAlertLocationManagers executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in function SendMailToEarlyAlertLocationManagers()" + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Exception " + ex.Message + " occurred in SendMailToEarlyAlertLocationManagers and Stack Trace:" + ex.StackTrace, _strCsvPath, true);
            }
        }

        /// <summary>
        /// GenerateReportEarlyAlertLocationManagers
        /// </summary>
        /// <param name="dtReportData"></param>
        /// <param name="drLocationID"></param>
        /// <param name="sbRecorords"></param>
        /// <returns></returns>
        public StringBuilder GenerateReportEarlyAlertLocationManagers(DataTable dtReportDataOld, DataRow drLocationID, StringBuilder sbRecorords, bool blnCompleted, String strReportTitle)
        {
            string strPrevDept, strPrevAssoName, strPrevJobTitle;
            strPrevDept = strPrevAssoName = strPrevJobTitle = "#";
            DataTable dtRptDataForCurLocAndDept, dtRptDataForCurLocAndDeptAndAssocName, dtRptDataForClass;
            DataTable dtUniqueDept, dtUniqueAssocName, dtUniqueJobTitle;
            DataView dvReportData;

            //sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");

            DataTable distinctYearQuarter = new DataView(dtReportDataOld).ToTable(true, new string[] { "Year", "Quarter" });

            foreach (DataRow drYearQuarter in distinctYearQuarter.Rows) 
            {
                DataTable dtReportData = new DataView(dtReportDataOld, "PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "' AND Year ='" + drYearQuarter["Year"].ToString() + "' AND Quarter = '" + drYearQuarter["Quarter"].ToString() + "'", "", DataViewRowState.CurrentRows).ToTable();
                if (dtReportData != null && dtReportData.Rows.Count > 0 && distinctYearQuarter != null && distinctYearQuarter.Rows.Count > 0)
                {
                   // DataTable dtReportData = new DataView(dtReportData, "PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "' AND Year ='" + drYearQuarter["Year"].ToString() + "' AND Quarter = '" + drYearQuarter["Quarter"].ToString() + "'", "", DataViewRowState.CurrentRows).ToTable();
                    if (dtReportData != null && dtReportData.Rows.Count > 0)
                    {
                        //Gets location detail
                        
                        DataTable dtLocation = ReportSendMail.SelectByPK(Convert.ToDecimal(drLocationID["PK_LU_Location_ID"])).Tables[0];

                        //WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"] + " Report Data Rows Count : " + dtLocationWiseData.Length, _strCsvPath, false);
                        sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
                        sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt' colspan='4'>" + strReportTitle + " Year - " + drYearQuarter["Year"].ToString() + " - Quarter " + drYearQuarter["Quarter"].ToString() + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(dtLocation.Rows[0]["Sonic_Location_Code"]).PadLeft(4, '0') + " - " + Convert.ToString(dtLocation.Rows[0]["dba"]) + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='4'>" + Convert.ToString(dtLocation.Rows[0]["City"]) + ", " + Convert.ToString(dtLocation.Rows[0]["StateName"]) + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='4'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr><td>&nbsp;</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td><table border='1' cellspacing='0' width='100%' cellpadding='0' style='border: black 0.5px solid'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25px;'  valign='top'>");
                        sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;padding-left:10px;'>Department</td>");
                        sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;padding-left:10px;'>Associate</td>");
                        sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;padding-left:10px;'>Job Title</td>");

                        //for Completed Training Report add column
                        if (blnCompleted)
                        {
                            sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt;padding-left:10px;'>Completed Training</td>");
                            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;padding-left:10px;'>Completed/Waived</td>");
                            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Date of Completion</td>");
                        }
                        else
                        {
                            sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt;padding-left:10px;'>Remaining Training to be Taken</td>");
                        }
                        sbRecorords.Append("</tr>");

                        //DataRow[] drLocationData = dtReportData.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'");
                        //DataTable dtLocationData=new DataTable();
                        //if(drLocationData!=null && drLocationData.Length>0)
                        //{
                        //    dtLocationData = drLocationData.CopyToDataTable<DataRow>();
                        //}
                        //DataTable dtLocationData = dtReportData.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'").CopyToDataTable<DataRow>();
                        dvReportData = new DataView(dtReportData, "PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'", "PK_LU_Location_ID", DataViewRowState.CurrentRows);

                        if (dvReportData.Count > 0)
                        {
                            DataTable dtLocationData = dvReportData.ToTable();
                            dtUniqueDept = dtLocationData.AsDataView().ToTable(true, "Department");
                            string str = "bgcolor=white";

                            for (int i = 0; i < dtUniqueDept.Rows.Count; i++) //Fetches unique departments for the current Location
                            {
                                if (strPrevDept != "#" && strPrevDept != dtUniqueDept.Rows[i]["Department"].ToString())
                                {
                                    str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                                    if (blnCompleted)
                                        sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>");
                                    else
                                        sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                }

                                str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                sbRecorords.Append("<tr align='left' valign='top' style='width:15%;padding-left:10px;font-size:8.5pt;page-break-inside: avoid' " + str + ">");
                                sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;padding-left:10px;'>" + Convert.ToString(dtUniqueDept.Rows[i]["Department"]) + "</td>");

                                //Fetch Data for current department and current location
                                //dtRptDataForCurLocAndDept = dtLocationData.Select("Department='" + dtUniqueDept.Rows[i]["Department"].ToString() + "'").CopyToDataTable<DataRow>();                                
                                dvReportData = new DataView(dtLocationData, "Department='" + dtUniqueDept.Rows[i]["Department"].ToString() + "'", "Department", DataViewRowState.CurrentRows);
                                dtRptDataForCurLocAndDept = dvReportData.ToTable();

                                dtUniqueAssocName = dtRptDataForCurLocAndDept.AsDataView().ToTable(true, "Associate_Name");
                                for (int j = 0; j < dtUniqueAssocName.Rows.Count; j++) //Fetches unique associates for the current Location and department
                                {
                                    if (strPrevAssoName != "#" && strPrevAssoName != dtUniqueAssocName.Rows[j]["Associate_Name"].ToString()) //Add Blank row
                                    {
                                        str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                                        if (blnCompleted)
                                            sbRecorords.Append("<tr " + str + " valign='top' style='page-break-inside: avoid;' ><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>");
                                        else
                                            sbRecorords.Append("<tr " + str + " valign='top' style='page-break-inside: avoid;' ><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                    }
                                    if (j == 0)
                                        sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");
                                    else
                                    {
                                        str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                        sbRecorords.Append("<tr " + str + " valign='top' style='padding-left:10px;page-break-inside: avoid;' ><td>&nbsp;</td><td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");
                                    }

                                    //Fetch Data for current Associate_Name and current location and department Replace("'", "''" + "'")
                                    //dtRptDataForCurLocAndDeptAndAssocName = dtRptDataForCurLocAndDept.Select("Associate_Name='" + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString().Replace("'", "''") + "'").CopyToDataTable<DataRow>();
                                    //dvReportData = new DataView(dtRptDataForCurLocAndDept, "Associate_Name='" + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString().Replace("'", "'" + "'") + "'", "Associate_Name", DataViewRowState.CurrentRows);
                                    dvReportData = new DataView(dtRptDataForCurLocAndDept, "Associate_Name='" + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString().Replace("'", "''") + "'", "Associate_Name", DataViewRowState.CurrentRows);
                                    dtRptDataForCurLocAndDeptAndAssocName = dvReportData.ToTable();
                                    dtUniqueJobTitle = dtRptDataForCurLocAndDeptAndAssocName.AsDataView().ToTable(true, "Job_Title");
                                    for (int k = 0; k < dtUniqueJobTitle.Rows.Count; k++) //Fetches unique associates for the current Location and department
                                    {
                                        if (strPrevJobTitle != "#" && strPrevJobTitle != dtUniqueJobTitle.Rows[k]["Job_Title"].ToString()) //Add Blank row
                                        {
                                            str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                                            if (blnCompleted)
                                                sbRecorords.Append("<tr " + str + " valign='top' style='page-break-inside: avoid;'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>");
                                            else
                                                sbRecorords.Append("<tr " + str + " valign='top' style='page-break-inside: avoid;'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                        }

                                        if (k == 0)
                                            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
                                        else
                                        {
                                            str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                            sbRecorords.Append("<tr " + str + " valign='top' style='padding-left:10px;page-break-inside: avoid;'><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
                                        }
                                        //Fetches data for current location,Department,Associate_Name,Job title
                                        //dtRptDataForClass = dtRptDataForCurLocAndDeptAndAssocName.Select("Job_Title='" + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString() + "'").CopyToDataTable<DataRow>();
                                        dvReportData = new DataView(dtRptDataForCurLocAndDeptAndAssocName, "Job_Title='" + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString() + "'", "Job_Title", DataViewRowState.CurrentRows);
                                        dtRptDataForClass = dvReportData.ToTable();
                                        for (int m = 0; m < dtRptDataForClass.Rows.Count; m++)
                                        {
                                            // WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"] + " Department : " + dtUniqueDept.Rows[i]["Department"].ToString() + " Associate_Name : " + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString() + " Job_Title : " + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString(), _strCsvPath, false);
                                            if (m == 0)
                                            {
                                                if (blnCompleted)
                                                    sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td><td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Completed/Waived"]) + "</td><td align='left' style='width:55%;font-size:9pt'>" + String.Format("{0:MM/dd/yyyy}", dtRptDataForClass.Rows[m]["Date of Completion"]) + " </td></tr>");
                                                else
                                                    sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
                                            }
                                            else
                                            {
                                                str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                                                if (blnCompleted)
                                                    sbRecorords.Append("<tr " + str + " valign='top' style='padding-left:10px;page-break-inside: avoid;'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Completed/Waived"]) + "</td><td align='left' style='width:55%;font-size:9pt'>" + String.Format("{0:MM/dd/yyyy}", dtRptDataForClass.Rows[m]["Date of Completion"]) + " </td></tr>");
                                                else
                                                    sbRecorords.Append("<tr " + str + " valign='top' style='padding-left:10px;page-break-inside: avoid;'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
                                            }
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
                            sbRecorords.Append("<tr valign='top' style='background-color:#F2F2F2;color:Black;page-break-inside: avoid;'>");
                            if (blnCompleted)
                                sbRecorords.Append("<td align='center' colspan='6' style='font-size:9pt;'>No Records found.</td></tr>");
                            else
                                sbRecorords.Append("<td align='center' colspan='4' style='font-size:9pt;'>No Records found.</td></tr>");
                        }
                    }
                    else
                    {
                        WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                        //sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' border='1' cellspacing='0' Width='100%'>");
                        sbRecorords.Append("<tr valign='top' style='background-color:#F2F2F2;color:Black;page-break-inside: avoid;'>");
                        sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Associates to be trained in quarter.</td></tr>");
                    }
                    //sbRecorords.Append("</table></td></tr></table>");
                    sbRecorords.Append("</table></td></tr><tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td><tr></table>");
                }
                
                //sbRecorords.Append("</table></td></tr></table>");

               
            }
            return sbRecorords;
        }

        /// <summary>
        /// Send Mail To Location Managers(Associate Training Report)
        /// </summary>
        public void SendMailToRLCMLocationManagers()
        {
            try
            {
                WriteLog("Executing SendMailToRLCMLocationManagers", _strCsvPath, false);
                DataSet dtReport = ReportSendMail.GetEmployeeTrainingDataForReport();
                DataTable dtReportData = dtReport.Tables[0];
                DataTable dtReportCompletedData = dtReport.Tables[3];
                DataTable dtRLCMUsers = ReportSendMail.GetRLCMUsers().Tables[0];

                System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
                System.Text.StringBuilder sbRecorordsCompleted = new System.Text.StringBuilder("");
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
                                //WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                                try
                                {
                                    sbRecorords = GenerateReportRLCMLocationManagers(dtReportData, sbRecorords, drLocationID, false, "Associate Training Report");
                                    sbRecorordsCompleted = GenerateReportRLCMLocationManagers(dtReportCompletedData, sbRecorordsCompleted, drLocationID, true, "Associate Training Completed Report");
                                }
                                catch (Exception ex)
                                {
                                    WriteLog("Exception occurred for Location ID: " + drLocationID["PK_LU_Location_ID"] + ", Exception Message :" + ex.Message + ", Stack Trace :" + ex.StackTrace, _strCsvPath, true);
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
                    htmlWrite.WriteLine(sbRecorords.ToString());
                    // SendMailPDF("Associate Training Report", "Associate Training Report.pdf", sbRecorords.ToString(), drRLCM);
                    SendMail("Associate Training Report", "Associate Training Report.xls", sbRecorords.ToString(), drRLCM, sbRecorordsCompleted.ToString(), "Associate Completed Training Report", "Associate Completed Training Report.xls", "Associate Training Report and Associate Completed Training Report");
                }
                WriteLog("function SendMailToRLCMLocationManagers() executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Exception occurred : " + ex.Message + ",Stack Trace : " + ex.StackTrace, _strCsvPath, true);
            }
        }

        /// <summary>
        /// Generate Report for RLCM Location Manager
        /// </summary>
        /// <param name="dtReportData"></param>
        /// <param name="sbRecorords"></param>
        /// <param name="drLocationID"></param>
        /// <returns></returns>
        public StringBuilder GenerateReportRLCMLocationManagers(DataTable dtReportData, StringBuilder sbRecorords, DataRow drLocationID, bool blnCompleted, String strReportTitle)
        {
            DataTable distinctYearQuarter = new DataView(dtReportData).ToTable(true, new string[] { "Year", "Quarter" });
            

            if (dtReportData != null && dtReportData.Rows.Count > 0 && distinctYearQuarter!=null && distinctYearQuarter.Rows.Count > 0)
            {

                foreach (DataRow drYearQuarter in distinctYearQuarter.Rows)
                {
                    sbRecorords.Append("<table style='padding-left:4px;font-size:9pt;font-family:Tahoma;' cellpadding='4' cellspacing='0' Width='996px'>");

                    #region Print Header
                    //Gets location detail
                    //DataTable dtLocation = ReportSendMail.SelectByPK(Convert.ToDecimal(drLocationID["PK_LU_Location_ID"])).Tables[0];

                    //WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"] + " Report Data Rows Count : " + dtLocationWiseData.Length, _strCsvPath, false);
                    if (blnCompleted)
                    {
                        sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  ><td align='left' style='font-size:9pt'  colspan='6'>" + strReportTitle + " Year - " + drYearQuarter["Year"].ToString() + " - Quarter " + drYearQuarter["Quarter"].ToString() + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  ><td align='left' style='font-size:9pt'  colspan='6'>" + Convert.ToString(drLocationID["Sonic_Location_Code"]).PadLeft(4, '0') + " - " + Convert.ToString(drLocationID["dba"]) + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  ><td align='left' style='font-size:9pt'  colspan='6'>" + Convert.ToString(drLocationID["City"]) + ", " + Convert.ToString(drLocationID["FLD_state"]) + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  ><td align='left' style='font-size:9pt'  colspan='6'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr><td>&nbsp;</td></tr>");
                    }
                    else
                    {
                        sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  ><td align='left' style='font-size:9pt;' colspan='4'>" + Convert.ToString(drLocationID["Sonic_Location_Code"]).PadLeft(4, '0') + " - " + Convert.ToString(drLocationID["dba"]) + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  ><td align='left' style='font-size:9pt;' colspan='4'>" + Convert.ToString(drLocationID["City"]) + ", " + Convert.ToString(drLocationID["FLD_state"]) + "</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  ><td align='left' style='font-size:9pt;' colspan='4'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr><td>&nbsp;</td></tr>");
                        sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  ><td align='left' style='font-size:9pt;' colspan='4'>" + strReportTitle + " Year - " + drYearQuarter["Year"].ToString() + " - Quarter " + drYearQuarter["Quarter"].ToString() + "</td></tr>");
                    }
                    //sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  border='0'><td align='left' style='font-size:9pt'  border='0'  colspan='6'>" + strReportTitle + " Year - " + drYearQuarter["Year"].ToString() + " - Quarter " + drYearQuarter["Quarter"].ToString() + "</td></tr>");
                    //sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  border='0'><td align='left' style='font-size:9pt'  border='0'  colspan='6'>" + Convert.ToString(drLocationID["Sonic_Location_Code"]).PadLeft(4, '0') + " - " + Convert.ToString(drLocationID["dba"]) + "</td></tr>");
                    //sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  border='0'><td align='left' style='font-size:9pt'   border='0' colspan='6'>" + Convert.ToString(drLocationID["City"]) + ", " + Convert.ToString(drLocationID["FLD_state"]) + "</td></tr>");
                    //sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'  border='0'><td align='left' style='font-size:9pt'   border='0' colspan='6'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr><td>&nbsp;</td></tr>");
                    sbRecorords.Append("<tr style='font-weight: bold;' valign='top' ><td><table width='100%' cellspacing='0' cellpadding='0' style='border: black 0.5px solid;border-color: black;'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25px;page-break-inside: avoid' valign='top'>");
                    sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Department</td>");
                    sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Associate</td>");
                    sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Job Title</td>");

                    //for Completed Training Report add column
                    if (blnCompleted)
                    {
                        sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt; padding-left:10px;'>Completed Training</td>");
                        sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Completed/Waived</td>");
                        sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Date of Completion</td>");
                    }
                    else
                    {
                        sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt; padding-left:10px;'>Remaining Training to be Taken</td>");
                    }

                    sbRecorords.Append("</tr>");

                    #endregion

                    //DataView dv = new DataView(dtReportData);
                    //DataTable distinctValues = dv.ToTable(true, "Department");

                    //DataRow[] dtTrainingData = dtReportData.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "' AND Department='" + dtDept.Rows[i]["Department"].ToString() + "' AND Associate_Name='" + dtDistinctData.Rows[i]["Associate_Name"].ToString() + "' AND Job_Title='" + dtDistinctData.Rows[i]["Job_Title"].ToString() + "'");

                    string strPrevDept, strPrevAssoName, strPrevJobTitle;
                    strPrevDept = strPrevAssoName = strPrevJobTitle = "#";
                    DataTable dtRptDataForCurLocAndDept, dtRptDataForCurLocAndDeptAndAssocName, dtRptDataForClass;
                    DataTable dtUniqueDept, dtUniqueAssocName, dtUniqueJobTitle;
                    DataView dvReportData;

                    DataTable dtLocationData = new DataView(dtReportData, "PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "' AND Year ='" + drYearQuarter["Year"].ToString() + "' AND Quarter = '" + drYearQuarter["Quarter"].ToString() + "'", "", DataViewRowState.CurrentRows).ToTable();

                   
                    if (dtLocationData.Rows.Count > 0 && dtLocationData != null)
                    {
                        #region Print data
                        dtUniqueDept = dtLocationData.AsDataView().ToTable(true, "Department");
                        string str = "bgcolor=white";

                        for (int i = 0; i < dtUniqueDept.Rows.Count; i++) //Fetches unique departments for the current Location
                        {
                            if (strPrevDept != "#" && strPrevDept != dtUniqueDept.Rows[i]["Department"].ToString())
                            {
                                str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                                if (blnCompleted)
                                    sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>");
                                else
                                    sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                            }

                            str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                            sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + " align='left'  style='width:15%;font-size:8.5pt;padding-left:10px;' valign='top'>");
                            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueDept.Rows[i]["Department"]) + "</td>");

                            //Fetch Data for current department and current location
                            //dtRptDataForCurLocAndDept = dtLocationData.Select("Department='" + dtUniqueDept.Rows[i]["Department"].ToString() + "'").CopyToDataTable<DataRow>();
                            dvReportData = new DataView(dtLocationData, "Department='" + dtUniqueDept.Rows[i]["Department"].ToString() + "'", "Department", DataViewRowState.CurrentRows);
                            dtRptDataForCurLocAndDept = dvReportData.ToTable();

                            dtUniqueAssocName = dtRptDataForCurLocAndDept.AsDataView().ToTable(true, "Associate_Name");
                            for (int j = 0; j < dtUniqueAssocName.Rows.Count; j++) //Fetches unique associates for the current Location and department
                            {
                                if (strPrevAssoName != "#" && strPrevAssoName != dtUniqueAssocName.Rows[j]["Associate_Name"].ToString()) //Add Blank row
                                {
                                    str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                                    if (blnCompleted)
                                        sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>");
                                    else
                                        sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                }

                                if (j == 0)
                                    sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");
                                else
                                {
                                    str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                    sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + " valign='top' style='padding-left:10px;'><td>&nbsp;</td><td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueAssocName.Rows[j]["Associate_Name"]) + "</td>");
                                }

                                //Fetch Data for current Associate_Name and current location and department
                                //dtRptDataForCurLocAndDeptAndAssocName = dtRptDataForCurLocAndDept.Select("Associate_Name='" + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString() + "'").CopyToDataTable<DataRow>();
                                dvReportData = new DataView(dtRptDataForCurLocAndDept, "Associate_Name='" + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString().Replace("'", "''") + "'", "Associate_Name", DataViewRowState.CurrentRows);
                                dtRptDataForCurLocAndDeptAndAssocName = dvReportData.ToTable();

                                dtUniqueJobTitle = dtRptDataForCurLocAndDeptAndAssocName.AsDataView().ToTable(true, "Job_Title");
                                for (int k = 0; k < dtUniqueJobTitle.Rows.Count; k++) //Fetches unique associates for the current Location and department
                                {
                                    if (strPrevJobTitle != "#" && strPrevJobTitle != dtUniqueJobTitle.Rows[k]["Job_Title"].ToString()) //Add Blank row
                                    {
                                        str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                                        if (blnCompleted)
                                            sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>");
                                        else
                                            sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                    }

                                    if (k == 0)
                                        sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
                                    else
                                    {
                                        str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                        sbRecorords.Append("<tr " + str + " valign='top' style='padding-left:10px;'><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueJobTitle.Rows[k]["Job_Title"]) + "</td>");
                                    }
                                    //Fetches data for current location,Department,Associate_Name,Job title
                                    //dtRptDataForClass = dtRptDataForCurLocAndDeptAndAssocName.Select("Job_Title='" + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString() + "'").CopyToDataTable<DataRow>();
                                    dvReportData = new DataView(dtRptDataForCurLocAndDeptAndAssocName, "Job_Title='" + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString() + "'", "Job_Title", DataViewRowState.CurrentRows);
                                    dtRptDataForClass = dvReportData.ToTable();
                                    for (int m = 0; m < dtRptDataForClass.Rows.Count; m++)
                                    {
                                        if (m == 0)
                                        {
                                            if (blnCompleted)
                                                sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Completed/Waived"]) + "</td><td align='left' style='width:55%;font-size:9pt'>" + String.Format("{0:MM/dd/yyyy}", dtRptDataForClass.Rows[m]["Date of Completion"]) + " </td></tr>");
                                            else
                                                sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
                                        }
                                        else
                                        {
                                            str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                                            if (blnCompleted)
                                                sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + " valign='top' style='padding-left:10px;'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Completed/Waived"]) + "</td><td align='left' style='width:55%;font-size:9pt'>" + String.Format("{0:MM/dd/yyyy}", dtRptDataForClass.Rows[m]["Date of Completion"]) + " </td></tr>");
                                            else
                                                sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + " valign='top' style='padding-left:10px;'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Class_Name"]) + "</td></tr>");
                                        }
                                    }
                                    //str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                    //sbRecorords.Append("<tr " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                                    strPrevJobTitle = dtUniqueJobTitle.Rows[k]["Job_Title"].ToString();
                                }
                                strPrevJobTitle = "#";
                                strPrevAssoName = dtUniqueAssocName.Rows[j]["Associate_Name"].ToString();
                            }
                            strPrevAssoName = "#";
                            strPrevDept = dtUniqueDept.Rows[i]["Department"].ToString();
                        }
                        strPrevDept = "#";
                        #endregion
                    }
                    
                    else
                    {
                        WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                        // sbRecorords.Append("<table style='font-family:Tahoma;border: black 0.5px solid' border='1' cellpadding='4' cellspacing='0' Width='100%'>");
                        sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;page-break-inside: avoid;height:25px;'  border='1'>");
                        if (blnCompleted)
                            sbRecorords.Append("<td align='center'  colspan='6'  style='font-size:9pt;'>No Associates to be trained in quarter.</td></tr>");
                        else
                            sbRecorords.Append("<td align='center'  colspan='4'  style='font-size:9pt;'>No Associates to be trained in quarter.</td></tr>");
                    }

                    sbRecorords.Append("</table></td></tr><tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td><tr></table>");
                }

            }
            else
            {
                sbRecorords.Append("<table style='padding-left:4px;font-size:9pt;font-family:Tahoma; border:none;' border='0' cellpadding='4' cellspacing='0' Width='996px'>");

                WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                //sbRecorords.Append("<table style='font-family:Tahoma;border: black 0.5px solid'  border='1' cellpadding='4' cellspacing='0' Width='100%'>");
                sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;page-break-inside: avoid;height:25px;' border='1'>");
                if (blnCompleted)
                    sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='6'  border='1'>No Associates to be trained in quarter.</td></tr>");
                else
                    sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='4'  border='1'>No Associates to be trained in quarter.</td></tr>");

                sbRecorords.Append("</table></td></tr><tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td></tr></table>");
            }

            
            return sbRecorords;
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
                string strClassNameList = "";

                DataTable temp = dtTraining.AsDataView().ToTable(true, "FK_Employee", "EmailTo");

                WriteLog("No of employees having training in this Quarter : " + dtTraining.Rows.Count, _strCsvPath, false);

                mail.From = new MailAddress(_strSMTPmailFrom);
                mail.Subject = "Required Associated Safety Training This Quarter";
                mail.IsBodyHtml = true;

                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Port = Convert.ToInt16(_strPort);
                mSmtpClient.Host = _strSMTPServer;
                mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmailFrom, _strSMTPPwd);

                //distinct Employees in temp table
                if (temp.Rows.Count > 0 && temp != null)
                {
                    foreach (DataRow drEmployee in temp.Rows)
                    {
                        //filter by FK_Employee
                        DataTable dtEmployeeData = dtTraining.Select("FK_Employee='" + Convert.ToString(drEmployee["FK_Employee"]) + "'").CopyToDataTable<DataRow>();

                        if (dtEmployeeData.Rows.Count > 0 && dtEmployeeData != null)
                        {
                            foreach (DataRow dr in dtEmployeeData.Rows)
                            {
                                strClassNameList += "<li>" + (Convert.ToString(dr["Class_Name"])).Replace(",", "</li>");
                            }

                            mail.Body = "You are scheduled to take and complete the following training this quarter: <ul style='list-style-type:circle'>" + strClassNameList;

                            try
                            {
                                mail.Body += "</ul>";
                                mail.To.Add(new MailAddress(Convert.ToString(drEmployee["EmailTo"])));
                                mSmtpClient.Send(mail);
                                mail.To.Clear();
                                mail.Body = "";
                            }
                            catch (Exception Ex)
                            {
                                WriteLog("Exception occurred in SendMailEveryQuarterToEmployees while sending mail for Employee ID: " + Convert.ToDecimal(drEmployee["FK_Employee"]) + " Message : " + Ex.Message + ", Stack Trace: " + Ex.StackTrace, _strCsvPath, true);
                                mail.To.Clear();
                                mail.Body = "";
                            }

                            strClassNameList = "";
                        }
                    }
                }
                else
                {
                    WriteLog("No Data exists for SendMailEveryQuarterToEmployees()", _strCsvPath, false);
                }
                WriteLog("Function SendMailEveryQuarterToEmployees executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                WriteLog("Exception occurred while executing SendMailEveryQuarterToEmployees " + ex.Message, _strCsvPath + ", Stack Trace: " + ex.StackTrace, true);
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
                        mail.Body = "The following employees may have personal e-mails in their HR data:<br/>";
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

        /// <summary>
        /// Send Email To Each Employee for Remaining Quarterly Training to Every Week(till the 3 quarter)
        /// </summary>
        /// <param name="strMailFrom"></param>
        /// <param name="dtRecipients"></param>
        private void SendMailForWeeklyReminderOfRemainingTrainingToEmployees()
        {
            try
            {
                WriteLog("Executing SendMailForWeeklyReminderOfRemainingTrainingToEmployees", _strCsvPath, false);

                DataTable dtTraining = ReportSendMail.GetEmployeeTrainingData().Tables[0];
                MemoryStream memorystream = new MemoryStream();
                MailMessage mail = new MailMessage();
                string strClassNameList = "";
                string strURL = "";
                int month = 0;

                if ((quarterMonth == 1) || (quarterMonth == 2) || (quarterMonth == 3))
                {
                    month = 1;
                }
                else if ((quarterMonth == 4) || (quarterMonth == 5) || (quarterMonth == 6))
                {
                    month = 4;
                }
                else if ((quarterMonth == 7) || (quarterMonth == 8) || (quarterMonth == 9))
                {
                    month = 7;
                }
                else if ((quarterMonth == 10) || (quarterMonth == 11) || (quarterMonth == 12))
                {
                    month = 10;
                }

                var date = new DateTime(quarterDate.Year, month, 1);

                DataTable temp = dtTraining.AsDataView().ToTable(true, "FK_Employee", "EmailTo", "Company_Name");

                WriteLog("No of employees having Remaining training in this Quarter : " + dtTraining.Rows.Count, _strCsvPath, false);

                mail.From = new MailAddress(_strSMTPmailFrom);
                mail.Subject = "Associate Training Reminder";
                mail.IsBodyHtml = true;

                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Port = Convert.ToInt16(_strPort);
                mSmtpClient.Host = _strSMTPServer;
                mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmailFrom, _strSMTPPwd);

                //distinct Employees in temp table
                if (temp.Rows.Count > 0 && temp != null)
                {
                    foreach (DataRow drEmployee in temp.Rows)
                    {
                        //filter by FK_Employee
                        DataTable dtEmployeeData = dtTraining.Select("FK_Employee='" + Convert.ToString(drEmployee["FK_Employee"]) + "'").CopyToDataTable<DataRow>();

                        if (dtEmployeeData.Rows.Count > 0 && dtEmployeeData != null)
                        {
                            foreach (DataRow dr in dtEmployeeData.Rows)
                            {
                                strClassNameList += "<li>" + (Convert.ToString(dr["Class_Name"])).Replace(",", "</li>");
                            }

                            if (Convert.ToString(drEmployee["Company_Name"]) == "Sonic")
                            {
                                strURL = "https://sonic.erims2.com/user manual/ehs training flyer - sonic - all.pdf";
                            }
                            else
                            {
                                strURL = "https://sonic.erims2.com/user manual/ehs training flyer - ep - all.pdf";
                            }

                            mail.Body = Convert.ToString(drEmployee["Company_Name"]) + " Associate: <br/><br/> On " + date.ToString("d MMMM, yyyy") + " you were scheduled to take the following training courses: <br/> <ul style='list-style-type:circle'>" + strClassNameList
                                         + "</ul><br/>It appears that you have not yet completed the above course(s); please complete your training as soon as possible.<br/><br/>Please refer to the training brochure which includes a link to the training web site by clicking <a href=\"" + strURL + "\">here.</a>" +
                                         "<br/><br/>If you have any questions please contact your Regional Loss Control Manager.<br/><br/>Thank you!";

                            try
                            {
                                mail.To.Add(new MailAddress(Convert.ToString(drEmployee["EmailTo"])));
                                mSmtpClient.Send(mail);
                                mail.To.Clear();
                                mail.Body = "";
                            }
                            catch (Exception Ex)
                            {
                                WriteLog("Exception occurred in SendMailForWeeklyReminderOfRemainingTrainingToEmployees while sending mail for Employee ID: " + Convert.ToDecimal(drEmployee["FK_Employee"]) + " Message : " + Ex.Message + ", Stack Trace: " + Ex.StackTrace, _strCsvPath, true);
                                mail.To.Clear();
                                mail.Body = "";
                            }
                            strClassNameList = "";
                        }
                    }
                }
                else
                {
                    WriteLog("No Data exists for SendMailForWeeklyReminderOfRemainingTrainingToEmployees()", _strCsvPath, false);
                }
                WriteLog("Function SendMailForWeeklyReminderOfRemainingTrainingToEmployees executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                WriteLog("Exception occurred while executing SendMailForWeeklyReminderOfRemainingTrainingToEmployees " + ex.Message, _strCsvPath + ", Stack Trace: " + ex.StackTrace, true);
            }
        }

        /// <summary>
        /// Send Mail For Payroll Training Report
        /// </summary>
        private void SendMailForPayrollTrainingReport()
        {
            try
            {
                WriteLog("Executing SendMailForPayrollTrainingReport", _strCsvPath, false);

                DataSet dsReportData = ReportSendMail.GetEmployeeTrainingDataForPayRollTrainingReport();
                DataTable dtReportData = dsReportData.Tables[0];
                DataTable dtReceipient = dsReportData.Tables[1];
                DataTable dtLocationIDs = dsReportData.Tables[2];
                DataTable dtReportDataLastWeek = dsReportData.Tables[3];

                WriteLog("Report Data Count : " + dtReportData.Rows.Count, _strCsvPath, false);
                WriteLog("Recipient count : " + dtReceipient.Rows.Count, _strCsvPath, false);
                WriteLog("Location count : " + dtLocationIDs.Rows.Count, _strCsvPath, false);

                System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                foreach (DataRow drLocationID in dtLocationIDs.Rows) //Location wise
                {
                    sbRecorords.Clear();

                    try
                    {
                        sbRecorords = GenerateReportForPayrollTraining(dtReportData, drLocationID, sbRecorords, "Payroll Training Report", dtReportDataLastWeek);
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Exception occurred  for Location ID: " + Convert.ToDecimal(drLocationID["PK_LU_Location_ID"]) + ", Exception Message :" + ex.Message + ", Stack Trace:" + ex.StackTrace, _strCsvPath, true);
                        EventLog.WriteEntry("Error in function SendMailForPayrollTrainingReport()" + ex.Message + ",Stack Trace:" + ex.StackTrace);
                    }

                    //Write HTML in to HtmlWriter
                    htmlWrite.WriteLine(sbRecorords.ToString());
                    DataRow[] drReceipientNew = dtReceipient.Select("PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'");
                    SendMail("Payroll Training Report", "Payroll Training Report.xls", sbRecorords.ToString(), drReceipientNew, String.Empty, String.Empty, String.Empty, "Payroll Training Report");
                }

                WriteLog("Function SendMailForPayrollTrainingReport executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in function SendMailForPayrollTrainingReport()" + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Exception " + ex.Message + " occurred in SendMailForPayrollTrainingReport and Stack Trace:" + ex.StackTrace, _strCsvPath, true);
            }
        }

        /// <summary>
        /// GenerateReportForPayrollTraining 
        /// </summary>
        /// <param name="dtReportData"></param>
        /// <param name="drLocationID"></param>
        /// <param name="sbRecorords"></param>
        /// <returns></returns>
        public StringBuilder GenerateReportForPayrollTraining(DataTable dtReportData, DataRow drLocationID, StringBuilder sbRecorords, String strReportTitle, DataTable dtReportDataLastWeek)
        {
            if (dtReportData != null && dtReportData.Rows.Count > 0)
            {
                //Gets location detail
                DataTable dtLocation = ReportSendMail.SelectByPK(Convert.ToDecimal(drLocationID["PK_LU_Location_ID"])).Tables[0];

                sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt' colspan='3'>" + strReportTitle + " - Quarter " + ((quarterMonth - 1) / 3 + 1) + "</td></tr>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='3'>" + Convert.ToString(dtLocation.Rows[0]["Sonic_Location_Code"]).PadLeft(4, '0') + " - " + Convert.ToString(dtLocation.Rows[0]["dba"]) + "</td></tr>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='3'>" + Convert.ToString(dtLocation.Rows[0]["City"]) + ", " + Convert.ToString(dtLocation.Rows[0]["StateName"]) + "</td></tr>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='3'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr colspan='3'><td>&nbsp;</td></tr>");
                sbRecorords = GenerateTable(sbRecorords, dtReportDataLastWeek, drLocationID);
                WriteLog("Executing GenerateTable Method Executed", _strCsvPath, false);
                sbRecorords.Append("<tr colspan='3'><td>&nbsp;</td></tr>");
                sbRecorords = GenerateTable(sbRecorords, dtReportData, drLocationID);
                WriteLog("Executing GenerateTable Method Executed", _strCsvPath, false);
            }
            else
            {
                WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                DataTable dtLocation = ReportSendMail.SelectByPK(Convert.ToDecimal(drLocationID["PK_LU_Location_ID"])).Tables[0];
                sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt' colspan='3'>" + strReportTitle + " - Quarter " + ((quarterMonth - 1) / 3 + 1) + "</td></tr>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='3'>" + Convert.ToString(dtLocation.Rows[0]["Sonic_Location_Code"]).PadLeft(4, '0') + " - " + Convert.ToString(dtLocation.Rows[0]["dba"]) + "</td></tr>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='3'>" + Convert.ToString(dtLocation.Rows[0]["City"]) + ", " + Convert.ToString(dtLocation.Rows[0]["StateName"]) + "</td></tr>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td align='left' style='font-size:9pt'  colspan='3'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr colspan='3'><td>&nbsp;</td></tr>");
                sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td><table border='1' cellspacing='0' width='100%' cellpadding='0' style='border: black 0.5px solid'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25px;'  valign='top'>");
                sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;padding-left:10px;'>Associate</td>");
                sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt;padding-left:10px;'>Completed Training Class</td>");
                sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt;padding-left:10px;'>Date of Completion</td>");
                sbRecorords.Append("<tr valign='top' style='background-color:#F2F2F2;color:Black;page-break-inside: avoid;'>");
                sbRecorords.Append("<td align='center' colspan='3' style='font-size:9pt;'>No Records found.</td></tr>");
            }

            sbRecorords.Append("</td></tr></table>");
            return sbRecorords;
        }

        /// <summary>
        /// generate the table in reports
        /// </summary>
        /// <param name="sbRecorords"></param>
        /// <param name="dtReportData"></param>
        /// <param name="drLocationID"></param>
        /// <returns></returns>
        public StringBuilder GenerateTable(StringBuilder sbRecorords, DataTable dtReportData, DataRow drLocationID)
        {
            DataView dvReportData;
            string strPrevAssoName;
            strPrevAssoName = "#";
            DataTable dtRptDataForCurLocAndDeptAndAssocName, dtUniqueAssocName;
            WriteLog("Executing GenerateTable Method", _strCsvPath, false);
            sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td><table border='1' cellspacing='0' width='100%' cellpadding='0' style='border: black 0.5px solid'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25px;'  valign='top'>");
            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;padding-left:10px;'>Associate</td>");
            sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt;padding-left:10px;'>Completed Training Class</td>");
            sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt;padding-left:10px;'>Date of Completion</td>");
            sbRecorords.Append("</tr>");

            dvReportData = new DataView(dtReportData, "PK_LU_Location_ID ='" + drLocationID["PK_LU_Location_ID"].ToString() + "'", "PK_LU_Location_ID", DataViewRowState.CurrentRows);

            if (dvReportData.Count > 0)
            {
                DataTable dtLocationData = dvReportData.ToTable();
                dtUniqueAssocName = dtLocationData.AsDataView().ToTable(true, "Associate_Name");

                string str = "bgcolor=white";

                for (int i = 0; i < dtUniqueAssocName.Rows.Count; i++)
                {
                    if (strPrevAssoName != "#" && strPrevAssoName != dtUniqueAssocName.Rows[i]["Associate_Name"].ToString())
                    {
                        str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";

                        sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td><td>&nbsp;</td></tr>");
                    }

                    str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                    sbRecorords.Append("<tr align='left' valign='top' style='width:15%;padding-left:10px;font-size:8.5pt;page-break-inside: avoid' " + str + ">");
                    sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt;padding-left:10px;'>" + Convert.ToString(dtUniqueAssocName.Rows[i]["Associate_Name"]) + "</td>");

                    dvReportData = new DataView(dtLocationData, "Associate_Name='" + dtUniqueAssocName.Rows[i]["Associate_Name"].ToString().Replace("'", "''") + "'", "Associate_Name", DataViewRowState.CurrentRows);
                    dtRptDataForCurLocAndDeptAndAssocName = dvReportData.ToTable();

                    for (int m = 0; m < dtRptDataForCurLocAndDeptAndAssocName.Rows.Count; m++)
                    {
                        // WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"] + " Department : " + dtUniqueDept.Rows[i]["Department"].ToString() + " Associate_Name : " + dtUniqueAssocName.Rows[j]["Associate_Name"].ToString() + " Job_Title : " + dtUniqueJobTitle.Rows[k]["Job_Title"].ToString(), _strCsvPath, false);
                        if (m == 0)
                        {
                            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtRptDataForCurLocAndDeptAndAssocName.Rows[m]["Class_Name"]) + "</td><td align='left' style='width:15%;font-size:9pt'>" + String.Format("{0:MM/dd/yyyy}", dtRptDataForCurLocAndDeptAndAssocName.Rows[m]["Date of Completion"]) + "</td></tr>");
                        }
                        else
                        {
                            str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                            sbRecorords.Append("<tr " + str + " valign='top' style='padding-left:10px;page-break-inside: avoid;'><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForCurLocAndDeptAndAssocName.Rows[m]["Class_Name"]) + "</td><td align='left' style='width:15%;font-size:9pt'>" + String.Format("{0:MM/dd/yyyy}", dtRptDataForCurLocAndDeptAndAssocName.Rows[m]["Date of Completion"]) + "</td></tr>");
                        }
                    }
                    strPrevAssoName = Convert.ToString(dtUniqueAssocName.Rows[i]["Associate_Name"]);
                }
                strPrevAssoName = "#";
            }
            else
            {
                WriteLog("No data exists for Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                sbRecorords.Append("<tr valign='top' style='background-color:#F2F2F2;color:Black;page-break-inside: avoid;'>");
                sbRecorords.Append("<td align='center' colspan='3' style='font-size:9pt;'>No Associates Trained.</td></tr>");
            }
            sbRecorords.Append("</table></td></tr>");
            return sbRecorords;
        }

        /// <summary>
        /// Send Mail For Percentage Recap
        /// </summary>
        public void SendMailForPercentageRecap()
        {
            try
            {
                WriteLog("Executing SendMailForPercentageRecap", _strCsvPath, false);
                DataSet dsReport = ReportSendMail.GetEmployeeTrainingDataForPercentageRecap();
                DataTable dtReportData = dsReport.Tables[0];
                DataTable dtPercentage = dsReport.Tables[1];
                DataTable dtRLCMUsers = ReportSendMail.GetRLCMUsers().Tables[0];

                System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
                System.Text.StringBuilder sbRecorordsCompleted = new System.Text.StringBuilder("");
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
                        DataTable dtRegion = ReportSendMail.SelectRegion_By_RLCM(Convert.ToDecimal(drRLCM["FK_Employee_Id"])).Tables[0];

                        WriteLog("Region count : " + dtRegion.Rows.Count + " for RLCM user : " + drRLCM["FK_Employee_Id"], _strCsvPath, false);

                        if (dtRegion != null && dtRegion.Rows.Count > 0)
                        {
                            //WriteLog("Location ID : " + drLocationID["PK_LU_Location_ID"], _strCsvPath, false);
                            try
                            {
                                sbRecorords = GenerateReportForPercentageRecap(dtReportData, sbRecorords, dtRegion, dtPercentage, "Percentage Recap Report", drRLCM);
                            }
                            catch (Exception ex)
                            {
                                WriteLog("Exception occurred for Location ID: " + drRLCM["region"] + ", Exception Message :" + ex.Message + ", Stack Trace :" + ex.StackTrace, _strCsvPath, true);
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
                    htmlWrite.WriteLine(sbRecorords.ToString());
                    // SendMailPDF("Associate Training Report", "Associate Training Report.pdf", sbRecorords.ToString(), drRLCM);
                    SendMail("Percentage Recap Report", "Percentage Recap Report.xls", sbRecorords.ToString(), drRLCM, string.Empty, string.Empty, String.Empty, "Percentage Recap Report");
                }
                WriteLog("function SendMailToRLCMLocationManagers() executed", _strCsvPath, false);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Exception occurred : " + ex.Message + ",Stack Trace : " + ex.StackTrace, _strCsvPath, true);
            }
        }

        /// <summary>
        /// Generate Report For Percentage Recap
        /// </summary>
        /// <param name="dtReportData"></param>
        /// <param name="sbRecorords"></param>
        /// <param name="drLocationID"></param>
        /// <returns></returns>
        public StringBuilder GenerateReportForPercentageRecap(DataTable dtReportData, StringBuilder sbRecorords, DataTable dtRegion, DataTable dtPercentage, String strReportTitle, DataRow drRLCM)
        {
            sbRecorords.Append("<table style='padding-left:4px;font-size:9pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
            sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'><td align='left' style='font-size:9pt'  colspan='4'>" + strReportTitle + "- Quarter " + ((quarterMonth - 1) / 3 + 1) + "</td></tr>");
            sbRecorords.Append("<tr style='font-weight: bold;page-break-inside: avoid' valign='top'><td align='left' style='font-size:9pt'  colspan='4'>" + DateTime.Now.ToString("dd MMMM yyyy") + "</td></tr><tr><td>&nbsp;</td></tr>");
            sbRecorords.Append("<tr style='font-weight: bold;' valign='top'><td><table border='1' width='100%' cellspacing='0' cellpadding='0' style='border: black 0.5px solid;border-color: black;'><tr style='font-weight: bold;background-color:#95B3D7;color:Black;font-size:11pt;height:25px;page-break-inside: avoid' valign='top'>");
            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Region</td>");
            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Market</td>");
            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt; padding-left:10px;'>Location</td>");
            sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt; padding-left:10px;'>Percent Complete</td>");
            sbRecorords.Append("</tr>");

            if (dtRegion != null && dtRegion.Rows.Count > 0)
            {
                //Gets  detail
                WriteLog("RLCM User : " + drRLCM["FK_Employee_Id"] + " Report Data Rows Count : " + dtRegion.Rows.Count, _strCsvPath, false);

                string strPrevRegion, strPrevMarket, strPrevLoc;
                strPrevRegion = strPrevMarket = strPrevLoc = "#";
                DataTable dtRptDataForCurRegion, dtRptDataForCurRegionAndMarket, dtRptDataForClass;
                DataTable dtUniqueRegion, dtUniqueMarket, dtUniqueLoc;
                DataView dvReportData;

                dtUniqueRegion = dtRegion.AsDataView().ToTable(true, "region");
                string str = "bgcolor=white";

                for (int i = 0; i < dtUniqueRegion.Rows.Count; i++) //Fetches unique Region for the current RLCM User
                {
                    if (strPrevRegion != "#" && strPrevRegion != dtUniqueRegion.Rows[i]["Region"].ToString())
                    {
                        str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                        sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                    }

                    str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                    sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + " align='left'  style='width:15%;font-size:8.5pt;padding-left:10px;' valign='top'>");
                    sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueRegion.Rows[i]["Region"]) + "</td>");

                    //Fetch Data for current Region 
                    dvReportData = new DataView(dtReportData, "Region='" + dtUniqueRegion.Rows[i]["Region"].ToString() + "'" + "AND FK_Employee_Id='" + drRLCM["FK_Employee_Id"].ToString() + "'", "Region", DataViewRowState.CurrentRows);
                    dtRptDataForCurRegion = dvReportData.ToTable();

                    dtUniqueMarket = dtRptDataForCurRegion.AsDataView().ToTable(true, "Market");

                    for (int j = 0; j < dtUniqueMarket.Rows.Count; j++) //Fetches unique Market for the current Region
                    {
                        if (strPrevMarket != "#" && strPrevMarket != dtUniqueMarket.Rows[j]["Market"].ToString()) //Add Blank row
                        {
                            str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                            sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                        }

                        if (j == 0)
                            sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueMarket.Rows[j]["Market"]) + "</td>");
                        else
                        {
                            str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                            sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + " valign='top' style='padding-left:10px;'><td>&nbsp;</td><td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueMarket.Rows[j]["Market"]) + "</td>");
                        }

                        //Fetch Data for current MArket and Region
                        dvReportData = new DataView(dtRptDataForCurRegion, "Market='" + dtUniqueMarket.Rows[j]["Market"].ToString().Replace("'", "''") + "'", "Market", DataViewRowState.CurrentRows);
                        dtRptDataForCurRegionAndMarket = dvReportData.ToTable();

                        dtUniqueLoc = dtRptDataForCurRegionAndMarket.AsDataView().ToTable(true, "PK_LU_Location_ID", "Sonic_Location_Code", "dba");
                        for (int k = 0; k < dtUniqueLoc.Rows.Count; k++) //Fetches unique Location for the current Region and Market
                        {
                            if (strPrevLoc != "#" && strPrevLoc != dtUniqueLoc.Rows[k]["PK_LU_Location_ID"].ToString()) //Add Blank row
                            {
                                str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + "><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>&nbsp;</td></tr>");
                            }

                            if (k == 0)
                                sbRecorords.Append("<td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueLoc.Rows[k]["Sonic_Location_Code"]).PadLeft(4, '0') + " - " + Convert.ToString(dtUniqueLoc.Rows[k]["dba"]) + "</td>");
                            else
                            {
                                str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                sbRecorords.Append("<tr " + str + " valign='top' style='padding-left:10px;'><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:15%;font-size:9pt'>" + Convert.ToString(dtUniqueLoc.Rows[k]["Sonic_Location_Code"]).PadLeft(4, '0') + " - " + Convert.ToString(dtUniqueLoc.Rows[k]["dba"]) + "</td>");
                            }

                            //Fetches data for current Region,MArket,Location
                            dvReportData = new DataView(dtPercentage, "PK_LU_Location_ID='" + dtUniqueLoc.Rows[k]["PK_LU_Location_ID"].ToString() + "'" + "AND FK_Employee_Id='" + drRLCM["FK_Employee_Id"].ToString() + "'", "PK_LU_Location_ID", DataViewRowState.CurrentRows);
                            dtRptDataForClass = dvReportData.ToTable();
                            if (dtRptDataForClass.Rows.Count > 0)
                            {
                                for (int m = 0; m < dtRptDataForClass.Rows.Count; m++)
                                {
                                    if (m == 0)
                                    {
                                        sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Percentage_Final"]) + "</td></tr>");
                                    }
                                    else
                                    {
                                        str = (str == "bgcolor=white") ? "bgcolor=#eaeaea" : "bgcolor=white";
                                        sbRecorords.Append("<tr style='page-break-inside: avoid;' " + str + " valign='top' style='padding-left:10px;'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td align='left' style='width:55%;font-size:9pt'>" + Convert.ToString(dtRptDataForClass.Rows[m]["Percentage_Final"]) + "</td></tr>");
                                    }
                                }
                            }
                            else
                            {
                                sbRecorords.Append("<td align='left' style='width:55%;font-size:9pt'></td></tr>");
                            }
                            strPrevLoc = dtUniqueLoc.Rows[k]["PK_LU_Location_ID"].ToString();
                        }
                        strPrevLoc = "#";
                        strPrevMarket = dtUniqueMarket.Rows[j]["Market"].ToString();
                    }
                    strPrevMarket = "#";
                    strPrevRegion = dtUniqueRegion.Rows[i]["Region"].ToString();
                }
                strPrevRegion = "#";
            }
            else
            {
                WriteLog("No data exists for RLCM User : " + drRLCM["FK_Employee_Id"], _strCsvPath, false);
                //sbRecorords.Append("<table style='font-family:Tahoma;border: black 0.5px solid'  border='1' cellpadding='4' cellspacing='0' Width='100%'>");
                sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;page-break-inside: avoid;height:25px;' border='1'>");
                sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='4'  border='1'>No Records found.</td></tr>");
            }

            sbRecorords.Append("</table></td></tr></table>");
            return sbRecorords;
        }

        #region Mail Send Method

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
                objPdf.PdfDocumentOptions.GenerateSelectablePdf = true;
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
                            mail.Body = drRecipient["First_Name"].ToString() + " " + drRecipient["Last_Name"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thank you!<br />";
                            mail.Body += "<br /> This is system generated message. Please do not reply.";
                            mail.IsBodyHtml = true;
                            mail.To.Add(new MailAddress(drRecipient["Email"].ToString()));
                            mSmtpClient.Send(mail);
                            mail.To.Clear();
                        }
                        catch (Exception Ex)
                        {
                            EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + Ex.Message + ",Stack Trace:" + Ex.StackTrace);
                            WriteLog("Error in Sending Mail for " + strReportTitle + "Message: " + Ex.Message + " , Stack Trace:" + Ex.StackTrace, _strCsvPath, true);
                        }
                    }

                    atts.Dispose();

                    if (File.Exists(strPath))
                        File.Delete(strPath);
                }
                else
                {
                    EventLog.WriteEntry("Error in converting Report to PDF for " + strReportTitle);
                    WriteLog("Error in converting Report to PDF for " + strReportTitle, _strCsvPath, false);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Error in Sending Mail for " + ex.Message + " , Stack Trace:" + ex.StackTrace, _strCsvPath, true);
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
            objPdf.PdfDocumentOptions.GenerateSelectablePdf = true;
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
                    //mail.Body = drRecipients["First_Name"].ToString() + " " + drRecipients["Last_Name"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thankyou!<br />";
                    mail.Body = drRecipients["NAME"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thank you!<br />";
                    mail.Body += "<br /> This is system generated message. Please do not reply.";
                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(drRecipients["Email"].ToString()));
                    mSmtpClient.Send(mail);
                    mail.To.Clear();
                    //}
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ", Stack Trace:" + ex.StackTrace);
                    WriteLog("Exception occurred " + ex.Message + " in SendMailPDF() , Stack Trace:" + ex.StackTrace, _strCsvPath, true);
                }
                atts.Dispose();

                if (File.Exists(strPath))
                    File.Delete(strPath);
            }
            else
            {
                EventLog.WriteEntry("Error in converting Report to PDF for " + strReportTitle);
                WriteLog("Error in converting Report to PDF for " + strReportTitle, _strCsvPath, false);
            }
        }

        /// <summary>
        /// send Mail with Excel attachment
        /// </summary>
        /// <param name="strReportTitle"></param>
        /// <param name="strFileNameToSave"></param>
        /// <param name="sw"></param>
        /// <param name="drRecipients"></param>
        protected void SendMail(String strReportTitle, String strFileNameToSave, String sw, DataRow[] drRecipients, String swCompleted, String strReportTitleCompleted, String strFileNameToSaveCompleted, String strSubjet)
        {
            try
            {
                ArrayList arrPaths = new ArrayList();
                arrPaths.Add(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + strFileNameToSave.Replace(".xls", "") + System.DateTime.Now.ToString("MMddyyhhmmss") + ".xls");

                if (strFileNameToSaveCompleted != string.Empty)
                {
                    arrPaths.Add(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + strFileNameToSaveCompleted.Replace(".xls", "") + System.DateTime.Now.ToString("MMddyyhhmmss") + ".xls");
                }

                File.WriteAllText(arrPaths[0].ToString(), sw.ToString());

                if (strFileNameToSaveCompleted != string.Empty)
                {
                    File.WriteAllText(arrPaths[1].ToString(), swCompleted.ToString());
                }

                bool[] blnHTML2Excel = new bool[2];
                ArrayList arrOutputFiles = new ArrayList();
                int i = 0;

                
                MailMessage mail = new MailMessage();
                

                try
                {
                    foreach (string arrPath in arrPaths)
                    {
                        if (File.Exists(arrPath))
                        {
                            string data = File.ReadAllText(arrPath);
                            data = data.Trim();
                            HTML2Excel objHtml2Excel = new HTML2Excel(data);
                            arrOutputFiles.Add(Path.GetFullPath(arrPath).Replace(".xls", ".xlsx"));
                            objHtml2Excel.isGrid = true;
                            objHtml2Excel.overwriteBorder = false;
                            blnHTML2Excel[i] = objHtml2Excel.Convert2Excel(arrOutputFiles[i].ToString());
                            i++;
                        }
                    }

                    

                    mail.From = new MailAddress(_strSMTPmailFrom);
                    mail.Subject = "eRIMS ::" + strSubjet;

                    SmtpClient mSmtpClient = new SmtpClient();
                    mSmtpClient.Host = _strSMTPServer;
                    mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmailFrom, _strSMTPPwd);

                    foreach (DataRow drRecipient in drRecipients)
                    {
                        MemoryStream memorystream = new MemoryStream();
                        MemoryStream memorystreamCompleted = new MemoryStream();
                        Attachment atts;
                        memorystream = new MemoryStream(File.ReadAllBytes(arrOutputFiles[0].ToString()));
                        atts = new Attachment(memorystream, strFileNameToSave.Replace(".xls", ".xlsx"));
                        mail.Attachments.Add(atts);

                        if (strFileNameToSaveCompleted != string.Empty)
                        {
                            memorystreamCompleted = new MemoryStream(File.ReadAllBytes(arrOutputFiles[1].ToString()));
                            atts = new Attachment(memorystreamCompleted, strFileNameToSaveCompleted.Replace(".xls", ".xlsx"));
                            mail.Attachments.Add(atts);
                        }

                        try
                        {
                            mail.Body = drRecipient["First_Name"].ToString() + " " + drRecipient["Last_Name"].ToString() + ",<br />Please find the " + strSubjet + " Attached with this mail.<br /><br /><br />Thank you!<br />";
                            mail.Body += "<br /> This is system generated message. Please do not reply.";
                            mail.IsBodyHtml = true;
                            mail.To.Add(new MailAddress(drRecipient["Email"].ToString()));
                            mSmtpClient.Send(mail);
                            mail.To.Clear();
                        }
                        catch (Exception Ex)
                        {
                            EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + Ex.Message + ",Stack Trace:" + Ex.StackTrace);
                            WriteLog("Error in Sending Mail for " + strReportTitle + "Message: " + Ex.Message + " , Stack Trace:" + Ex.StackTrace + ",To Email : " + drRecipient["Email"].ToString(), _strCsvPath, true);
                        }
                        finally
                        {
                            memorystream.Dispose();
                            memorystreamCompleted.Dispose();
                        }
                        mail.Attachments.Clear();
                        atts.Dispose();
                    }

                    foreach (string arrPath in arrPaths)
                    {
                        if (File.Exists(arrPath))
                            File.Delete(arrPath);
                    }

                    foreach (string outputFile in arrOutputFiles)
                    {
                        if (File.Exists(outputFile))
                            File.Delete(outputFile);
                    }
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                    WriteLog("Error in Sending Mail for " + ex.Message + " , Stack Trace:" + ex.StackTrace, _strCsvPath, true);
                }
                finally
                {
                    
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Error in Sending Mail for " + ex.Message + " , Stack Trace:" + ex.StackTrace, _strCsvPath, true);
            }
        }

        /// <summary>
        /// send Mail with Excel attachment
        /// </summary>
        /// <param name="strReportTitle"></param>
        /// <param name="strFileNameToSave"></param>
        /// <param name="sw"></param>
        /// <param name="drRecipients"></param>
        protected void SendMail(String strReportTitle, String strFileNameToSave, String sw, DataRow drRecipients, String swCompleted, String strReportTitleCompleted, String strFileNameToSaveCompleted, String strSubject)
        {
            try
            {
                ArrayList arrPaths = new ArrayList();
                arrPaths.Add(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + strFileNameToSave.Replace(".xls", "") + System.DateTime.Now.ToString("MMddyyhhmmss") + ".xls");

                if (strFileNameToSaveCompleted != string.Empty)
                {
                    arrPaths.Add(AppDomain.CurrentDomain.BaseDirectory + @"temp\" + strFileNameToSaveCompleted.Replace(".xls", "") + System.DateTime.Now.ToString("MMddyyhhmmss") + ".xls");
                }

                File.WriteAllText(arrPaths[0].ToString(), sw.ToString());

                if (strFileNameToSaveCompleted != string.Empty)
                {
                    File.WriteAllText(arrPaths[1].ToString(), swCompleted.ToString());
                }

                bool[] blnHTML2Excel = new bool[2];
                ArrayList arrOutputFiles = new ArrayList();
                int i = 0;

                MemoryStream memorystream = new MemoryStream();
                MailMessage mail = new MailMessage();
                Attachment atts;

                try
                {
                    foreach (string arrPath in arrPaths)
                    {
                        if (File.Exists(arrPath))
                        {
                            string data = File.ReadAllText(arrPath);
                            data = data.Trim();
                            HTML2Excel objHtml2Excel = new HTML2Excel(data);
                            arrOutputFiles.Add(Path.GetFullPath(arrPath).Replace(".xls", ".xlsx"));
                            objHtml2Excel.isGrid = true;
                            objHtml2Excel.overwriteBorder = false;
                            blnHTML2Excel[i] = objHtml2Excel.Convert2Excel(arrOutputFiles[i].ToString());
                            i++;
                        }
                    }

                    memorystream = new MemoryStream(File.ReadAllBytes(arrOutputFiles[0].ToString()));
                    atts = new Attachment(memorystream, strFileNameToSave.Replace(".xls", ".xlsx"));
                    mail.Attachments.Add(atts);

                    if (strFileNameToSaveCompleted != string.Empty)
                    {
                        memorystream = new MemoryStream(File.ReadAllBytes(arrOutputFiles[1].ToString()));
                        atts = new Attachment(memorystream, strFileNameToSaveCompleted.Replace(".xls", ".xlsx"));
                        mail.Attachments.Add(atts);
                    }

                    mail.From = new MailAddress(_strSMTPmailFrom);
                    mail.Subject = "eRIMS :: " + strSubject;

                    SmtpClient mSmtpClient = new SmtpClient();
                    mSmtpClient.Host = _strSMTPServer;
                    mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmailFrom, _strSMTPPwd);

                    try
                    {
                        mail.Body = drRecipients["NAME"].ToString() + ",<br />Please find the " + strSubject + " Attached with this mail.<br /><br /><br />Thank you!<br />";
                        mail.Body += "<br /> This is system generated message. Please do not reply.";
                        mail.IsBodyHtml = true;
                        mail.To.Add(new MailAddress(drRecipients["Email"].ToString()));
                        mSmtpClient.Send(mail);
                        mail.To.Clear();
                    }
                    catch (Exception Ex)
                    {
                        EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + Ex.Message + ",Stack Trace:" + Ex.StackTrace);
                        WriteLog("Error in Sending Mail for " + strReportTitle + "Message: " + Ex.Message + " , Stack Trace:" + Ex.StackTrace + ",To Email : " + drRecipients["Email"].ToString(), _strCsvPath, true);
                    }

                    atts.Dispose();

                    foreach (string arrPath in arrPaths)
                    {
                        if (File.Exists(arrPath))
                            File.Delete(arrPath);
                    }

                    foreach (string outputFile in arrOutputFiles)
                    {
                        if (File.Exists(outputFile))
                            File.Delete(outputFile);
                    }
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                    WriteLog("Error in Sending Mail for " + ex.Message + " , Stack Trace:" + ex.StackTrace + ",To Email : " + drRecipients["Email"].ToString(), _strCsvPath, true);

                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message + ",Stack Trace:" + ex.StackTrace);
                WriteLog("Error in Sending Mail for " + ex.Message + " , Stack Trace:" + ex.StackTrace, _strCsvPath, true);
            }
        }

        #endregion
        #endregion
    }
}
