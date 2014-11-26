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
using ERIMS.DAL;

public partial class Admin_SendEmail : clsBasePage
{

    public static string[] arrAttachments;

    private int EmailType
    {
        get { return clsGeneral.GetInt(ViewState["Type"]); }
        set { ViewState["Type"] = value; }
    }


    # region " Page EVents "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // to use this page , user must pass EmailType in querystring.
            EmailType = clsGeneral.GetInt(Request.QueryString["EmailType"]);
            if (EmailType == 0)
            {
                ClosePage();
            }
            else
            {
                // code to show layout of page as per selected email type.
                switch (EmailType)
                {
                    case (int)clsGeneral.EmailTYpe.Attachment:
                        string[] AttachmentIds = Request.QueryString["AttachmentId"].Split(',');
                        arrAttachments = new string[AttachmentIds.Length];

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

                                // if attachment is pased
                                //lblMsg.Text += intAttachmentId.ToString();
                                COI_Attachment objAttach = new COI_Attachment(intAttachmentId);
                                lblAttachment.Text += " " + objAttach.Attachment_Name.Substring(12) + ",";
                                this.Page.Title = " Email Attachment ";
                                string strAttachment = clsGeneral.GetAttachmentDocPath(objAttach.Attachment_Table) + objAttach.Attachment_Name;
                                arrAttachments[i] = strAttachment;

                            }
                        }
                        lblAttachment.Text = lblAttachment.Text.TrimEnd(',');


                        break;
                    default:
                        //lblMsg.Text = "No Email Type Found";
                        break;
                }
            }

            if (arrAttachments.Length > 0)
            {
                decimal FileSize = clsGeneral.GetMailAttachmentSize(arrAttachments);
                if (FileSize > 9.5M)
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('The e-mailing of the selected attachments exceeds 10 megabytes, which does not conform to Sonic Corporate e-mail policy. Please reduce the attachment size or number of attachments before trying to send e-mail through eRIMS2.');window.close();", true);
            
            }
        }
    }

    #endregion

    protected void btnSend_Click(object sender, EventArgs e)
    {
        //string[] AttachmentIds = Request.QueryString["AttachmentId"].Split(',');
        //string[] arrAttachments=new string[AttachmentIds.Length ];
        //for (int i = 0; i < AttachmentIds.Length ; i++)
        //{
        //    int intAttachmentId = clsGeneral.GetInt(AttachmentIds[i]);
        //    COI_Attachment objAttachment = new COI_Attachment(intAttachmentId);
        //    string strAttachment = clsGeneral.GetAttachmentDocPath(objAttachment.Attachment_Table) + objAttachment.Attachment_Name;
        //    arrAttachments[i] = strAttachment;
        //}
        clsGeneral.SendMailMessage(AppConfig.MailFrom,txtTo.Text,"","",txtSubject.Text,txtBody.Text,true,arrAttachments);
        ClosePage();
    }

    private void ClosePage()
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), "keyclosewindow", "alert('Mail Sent Successfully');window.close();", true);
    }

}
