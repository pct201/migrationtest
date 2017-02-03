using System;
using System.Data;
using System.ServiceProcess;
using System.IO;
using System.Configuration;
using System.Net;
using ERIMS_DAL;
using System.Threading;
using System.Text;
using System.Net.Mail;
using System.Drawing;
using Aspose.Words;

namespace Erims_ACI_ImportEvent_Mail
{
    public partial class Erims_ACIImportEvent_Mail : ServiceBase
    {
         bool _bStartImport = true;
        DateTime dtSchduleDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 06:15:00");
        public string _strCsvPath = string.Empty;
        public string _strStartDate = string.Empty;
        public string _strEndDate = string.Empty;
        public string _strImagePath = string.Empty;
        public string _strInvestigationImagePath = string.Empty;
        public string _strCsvProtocol = string.Empty;
        public bool _First_Run = true;
        public string _strACI_ActionableEvent_Time = string.Empty;
      
        public string _strEvent_Start_Time_Offset = string.Empty;
        public string _strEvent_Run_Time_Interval = string.Empty;

        public string _strFormatDateToDisplay = string.Empty;

        public string _strSMTPMailFrom = string.Empty;
        public string _strSMTPServer = string.Empty;
        public string _strSMTPmail = string.Empty;
        public string _strSMTPPwd = string.Empty;
        public string _strToEmail = string.Empty;
        public string _strPort = string.Empty;
        public string _strAttachmentName = string.Empty;
        
        public Erims_ACIImportEvent_Mail()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ReadConfigSetting();
            Thread TDownloadFile = default(Thread);
            TDownloadFile = new System.Threading.Thread(DownloadFile);
            TDownloadFile.Start();
        }

        public void niktest()
        {
            ReadConfigSetting();
            Thread TDownloadFile = default(Thread);
            TDownloadFile = new System.Threading.Thread(DownloadFile);
            TDownloadFile.Start();
        }

        private void ReadConfigSetting()
        {
            _strCsvPath = ConfigurationSettings.AppSettings.Get("CSVPath");
            _strImagePath = ConfigurationSettings.AppSettings.Get("ImagePath");
            _strInvestigationImagePath = ConfigurationSettings.AppSettings.Get("InvestigationImagePath");
            _strCsvProtocol = ConfigurationSettings.AppSettings.Get("CsvProtocol");
            _strEvent_Start_Time_Offset = ConfigurationSettings.AppSettings.Get("Event_Start_Time_Offset");
            _strEvent_Run_Time_Interval = ConfigurationSettings.AppSettings.Get("Event_Run_Time_Interval");
            _strACI_ActionableEvent_Time = ConfigurationSettings.AppSettings.Get("ACI_ActionableEvent_Time");
            _strFormatDateToDisplay = ConfigurationSettings.AppSettings.Get("DisplayDateFormat");
            _strSMTPMailFrom = ConfigurationSettings.AppSettings.Get("SMTPMailFrom");
            _strSMTPServer = ConfigurationSettings.AppSettings.Get("SMTPServer");
            _strSMTPmail = ConfigurationSettings.AppSettings.Get("SMTPmail");
            _strSMTPPwd = ConfigurationSettings.AppSettings.Get("SMTPPwd");
            _strToEmail = ConfigurationSettings.AppSettings.Get("ToEmail");
            _strPort = ConfigurationSettings.AppSettings.Get("Port");

            _First_Run = true;

            if (!Directory.Exists(_strCsvPath))
            {
                Directory.CreateDirectory(_strCsvPath);
            }

            if (!Directory.Exists(_strImagePath))
            {
                Directory.CreateDirectory(_strImagePath);
            }
        }

