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
using ERIMS_DAL;

public partial class EventAttachmentMail : System.Web.UI.Page
{
    /// <summary>
    ///  store Attachment String Array
    /// </summary>    
    public string[] DocName
    {
        get { return (string[])this.ViewState["strDocName"]; }
        set { this.ViewState["strDocName"] = value; }
    }

    #region Public Variables

    public static string m_strGlobalPath = string.Empty;
    public static string[] m_arrGlobalPath;

    #endregion

    #region Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check Parameter is properly passed or not
            if (!string.IsNullOrEmpty(Request.QueryString["AttIds"]))
            {              
                m_strGlobalPath = AppConfig.DocumentsPath + "Attach\\";
                DataTable dtAttachments = ERIMS.DAL.clsAttachment_Event.SelectAttachmentBy_ID(Request.QueryString["AttIds"].ToString()).Tables[0];  
                m_arrGlobalPath = new string[Request.QueryString["AttIds"].ToString().Split(',').Length];
                string[] strOriginal = new string[m_arrGlobalPath.Length];

                string strFileNameList = string.Empty;
                for (int i = 0; i < dtAttachments.Rows.Count; i++)
                {                   
                    m_arrGlobalPath[i] = m_strGlobalPath + Convert.ToString(dtAttachments.Rows[i]["Attachment_Name"]);
                    strFileNameList += Convert.ToString(dtAttachments.Rows[i]["Attachment_Description"]) + ",";
                }
                strFileNameList = strFileNameList.TrimEnd(',');
                DocName = m_arrGlobalPath;
                lblAttachment.Text = strFileNameList;
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["ClaimIds"]))
            {
                m_strGlobalPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Property_Claims]);
                DataTable dtAttachments = ERIMS.DAL.Property_Claims_Attachments.SelectAttachmentBy_ID(Request.QueryString["ClaimIds"].ToString()).Tables[0];
                m_arrGlobalPath = new string[Request.QueryString["ClaimIds"].ToString().Split(',').Length];
                string[] strOriginal = new string[m_arrGlobalPath.Length];

                string strFileNameList = string.Empty;
                for (int i = 0; i < dtAttachments.Rows.Count; i++)
                {
                    m_arrGlobalPath[i] = m_strGlobalPath + Convert.ToString(dtAttachments.Rows[i]["Attachment_Path"]);
                    strFileNameList += Convert.ToString(dtAttachments.Rows[i]["Description"]) + ",";
                }
                strFileNameList = strFileNameList.TrimEnd(',');
                DocName = m_arrGlobalPath;
                lblAttachment.Text = strFileNameList;
            }
            else
            {
                lblError.Text = "Invalid Parameter. Please retry to re-open this page or Contact Administrator. ";
                lblError.Visible = true;
                dvContain.Visible = false;
            }
        }
        lblScript.Text = string.Empty;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            if (clsGeneral.SendMailMessage(AppConfig.MailFrom, txtToEmail.Text.Trim().Replace(';',','), string.Empty, string.Empty, txtSubject.Text.Trim(), txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, DocName))
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Mail sent successfully');self.close();", true);
            else ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Mail is sent not successfully');self.close();", true);

            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:Close();", true);
        }
        catch
        {
        }
        finally
        {
            lblScript.Text = "<script type='text/javascript'>Close();</script>";
        }
    }  

    #endregion
}