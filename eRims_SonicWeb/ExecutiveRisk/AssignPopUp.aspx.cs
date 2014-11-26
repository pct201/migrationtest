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
using System.Collections.Generic;
using System.Web.Mail;
using System.Net;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using ERIMS.DAL;
public partial class Diary_AssignPopUp : clsBasePage
{
    #region Public Variables
    public RIMS_Base.Biz.Diary m_objUserList;
    DataSet m_dsUserList;
    public RIMS_Base.Biz.Diary m_objDiary;
    public RIMS_Base.Biz.CSecurity m_objSecurity;
    List<RIMS_Base.CSecurity> lstSecurity = null;
    public int nRetVal = -1;
    #endregion
    #region Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["ClaimNo"] != null)
                {
                    //gvUser.DataSource = GetUserListForAssign(Request.QueryString[1].ToString());
                    gvUser.DataSource = GetUserListForAssign();
                    gvUser.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnAddDiary_Click(object sender, EventArgs e)
    {
        try
        {
            m_objDiary = new RIMS_Base.Biz.Diary();
            m_objDiary.Pk_Assign_Id = 0;
            m_objDiary.ClaimNo = Request.QueryString[0].ToString();
            m_objDiary.ClaimType = "Executive Risk";
            m_objDiary.AssignBy = clsSession.UserID;
            m_objDiary.Assigned_To = Request.Form["chkItem"].ToString();
            m_objDiary.Note = txtNote.Text;
            m_objDiary.Clear = "N";
            nRetVal = m_objDiary.InsertClaimAssign(m_objDiary);
            if (nRetVal > 0)
            {
                m_objSecurity = new RIMS_Base.Biz.CSecurity();
                lstSecurity = new List<RIMS_Base.CSecurity>();
                lstSecurity = m_objSecurity.GetSecurityByID(Convert.ToInt32(Request.Form["chkItem"].ToString()));
                if (lstSecurity.Count > 0)
                {
                    if (lstSecurity[0].Email != string.Empty)
                    {
                        clsGeneral.SendMailMessage(AppConfig.MailFrom, lstSecurity[0].Email, string.Empty, AppConfig.MailCC, "Diary Assigned :" + Request.QueryString[0].ToString(), "You have been assigned diary for claim number :" + Request.QueryString[0].ToString(), false);
                        //sendMail(ConfigurationManager.AppSettings["mailFrom"].ToString(), lstSecurity[0].Email, string.Empty, string.Empty, "Diary Assigned :" + Request.QueryString[0].ToString(), "You have been assigned diary for claim number :" + Request.QueryString[0].ToString());
                    }
                }


                lblScript.Text = "<script type='text/javascript'>Close('" + Request.QueryString["btn"] + "');</script>";            
                
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion
    #region Private Methods
    private DataSet GetUserListForAssign()
    {
        try
        {
            //m_objUserList = new RIMS_Base.Biz.Diary();
            //m_dsUserList = new DataSet();
            //m_dsUserList = m_objUserList.GetUserToAssign(m_strCostCenter);
            //return m_dsUserList;
            return Security.SelectAll();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
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
        if (!AppConfig.AllowMailSending)
            return "";
        // Mail initialization
        System.Web.Mail.MailMessage mailMsg = new System.Web.Mail.MailMessage();
        mailMsg.From = "Erims2<" + from + ">";
        mailMsg.To = to;
        mailMsg.Cc = cc;
        mailMsg.Bcc = bcc;
        mailMsg.Subject = subject;
        mailMsg.BodyFormat = System.Web.Mail.MailFormat.Html;
        mailMsg.Body = body;



        mailMsg.Priority = System.Web.Mail.MailPriority.Normal;
        // Smtp configuration
        System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";
        // - smtp.gmail.com use smtp authentication
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", from);
        //Password for From mail account.
        //m_strSMTPpwd = DecryptPassword(System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
        // - smtp.gmail.com use port 465 or 587 ifmisBugs@astegic.com/ifmisbugs
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
        // - smtp.gmail.com use STARTTLS (some call this SSL)
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
        // try to send Mail
        try
        {
            System.Web.Mail.SmtpMail.Send(mailMsg);
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
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
    #endregion

}
