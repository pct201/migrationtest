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

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserName"] != null)
            {
                if (Request.QueryString["IsLogin"] != null)
                {
                    if (Request.QueryString["IsLogin"].ToString() == "yes")
                    {
                        DataSet dsReportID = First_Report_Wizard.SelectWizardWithUncompleteReport(Convert.ToDecimal(clsSession.CurrentLoginEmployeeId));
                        if (dsReportID.Tables[0].Rows.Count > 0)
                        {
                            //ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:OpenWizardPopup();", true);
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:OpenWizardPopup();", true);
                        }
                        else
                            Response.Redirect(AppConfig.SiteURL + "DashBoard/DashboardGraph.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("../Logoff.aspx");
            }

        }
    }
    protected void btnHdnSearchPage_Click(object sender, EventArgs e)
    {
        //Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/FirstReportSearch.aspx");
        Response.Redirect(AppConfig.SiteURL + "DashBoard/DashboardGraph.aspx");
    }
    protected void btnHdnStatusPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/FirstReportStatus.aspx");
    }
}
