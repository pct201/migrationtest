using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS_DAL;
public partial class _Default : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        header.Style.Add("background-image", "url('" + AppConfig.ImageURL + "//header2.jpg')");

        //lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
        if (!IsPostBack)
        {
            hdnLoginAuditID.Value = Convert.ToString(Session["LoginAuditID"]);
        }
        else
        {
            string eventArgs = Convert.ToString(Request.Params["__EVENTARGS"]);
            string eventTarget = Convert.ToString(Request.Params["__EVENTTARGET"]);
            if (eventTarget == "PerformLogOff")
            {
                // unlock all claim/incident records locked by user
                //if (!string.IsNullOrEmpty(clsSession.UserID))
                //    clsClaim_Edit.DeleteAllByUserID(Convert.ToDecimal(clsSession.UserID));
                Session.Clear();
                Session.Abandon();

                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:window.close();", true);
            }
        }

    }
    /// <summary>
    /// Redirects to the logoff page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void HrefClick(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdnLoginAuditID.Value))
        {
            if (hdnLoginAuditID.Value != Convert.ToString(Session["LoginAuditID"]))
                Response.Redirect(AppConfig.SiteURL + "Logoff.aspx?LogID=" + hdnLoginAuditID.Value + "&outlook=1");
            else
                Response.Redirect(AppConfig.SiteURL + "Logoff.aspx?outlook=1");

        }
        else
            Response.Redirect(AppConfig.SiteURL + "Logoff.aspx?outlook=1");
    }

}
