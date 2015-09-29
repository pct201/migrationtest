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

/// </summary>
public partial class SONIC_EmailAttachment : System.Web.UI.Page
{
    //string strBody = "This e-mail communication is to request your decision to approve/not approve the settlement on the eRIMS2 Management {Origin_Claim_Number}. Please login to eRIMS2, search for Management {Origin_Claim_Number}, click on the Risk Management Worksheet link on the left side of the screen, scroll down to the Settlement Approvals band and provide your decision and enter the date of approval in the appropriate approval area. Thank you!";
    string strBody = "This e-mail communication is to request your decision to approve/not approve the settlement on the eRIMS2 ACI Management. Please login to eRIMS2 (Your Sonic Shared Drive – My Business APPS – eRIMS2 – enter your User ID and Password, search for ACI and then ACI Management , click on the Approvals link on the left side of the screen, scroll down &lt;click&gt; \"Edit\" to the Approvals band and provide your decision and enter the date of approval in the appropriate approval area. Thank you!";

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
            lblEmailFrom.Text = AppConfig.ManagementEmailID;
            ComboHelper.FillListBoxforAllEmilIDfromSecurity(new ListBox[] { lstEmailTo }, false);

            //string strManagement_Numberr = "";
            //DataSet dsManagement = null;
            //if (Request.QueryString[1] != null && Request.QueryString[1].ToString().ToLower() == "management")
            //{
            //    dsManagement = WC_ClaimInfo.SelectByPK(Request.QueryString[0] != null ? Convert.ToInt32(Request.QueryString[0]) : 0);
            //}

            //DataTable dtManagement = dsManagement.Tables[0];
            //if (dtManagement.Rows.Count > 0)
            //{
            //    DataRow drManagement = dtManagement.Rows[0];
            //    strManagement_Numberr = Convert.ToString(drManagement["Management_Number"]);
            //}
            decimal PK_Management = clsGeneral.GetDecimal(Request.QueryString["ManagementId"]);
            clsManagement management = new clsManagement((decimal)PK_Management);
            string strReference_Number = management.Reference_Number;
            string dba = management.FK_LU_Location.HasValue ? new LU_Location(management.FK_LU_Location.Value).dba : "";
            txtBody.Text = "Store Location Name : " + dba + " \nLocater Number : " + Convert.ToString(strReference_Number) + " \n \n" + strBody.Replace("{Origin_Claim_Number}", string.Empty);//strManagement_Numberr.ToString().Trim()
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
        objEmail.SendMailMessage(AppConfig.ManagementEmailID, " ", strEmailIds, " Email Notification for ACI Change Request for your Approval.", txtBody.Text.Replace("\n", "<br/>"), true, strAttachment, AppConfig.MailCC);      
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
