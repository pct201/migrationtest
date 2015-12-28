using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Text;
using ERIMS.DAL;

public partial class SONIC_Sedgwick_Attachment_SendMail : System.Web.UI.Page
{
    public static string[] arrAttachments;

    private int EmailType
    {
        get { return clsGeneral.GetInt(ViewState["Type"]); }
        set { ViewState["Type"] = value; }
    }

    private string TableName
    {
        get { return Convert.ToString(ViewState["TableName"]); }
        set { ViewState["TableName"] = value; }
    }

    # region " Page EVents "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // to use this page , user must pass EmailType in querystring.
            EmailType = clsGeneral.GetInt(Request.QueryString["EmailType"]);
            TableName = Request.QueryString["Tab"];
            if (EmailType == 0)
            {
                trAttachment.Visible = false;
            }
            else
            {
                // code to show layout of page as per selected email type.
                switch (EmailType)
                {
                    case (int)clsGeneral.EmailTYpe.Attachment:
                        trAttachment.Visible = true;
                        string[] AttachmentIds = Request.QueryString["AttachmentId"].Split(',');
                        arrAttachments = new string[AttachmentIds.Length];

                        if (TableName == "SLT_Meeting_Review")
                        {
                            DataSet ds = ERIMSAttachment.SelectByID(Convert.ToString(Request.QueryString["AttachmentId"]));

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                string Attachment_Name = Convert.ToString(ds.Tables[0].Rows[i]["Attachment_Name"]);
                                lblAttachment.Text += " " + Attachment_Name.Substring(12) + ",";
                                string strAttachment = AppConfig.strSLT_MeetingReviewDocsPath + Attachment_Name;
                                arrAttachments[i] = strAttachment;
                            }
                            //this.Page.Title = " Email Attachment ";

                        }
                        else
                        {
                            string PK_Field_Name = Convert.ToString(Request.QueryString["PK_Field_Name"]);
                            for (int i = 0; i < AttachmentIds.Length; i++)
                            {
                                int intAttachmentId = clsGeneral.GetInt(AttachmentIds[i]);

                                if (intAttachmentId == 0)
                                {
                                    // if attachment id is not passed.
                                    //lblMsg.Text = "Attachment Not Found";
                                }
                                else
                                {
                                    string strSQL = "";
                                    strSQL = strSQL + "SELECT Atachment_Name_On_Disk";
                                    strSQL = strSQL + " FROM " + "Sedgwick_Attachments" + Environment.NewLine;
                                    strSQL = strSQL + " WHERE " + PK_Field_Name + " = " + intAttachmentId;

                                    Database db = DatabaseFactory.CreateDatabase();
                                    DataSet ds = db.ExecuteDataSet(System.Data.CommandType.Text, strSQL);

                                    string Attachment_Name = Convert.ToString(ds.Tables[0].Rows[0]["Atachment_Name_On_Disk"]);
                                    lblAttachment.Text += " " + Attachment_Name.Substring(12) + ",";
                                    //this.Page.Title = " Email Attachment ";
                                    string strAttachment = AppConfig.strAPDocumentPath + Attachment_Name;
                                    arrAttachments[i] = strAttachment;

                                }
                            }
                        }
                        this.Page.Title = " Email Attachment ";
                        lblAttachment.Text = lblAttachment.Text.TrimEnd(',');


                        break;
                    default:
                        //lblMsg.Text = "No Email Type Found";
                        break;
                }

                if (arrAttachments.Length > 0)
                {
                    decimal FileSize = clsGeneral.GetMailAttachmentSize(arrAttachments);
                    if (FileSize > 9.5M)
                        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('The e-mailing of the selected attachments exceeds 10 megabytes, which does not conform to Sonic Corporate e-mail policy. Please reduce the attachment size or number of attachments before trying to send e-mail through eRIMS2.');window.close();", true);

                }
            }


        }
    }

    #endregion

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (EmailType == 0)
        {
            clsGeneral.SendMailMessage(AppConfig.MailFrom, txtTo.Text.Trim(), string.Empty, string.Empty, "Selected Claim Notes", txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, arrAttachments);
        }
        else
            clsGeneral.SendMailMessage(AppConfig.MailFrom, txtTo.Text, "", "", txtSubject.Text, txtBody.Text, true, arrAttachments);
        ClosePage();
    }

    private void ClosePage()
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), "keyclosewindow", "alert('Mail Sent Successfully');window.close();", true);
    }
}