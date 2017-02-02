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
using System.IO;
using ERIMS.DAL;
using System.Text;

public partial class _Default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        header.Style.Add("background-image", "url('" + AppConfig.ImageURL + "//header2.jpg')");
        if (!IsPostBack)
        {
            hdnLoginAuditID.Value = Convert.ToString(Session["LoginAuditID"]);
            if (clsSession.IsACIUser)
                smdAdmin.SiteMapProvider = "AdminACI";
            else
                smdAdmin.SiteMapProvider = "Admin";
        }
        //header.Style.Add("background-image", Server.MapPath("~") + "/images/header.jpg");
        //Response.Write(Server.MapPath("~") + "/images/header.jpg");
    }

    public void HrefClick(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdnLoginAuditID.Value))
        {
            if (hdnLoginAuditID.Value != Convert.ToString(Session["LoginAuditID"]))
                Response.Redirect(AppConfig.SiteURL + "Logoff.aspx?LogID=" + hdnLoginAuditID.Value);
            else
                Response.Redirect(AppConfig.SiteURL + "Logoff.aspx");

        }
        else
            Response.Redirect(AppConfig.SiteURL + "Logoff.aspx");
    }

    protected void mnuMain_MenuItemClick(object sender, MenuEventArgs e)
    {
        
    }
    protected void mnuMain_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        //check if First Report is selcted or not
        //if (e.Item.Text == "First Reports")
        //{
        //    //DataSet dsReportID = First_Report_Wizard.SelectWizardWithUncompleteReport(Convert.ToDecimal(clsSession.CurrentLoginEmployeeId));
        //    //if (dsReportID.Tables[0].Rows.Count > 0)
        //    //{
        //        //e.Item.Text = @"<a class='FirstReport' id='" + e.Item.Text + "' onclick='javascript:OpenWizardPopup();' href='javascript:void(0);'>" + e.Item.Text + "</a>";
        //    //}
        //}
        if (e.Item.Text == "Immix Webportal")
        {
            e.Item.Target = "_blank";
        }
     
    }
    protected void btnHdnSearchPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/FirstReportSearch.aspx");
    }
    protected void btnHdnStatusPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/FirstReportStatus.aspx");
    }  
    
}
