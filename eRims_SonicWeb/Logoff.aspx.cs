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

public partial class Logoff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strLogID = string.Empty;
        if (Request.QueryString["LogID"] != null)
            strLogID = Convert.ToString(Request.QueryString["LogID"]);
        decimal LogAuditID = 0;

        if (!string.IsNullOrEmpty(strLogID))
        {
            LogAuditID = Convert.ToDecimal(strLogID);
        }
        else
        {
            if (Session["LoginAuditID"] != null)
            {
                LogAuditID = Convert.ToDecimal(Session["LoginAuditID"]);
                Session.Clear();
                Session.Abandon();
            }
        }
        Login_Logout objLogin_Logout = new Login_Logout(LogAuditID);
        objLogin_Logout.Logout_Date = DateTime.Now;
        objLogin_Logout.UpdateLogout();

        //Session.Clear();
        //Session.Abandon();
        Response.Redirect("Signin.aspx");
    }
}
