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
using System.IO;
using System.Text;
/// <summary>
/// 
/// Date           : 6-Feb-09
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : This page is used send a attachments throught email 
/// </summary>
public partial class SONIC_EmailAttachment : System.Web.UI.Page
{
    string strBody = "This e-mail communication is to request your decision to approve/not approve the settlement on the eRIMS2 Worker’s Compensation Claim {Origin_Claim_Number}. Please login to eRIMS2, search for Worker’s Compensation Claim {Origin_Claim_Number}, click on the Risk Management Worksheet link on the left side of the screen, scroll down to the Settlement Approvals band and provide your decision and enter the date of approval in the appropriate approval area. Thank you!";

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Page Is POst Back or NOt
        if (!IsPostBack)
        {
            string strOrigin_Claim_Number = "";
            lblEmailFrom.Text = AppConfig.ClaimEmailID;
            ComboHelper.FillListBoxforAllEmilIDfromSecurity(new ListBox[] { lstEmailTo }, false);
            DataSet dsWorkers_Comp_Claims = null;
            if (Request.QueryString[1] != null && Request.QueryString[1].ToString().ToLower() == "wc")
            {
                dsWorkers_Comp_Claims = WC_ClaimInfo.SelectByPK(Request.QueryString[0] != null ? Convert.ToInt32(Request.QueryString[0]) : 0);
            }
            else if(Request.QueryString[1] != null && Request.QueryString[1].ToString().ToLower() == "al")
            {
                dsWorkers_Comp_Claims = AL_ClaimInfo.SelectByPK(Request.QueryString[0] != null ? Convert.ToInt32(Request.QueryString[0]) : 0);
            }
            else if (Request.QueryString[1] != null && Request.QueryString[1].ToString().ToLower() == "pl")
            {
                dsWorkers_Comp_Claims = PL_ClaimInfo.SelectByPK(Request.QueryString[0] != null ? Convert.ToInt32(Request.QueryString[0]) : 0);
            }
            DataTable dtWorkers_Comp_Claims = dsWorkers_Comp_Claims.Tables[0];
            if (dtWorkers_Comp_Claims.Rows.Count > 0)
            {
                DataRow drWorkers_Comp_Claims = dtWorkers_Comp_Claims.Rows[0];
                strOrigin_Claim_Number = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
            }
            txtBody.Text = strBody.Replace("{Origin_Claim_Number}", strOrigin_Claim_Number.ToString().Trim());
        }

    }
    /// <summary>
    /// Button Send Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string strToEmailIDs = string.Empty;
        foreach (ListItem ls in lstEmailTo.Items)
        {
            if (ls.Selected == true)
            {
                strToEmailIDs = strToEmailIDs + ls.Text + ",";
            }
        }
        string[] strEmailIds = strToEmailIDs.TrimEnd(Convert.ToChar(",")).Split(Convert.ToChar(","));
        string[] strAttachment = null;
        EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
        objEmail.SendMailMessage(AppConfig.ClaimEmailID, " ", strEmailIds, "Email Notification for Settlement Approvals.", txtBody.Text, true, strAttachment, AppConfig.MailCC);      
        StringBuilder sb = new StringBuilder();
        sb.Append("var obj=document.getElementById('lstEmailTo');");
        sb.Append("var strEmails = '';");
        sb.Append("for(i=0;i<obj.length; i++)");
        sb.Append("{");
        sb.Append("if(obj.options[i].selected == true)");
        sb.Append("strEmails = strEmails + obj.options[i].text + ', ';");
        sb.Append("}");
        sb.Append("parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnEmailList').value=strEmails;");
        sb.Append("parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnEmailDate').value='" + DateTime.Now.ToString("MM/dd/yyyy") + "';");
        sb.Append("strEmails = '';");
        sb.Append("parent.parent.GB_hide();");
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), sb.ToString(), true);
    }

}
