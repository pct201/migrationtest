using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Collections;

public partial class SONIC_Exposures_AM_Attachment_Mail : System.Web.UI.Page
{
    #region " Properties "
    public ArrayList DocName
    {
        get { return (ArrayList)this.ViewState["strDocName"]; }
        set { this.ViewState["strDocName"] = value; }
    }

    public static string m_strGlobalPath = string.Empty;
    public static string[] m_arrGlobalPath;
    public static string[] arrOrginalFileName;
    #endregion

    #region " Page Load event "
    /// <summary>
    /// Handles page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Attch_Ids"]))
            {
                DataTable dtAttachments = clsAM_Attachments.GetAttchmentsByID(Request.QueryString["Attch_Ids"].ToString()).Tables[0];
                m_arrGlobalPath = new string[Request.QueryString["Attch_Ids"].ToString().Split(',').Length];
                m_strGlobalPath = AppConfig.strAPDocumentPath;
                string[] strOriginal = new string[m_arrGlobalPath.Length];

                string strFileNameList = string.Empty;
                for (int i = 0; i < dtAttachments.Rows.Count; i++)
                {
                    m_arrGlobalPath[i] = m_strGlobalPath + Convert.ToString(dtAttachments.Rows[i]["Attachment_Filename"]);
                    strFileNameList += Convert.ToString(dtAttachments.Rows[i]["Attachment_Description"]) + ",";
                }
                strFileNameList = strFileNameList.TrimEnd(',');
                ArrayList strTemp = new ArrayList();
                strTemp.AddRange(m_arrGlobalPath);
                DocName = strTemp;
                lblAttachment.Text = strFileNameList;
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["OC_Attch_Id"]))
            {
                DataTable dtAttachments = null;

                if (!string.IsNullOrEmpty(Request.QueryString["tbl"]) && Convert.ToString(Request.QueryString["tbl"]) == "PM_Respiratory_Protection_Attachments")
                {
                    dtAttachments = clsPM_Respiratory_Protection_Attachments.SelectAttachmentByPK(clsGeneral.GetDecimal
                       (Encryption.Decrypt(Request.QueryString["OC_Attch_Id"]).ToString())).Tables[0];
                }

                else if (!string.IsNullOrEmpty(Request.QueryString["tbl"]) && Convert.ToString(Request.QueryString["tbl"]) == "PM_Hearing_Conservation_Attachments")
                {
                    dtAttachments = PM_Hearing_Conservation.SelectAttachmentByPK(clsGeneral.GetDecimal
                       (Encryption.Decrypt(Request.QueryString["OC_Attch_Id"]).ToString())).Tables[0];
                }

                else if (!string.IsNullOrEmpty(Request.QueryString["tbl"]) && Convert.ToString(Request.QueryString["tbl"]) == "PM_FirstRepose_AEDEquipment_Attachments")
                {
                    clsPM_FirstRepose_AEDEquipment_Attachments objPM_FirstRepose_AEDEquipment_Attachments = new clsPM_FirstRepose_AEDEquipment_Attachments();
                    dtAttachments = objPM_FirstRepose_AEDEquipment_Attachments.SelectByPK(clsGeneral.GetDecimal
                       (Encryption.Decrypt(Request.QueryString["OC_Attch_Id"]).ToString())).Tables[0];
                }

                else if (!string.IsNullOrEmpty(Request.QueryString["tbl"]) && Convert.ToString(Request.QueryString["tbl"]) == "PM_AssociateTrainingFirstRepose_AED_Attachments")
                {
                    clsPM_AssociateTrainingFirstRepose_AED_Attachments objPM_AssociateTrainingFirstRepose_AED_Attachments = new clsPM_AssociateTrainingFirstRepose_AED_Attachments();
                    dtAttachments = objPM_AssociateTrainingFirstRepose_AED_Attachments.SelectByPK(clsGeneral.GetDecimal
                       (Encryption.Decrypt(Request.QueryString["OC_Attch_Id"]).ToString())).Tables[0];
                }
                
                else if (!string.IsNullOrEmpty(Request.QueryString["tbl"]) && Convert.ToString(Request.QueryString["tbl"]) == "Find_it_Fix_it_Attachments")
                {
                    dtAttachments = clsFind_it_Fix_it_Attachments.SelectByPK(clsGeneral.GetDecimal
                       (Encryption.Decrypt(Request.QueryString["OC_Attch_Id"]).ToString())).Tables[0];
                }

                    if (dtAttachments.Rows.Count > 0)
                {
                    string strRpFileName = Convert.ToString(dtAttachments.Rows[0]["NewAttachment_Name"]);
                    string strOriginalFileName = Convert.ToString(dtAttachments.Rows[0]["File_Name"]);
                    string strRpFilePath = AppConfig.PM_Respiratory_Protection_AttachmentsDocPath + strOriginalFileName;
                    lblAttachment.Text = strRpFileName;

                    m_arrGlobalPath = new string[Request.QueryString["OC_Attch_Id"].ToString().Split(',').Length];
                    m_arrGlobalPath[0] = strRpFilePath;
                    arrOrginalFileName = new string[strRpFileName.Split(',').Length];
                    arrOrginalFileName[0] = strRpFileName;
                    ArrayList strTemp = new ArrayList();
                    strTemp.AddRange(m_arrGlobalPath);
                    DocName = strTemp;
                }
            }
        }
    }
    #endregion

    #region " Control Events "
    /// <summary>
    /// Handles Click event of send button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        bool isSent = false;
        string[] arrAttachment = new string[DocName.Count];
        DocName.CopyTo(arrAttachment);

        if (!string.IsNullOrEmpty(Request.QueryString["OC_Attch_Id"]))
            isSent = clsGeneral.SendMailWithNewFileName(AppConfig.MailFrom, txtToEmail.Text.Trim(), string.Empty, "", txtSubject.Text.Trim(), txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, arrAttachment, arrOrginalFileName);
        else
            isSent = clsGeneral.SendMailMessage(AppConfig.MailFrom, txtToEmail.Text.Trim(), string.Empty, "", txtSubject.Text.Trim(), txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, arrAttachment);

        if (isSent)
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Mail sent successfully');window.opener.AskfForLogoff=false;self.close();", true);
        }
        else ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Mail is not sent successfully');window.opener.AskfForLogoff=false;self.close();", true);
    }

    /// <summary>
    /// Handles Cancel Button's Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:window.opener.AskfForLogoff=false;self.close();", true);
    }
    #endregion
}