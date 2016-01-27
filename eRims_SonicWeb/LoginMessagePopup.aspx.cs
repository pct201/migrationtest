using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginMessagePopup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];

        switch (action)
        {
            case "FORGET USER ID":
                divForgetUserID.Visible = true;
                divForgetPassword.Visible = false;
                divAccessRequest.Visible = false;
                divForgetPasswordSuccess.Visible = false;
                break;
            case "FORGET PASSWORD":
                divForgetUserID.Visible = false;
                divForgetPassword.Visible = true;
                divAccessRequest.Visible = false;
                divForgetPasswordSuccess.Visible = false;
                break;
            case "ACCESS REQUEST":
                divForgetUserID.Visible = false;
                divForgetPassword.Visible = false;
                divAccessRequest.Visible = true;
                divForgetPasswordSuccess.Visible = false;
                break;
        }
    }

    protected void lnkResetPassword_Click(object sender, EventArgs e)
    {
        string userid = Request.QueryString["userid"];
        if (!AppConfig.AllowMailSending)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Password cannot be sent as mailing option is disabled');", true);
        }
        else
        {
            Security objSecurity = new Security(userid, true);

            if (objSecurity.PK_Security_ID > 0)
            {
                string strUserName = objSecurity.USER_NAME;
                string strPassword = Encryption.Decrypt(objSecurity.PASSWORD);
                string strEmail = objSecurity.Email;

                string strMailBody = "<table width='100%' cellpadding='3' cellspacing='1' border='0'>";
                strMailBody += "<tr>";
                strMailBody += "<td align='left'>User Id&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;" + strUserName + "</td>";
                strMailBody += "</tr>";
                strMailBody += "<tr>";
                strMailBody += "<td align='left'>Password&nbsp;:&nbsp;&nbsp;" + strPassword + "</td>";
                strMailBody += "</tr>";
                strMailBody += "<tr><td>&nbsp;</td></tr>";
                strMailBody += "<tr><td>If you did not request your password, or if you have received this e-mail in error, please contact your eRIMS2 system administrator immediately.</td></tr>";
                strMailBody += "</table>";
                
                clsGeneral.SendMailMessage(AppConfig.ClaimEmailID, strEmail, "", "", "eRIMS2 - Forgot Password?", strMailBody, true);
                //ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The password for <" + strUserName + "> was e-mailed to <" + strEmail + ">.');", true);
                divForgetPasswordSuccess.Visible = true;
                divForgetPassword.Visible = false;
                lblSuccess.Text = "The password for " + strUserName + " was e-mailed to " + strEmail + ".";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('To retrieve your password, please enter your valid user id in the login box, then click the Forgot Password? link.');", true);
            }
        }
    }
}