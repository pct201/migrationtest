using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using OpenPop.Pop3;
//using OpenPop.Mime;
//using OpenPop.Mime.Header;
using System.Text.RegularExpressions;
using ERIMS_DAL;
using ActiveUp.Net.Mail;

namespace ERIMS_Sonic_EmailScheduler
{
    public partial class ERIMS_SonicEmailScheduler : ServiceBase
    {
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
        public int _ReadMailCount = -1;
        public Imap4Client objImap4Client;

        public bool _First_Run = true;

        public ERIMS_SonicEmailScheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ReadConfigSetting();
            EventLog.WriteEntry("ERIMS Sonic Mail Scheduler Started at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Sonic Mail Scheduler Started", _strCsvPath, false);
            Thread TReadEmailReplyFromSMTPServer = default(Thread);
            TReadEmailReplyFromSMTPServer = new System.Threading.Thread(ReadEmailReplyFromSMTPServer);
            TReadEmailReplyFromSMTPServer.Start();
        }

        public void niktest()
        {
            ReadConfigSetting();
            //EventLog.WriteEntry("Event Import Service Started : " + DateTime.Now.ToString());
            WriteLog("ERIMS Sonic Mail Scheduler Started", _strCsvPath, false);
            Thread TReadEmailReplyFromSMTPServer = default(Thread);
            TReadEmailReplyFromSMTPServer = new System.Threading.Thread(ReadEmailReplyFromSMTPServer);
            TReadEmailReplyFromSMTPServer.Start();
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("ERIMS Sonic Mail Scheduler Stopped at : " + DateTime.Now.ToString());
            WriteLog("ERIMS Sonic Mail Scheduler Stopped ", _strCsvPath, false);
        }

