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
    public static string[] strAttachments;
   
    # region " Page EVents "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["AttachmentId"] != null)
            {

                string[] AttachmentIds = Request.QueryString["AttachmentId"].Split(',');

                strAttachments = new string[AttachmentIds.Length];
                string strAttachmentPath = clsGeneral.GetAttachmentDocPath(clsGeneral.Tables.Franchise.ToString());
                for (int i = 0; i < AttachmentIds.Length; i++)
                {
                    int intAttachmentId = clsGeneral.GetInt(AttachmentIds[i]);

                    if (intAttachmentId > 0)
                    {
                        Franchise_Attachments objAttach = new Franchise_Attachments(intAttachmentId);
                        lblAttachment.Text += " " + objAttach.FileName.Substring(12) + ",";
                        this.Page.Title = " Email Attachment ";
                        strAttachments[i] = strAttachmentPath + objAttach.FileName;
                    }
                }
                lblAttachment.Text = lblAttachment.Text.TrimEnd(',');
                if (strAttachments.Length > 0)
                {
                    decimal FileSize = clsGeneral.GetMailAttachmentSize(strAttachments);
                    if (FileSize > 9.5M)
                        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('The e-mailing of the selected attachments exceeds 10 megabytes, which does not conform to Sonic Corporate e-mail policy. Please reduce the attachment size or number of attachments before trying to send e-mail through eRIMS2.');window.close();", true);
                }
            }
            else
                ClosePage();
        }
                
    }

    #endregion

    protected void btnSend_Click(object sender, EventArgs e)
    {
        clsGeneral.SendMailMessage(AppConfig.MailFrom,txtTo.Text,"","",txtSubject.Text,txtBody.Text,true,strAttachments);
        ClosePage();
    }

    private void ClosePage()
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), "keyclosewindow", "alert('Mail Sent Successfully');window.close();", true);
    }

}
