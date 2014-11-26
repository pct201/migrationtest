using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.Net;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using System.Collections.Generic;
using ERIMS.DAL;
public partial class ErimsMail : System.Web.UI.Page
{
    #region Public Variables
	public static string m_strFrom=string.Empty ;
    public static string m_strTo =string.Empty;
    public static string m_strCC = string.Empty;
    public static string m_strBCC = string.Empty;
    public static string m_strSMTPpwd = string.Empty;
    public static string m_strGlobalPath=string.Empty;
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    public static string[] m_arrGlobalPath;
    public string[] m_arrIDs;
    #endregion
    #region Event Handlers
    

    protected void Page_Load(object sender, EventArgs e)
    {
        m_strFrom = ConfigurationManager.AppSettings["SMTPmail"].ToString();
        if (!IsPostBack)
        {
            if (Request.QueryString[0].ToString() == "Vendor")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Vendor/" );//+ Request.QueryString[1].ToString());
                
            }
            
            else if (Request.QueryString[0].ToString() == "SecEq")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/SecEq/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Provider")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Provider/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Employee")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Employee/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "AIGInfo")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/AIGInfo/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Claimant")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Claimant/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "EmployeeTraining")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/EmployeeTraining/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Policy")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Policy/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "PolicyCoverage")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/PolicyCoverage/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Carrier")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Carrier/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Worker_Comp_Adjustor_Notes")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Worker_Comp_Adjustor_Notes/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Worker_Comp_Subrogation_Detail")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Worker_Comp_Subrogation_Detail/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Worker_Comp_Subrogation")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Worker_Comp_Subrogation/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Worker_Comp_Settlement")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Worker_Comp_Settlement/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Workers_Comp")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Workers_Comp/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "Workers_Comp_RW")
			{
				m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Workers_Comp_RW/");// + Request.QueryString[1].ToString());
			}
            else if (Request.QueryString[0].ToString() == "Liability_Subrogation")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Liability_Subrogation/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Liability_Subrogation_Detail")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Liability_Subrogation_Detail/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Liability_Adjustor_Notes")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Liability_Adjustor_Notes/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Liability_Carrier")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Liability_Carrier/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "Liability_Claim")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Liability_Claim/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Property")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "Autoliability")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Autoliability/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "OtherVehicle")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/OtherVehicle/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "OtherDriver")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/OtherDriver/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "InjuredPerson")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/InjuredPerson/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "Witness")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Witness/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "Liability_Claim_RW")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Liability_Claim_RW/");// + Request.QueryString[1].ToString());
            }
            #region For Property
            else if (Request.QueryString[0].ToString() == "Property_COPE")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_COPE/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Property_Monitoring")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_Monitoring/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Property_SafetyAudit")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_SafetyAudit/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Property_E_Contact")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_E_Contact/");// + Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Property_U_Contact")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_U_Contact/");// + Request.QueryString[1].ToString());
            } 
            else if (Request.QueryString[0].ToString() == "Property_O_Contact")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_O_Contact/");// + Request.QueryString[1].ToString());
            }  

            else if (Request.QueryString[0].ToString() == "Property_Contact")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_Contact/");// + Request.QueryString[1].ToString());
            }

            else if (Request.QueryString[0].ToString() == "Prop_IndRec")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Prop_IndRec/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Prop_Rec")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Prop_Rec/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Prop_OEP")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Prop_OEP/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Prop_Waste")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Prop_Waste/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Property_Values")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_Values/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Property_Drivers")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_Drivers/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Environmental_Tanks")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Environmental_Tanks/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Tanks_Other_Reporting_Rqmts")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Prop_Env_Tank_Other_Report_Req/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "PropertyClaim")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Property_Claim/");// + Request.QueryString[1].ToString());
            }

            #endregion
            else if (Request.QueryString[0].ToString() == "Policy_Features")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Policy_Features/");//+ Request.QueryString[1].ToString());

            }
            else if (Request.QueryString[0].ToString() == "Executive_Risk")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/ExecutiveRisk/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Executive_Risk_Carrier")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/ExecutiveRiskCarrier/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Investigator_Notes")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/InvestigatorNotes/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Executive_Risk_Contacts")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/Executive_Risk_Contacts/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Defense_Attorney")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/DefenseAttorney/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Plaintiff_Attorney")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/PlantiffAttorney/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Executive_Risk_Expenses")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/RiskExpenses/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "Purchasing_Asset")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/PurchasingDocs/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "RE_Information")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/RealEstate/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "CRM_Customer")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/CRMCustomer/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "CRM_Non_Customer")
            {
                m_strGlobalPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "/CRMNonCustomer/");//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "WCClaim")
            {
                m_strGlobalPath = AppConfig.WCClaimDocPath;//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "ALClaim")
            {
                m_strGlobalPath = AppConfig.ALClaimDocPath;//+ Request.QueryString[1].ToString());
            }
            else if (Request.QueryString[0].ToString() == "PLClaim")
            {
                m_strGlobalPath = AppConfig.PLClaimDocPath;//+ Request.QueryString[1].ToString());
            }

            if (Request.QueryString["CRM"] != null)
            {
                DataTable dtAttach = CRM_Attachments.SelectByIDs(Request.QueryString[1].ToString()).Tables[0];

                lblAttachment.Text = Convert.ToString(dtAttach.Rows[0]["Attachment_Name1"]);
                //For Setting of Document
                m_arrIDs = Request.QueryString[0].ToString().Split(',');
                m_arrGlobalPath = new string[m_arrIDs.Length];
                m_arrGlobalPath = Convert.ToString(dtAttach.Rows[0]["Attachment_Name"]).ToString().Split(',');
            }
            else
            {
                //lblAttachment.Text=Request.QueryString[1].ToString().Substring(12);
                m_objAttachment = new RIMS_Base.Biz.CAttachment();
                lstAttachment = new List<RIMS_Base.CAttachment>();
                lstAttachment = m_objAttachment.GetAttachMentMail(Request.QueryString[1].ToString());

                lblAttachment.Text = lstAttachment[0].Attachment_Name1;
                //For Setting of Document
                m_arrIDs = Request.QueryString[0].ToString().Split(',');
                m_arrGlobalPath = new string[m_arrIDs.Length];
                m_arrGlobalPath = lstAttachment[0].Attachment_Name.ToString().Split(',');
            }

            for (int m_intCounter = 0; m_intCounter < m_arrGlobalPath.Length; m_intCounter++)
            {
                m_arrGlobalPath[m_intCounter] = m_strGlobalPath + m_arrGlobalPath[m_intCounter].ToString();
            }

            if (m_arrGlobalPath.Length > 0)
            {
                decimal FileSize = clsGeneral.GetMailAttachmentSize(m_arrGlobalPath);
                if (FileSize > 9.5M)
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('The e-mailing of the selected attachments exceeds 10 megabytes, which does not conform to Sonic Corporate e-mail policy. Please reduce the attachment size or number of attachments before trying to send e-mail through eRIMS2.');window.close();", true);
            }
        }    
        
        lblScript.Text = string.Empty;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        sendMail(m_strFrom, txtToEmail.Text, string.Empty, string.Empty, txtSubject.Text, txtBody.Text);
        lblScript.Text = "<script type='text/javascript'>alert('Mail sent successfully');Close();</script>";
    }
    #endregion
    #region Private Methods
    
    /// <summary>
    /// sending mail utitilty
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static string sendMail(string from, string to, string cc, string bcc, string subject, string body)
    {
        //for (int m_intCounter = 0; m_intCounter < m_arrGlobalPath.Length; m_intCounter++)
        //{
        //    m_arrGlobalPath[m_intCounter] = m_strGlobalPath + m_arrGlobalPath[m_intCounter].ToString();            
        //}

        clsGeneral.SendMailMessage(from, to, bcc, cc, subject, body, true, m_arrGlobalPath);
        return "";
        //// Mail initialization
        //System.Web.Mail.MailMessage mailMsg = new System.Web.Mail.MailMessage();
        //mailMsg.From = "Erims2<" + from + ">";
        //mailMsg.To = to;
        //mailMsg.Cc = cc;
        //mailMsg.Bcc = bcc;
        //mailMsg.Subject = subject;
        //mailMsg.BodyFormat = System.Web.Mail.MailFormat.Html;
        //mailMsg.Body = body;

        //for (int m_intCounter = 0; m_intCounter < m_arrGlobalPath.Length; m_intCounter++)
        //{
        //    MailAttachment m_mAttach = new MailAttachment(m_strGlobalPath+m_arrGlobalPath[m_intCounter].ToString(), System.Web.Mail.MailEncoding.Base64);
        //    mailMsg.Attachments.Add(m_mAttach);
        //}

        //mailMsg.Priority = System.Web.Mail.MailPriority.Normal;
        //// Smtp configuration
        //System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";
        //// - smtp.gmail.com use smtp authentication
        //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", from);
        ////Password for From mail account.
        ////m_strSMTPpwd = DecryptPassword(System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
        //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
        //// - smtp.gmail.com use port 465 or 587 ifmisBugs@astegic.com/ifmisbugs
        //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
        //// - smtp.gmail.com use STARTTLS (some call this SSL)
        //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
        //// try to send Mail
        //try
        //{
        //    System.Web.Mail.SmtpMail.Send(mailMsg);
        //    return "";
        //}
        //catch (Exception ex)
        //{
        //    return ex.Message;
        //}
    }
    public static string DecryptPassword(string sPWD)
    {
        byte[] _DecryptionKey = GenerateKey();

        byte[] StoredPassword = Convert.FromBase64String(sPWD);

        System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();
        string RetVal = null;

        TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();

        tripleDes.Key = _DecryptionKey;
        tripleDes.IV = new byte[8];

        CryptoStream cryptoStream = new CryptoStream(new MemoryStream(StoredPassword), tripleDes.CreateDecryptor(), CryptoStreamMode.Read);
        MemoryStream msPasswordDec = new MemoryStream();
        int BytesRead = 0;

        byte[] Buffer = new byte[32];
        while ((BytesRead = cryptoStream.Read(Buffer, 0, 32)) > 0)
        {
            msPasswordDec.Write(Buffer, 0, BytesRead);
        }
        cryptoStream.Close();

        RetVal = ue.GetString(msPasswordDec.ToArray());
        msPasswordDec.Close();

        return RetVal;
    }
    private static byte[] GenerateKey()
    {
        //TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
        //tDes.GenerateKey();
        //_DecryptionKey = tDes.Key;
        return new byte[] { 137, 241, 181, 79, 71, 224, 162, 36, 42, 198, 36, 4, 89, 100, 242, 89, 49, 180, 203, 213, 76, 230, 95, 37 };
    }
    #endregion
}