        public void ReadEmailReplyFromSMTPServer()
        {
            try
            {
                //Uncomment it
                //Thread.Sleep(15000); 
                int _RepeatMailCount;
                while (true)
                {
                    _RepeatMailCount = _ReadMailCount; //Reset read mail count to actual if one unprocessed mail found
                    try
                    {
                        if (_bStartMailReading)
                        {
                            WriteLog("//////////////////////////////////Email Reading from SMTP server Starts Now ///////////////////////////////////////////////", _strCsvPath, false);

                            if (_First_Run == true)
                            {
                                if (string.IsNullOrEmpty(_strStartDate))
                                    _strStartDate = DateTime.Now.ToString("yyyy-MM-dd HH:00:00");

                                if (string.IsNullOrEmpty(_strEndDate))
                                    _strEndDate = Convert.ToDateTime(_strStartDate).AddHours(-1 + GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:59:59");
                            }


                            //Code for reading email from SMTP server                      
                            int unReadMailCount;
                            if (objImap4Client == null)
                                objImap4Client = new Imap4Client();

                            WriteLog("Connecting to SMTP server", _strCsvPath, false);
                            objImap4Client.ConnectSsl(_strSMTPServer, Convert.ToInt32(_strPort));
                            objImap4Client.Login(_strSMTPmail, _strSMTPPwd);

                            WriteLog("Connected to SMTP server", _strCsvPath, false);

                            //Fetches mail from INBOX
                            Mailbox inbox = objImap4Client.SelectMailbox("INBOX");
                            //Gets mail received of today
                            MessageCollection objMsgsReceivedToday = inbox.SearchParse("SENTSINCE " + DateTime.Now.ToString("dd-MMM-yyyy"));

                            unReadMailCount = objMsgsReceivedToday.Count;
                            WriteLog("Unread Mail Count to be processed : " + unReadMailCount.ToString(), _strCsvPath, false);

                            //Fetch objfetchMails = inbox.Fetch;
                            //Message objMessage;
                            //string _strMessageBody, _strSubject;

                            DataSet ds;
                            //for (int index = 0; index < objMsgsReceivedToday.Count; index++)
                            for (int index = objMsgsReceivedToday.Count - 1; index >= 0; index--)
                            {
                                if (objMsgsReceivedToday[index].HeaderFields["in-reply-to"] != null && objMsgsReceivedToday[index].Subject != null && objMsgsReceivedToday[index].Subject.Contains(_strSentMailSubjectFrmt)) //This indicates mail is reply
                                {
                                    WriteLog(" Message Details :" + "\n\t\t\t\t\t\tMessage Subject :" + objMsgsReceivedToday[index].Subject + "\n\t\t\t\t\t\tReply From :" + objMsgsReceivedToday[index].From + "\n\t\t\t\t\t\tReply Time :" + objMsgsReceivedToday[index].Date.ToString(), _strCsvPath, false);
                                    if (_RepeatMailCount != 0)
                                    {
                                        try
                                        {
                                            Facility_Maintenance_Notes objFacility_Maintenance_Notes = new Facility_Maintenance_Notes();
                                            if (objMsgsReceivedToday[index].HeaderFields["in-reply-to"].Contains("#-#"))
                                                objFacility_Maintenance_Notes.FK_Facility_Maintenance_Item = Convert.ToDecimal(objMsgsReceivedToday[index].HeaderFields["in-reply-to"].Substring(1, objMsgsReceivedToday[index].HeaderFields["in-reply-to"].IndexOf("#-#") - 1));
                                            else
                                            {
                                                //Fetch PK_Facility_Construction_Maintenance_Item on basis of Item_Number
                                                //If reference does not contain required message id extract it from subject line
                                                string _strItem_Number = objMsgsReceivedToday[index].Subject.Substring(objMsgsReceivedToday[index].Subject.IndexOf(_strSentMailSubjectFrmt) + _strSentMailSubjectFrmt.Length);
                                                ds = clsGeneral.SelectFacilityConstructionMaintenanceItemByItemNumber(_strItem_Number);
                                                if(ds.Tables[0].Rows.Count>0)
                                                    objFacility_Maintenance_Notes.FK_Facility_Maintenance_Item = Convert.ToDecimal(ds.Tables[0].Rows[0]["PK_Facility_Construction_Maintenance_Item"]);
                                                
                                            }
                                            ds = clsGeneral.SelectAuthorByEmail(objMsgsReceivedToday[index].From.Email);
                                            if (ds.Tables[0].Rows.Count > 0)
                                                objFacility_Maintenance_Notes.FK_Author = Convert.ToDecimal(ds.Tables[0].Rows[0]["PK_Contactor_Security"].ToString());
                                            else
                                            {
                                                WriteLog("User does not exist", _strCsvPath, false);
                                                continue;
                                            }
                                            objFacility_Maintenance_Notes.Note_Date = Convert.ToDateTime(objMsgsReceivedToday[index].Date);
                                            objFacility_Maintenance_Notes.Note = ExtractReply(objMsgsReceivedToday[index].BodyText.TextStripped, _strSMTPmail);
                                            objFacility_Maintenance_Notes.Author_Table = "Contractor_Security";
                                            int returnValue = objFacility_Maintenance_Notes.Insert();

                                            if (returnValue == 1)
                                            {
                                                WriteLog("Record already exists", _strCsvPath, false);
                                                _RepeatMailCount--;
                                            }
                                            else
                                            {
                                                WriteLog("Facility Management Note Record Inserted", _strCsvPath, false);                                                
                                                _RepeatMailCount = _ReadMailCount; //Reset read mail count to actual if one unprocessed mail found
                                            }
                                        }
                                        catch (Exception Ex)
                                        {
                                            WriteLog("Exception ocurred while inserting record : " + Ex.Message + "\n Details of message not inserted :" + "\n\t\t\t\t\t\tMessage Subject :" + objMsgsReceivedToday[index].Subject + "\n\t\t\t\t\t\tReply From :" + objMsgsReceivedToday[index].From + "\n\t\t\t\t\t\tReply Time :" + objMsgsReceivedToday[index].Date.ToString(), _strCsvPath, true);
                                        }

                                    }
                                }
                                else
                                {
                                    //WriteLog("Other mail", _strCsvPath, false);
                                    WriteLog(" Details of message not inserted :" + "\n\t\t\t\t\t\tMessage Subject :" + objMsgsReceivedToday[index].Subject + "\n\t\t\t\t\t\tReply From :" + objMsgsReceivedToday[index].From + "\n\t\t\t\t\t\tReply Time :" + objMsgsReceivedToday[index].Date.ToString(), _strCsvPath, false);
                                }
                            }
                            objMsgsReceivedToday.Clear();
                            _bStartMailReading = false;
                            _First_Run = false;
                            WriteLog("//////////////////////////////////Email Reading from SMTP server Ends ////////////////////////////////////////////////////", _strCsvPath, false);
                            WriteLog("Thread is going to sleep.", _strCsvPath, false);
                        }
                    }
                    catch(Exception ex)
                    {
                        WriteLog("Exception occurred while reading mail from server : "+ex.Message, _strCsvPath, true);
                    }

                    if (objImap4Client != null)
                    {
                        objImap4Client.Disconnect();
                        objImap4Client = null;
                    }
                    

                    //This will halt execution of service for Event_Run_Time_Interval attribute specified.
                    DateTime dtNextTime = Convert.ToDateTime(_strStartDate).AddHours(GetInt(_strEvent_Run_Time_Interval));
                    DateTime dtCurrentTime = DateTime.Now;
                    TimeSpan span = dtNextTime - dtCurrentTime;
                    int ms = (int)span.TotalMilliseconds;
                    if (ms > 0)
                    {
                        WriteLog("Thread sleeps for next " + ms / 60000 + " Minutes", _strCsvPath, false);
                        Thread.Sleep(ms);
                    }

                  

                    WriteLog("//////////////////////////////////Email Reading from SMTP server resumes  ////////////////////////////////////////////////////", _strCsvPath, false);
                    _RepeatMailCount = _ReadMailCount;
                    _bStartMailReading = true;
                    _strStartDate = Convert.ToDateTime(_strStartDate).AddHours(GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:00:00");
                    _strEndDate = Convert.ToDateTime(_strEndDate).AddHours(GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:59:59");
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, _strCsvPath, true);
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
            _First_Run = true;
        }

        /// <summary>
        /// if object is not able to be converted to int, it returns 0
        /// </summary>      
        public static int GetInt(object obj)
        {
            string strObj = Convert.ToString(obj);
            int result;
            int.TryParse(strObj, out result);
            return result;
        }

        public static string ExtractReply(string text, string address)
        {
            var regexes = new List<Regex>() { new Regex("From:\\s*" + Regex.Escape(address), RegexOptions.IgnoreCase),                        
                        new Regex("\\n.*On.*(\\r\\n)?wrote:\\r\\n", RegexOptions.IgnoreCase | RegexOptions.Multiline),
                        new Regex("-+original\\s+message-+\\s*$", RegexOptions.IgnoreCase),
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
    }
}
