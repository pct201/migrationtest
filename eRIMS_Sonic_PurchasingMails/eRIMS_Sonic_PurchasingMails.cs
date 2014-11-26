using System;
using System.Configuration;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Threading;
using Aspose.Words;
using StandardModel;

namespace eRIMS_Sonic_PurchasingMails
{
    public partial class eRIMS_Sonic_PurchasingMails : ServiceBase
    {
        #region " Properties "

        //flag to check status of mail for today is sent or not
        bool flgSendEmail = true;

        //Report schedule on this date will be send.
        DateTime dtSchduleDate = DateTime.Today;

        //Date time format to dispaly in attached excel with Email
        public const String DateDisplayFormat = "MM/dd/yyyy";

        Thread TSendMail;
        #endregion

        #region " Constructor "

        public eRIMS_Sonic_PurchasingMails()
        {
            InitializeComponent();
        }

        #endregion

        #region " Events "

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.

            //Make event log entry to indicate starting of service
            EventLog.WriteEntry("eRIMS_Sonic Purchasing Mail service Started At : " + DateTime.Now.ToString());

            //Create a thred for the function which send email
            TSendMail = default(Thread);
            TSendMail = new System.Threading.Thread(SendPurchasingMails);

            //Start the thread
            TSendMail.Start();

        }

        protected override void OnStop()
        {
            try
            {
                EventLog.WriteEntry("Service stopped successfully");
            }
            catch (Exception exc)
            {
                EventLog.WriteEntry(exc.Message);
            }
        }

        #endregion

        #region " Methods "