        public void DownloadFile()
        {
            DataSet ds = new DataSet();
            
            try
            {
                //Thread.Sleep(15000);
                //Thread.Sleep(3600000 * GetInt(_strEvent_Start_Time_Offset));//
                while (true)
                {
                    if (_bStartImport)
                    {
                        WriteLog("//////////////////////////////////Event Notification Start On :" + DateTime.Now.ToString() + "  ///////////////////////////", _strCsvPath, false);

                        if (_First_Run == true)
                        {
                            if (string.IsNullOrEmpty(_strStartDate))
                                _strStartDate = DateTime.Now.AddHours(GetInt(_strEvent_Start_Time_Offset)).ToString("yyyy-MM-dd HH:00:00");

                            if (string.IsNullOrEmpty(_strEndDate))
                                _strEndDate = Convert.ToDateTime(_strStartDate).AddHours(-1 + GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:59:59");
                        }

                        _bStartImport = false;
                        _First_Run = false;

                        #region EventAbstract

                        bool Is_ACI_Event = false;

                        if (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + _strACI_ActionableEvent_Time) >= Convert.ToDateTime(_strStartDate).AddHours(-GetInt(_strEvent_Start_Time_Offset) - GetInt(_strEvent_Run_Time_Interval)).AddHours(1)
                            & Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + _strACI_ActionableEvent_Time) <= Convert.ToDateTime(_strEndDate).AddHours(-GetInt(_strEvent_Start_Time_Offset) - GetInt(_strEvent_Run_Time_Interval)).AddHours(1))
                        {
                            Is_ACI_Event = true;
                            //WriteLog("Start Sending Event Abstract Notification For Actionable Event Update Date Time Between : " + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + _strACI_ActionableEvent_Time).AddSeconds(-1).AddDays(-1) + "  And : " + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + _strACI_ActionableEvent_Time).AddSeconds(-2), _strCsvPath, false);
                        }
                        
                        if (Is_ACI_Event)
                        {
                            try
                            {
                                DataSet dsEmails = Event.GetEmailsByEventUpdateDate(Convert.ToDateTime(_strStartDate).AddHours(-GetInt(_strEvent_Start_Time_Offset) - GetInt(_strEvent_Run_Time_Interval)), Convert.ToDateTime(_strEndDate).AddHours(-GetInt(_strEvent_Start_Time_Offset) - GetInt(_strEvent_Run_Time_Interval)), Is_ACI_Event);
                                
                                if (dsEmails.Tables.Count > 1 && dsEmails.Tables[1].Rows.Count > 0)
                                {
                                    WriteLog("Start Sending Event Abstract Notification For Actionable Event Update Date Time Between : " + Convert.ToDateTime(dsEmails.Tables[1].Rows[0][0]) + "  And : " + Convert.ToDateTime(dsEmails.Tables[1].Rows[0][1]), _strCsvPath, false);
                                }

                                if (dsEmails.Tables[0].Rows.Count > 0)
                                {
                                    
                                    foreach (DataRow drEmailTO in dsEmails.Tables[0].Rows)
                                    {
                                        string[] strEmails = null;

                                        DataSet ds_Event = Event.GetEventAbstractLetterData(Convert.ToDecimal(drEmailTO["PK_Event"]));

                                        string strEventAbstrct = Convert.ToString(Event_AbstactReportDOC(ds_Event, Convert.ToDecimal(drEmailTO["PK_Event"]), false, Event.Claim_Major_Coverage.Event));

                                        string strPath = AppDomain.CurrentDomain.BaseDirectory + @"Event.doc";

                                        #region " Generate WORD Doc "
                                        string strLisenceFile = AppDomain.CurrentDomain.BaseDirectory + @"Aspose.Words.lic";

                                        if (File.Exists(strLisenceFile))
                                        {
                                            Aspose.Words.License license = new Aspose.Words.License();
                                            license.SetLicense(strLisenceFile);
                                        }

                                        Aspose.Words.Document doc = new Aspose.Words.Document();

                                        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
                                        builder.PageSetup.BottomMargin = 20;
                                        builder.PageSetup.TopMargin = 20;
                                        builder.PageSetup.LeftMargin = 20;
                                        builder.PageSetup.RightMargin = 20;
                                        builder.Font.Size = 10;
                                        builder.PageSetup.PaperSize = PaperSize.A4;
                                        //builder.Font.Bold = false;
                                        //builder.Font.Color = System.Drawing.Color.Black;
                                        builder.Font.Name = "Arial";
                                        builder.InsertParagraph();
                                        builder.InsertHtml(strEventAbstrct);

                                        //imageFileName = AppConfig.ImageURL + "letter-footer.JPG";
                                        //builder.InsertImage(imageFileName, Aspose.Words.Drawing.RelativeHorizontalPosition.Page, 25, Aspose.Words.Drawing.RelativeVerticalPosition.Page, 710, 550, 42, Aspose.Words.Drawing.WrapType.Through);

                                        //Don't need merge fields in the document anymore.
                                        doc.MailMerge.DeleteFields();
                                        //builder.MoveToSection(0);
                                        //builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
                                        //builder.PageSetup.PageNumberStyle = NumberStyle.Number;
                                        //builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                                        //builder.Write("Page ");
                                        //builder.InsertField("PAGE", "");
                                        //builder.Write(" of ");
                                        //builder.InsertField("NUMPAGES", "");
                                        //Section section = doc.Sections[0];
                                        //section.PageSetup.PageStartingNumber = 1;
                                        //section.PageSetup.RestartPageNumbering = true;
                                        //section.PageSetup.PageNumberStyle = NumberStyle.Arabic;

                                        doc.Save(strPath, Aspose.Words.SaveFormat.Doc);
                                        
                                        #endregion



                                        WriteLog("Sending Event Abstract Notification for Event Number: " + drEmailTO["Event_Number"], _strCsvPath, false);

                                        System.Collections.Generic.List<string> lstImages = new System.Collections.Generic.List<string>();
                                        int intImagescount = 0;

                                        
                                        //if (!string.IsNullOrEmpty(_strAttachmentName) && File.Exists(_strImagePath + _strAttachmentName))
                                        //{
                                        //    lstImages.Insert(intImagescount, _strImagePath + _strAttachmentName);
                                        //    intImagescount++;
                                        //}

                                        //DataTable dtInvestigationImages = ds_Event.Tables[6];

                                        //foreach (DataRow drEvent_Images in dtInvestigationImages.Rows)
                                        //{
                                        //    if (!string.IsNullOrEmpty(Convert.ToString(drEvent_Images["Attachment_Name"])) && File.Exists(_strInvestigationImagePath + drEvent_Images["Attachment_Name"]))
                                        //    {
                                        //        lstImages.Insert(intImagescount, _strInvestigationImagePath + drEvent_Images["Attachment_Name"]);
                                        //        intImagescount++;
                                        //    }
                                        //}

                                        DataTable dtEventAttachment = ds_Event.Tables[9];

                                        foreach (DataRow drEvent_Attachment in dtEventAttachment.Rows)
                                        {
                                            if (!string.IsNullOrEmpty(Convert.ToString(drEvent_Attachment["Attachment_Name"])) && File.Exists(_strInvestigationImagePath + drEvent_Attachment["Attachment_Name"]))
                                            {
                                                lstImages.Insert(intImagescount, _strInvestigationImagePath + drEvent_Attachment["Attachment_Name"]);
                                                intImagescount++;
                                            }
                                        }

                                        string[] strTemp = lstImages.ToArray();

                                        MailMessage mail = new MailMessage();
                                        mail.From = new MailAddress(_strSMTPMailFrom);
                                        mail.Subject = "ACI Actionable Event Abstract";

                                        SmtpClient mSmtpClient = new SmtpClient();
                                        mSmtpClient.Port = Convert.ToInt16(_strPort);
                                        mSmtpClient.Host = _strSMTPServer;
                                        mSmtpClient.Credentials = new System.Net.NetworkCredential(_strSMTPmail, _strSMTPPwd);

                                        if (!string.IsNullOrEmpty(Convert.ToString(drEmailTO["Email"])))
                                        {
                                            if (Convert.ToString(drEmailTO["Email"]).Contains(","))
                                            {
                                                strEmails = Convert.ToString(drEmailTO["Email"]).Split(',');
                                            }
                                            else
                                            {
                                                strEmails = new string[1];
                                                strEmails[0] = Convert.ToString(drEmailTO["Email"]);
                                            }

                                            for (int i = 0; i < strEmails.Length; i++)
                                            {
                                                mail.To.Add(strEmails[i]);
                                            }

                                            if (strEmails.Length > 0)
                                            {
                                                try
                                                {
                                                    //mail.Body = strEventAbstrct;
                                                    mail.Body = "ACI Actionable Event Abstract for Event Number: " + drEmailTO["Event_Number"] + ".<br/>Thank You";
                                                    if (strTemp != null && strTemp.Length > 0)
                                                    {
                                                        #region " Generate Zip "

                                                        string strzipDir = AppDomain.CurrentDomain.BaseDirectory + @"Event_Attachment";
                                                        AciImportHelper.SetZipDirectory(strTemp, strzipDir);
                                                        AciImportHelper.ConvertZIP(strzipDir);
                                                        System.IO.FileInfo file = new System.IO.FileInfo(strzipDir + ".Zip");
                                                        string zipFile = Convert.ToString(file);
                                                        mail.Attachments.Add(new Attachment(zipFile));
                                                        
                                                        #endregion
                                                    }
                                                    if (!string.IsNullOrEmpty(strPath) && File.Exists(strPath))
                                                    {
                                                        mail.Attachments.Add(new Attachment(strPath));
                                                    }

                                                    mail.IsBodyHtml = true;
                                                    mSmtpClient.Send(mail);
                                                    mail.To.Clear();
                                                    WriteLog("Event Abstract for Event Number: " + drEmailTO["Event_Number"] + " Sent To Email Id: " + Convert.ToString(drEmailTO["Email"]), _strCsvPath, false);
                                                }
                                                catch (Exception ex)
                                                {
                                                    WriteLog("Error While Sending Event Abstract for Event Number: " + drEmailTO["Event_Number"] + " To Email Id: " + Convert.ToString(drEmailTO["Email"]), _strCsvPath, false);
                                                    string strErrorMsg = string.Empty;

                                                    strErrorMsg = ex != null ? (ex.InnerException != null ? (ex.InnerException.InnerException != null ? ex.Message + Environment.NewLine + "                        " + ex.InnerException.Message + Environment.NewLine + "                        " + ex.InnerException.InnerException.Message : ex.Message + Environment.NewLine + "                        " + ex.InnerException.Message) : ex.Message) : "";

                                                    WriteLog("Error While Sending Event Abstract for Event Number: " + drEmailTO["Event_Number"] + " To Email Id: " + Convert.ToString(drEmailTO["Email"]) + "  " + strErrorMsg, _strCsvPath, false);
                                                }
                                                finally
                                                {
                                                    mail.Dispose();
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    WriteLog("There is no Actionable Event Found for Event Abstract Notification.", _strCsvPath, false);
                                }

                                WriteLog("Completed Sending Event Abstract Notification.", _strCsvPath, false);
                            }
                            catch (Exception ex)
                            {
                                WriteLog("Error While Sending Event Abstract Notification", _strCsvPath, false);
                                WriteLog("Completed Sending Event Abstract Notification", _strCsvPath, false);
                                WriteLog("Error While Sending Event Abstract Notification :- " + ex.Message, _strCsvPath, false);
                            }
                        }

                        #endregion

                        WriteLog("//////////////////////////////////Event Notification End /////////////////////////////////////////////////////////", _strCsvPath, false);

                        WriteLog("Thread is going to sleep.", _strCsvPath, false);
                    }

                    DateTime dtNextTime = Convert.ToDateTime(_strStartDate).AddHours(GetInt(_strEvent_Run_Time_Interval));
                    DateTime dtCurrentTime = DateTime.Now.AddHours(GetInt(_strEvent_Start_Time_Offset));
                    TimeSpan span = dtNextTime - dtCurrentTime;
                    int ms = (int)span.TotalMilliseconds;

                    if (ms > 0)
                    {
                        WriteLog("Thread sleeps for next " + ms/60000 + " Minutes", _strCsvPath, false);
                        Thread.Sleep(ms);
                    }
             
                    WriteLog("Time is changed Event Notification process start again.", _strCsvPath, false);
                    _bStartImport = true;
                    _strStartDate = Convert.ToDateTime(_strStartDate).AddHours(GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:00:00");
                    _strEndDate = Convert.ToDateTime(_strEndDate).AddHours(GetInt(_strEvent_Run_Time_Interval)).ToString("yyyy-MM-dd HH:59:59");
             
                }
            }

            catch (Exception ex)
            {
                WriteLog(ex.Message, _strCsvPath, false);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;
                }
            }
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Event Notification Service Stopped : " + DateTime.Now.ToString());
            WriteLog("Event Notification Service Stopped ", _strCsvPath, false);
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
                sFilePath = sFolderName + "EmailNotification.log";
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

        /// <summary>
        /// if object is not able to be converted to int, it returns 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt(object obj)
        {
            string strObj = Convert.ToString(obj);
            int result;
            int.TryParse(strObj, out result);
            return result;
        }

        /// <summary>
        /// Sets the dates for the labels which are not mendatory fields,
        /// it may have null value which should return an empty string
        /// </summary>
        /// <param name="objDate"></param>
        /// <returns></returns>
        public string FormatDBNullDateToDisplay(object objDate)
        {
            if (objDate == DBNull.Value || objDate == null || string.IsNullOrEmpty(Convert.ToString(objDate)))
                return string.Empty;
            else
            {
                if ((DateTime)System.Data.SqlTypes.SqlDateTime.MinValue == Convert.ToDateTime(objDate))
                    return string.Empty;
                else
                    return Convert.ToDateTime(objDate).ToString(_strFormatDateToDisplay);
            }
        }

        public string GetBuildingDetails(DataTable dtBuilding)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Attachments</td></tr>");
            //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; '  colspan='6'>");
            sbGrid.Append("<tr style='page-break-inside: avoid'><td colspan='6'> <table border='0' cellspacing='1' cellpadding='1' width='100%'>");
            sbGrid.Append("<tr style='page-break-inside: avoid'>");
            sbGrid.Append("<td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Buildings</td></tr>");
            sbGrid.Append("<tr style='page-break-inside: avoid'><td style='font-size: 12px; font-family: Arial;'  colspan='6'>");
            if (dtBuilding.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Building Number </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Address </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Occupancy </td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtBuilding.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Building_Number"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Address"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Occupancy"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
                sbGrid.Append("</td>");
                sbGrid.Append("</tr>");
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr valign='top' style='font-family: Arial; font-size: 12px; padding-left:20px;' align='center'><td align='left'>No Building Records Found.</td></tr>");
                sbGrid.Append("</table>");
                sbGrid.Append("</td>");
                sbGrid.Append("</tr>");
                sbGrid.Append("</table>");
            }
            sbGrid.Append("</td></tr>");
            sbGrid.Append("<tr><td>&nbsp;</td></tr>");
            return sbGrid.ToString();
        }

        public string GetCameraDetails(DataTable dtCamera)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtCamera.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Camera Name </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Camera Number </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Event Time From </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Event Time To </td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtCamera.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Camera_Name"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Camera_Number"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Event_Time_From"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Event_Time_To"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public static string GetVehicleDetails(DataTable dtVehicle)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtVehicle.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Make </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Model </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Color </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> License </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> State </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Suspect Vehicle </td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtVehicle.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Make"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Model"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Color"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["License"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["STATE"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Suspect_Vehicle"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public static string GetSuspectDetails(DataTable dtSuspect)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtSuspect.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Sex </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtSuspect.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Sex"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Description"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public string GetACINotesDetails(DataTable dtACINote)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtACINote.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Note Date </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtACINote.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", FormatDBNullDateToDisplay(dr["Note_Date"]));
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Note"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public string GetSonicNotesDetails(DataTable dtSonicNote)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtSonicNote.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Note Date </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> User </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtSonicNote.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", FormatDBNullDateToDisplay(dr["Note_Date"]));
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Updated_by_Name"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Note"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public string GetBuildingDetailsDOC(DataTable dtBuilding)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Attachments</td></tr>");
            //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; '  colspan='6'>");
            sbGrid.Append("<tr style='page-break-inside: avoid'><td colspan='6'> <table border='0' width='100%'>");
            sbGrid.Append("<tr style='page-break-inside: avoid'>");
            sbGrid.Append("<td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Buildings</td></tr>");
            sbGrid.Append("<tr style='page-break-inside: avoid'><td style='font-size: 12px; font-family: Arial;'  colspan='6'>");
            if (dtBuilding.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
                sbGrid.Append("<tr valign='top' align='center'>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Building Number</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:40%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Address</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:40%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Occupancy</b></span></td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtBuilding.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Building_Number"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:40%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Address"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:40%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Occupancy"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
                sbGrid.Append("</td>");
                sbGrid.Append("</tr>");
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr valign='top' style='font-family: Arial; font-size: 12px; padding-left:20px;' align='center'><td align='left'>No Building Records Found.</td></tr>");
                sbGrid.Append("</table>");
                sbGrid.Append("</td>");
                sbGrid.Append("</tr>");
                sbGrid.Append("</table>");
            }
            sbGrid.Append("</td></tr>");
            sbGrid.Append("<tr><td>&nbsp;</td></tr>");
            return sbGrid.ToString();
        }

        public string GetCameraDetailsDOC(DataTable dtCamera)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtCamera.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
                sbGrid.Append("<tr valign='top' align='center'>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:25%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Camera Name</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:25%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Camera Number</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:25%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Event Time From</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:25%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Event Time To</b></span></td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtCamera.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Camera_Name"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Camera_Number"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Event_Time_From"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Event_Time_To"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public static string GetVehicleDetailsDOC(DataTable dtVehicle)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtVehicle.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
                sbGrid.Append("<tr valign='top' align='center'>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Make</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Model </b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Color </b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>License</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>State</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Suspect Vehicle</b></span></td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtVehicle.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Make"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Model"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Color"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["License"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["STATE"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Suspect_Vehicle"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public static string GetSuspectDetailsDOC(DataTable dtSuspect)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtSuspect.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
                sbGrid.Append("<tr valign='top' align='center'>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Sex</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:80%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Notes</b></span></td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtSuspect.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Sex"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:80%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Description"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public string GetACINotesDetailsDOC(DataTable dtACINote)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtACINote.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
                sbGrid.Append("<tr valign='top' align='center'>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Note Date</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:80%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Notes</b></span></td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtACINote.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", FormatDBNullDateToDisplay(dr["Note_Date"]));
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:80%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Note"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public string GetSonicNotesDetailsDOC(DataTable dtSonicNote)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if (dtSonicNote.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
                sbGrid.Append("<tr valign='top' align='center'>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Note Date</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>User</b></span></td>");
                sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:70%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Notes</b></span></td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtSonicNote.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", FormatDBNullDateToDisplay(dr["Note_Date"]));
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Updated_by_Name"]);
                    sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:70%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Note"]);
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("No Records found.");
            }

            return sbGrid.ToString();
        }

        public StringBuilder Event_AbstactReport(DataSet dsEvent, decimal _PK_Event, bool ShowAttachments, Event.Claim_Major_Coverage MajorCoverageType)
        {
            //DataSet dsEvent = Event.GetEventAbstractLetterData(_PK_Event);

            StringBuilder strBody = new StringBuilder("");

            if (dsEvent != null && dsEvent.Tables.Count > 0 && dsEvent.Tables[0].Rows.Count > 0)
            {
                DataTable dtEvent = dsEvent.Tables[0];
                DataTable dtActionable_Event = dsEvent.Tables[1];
                DataTable dtBuilding = dsEvent.Tables[2];
                DataTable dtCamera = dsEvent.Tables[3];
                DataTable dtACINotes = dsEvent.Tables[4];
                DataTable dtSonicNotes = dsEvent.Tables[5];
                DataTable dtEventImages = dsEvent.Tables[6];
                DataTable dtVehicleInformation = dsEvent.Tables[7];
                DataTable dtSuspectInformation = dsEvent.Tables[8];

                FileStream fsMail = null;

                bool Is_Sonic_Event = Convert.ToBoolean(dtEvent.Rows[0]["Sonic_Event"]);

                if (Is_Sonic_Event)
                    fsMail = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Event_AbstractReport_Sonic.htm", FileMode.Open, FileAccess.Read);
                else fsMail = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Event_AbstractReport.htm", FileMode.Open, FileAccess.Read);
                StreamReader rd = new StreamReader(fsMail);
                //StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
                rd = new StreamReader(fsMail);
                strBody = new StringBuilder(rd.ReadToEnd().ToString());


                rd.Close();
                fsMail.Close();

                #region "ACI Reported Event"

                strBody = strBody.Replace("[Location]", Convert.ToString(dtEvent.Rows[0]["Location"]));
                strBody = strBody.Replace("[ACI_Event_ID]", Convert.ToString(dtEvent.Rows[0]["ACI_EventID"]));

                string strActionableEvent = string.Empty;
                if (dtActionable_Event.Rows.Count > 0)
                {
                    strActionableEvent = "<table cellpadding='4' cellspacing='0' width='100%'>";
                    foreach (DataRow drEvent_Type in dtActionable_Event.Rows)
                    {
                        if (Convert.ToBoolean(drEvent_Type["Is_Checked"]))
                        {
                            strActionableEvent += "<tr style='page-break-inside: avoid'><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'>" + drEvent_Type["Actionable_Event_Desc"] + "</td><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'> Yes </td></tr>";
                        }
                        else
                        {
                            strActionableEvent += "<tr style='page-break-inside: avoid'><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'>" + drEvent_Type["Actionable_Event_Desc"] + "</td><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'> No </td></tr>";
                        }
                    }
                    strActionableEvent += "</table>";
                }
                strBody = strBody.Replace("[Actionable_Event_Type]", strActionableEvent);
                strBody = strBody.Replace("[Description_of_Event]", Convert.ToString(dtEvent.Rows[0]["Event_Desc"]));
                if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Event_Start_Date"])))
                    strBody = strBody.Replace("[Date_of_Event]", FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Start_Date"]));
                else
                    strBody = strBody.Replace("[Date_of_Event]", string.Empty);

                strBody = strBody.Replace("[Event_Start_Time]", Convert.ToString(dtEvent.Rows[0]["Event_Start_Time"]));
                strBody = strBody.Replace("[Event_End_Time]", Convert.ToString(dtEvent.Rows[0]["Event_End_Time"]));


                strBody = strBody.Replace("[BuildingInformation]", GetBuildingDetails(dtBuilding));

                strBody = strBody.Replace("[Camera_Grid]", GetCameraDetails(dtCamera));

                strBody = strBody.Replace("[Acadian_Investigator_Name]", Convert.ToString(dtEvent.Rows[0]["Investigator_Name"]));
                strBody = strBody.Replace("[Acadian_Investigator_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Investigator_Email"]));
                strBody = strBody.Replace("[Acadian_Investigator_Phone]", Convert.ToString(dtEvent.Rows[0]["Investigator_Phone"]));

                int ImageCounter = 0;

                //string AttachmentDocPath = "Documents/EventImage";
                if (!DBNull.Value.Equals(dtEvent.Rows[0]["Event_Image"]) && File.Exists(_strImagePath + dtEvent.Rows[0]["Event_Image"]) && !Is_Sonic_Event)
                {
                    //strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + AppConfig.SiteURL + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"] + "' Height='200' Width='200' />");
                    _strAttachmentName = Convert.ToString(dtEvent.Rows[0]["Event_Image"]);
                    //strBody = strBody.Replace("[Event_Image]", "<img src=\"cid:Event_Images_" + ImageCounter + "\" Height=\"288\" Width=\"352\" />");
                    strBody = strBody.Replace("[Event_Image]", string.Empty);
                    ImageCounter++;
                }
                else
                {
                    strBody = strBody.Replace("[Event_Image]", string.Empty);
                    _strAttachmentName = string.Empty;
                }
                #endregion

                #region "Sonic Reported Event"

                strBody = strBody.Replace("[SRE#]", Convert.ToString(dtEvent.Rows[0]["Event_Number"]));
                strBody = strBody.Replace("[Monitoring_Hours]", Convert.ToString(dtEvent.Rows[0]["Monitoring_Hours"]));
                strBody = strBody.Replace("[Source_of_Information]", Convert.ToString(dtEvent.Rows[0]["Source_Of_Information"]));
                strBody = strBody.Replace("[Event_Level]", Convert.ToString(dtEvent.Rows[0]["Event_Level"]));
                strBody = strBody.Replace("[Budge#]", Convert.ToString(dtEvent.Rows[0]["Badge_Number"]));
                strBody = strBody.Replace("[Sonic_Contact_Name]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Name"]));
                strBody = strBody.Replace("[Sonic_Contact_Phone_#]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Phone"]));
                strBody = strBody.Replace("[Sonic_Contact_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Email"]));

