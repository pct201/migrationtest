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

public partial class Signin : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CSecurity m_objCSecurity;
    List<RIMS_Base.CSecurity> lstSecurity = null;
    DataSet m_dsUser;
    DataSet m_dsCommon;
    #endregion

    #region Event Handlers

    /// <summary>
    /// Handle page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //pnlPopup.Visible = false;
        if (!IsPostBack)
        {
            //Does not clear the session ID if the request is from the website itself
            if (Request.UrlReferrer != null)
            {
                if (Request.UrlReferrer.ToString().IndexOf(AppConfig.SiteURL) == -1)
                    Response.Cookies.Add(new System.Web.HttpCookie("ASP.NET_SessionId", ""));                
            }
            else
                Response.Cookies.Add(new System.Web.HttpCookie("ASP.NET_SessionId", ""));                
            txtUserId.Focus();
        }
    }

    /// <summary>
    /// Handle Login button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            // Validate User Name and Password
            int intUserID = Security.GetLoginID(txtUserId.Text.Trim(), Encryption.Encrypt(txtPwd.Text.Trim()));
            if (intUserID > 0)
            {
                Security objSecurity = new Security(intUserID);
                clsSession.UserID = objSecurity.PK_Security_ID.ToString();
                clsSession.UserName = objSecurity.USER_NAME;
                clsSession.UserAccess = objSecurity.USER_ROLE.ToString();
                clsSession.FirstName = objSecurity.FIRST_NAME.ToString();
                clsSession.LastName = objSecurity.LAST_NAME.ToString();
                clsSession.UserRole = objSecurity.USER_ROLE.ToString();
                clsSession.UserAllowToViewClaimInformation = objSecurity.Allow_ViewClaim;
                clsSession.IsUserRegionalOfficer = objSecurity.IsRegionalOfficer;
                clsSession.IsUserPurchsingAdmin = Security.IsUserPurchasingAdmin(objSecurity.PK_Security_ID);
                clsSession.IsACIUser = Security.IsACIUser(objSecurity.PK_Security_ID);
                
                DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(objSecurity.PK_Security_ID));

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
              

                if (dsRegion.Tables[0].Rows.Count > 0)
                {
                    clsSession.CurRegion = dsRegion.Tables[0].Rows[0]["Region"].ToString();
                }

                if (objSecurity.Employee_Id != null)
                {
                    clsSession.CurrentLoginEmployeeId = Convert.ToDecimal(objSecurity.Employee_Id);
                    clsSession.IsSONICEmployee = true;
                }
                else
                {
                    clsSession.CurrentLoginEmployeeId = 0;
                    clsSession.IsSONICEmployee = false;
                }
                DateTime OldPwdDate;
                OldPwdDate = Convert.ToDateTime(objSecurity.UPDATE_DATE.ToString());
                DateTime CompareDate = OldPwdDate.AddDays(60);
                DateTime dt1 = Convert.ToDateTime(CompareDate.ToShortDateString());
                DateTime dt2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                int ans = DateTime.Compare(dt1, dt2);
                if (ans == 0 || ans == -1)
                {
                    // if user had never update his profile since last 45 days than Popup open and ask for changing password
                    //enable popup script
                    //pnlPopup.Visible = true;
                    Response.Redirect(AppConfig.SiteURL + "ChangeExpiredPassword.aspx?UserName=" + Encryption.Encrypt(txtUserId.Text.Trim()) + "&id=1&UID=" + Encryption.Encrypt(clsSession.UserID) , false); 
                    //owin=window.open('Administrator/ChangePassword_Popup.aspx?UserName=' + document.getElementById('<%=txtUserId.ClientID %>').value + '&id=1&UID=<%=clsSession.UserID %>' ,'','location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=200');
                }
                else
                {
                    DateTime checkExpire = dt2.AddDays(7);
                    int ansExp = DateTime.Compare(dt1,checkExpire);
                    if (ansExp == 0 || ansExp == -1)
                    {
                        clsSession.ExpireDatelabel = "Your Current Password Expires on " + clsGeneral.FormatDateToDisplay(dt1); 
                    }
                    
                    objLogin_Logout.Session_Id = Session.SessionID;
                     if (!string.IsNullOrEmpty(clientIPAddress))
                        objLogin_Logout.IP_Address = clientIPAddress;
                        objLogin_Logout.Login_Date = DateTime.Now;
                        Session["LoginAuditID"] = objLogin_Logout.Insert();
                    if (Request.QueryString["ReturnUrl"] != null)
                        Response.Redirect(Request.QueryString["ReturnUrl"]);
                    else if (clsSession.IsACIUser)
                        Response.Redirect(AppConfig.SiteURL + "Default.aspx", false);
                    else
                        Response.Redirect(AppConfig.SiteURL + "DashBoard/DashboardGraph.aspx", false);                        
                        //pnlPopup.Visible = true;
                        //Response.Redirect(AppConfig.SiteURL + "DashBoard/DashBoard.aspx?IsLogin=yes", false);
                }

            }
            else
            {
                lblMessage.Text = "User Id And / Or Password is not correct";

            }
        }
    }

    /// <summary>
    /// Handle button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHdnSearchPage_Click(object sender, EventArgs e)
    {
        //Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReportSearch.aspx");
        btnLogin_Click(null, null);
    }

    /// <summary>
    /// Hanncle button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHdnStatusPage_Click(object sender, EventArgs e)
    {
        btnLogin_Click(null, null);
    }

    /// <summary>
    /// Handle Forgot Password link click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkForgotPassword_Click(object sender, EventArgs e)
    {
        if (!AppConfig.AllowMailSending)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Password cannot be sent as mailing option is disabled');", true);
        }
        else
        {
            Security objSecurity = new Security(txtUserId.Text.Trim(), true);

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

                ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The password for <" + strUserName + "> was e-mailed to <" + strEmail + ">.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('To retrieve your password, please enter your valid user id in the login box, then click the Forgot Password? link.');", true);
            }
        }
    }

    //Access Request
    protected void lnkAccessRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect(AppConfig.SiteURL + "Administrator/UserAccessRequestForm.aspx?Requester=1");     
    }


    #endregion

}