        private void SendPurchasingMails()
        {
            //Thread.Sleep(15000);
            //Thread.Sleep(3600000);            
            //while (true)
            //{
            object objMailSending = ConfigurationManager.AppSettings.Get("AllowMailSending");
            bool _bAllowMailSending = false;
            bool bOutMail;
            if (bool.TryParse(Convert.ToString(objMailSending), out bOutMail))
                _bAllowMailSending = bOutMail;
            else
                _bAllowMailSending = false;
            //Check send mail status for today
            if (flgSendEmail && _bAllowMailSending)
            {
                clsGeneral.strServicePath = Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName;

                EventLog.WriteEntry("Total No of Database Connection String Found : " + ConfigurationManager.ConnectionStrings.Count.ToString());

                string strFromAddress = ConfigurationManager.AppSettings.Get("SMTPmail");

                for (int i = 1; i < ConfigurationManager.ConnectionStrings.Count; i++)
                {
                    Purchasing.strConn = ConfigurationManager.ConnectionStrings[i].ConnectionString;
                    if (!string.IsNullOrEmpty(strFromAddress))
                    {
                        try
                        {
                            string strSubject = "Sonic Contract System Notification - Review Required";

                            #region " Send Mails for LR Agreement "
                            DataTable dtLRAgreement = Purchasing.GetLRAgreementsForMail().Tables[0];
                            foreach (DataRow drAgreement in dtLRAgreement.Rows)
                            {
                                string strTo = Convert.ToString(drAgreement["ToAddress"]);
                                string strcc = Convert.ToString(drAgreement["ccAddress"]);
                                string strBody = "Per the system records, the Lease/Rental Agreement with " + Convert.ToString(drAgreement["Supplier"]) +
                                                 " is at the end of its contractual term. Please review the attached or log into your eRIMS account and take appropriate action.";
                                StringBuilder strHTML = new StringBuilder();

                                // change the method to LR agreement
                                strHTML.Append(Purchasing.LRAgreement(Convert.ToInt32(drAgreement["PK_Purchasing_LR_Agreement"])));
                                string strFileName = "Sonic_LeaseRentalAgreementAbstract.doc";
                                clsGeneral.SaveFile(strHTML.ToString(), strFileName);
                                string[] strAttachment = new string[1];

                                if (File.Exists(clsGeneral.strServicePath + @"\" + strFileName))
                                {
                                    strAttachment = new string[1];
                                    strAttachment[0] = clsGeneral.strServicePath + @"\" + strFileName;
                                }

                                SendMailMessage(strFromAddress, strTo, "", strcc, strSubject, strBody, false, strAttachment);
                                if (File.Exists(clsGeneral.strServicePath + @"\" + strFileName))
                                    File.Delete(clsGeneral.strServicePath + @"\" + strFileName);
                            }
                            dtLRAgreement.Dispose();
                            #endregion

                            #region " Send Mails for Service Contracts "
                            DataTable dtServiceContract = Purchasing.GetServiceContractsForMail().Tables[0];
                            foreach (DataRow drSC in dtServiceContract.Rows)
                            {

                                string strTo = Convert.ToString(drSC["ToAddress"]);
                                string strcc = Convert.ToString(drSC["ccAddress"]);
                                string strBody = "Per the system records, the Service Contract with " + Convert.ToString(drSC["Supplier"]) +
                                                 " is at the end of its contractual term. Please review the attached or log into your eRIMS account and take appropriate action.";
                                StringBuilder strHTML = new StringBuilder();
                                strHTML.Append(Purchasing.ServiceContractAbstract(Convert.ToInt32(drSC["PK_Purchasing_Service_Contract"])));
                                string strFileName = "Sonic_ServiceContractAbstract.doc";
                                clsGeneral.SaveFile(strHTML.ToString(), strFileName);
                                string[] strAttachment = new string[1];

                                if (File.Exists(clsGeneral.strServicePath + @"\" + strFileName))
                                {
                                    strAttachment = new string[1];
                                    strAttachment[0] = clsGeneral.strServicePath + @"\" + strFileName;
                                }

                                SendMailMessage(strFromAddress, strTo, "", strcc, strSubject, strBody, false, strAttachment);
                                if (File.Exists(clsGeneral.strServicePath + @"\" + strFileName))
                                    File.Delete(clsGeneral.strServicePath + @"\" + strFileName);
                            }
                            dtServiceContract.Dispose();
                            EventLog.WriteEntry("Mails sent successfully.");
                            #endregion

                            flgSendEmail = false;
                        }
                        catch (Exception exc)
                        {
                            flgSendEmail = false;
                            EventLog.WriteEntry(exc.Message);
                        }
                    }
                }

                clsMemoryManagement.FlushMemory();
                //Stop Process For 1 Hour to reduce CPU Utilization
                //Thread.Sleep(3600000);

                //if date changes set schedule date to todays date(new schedule date)
                if (dtSchduleDate.Date < DateTime.Today.Date)
                {
                    dtSchduleDate = DateTime.Today;
                    flgSendEmail = true;
                }
            }
            clsMemoryManagement.FlushMemory();
            this.Stop();
            //}


        }

        /// <summary>
        /// Used to Send EMail with Attachment
        /// </summary>
        /// <param name="strFrom"></param>
        /// <param name="strTo"></param>
        /// <param name="strBCC"></param>
        /// <param name="strCC"></param>
        /// <param name="strSubject"></param>
        /// <param name="strBody"></param>
        /// <param name="boolIsHTML"></param>
        /// <param name="strAttachments"></param>
        /// <returns></returns>
        public static bool SendMailMessage(string strFrom, string strTo, string strBCC, string strCC, string strSubject, string strBody, bool boolIsHTML, string[] strAttachments)
        {
            // Instantiate a new instance of MailMessage
            MailMessage mMailMessage = new MailMessage();

            if (!string.IsNullOrEmpty(strFrom))
            {
                // Set the sender address of the mail message
                mMailMessage.From = new MailAddress(strFrom);
            }

            char[] arrSplitChar = { ',' };
            if (!string.IsNullOrEmpty(strTo))
            {
                string[] arrTo = strTo.Split(arrSplitChar);
                foreach (string strTOID in arrTo)
                {
                    // Set the recepient address of the mail message
                    mMailMessage.To.Add(new MailAddress(strTOID));
                }
            }


            // Check if the bcc value is nothing or an empty string
            if (!string.IsNullOrEmpty(strBCC))
            {
                string[] arrBCC = strBCC.Split(arrSplitChar);
                foreach (string strBCCID in arrBCC)
                {
                    // Set the recepient address of the mail message
                    mMailMessage.Bcc.Add(new MailAddress(strBCCID));
                }
            }

            // Check if the cc value is nothing or an empty value
            if (!string.IsNullOrEmpty(strCC))
            {
                string[] arrCC = strCC.Split(arrSplitChar);
                foreach (string strCCID in arrCC)
                {
                    // Set the recepient address of the mail message
                    mMailMessage.CC.Add(new MailAddress(strCCID));
                }
            }

            if (strAttachments != null)
            {
                foreach (string strAttachment in strAttachments)
                {
                    if (File.Exists(strAttachment))
                    {
                        mMailMessage.Attachments.Add(new Attachment(strAttachment));
                    }
                }
            }

            // Set the subject of the mail message
            mMailMessage.Subject = strSubject;
            // Set the body of the mail message
            mMailMessage.Body = strBody;

            // Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = boolIsHTML;
            // Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal;

            string SMTPServer = ConfigurationManager.AppSettings.Get("SMTPServer");
            string SMTPPort = ConfigurationManager.AppSettings.Get("Port");
            string SMTPPassword = ConfigurationManager.AppSettings.Get("SMTPPwd");

            // Instantiate a new instance of SmtpClient
            SmtpClient mSmtpClient = new SmtpClient(SMTPServer, Convert.ToInt32(SMTPPort));

            mSmtpClient.Credentials = new NetworkCredential(strFrom, SMTPPassword);

            try
            {
                // Send the mail message
                mSmtpClient.Send(mMailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                mMailMessage.Dispose();
                mMailMessage = null;
                mSmtpClient = null;
                //CommonHelper.DisposeOf(mMailMessage);
                //CommonHelper.DisposeOf(mSmtpClient);
            }

        }


        #endregion
    }
}
