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


namespace ERIMS_Sonic_EmailScheduler
{
    public partial class ERIMS_SonicEmailScheduler : ServiceBase
    {
        bool _bStartMailReading = true;       
        public string _strEvent_Run_Time_Interval = string.Empty;
        public string _strEvent_Run_Current_Date_Diff = string.Empty;
        public string _strStartDate = string.Empty;
        public string _strEndDate = string.Empty;
        public string _strFormatDateToDisplay = string.Empty;        
        public int _ReadMailCount = -1;
        

        public bool _First_Run = true;

        public ERIMS_SonicEmailScheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ReadConfigSetting();
            EventLog.WriteEntry("ERIMS Sonic Mail Scheduler Started at : " + DateTime.Now.ToString());
            clsGeneral.WriteLog("ERIMS Sonic Mail Scheduler Started", false);
            Thread TReadEmailReplyFromSMTPServer = default(Thread);
            TReadEmailReplyFromSMTPServer = new System.Threading.Thread(ReadEmailReplyFromSMTPServer);
            TReadEmailReplyFromSMTPServer.Start();
        }

        public void niktest()
        {
            ReadConfigSetting();
            //EventLog.WriteEntry("Event Import Service Started : " + DateTime.Now.ToString());
            clsGeneral.WriteLog("ERIMS Sonic Mail Scheduler Started", false);
            Thread TReadEmailReplyFromSMTPServer = default(Thread);
            TReadEmailReplyFromSMTPServer = new System.Threading.Thread(ReadEmailReplyFromSMTPServer);
            TReadEmailReplyFromSMTPServer.Start();
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("ERIMS Sonic Mail Scheduler Stopped at : " + DateTime.Now.ToString());
            clsGeneral.WriteLog("ERIMS Sonic Mail Scheduler Stopped ", false);
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
                    _RepeatMailCount = clsGeneral.ReadMailCount; //Reset read mail count to actual if one unprocessed mail found
                    try
                    {
                        if (_bStartMailReading)
                        {
                            clsGeneral.WriteLog("//////////////////////////////////Email Reading from SMTP server Starts Now ///////////////////////////////////////////////", false);

                            if (_First_Run == true)
                            {
                                if (string.IsNullOrEmpty(_strStartDate))
                                    _strStartDate = DateTime.Now.ToString("yyyy-MM-dd HH:00:00");

                                if (string.IsNullOrEmpty(_strEndDate))
                                    _strEndDate = Convert.ToDateTime(_strStartDate).AddHours(-1 + GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:59:59");
                            }
                            
                            if(clsGeneral.strMailServerType.ToUpper()=="IMAP") 
                            {
                                using (IMAPServer objIMAPServer=new IMAPServer())
                                {
                                    objIMAPServer.ReadMailFromIMAPServer();
                                }
                            }
                            else  //POP3
                            {
                                using (POP3Server objPOP3Server = new POP3Server())
                                {
                                    objPOP3Server.ReadMailFromPOP3Server();
                                }
                            }
                            
                            _bStartMailReading = false;
                            _First_Run = false;
                            clsGeneral.WriteLog("//////////////////////////////////Email Reading from SMTP server Ends ////////////////////////////////////////////////////", false);
                            clsGeneral.WriteLog("Thread is going to sleep.", false);
                        }
                    }
                    catch(Exception ex)
                    {
                        clsGeneral.WriteLog("Exception occurred while reading mail from server : " + ex.Message, true);
                    }

                    //This will halt execution of service for Event_Run_Time_Interval attribute specified.
                    DateTime dtNextTime = Convert.ToDateTime(_strStartDate).AddHours(GetInt(_strEvent_Run_Time_Interval));
                    DateTime dtCurrentTime = DateTime.Now;
                    TimeSpan span = dtNextTime - dtCurrentTime;
                    int ms = (int)span.TotalMilliseconds;
                    if (ms > 0)
                    {
                        clsGeneral.WriteLog("Thread sleeps for next " + ms / 60000 + " Minutes", false);
                        Thread.Sleep(ms);
                    }                  

                    clsGeneral.WriteLog("//////////////////////////////////Email Reading from SMTP server resumes  ////////////////////////////////////////////////////", false);
                    _RepeatMailCount = clsGeneral.ReadMailCount;
                    _bStartMailReading = true;
                    _strStartDate = Convert.ToDateTime(_strStartDate).AddHours(GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:00:00");
                    _strEndDate = Convert.ToDateTime(_strEndDate).AddHours(GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:59:59");
                }
            }
            catch (Exception ex)
            {
                clsGeneral.WriteLog(ex.Message, true);
            }
        }


        private void ReadConfigSetting()
        {
            clsGeneral.strCsvPath = ConfigurationSettings.AppSettings.Get("CSVPath");
            _strEvent_Run_Time_Interval = ConfigurationSettings.AppSettings.Get("Event_Run_Time_Interval");
            _strEvent_Run_Time_Interval = ConfigurationSettings.AppSettings.Get("Event_Run_Current_Date_Diff");
            _strStartDate = ConfigurationSettings.AppSettings.Get("StartDate");
            _strEndDate = ConfigurationSettings.AppSettings.Get("EndDate");
            _strFormatDateToDisplay = ConfigurationSettings.AppSettings.Get("DisplayDateFormat");
            clsGeneral.strSMTPServer = ConfigurationSettings.AppSettings.Get("SMTPServer");
            clsGeneral.strSMTPmail = ConfigurationSettings.AppSettings.Get("SMTPmail");
            clsGeneral.strSMTPPwd = ConfigurationSettings.AppSettings.Get("SMTPPwd");
            clsGeneral.strPort = ConfigurationSettings.AppSettings.Get("Port");
            clsGeneral.strSentMailSubjectFrmt = ConfigurationSettings.AppSettings.Get("SentMailSubjectFrmt");
            clsGeneral.ReadMailCount = Convert.ToInt32(ConfigurationSettings.AppSettings.Get("MailCount"));
            clsGeneral.strMailAttachmentStorePath = ConfigurationSettings.AppSettings.Get("MailAttachmentStorePath");
            clsGeneral.strMailServerType = ConfigurationSettings.AppSettings.Get("MailServerType");
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

       

       
    }
}
