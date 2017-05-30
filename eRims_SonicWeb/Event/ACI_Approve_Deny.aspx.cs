using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using Winnovative.WnvHtmlConvert;
using System.IO;

public partial class Event_ACI_Approve_Deny : System.Web.UI.Page
{
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Event_Video_Tracking_Request
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Event_Video_Tracking_Request"]);
        }
        set { ViewState["PK_Event_Video_Tracking_Request"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_Security_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Security_ID"]);
        }
        set { ViewState["FK_Security_ID"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrStatus
    {
        get { return ViewState["StrStatus"] != null ? Convert.ToString(ViewState["StrStatus"]) : ""; }
        set { ViewState["StrStatus"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrGroup
    {
        get { return ViewState["StrGroup"] != null ? Convert.ToString(ViewState["StrGroup"]) : ""; }
        set { ViewState["StrGroup"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Attachment_Event
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Attachment_Event"]);
        }
        set { ViewState["PK_Attachment_Event"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                trDeny.Style.Add("display", "none");
                trstatus.Style.Add("display", "none");

                PK_Event_Video_Tracking_Request = Convert.ToDecimal(clsGeneral.GetQueryStringID(Request.QueryString["tid"]));
                FK_Security_ID = Convert.ToDecimal(clsGeneral.GetQueryStringID(Request.QueryString["sid"]));
                StrStatus = Convert.ToString(Encryption.Decrypt(Request.QueryString["status"]));
                StrGroup = Convert.ToString(Encryption.Decrypt(Request.QueryString["grp"]));
                PK_Attachment_Event = Convert.ToDecimal(clsGeneral.GetQueryStringID(Request.QueryString["aid"]));

                DataSet ds = clsEvent_Video_Tracking_Request.GetVideoRequestData(PK_Event_Video_Tracking_Request);

                string currentstatus = string.Empty;
                bool Isclose = false;
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Status"] != null)
                {
                    currentstatus = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                }

                if (currentstatus.ToLower() != clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Pending].ToLower()
                    & currentstatus.ToLower() != clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Submitted].ToLower())
                {
                    lblStatus.Text = "Video Request Status is already updated to " + currentstatus;
                    trstatus.Style.Add("display", "");
                    Isclose = true;
                }
                else
                {
                    trDeny.Style.Add("display", "");
                }


                if (StrStatus.ToLower() != clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Sonic_Denied].ToLower() && !Isclose)
                {
                    //DataSet ds = clsEvent_Video_Tracking_Request.GetVideoRequestData(PK_Event_Video_Tracking_Request);

                    //if (StrGroup.ToLower() == "rlcmd")
                    //{
                    //    SendEmailForLegalApproval(ds);
                    //    StrStatus = "Pending";
                    //}
                    
                    clsEvent_Video_Tracking_Request.Event_Video_Tracking_RequestUpdateStatus(PK_Event_Video_Tracking_Request, StrStatus, FK_Security_ID, null);
                    SendNotificatonToCreater(ds);
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "javascript:closewindow();", true);
                }
                
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "javascript:closewindow();", true);
            }
        }
        
    }

    /// <summary>
    /// Send Notification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord();

    }

    /// <summary>
    /// Send Notification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
         Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:closewindow();", true);
    }

        /// <summary>
    /// Save Event Information In database
    /// </summary>
    private void SaveRecord()
    {
        try
        {
            PK_Event_Video_Tracking_Request = Convert.ToDecimal(clsGeneral.GetQueryStringID(Request.QueryString["tid"]));
            FK_Security_ID = Convert.ToDecimal(clsGeneral.GetQueryStringID(Request.QueryString["sid"]));
            StrStatus = Convert.ToString(Encryption.Decrypt(Request.QueryString["status"]));

            string strIspopup = Request.QueryString["ispop"] != null ? Request.QueryString["ispop"] : "";

            clsEvent_Video_Tracking_Request.Event_Video_Tracking_RequestUpdateStatus(PK_Event_Video_Tracking_Request, StrStatus, FK_Security_ID,  txtReason_Request_Video.Text);
            
            DataSet ds = clsEvent_Video_Tracking_Request.GetVideoRequestData(PK_Event_Video_Tracking_Request);
            SendNotificatonToCreater(ds);

            if (strIspopup == "1")
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:closeFormGrid();", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:closeForm();", true);
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "javascript:this.close();", true);
        }
    }

    private void SendEmailForLegalApproval(DataSet dsVideo)
    {
        if (PK_Event_Video_Tracking_Request > 0)
        {
            DataTable dtEmailList = clsEvent_Video_Tracking_Request.GetVideoRequesterByGroups("Legal").Tables[0];

            string fileName = string.Empty;
            string strUploadPath = AppConfig.DocumentsPath + "Attach\\";

            if (PK_Attachment_Event > 0)
            {
                clsAttachment_Event objAttachment = new clsAttachment_Event(PK_Attachment_Event);
                fileName = objAttachment.Attachment_Name;
            }

            if (dtEmailList.Rows.Count > 0)
            {
                foreach (DataRow drRecipient in dtEmailList.Rows)
                {
                    System.Collections.Generic.List<string> lstMail = new System.Collections.Generic.List<string>();
                    int intToMailCount = 0;
                    lstMail.Insert(intToMailCount, drRecipient["Email"].ToString());
                    intToMailCount++;


                    string[] EmailTo = lstMail.ToArray();

                    System.Collections.Generic.List<string> lstAttachment = new System.Collections.Generic.List<string>();
                    int intAttachmentcount = 0;


                    if (!string.IsNullOrEmpty(fileName) && File.Exists(strUploadPath + "\\" + fileName))
                    {
                        lstAttachment.Insert(intAttachmentcount, strUploadPath + "\\" + fileName);
                        intAttachmentcount++;
                    }

                    string[] strTemp = lstAttachment.ToArray();

                    string strlocation = string.Empty;
                    string strFullName = string.Empty;
                    string strReason = string.Empty;
                    
                    if (dsVideo != null && dsVideo.Tables.Count > 0 && dsVideo.Tables[0].Rows.Count > 0)
                    {
                        strlocation = Convert.ToString(dsVideo.Tables[0].Rows[0]["Location"]);
                        strFullName = Convert.ToString(dsVideo.Tables[0].Rows[0]["Full_Name"]);
                        strReason = Convert.ToString(dsVideo.Tables[0].Rows[0]["Reason_Request"]);
                    }

                    string strMailHeader = "ACI Video Request has been Created for " + strlocation + " by " + strFullName;

                    string strMailBody = "ERIMS has requested ACI Video Approval. Please click APPROVE or DENY for video Request.";
                    strMailBody = strMailBody + "<br/><br/>";
                    strMailBody = strMailBody + "<span style='font-size: 20px;'><A href=" + AppConfig.SiteURL + "/Event/ACI_Approve_Deny.aspx?tid=" + Encryption.Encrypt(Convert.ToString(PK_Event_Video_Tracking_Request)) + "&sid=" + Encryption.Encrypt(Convert.ToString(drRecipient["PK_Security_ID"].ToString())) + "&status=" + Encryption.Encrypt(clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Sonic_Approved]) + "&grp=" + Encryption.Encrypt("Legal") + ">APPROVE</A></span>";
                    strMailBody = strMailBody + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                    strMailBody = strMailBody + "<span style='font-size: 20px;'><A href=" + AppConfig.SiteURL + "/Event/ACI_Approve_Deny.aspx?tid=" + Encryption.Encrypt(Convert.ToString(PK_Event_Video_Tracking_Request)) + "&sid=" + Encryption.Encrypt(Convert.ToString(drRecipient["PK_Security_ID"].ToString())) + "&status=" + Encryption.Encrypt(clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Sonic_Denied]) + "&grp=" + Encryption.Encrypt("Legal") + ">DENY</A></span>";
                    strMailBody = strMailBody + "<br/><br/><br/>";
                    strMailBody = strMailBody + "<span style='font-size: 18px;'><b>Reason   :   </b></span>" + strReason;

                    if (EmailTo.Length > 0)
                    {
                        EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                        objEmail.SendEventMailMessage(AppConfig.ManagementEmailID, " ", EmailTo, strMailHeader, strMailBody, true, strTemp, AppConfig.MailCC);
                    }
                }
            }

        }
    }

    private void SendNotificatonToCreater(DataSet dsEmail)
    {
        string strlocation = string.Empty;
        string strFullName = string.Empty;
        string strReason = string.Empty;
        string strRequestNumber = string.Empty;
        string strEmailTo = string.Empty;

        if (dsEmail != null && dsEmail.Tables.Count > 0 && dsEmail.Tables[0].Rows.Count > 0)
        {
            strlocation = Convert.ToString(dsEmail.Tables[0].Rows[0]["Location"]);
            strFullName = Convert.ToString(dsEmail.Tables[0].Rows[0]["Full_Name"]);
            strReason = Convert.ToString(dsEmail.Tables[0].Rows[0]["Reason_Request"]);
            strRequestNumber = Convert.ToString(dsEmail.Tables[0].Rows[0]["Request_Number"]);
            strEmailTo = Convert.ToString(dsEmail.Tables[0].Rows[0]["Creater_Email"]);
        }


        if (strEmailTo.Length > 0)
        {
            System.Collections.Generic.List<string> lstMail = new System.Collections.Generic.List<string>();
            int intToMailCount = 0;
            lstMail.Insert(intToMailCount, strEmailTo);
            intToMailCount++;

            DataTable dtEmailList = clsEvent_Video_Tracking_Request.GetACIGroupEmail().Tables[0];

            if (dtEmailList.Rows.Count > 0)
            {
                foreach (DataRow drRecipient in dtEmailList.Rows)
                {
                    lstMail.Insert(intToMailCount, drRecipient["Email"].ToString());
                    intToMailCount++;
                }
            }

            Security objSecurity = new Security(FK_Security_ID);

            string[] EmailTo = lstMail.ToArray();

            string strMailHeader = "ACI Video Request status for Request Number : " + strRequestNumber;
            string strMailBody = string.Empty;

            string StrSendstatus = StrStatus;
            if (StrStatus.ToLower() == clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Sonic_Approved].ToLower())
                StrSendstatus = "Approved";
            else if (StrStatus.ToLower() == clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Sonic_Denied].ToLower())
                StrSendstatus = "Denied";

            if (StrGroup.ToLower() == "rlcmd" && StrStatus.ToLower() == clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Submitted])
            {
                strMailBody = "ACI Video Request has been " + (StrStatus.ToLower() == clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Submitted] ? StrSendstatus : StrStatus) + " for " + strlocation + " by " + objSecurity.FIRST_NAME + " " + objSecurity.LAST_NAME + ".";
                strMailBody = strMailBody + "<br/>";
                strMailBody = strMailBody + "Awaits the approval from Legal Group.";
            }
            else
            {
                strMailBody = "ACI Video Request has been " + StrSendstatus + " for " + strlocation + " by " + objSecurity.FIRST_NAME + " " + objSecurity.LAST_NAME + ".";
            }
            strMailBody = strMailBody + "<br/><br/><br/>";

            if (StrStatus.ToLower() == clsGeneral.VideoRequestStatus[(int)clsGeneral.VideoRequest_Status.Sonic_Denied].ToLower())
            {
                strMailBody = strMailBody + "<span style='font-size: 18px;'><b>Reason   :   </b></span>" + strReason;
            }

            if (EmailTo.Length > 0)
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                objEmail.SendEventMailMessage(AppConfig.ManagementEmailID, " ", EmailTo, strMailHeader, strMailBody, true, null, AppConfig.MailCC);
            }
        }
    }

}