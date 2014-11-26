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
using System.Collections.Generic;
using ERIMS.DAL;

public partial class ChangeExpiredPassword : System.Web.UI.Page
{
    #region Public Variables
    /// <summary>
    /// Denotes the User Name
    /// </summary>
    public string User_Name
    {
        get
        {
            return Encryption.Decrypt(Request.QueryString[0].ToString());
        }
    }
    public Decimal UID
    {
        get
        {
            return Convert.ToDecimal(Encryption.Decrypt(Request.QueryString[2].ToString()));
        }
    }
    #endregion

    #region Main Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check Page Validation
        if (IsValid)
        {
            // check User_Name is available is or not
            if (User_Name != null && User_Name != String.Empty)
            {
                // check User Name and Password available
                int intUserID = Security.GetLoginID(User_Name, Encryption.Encrypt(txtCurrentPwd.Text.Trim()));
                if (intUserID > 0)
                {
                    Security objsecurity = new Security(UID);
                    decimal SecurityID = Convert.ToInt32(objsecurity.PK_Security_ID);
                    // Check Password Strength
                    if (clsGeneral.CheckPassword(txtNewPwd.Text) == false)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Password must have at least 7 characters, one character, one digit and one special character!')", true);
                        return;
                    }
                    //Update Password Details
                    Security.UpdatePassword(SecurityID, Encryption.Encrypt(txtNewPwd.Text.ToString()), DateTime.Now);

                    Login_Logout objLogin_Logout = new Login_Logout();
                    if (clsSession.UserID != null)
                        objLogin_Logout.PK_Security = Convert.ToDecimal(clsSession.UserID);

                    string clientIPAddress = string.Empty;
                    // Check if Application run on Localohst(localmachine) then We can not IP address of localhost. 
                    // So, Check it with Current Host Name (On machine wich applicaion run)
                    if (HttpContext.Current.Request.Url.Authority.CompareTo("localhost") == 0)
                    {
                        string strHostName = System.Net.Dns.GetHostName();
                        System.Net.IPAddress[] IPAddr = System.Net.Dns.GetHostAddresses(strHostName);

                        if (IPAddr.Length > 0)
                            clientIPAddress = IPAddr[IPAddr.Length - 1].ToString();
                    }
                    else
                    {
                        // To get the IP address of the machine and not the proxy use the following code 
                        clientIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                        // if proxy settings not available then Get user IP Address
                        if (string.IsNullOrEmpty(clientIPAddress))
                            clientIPAddress = Request.ServerVariables["REMOTE_ADDR"];
                    }

                    objLogin_Logout.Session_Id = Session.SessionID;
                    if (!string.IsNullOrEmpty(clientIPAddress))
                        objLogin_Logout.IP_Address = clientIPAddress;
                    objLogin_Logout.Login_Date = DateTime.Now;
                    Session["LoginAuditID"] = objLogin_Logout.Insert();
                    Response.Redirect(AppConfig.SiteURL + "DashBoard/DashboardGraph.aspx", false); 
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invalid current password.";

                }
            }
        }
    }
    #endregion
   
}