                #endregion

                #region "Acadian Investigation"

                strBody = strBody.Replace("[Police_Called]", Convert.ToString(dtEvent.Rows[0]["Police_Called"]));
                strBody = strBody.Replace("[Video_Requested_By_Sonic]", Convert.ToString(dtEvent.Rows[0]["Video_Requested_By_Sonic"]));
                strBody = strBody.Replace("[Agency_Name]", Convert.ToString(dtEvent.Rows[0]["Agency_Name"]));
                strBody = strBody.Replace("[Officer_Name]", Convert.ToString(dtEvent.Rows[0]["Officer_Name"]));
                strBody = strBody.Replace("[Phone_#]", Convert.ToString(dtEvent.Rows[0]["Officer_Phone"]));
                strBody = strBody.Replace("[Police_Report_#]", Convert.ToString(dtEvent.Rows[0]["Police_Report_Number"]));
                strBody = strBody.Replace("[Incident_Report_Desc]", Convert.ToString(dtEvent.Rows[0]["Incident_Report_Desc"]));

                strBody = strBody.Replace("[Vehicle_Information_Grid]", GetVehicleDetails(dtVehicleInformation));
                strBody = strBody.Replace("[Suspect_Information_Grid]", GetSuspectDetails(dtSuspectInformation));
                strBody = strBody.Replace("[Acadian_Notes_Grid]", GetACINotesDetails(dtACINotes));

