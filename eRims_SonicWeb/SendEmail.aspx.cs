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

public partial class Admin_SendEmail : System.Web.UI.Page
{

    private int EmailType
    {
        get { return clsGeneral.GetInt(ViewState["Type"]); }
        set { ViewState["Type"] = value; }
    }


    # region " Page EVents "

    protected void Page_Load(object sender, EventArgs e)
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
                    int intAttachmentId = clsGeneral.GetInt(Request.QueryString["AttachmentId"]);
                    if (intAttachmentId == 0)
                    {
                        // if attachment id is not passed.
                        lblMsg.Text = "Attachment Not Found";
                    }
                    else
                    {
                        
                        // if attachment is pased
                        ERIMSAttachment objAttach = new ERIMSAttachment(Convert.ToDecimal(intAttachmentId));
                        lblAttachment.Text = objAttach.Attachment_Name; 
                        this.Page.Title = " Email Attachment - " + objAttach.Attachment_Name;

                    }
                    break;
                default:
                    lblMsg.Text = "No Email Type Found";
                    break;
            }
        }        
    }

    #endregion

    protected void btnSend_Click(object sender, EventArgs e)
    {
        int intAttachmentId = clsGeneral.GetInt(Request.QueryString["AttachmentId"]);
        ERIMSAttachment objAttachment = new ERIMSAttachment(Convert.ToDecimal(intAttachmentId));
        string strAttachment = clsGeneral.GetAttachmentDocPath(objAttachment.Attachment_Table) + objAttachment.Foreign_Key.ToString() + "\\" + objAttachment.Attachment_Name;
        string[] arrAttachments = new string[] { strAttachment };
        clsGeneral.SendMailMessage(AppConfig.FromAddress,txtTo.Text,"","",txtSubject.Text,txtBody.Text,true,arrAttachments);
        ClosePage();
    }

    private void ClosePage()
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), "keyclosewindow", "window.close();", true);
    }

}
