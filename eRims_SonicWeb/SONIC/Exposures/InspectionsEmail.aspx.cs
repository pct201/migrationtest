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
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using Aspose.Words;
using Aspose.Words.Drawing;
using System.Windows.Forms;
public partial class SONIC_Exposures_InspectionsEmail : System.Web.UI.Page
{
    
    ArrayList strAttachmentPath = new ArrayList();
    private int Pk_Inspection
    {
        get { return Convert.ToInt32(ViewState["Pk_Inspection"]); }
        set { ViewState["Pk_Inspection"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PK_Inspection"] != null)
                Pk_Inspection = Convert.ToInt32(Request.QueryString["PK_Inspection"]);
            decimal FK_LU_Location_ID=0;
            if (Pk_Inspection > 0)
            {
                Inspection objInspection = new Inspection(Pk_Inspection);
                if (objInspection.FK_LU_Location_ID != null) FK_LU_Location_ID = Convert.ToDecimal(objInspection.FK_LU_Location_ID);
            }
            //Display Recipient List 
            DataTable dtEmails = Inspection.SelectEmailIDs(FK_LU_Location_ID).Tables[0];
            drpRecipientList.DataSource = dtEmails;
            drpRecipientList.DataTextField = "Name";
            drpRecipientList.DataValueField = "Email";
            drpRecipientList.DataBind();
        }
        else
        {
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            // if postback by Confirmation dialog then save record
            if (eventTarget == "UserConfirmationPostBack")
            {
                if (eventArgument == "true")
                    MailForSend();
                ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('the Inspection Report e-mail send without the attachments.');parent.parent.GB_hide();", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The Inspection Report has NOT been sent, please reduce the number and/or size of the photographs before e-mailing.');parent.parent.GB_hide();", true);
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        //decimal FileSize = GetAttachmentSize(Pk_Inspection, ref strAttachmentPath);
        //if (FileSize > 13.00M)
        //{
        //    String confirmMessage = "The photographs on this Inspection Report exceed the size limitations for e-mail. The Inspection Report can be sent without the photographs or you can Cancel and remove or reduce the size of the exiting photographs. Do you want to send the Inspection Report without the photographs?";
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBack', 'true');} else { alert('The Inspection Report has NOT been sent, please reduce the number and/or size of the photographs before e-mailing.');parent.parent.GB_hide();}", true);
        //    return;
        //}
        Inspection objinspection = new Inspection(Pk_Inspection);
        if (objinspection.Date_Report_Initially_Distibuted == null)
        {
            objinspection.Date_Report_Initially_Distibuted = DateTime.Today;
            objinspection.Update();
        }
        MailForSend();
    }
    private void MailForSend()
    {       
        
        String strMailFrom = new Security(Convert.ToDecimal(clsSession.UserID)).Email;
        string strFilePath = Encryption.Decrypt(Request.QueryString["fpath"]);
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(strMailFrom);
        mail.Subject = txtSubject.Text.Trim();
        if(File.Exists(strFilePath))
            mail.Attachments.Add(new Attachment(strFilePath));

        SmtpClient mSmtpClient = new SmtpClient(AppConfig.SMTPServer, Convert.ToInt32(AppConfig.Port));
        mSmtpClient.Credentials = new NetworkCredential(AppConfig.MailFrom, AppConfig.SMTPpwd);

        DataTable dtRecipients = new DataTable();
        DataColumn dcRec = new DataColumn("Email", typeof(string));
        dtRecipients.Columns.Add(dcRec);

        foreach (ListItem li in drpRecipientList.Items)
            if (li.Selected)
                dtRecipients.Rows.Add(dtRecipients.NewRow()[0] = li.Value);

        if (txtAdditionalAddresses.Text.Trim() != "")
        {
            string[] strEmails = txtAdditionalAddresses.Text.Trim().Split(',');
            foreach (string strEmail in strEmails)
            {
                if (strEmail != string.Empty)
                {
                    dtRecipients.Rows.Add(dtRecipients.NewRow()[0] = strEmail);
                }
            }
        }

        try
        {
            for (int i = 0; i < dtRecipients.Rows.Count; i++)
            {
                mail.Body = txtText.Text.Trim();
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(dtRecipients.Rows[i]["Email"].ToString()));
                mSmtpClient.Send(mail);
                mail.To.Clear();                
            }
            //ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "alert('Mail sent successfully!');parent.parent.GB_hide();", true);
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:SetDate();", true);
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "alert('Failure sending mail!');parent.parent.GB_hide();", true);
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:SetDate();", true);
        }
        finally
        {
            mail.Dispose();
            mail = null;
            mSmtpClient = null;
        }

        if (File.Exists(strFilePath))
            File.Delete(strFilePath);
    }

     

}