                strBody = strBody.Replace("[Sonic_Notes_Grid]", GetSonicNotesDetails(dtSonicNotes));
               
                #endregion

                #region "Images of Event"

                string strEventImages = string.Empty;

                strBody = strBody.Replace("[Images_of_Event]", strEventImages);

                #endregion
            }

            return strBody;

        }

        public StringBuilder Event_AbstactReportDOC(DataSet dsEvent, decimal _PK_Event, bool ShowAttachments, Event.Claim_Major_Coverage MajorCoverageType)
        {
            //DataSet dsEvent = Event.GetEventAbstractLetterData(_PK_Event);

            StringBuilder strBody = new StringBuilder("");

            if (dsEvent != null && dsEvent.Tables.Count > 0 && dsEvent.Tables[0].Rows.Count > 0)
            {
                DataTable dtEvent = dsEvent.Tables[0];
                DataTable dtActionable_Event = dsEvent.Tables[1];
                DataTable dtBuilding = dsEvent.Tables[2];
                DataTable dtCamera = dsEvent.Tables[3];
                DataTable dtACINotes = dsEvent.Tables[4];
                DataTable dtSonicNotes = dsEvent.Tables[5];
                DataTable dtEventImages = dsEvent.Tables[6];
                DataTable dtVehicleInformation = dsEvent.Tables[7];
                DataTable dtSuspectInformation = dsEvent.Tables[8];

                FileStream fsMail = null;

                bool Is_Sonic_Event = Convert.ToBoolean(dtEvent.Rows[0]["Sonic_Event"]);

                if (Is_Sonic_Event)
                    fsMail = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Event_AbstractReport_Sonic.htm", FileMode.Open, FileAccess.Read);
                else fsMail = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Event_AbstractReport.htm", FileMode.Open, FileAccess.Read);
                StreamReader rd = new StreamReader(fsMail);
                //StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
                rd = new StreamReader(fsMail);
                strBody = new StringBuilder(rd.ReadToEnd().ToString());


                rd.Close();
                fsMail.Close();

                #region "ACI Reported Event"

                strBody = strBody.Replace("[Location]", Convert.ToString(dtEvent.Rows[0]["Location"]));
                strBody = strBody.Replace("[ACI_Event_ID]", Convert.ToString(dtEvent.Rows[0]["ACI_EventID"]));

                string strActionableEvent = string.Empty;
                if (dtActionable_Event.Rows.Count > 0)
                {
                    strActionableEvent = "<table cellpadding='4' cellspacing='0' width='100%'>";
                    foreach (DataRow drEvent_Type in dtActionable_Event.Rows)
                    {
                        if (Convert.ToBoolean(drEvent_Type["Is_Checked"]))
                        {
                            strActionableEvent += "<tr style='page-break-inside: avoid'><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'>" + drEvent_Type["Actionable_Event_Desc"] + "</td><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'> Yes </td></tr>";
                        }
                        else
                        {
                            strActionableEvent += "<tr style='page-break-inside: avoid'><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'>" + drEvent_Type["Actionable_Event_Desc"] + "</td><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'> No </td></tr>";
                        }
                    }
                    strActionableEvent += "</table>";
                }
                strBody = strBody.Replace("[Actionable_Event_Type]", strActionableEvent);
                strBody = strBody.Replace("[Description_of_Event]", Convert.ToString(dtEvent.Rows[0]["Event_Desc"]));
                if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Event_Start_Date"])))
                    strBody = strBody.Replace("[Date_of_Event]", FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Start_Date"]));
                else
                    strBody = strBody.Replace("[Date_of_Event]", string.Empty);

                strBody = strBody.Replace("[Event_Start_Time]", Convert.ToString(dtEvent.Rows[0]["Event_Start_Time"]));
                strBody = strBody.Replace("[Event_End_Time]", Convert.ToString(dtEvent.Rows[0]["Event_End_Time"]));


                strBody = strBody.Replace("[BuildingInformation]", GetBuildingDetailsDOC(dtBuilding));

                strBody = strBody.Replace("[Camera_Grid]", GetCameraDetailsDOC(dtCamera));

                strBody = strBody.Replace("[Acadian_Investigator_Name]", Convert.ToString(dtEvent.Rows[0]["Investigator_Name"]));
                strBody = strBody.Replace("[Acadian_Investigator_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Investigator_Email"]));
                strBody = strBody.Replace("[Acadian_Investigator_Phone]", Convert.ToString(dtEvent.Rows[0]["Investigator_Phone"]));

                int ImageCounter = 0;

                //string AttachmentDocPath = "Documents/EventImage";
                if (!DBNull.Value.Equals(dtEvent.Rows[0]["Event_Image"]) && File.Exists(_strImagePath + dtEvent.Rows[0]["Event_Image"]) && !Is_Sonic_Event)
                {
                    //strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + AppConfig.SiteURL + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"] + "' Height='200' Width='200' />");
                    _strAttachmentName = Convert.ToString(dtEvent.Rows[0]["Event_Image"]);
                    //strBody = strBody.Replace("[Event_Image]", "<img src=\"cid:Event_Images_" + ImageCounter + "\" Height=\"288\" Width=\"352\" />");
                    //strBody = strBody.Replace("[Event_Image]", string.Empty);
                    strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + _strImagePath + dtEvent.Rows[0]["Event_Image"] + "' Height='288' Width='352' />");
                    ImageCounter++;
                }
                else
                {
                    strBody = strBody.Replace("[Event_Image]", string.Empty);
                    _strAttachmentName = string.Empty;
                }
                #endregion

                #region "Sonic Reported Event"

                strBody = strBody.Replace("[SRE#]", Convert.ToString(dtEvent.Rows[0]["Event_Number"]));
                strBody = strBody.Replace("[Monitoring_Hours]", Convert.ToString(dtEvent.Rows[0]["Monitoring_Hours"]));
                strBody = strBody.Replace("[Source_of_Information]", Convert.ToString(dtEvent.Rows[0]["Source_Of_Information"]));
                strBody = strBody.Replace("[Event_Level]", Convert.ToString(dtEvent.Rows[0]["Event_Level"]));
                strBody = strBody.Replace("[Budge#]", Convert.ToString(dtEvent.Rows[0]["Badge_Number"]));
                strBody = strBody.Replace("[Sonic_Contact_Name]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Name"]));
                strBody = strBody.Replace("[Sonic_Contact_Phone_#]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Phone"]));
                strBody = strBody.Replace("[Sonic_Contact_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Email"]));

                #endregion

                #region "Acadian Investigation"

                strBody = strBody.Replace("[Police_Called]", Convert.ToString(dtEvent.Rows[0]["Police_Called"]));
                strBody = strBody.Replace("[Video_Requested_By_Sonic]", Convert.ToString(dtEvent.Rows[0]["Video_Requested_By_Sonic"]));
                strBody = strBody.Replace("[Agency_Name]", Convert.ToString(dtEvent.Rows[0]["Agency_Name"]));
                strBody = strBody.Replace("[Officer_Name]", Convert.ToString(dtEvent.Rows[0]["Officer_Name"]));
                strBody = strBody.Replace("[Phone_#]", Convert.ToString(dtEvent.Rows[0]["Officer_Phone"]));
                strBody = strBody.Replace("[Police_Report_#]", Convert.ToString(dtEvent.Rows[0]["Police_Report_Number"]));
                strBody = strBody.Replace("[Incident_Report_Desc]", Convert.ToString(dtEvent.Rows[0]["Incident_Report_Desc"]));

                strBody = strBody.Replace("[Vehicle_Information_Grid]", GetVehicleDetailsDOC(dtVehicleInformation));
                strBody = strBody.Replace("[Suspect_Information_Grid]", GetSuspectDetailsDOC(dtSuspectInformation));
                strBody = strBody.Replace("[Acadian_Notes_Grid]", GetACINotesDetailsDOC(dtACINotes));

                strBody = strBody.Replace("[Sonic_Notes_Grid]", GetSonicNotesDetailsDOC(dtSonicNotes));

                #endregion

                #region "Images of Event"

                string strEventImages = string.Empty;

                //strBody = strBody.Replace("[Images_of_Event]", strEventImages);

                DataTable dtInvestigationImages = dsEvent.Tables[6];

                if (dtInvestigationImages.Rows.Count > 0)
                {
                    string strImagesEvents = string.Empty;

                    strImagesEvents = "<table>";

                    foreach (DataRow drEvent_Images in dtInvestigationImages.Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(drEvent_Images["Attachment_Name"])) && File.Exists(_strInvestigationImagePath + drEvent_Images["Attachment_Name"]))
                        {
                            strImagesEvents = strImagesEvents + "<tr><td align='center'><img  alt='' src='" + _strInvestigationImagePath + drEvent_Images["Attachment_Name"] + "' Height='288' Width='352' /></td></tr>";
                        }
                    }

                    strImagesEvents = strImagesEvents + "</table>";

                    strBody = strBody.Replace("[Images_of_Event]", strImagesEvents);
                }
                else
                {
                    strBody = strBody.Replace("[Images_of_Event]", string.Empty);
                }

                #endregion
            }

            return strBody;

        }

    }
}
