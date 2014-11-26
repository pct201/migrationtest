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
public partial class SONIC_ClaimInfo_rptDefault : clsBasePage
{
    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            //string strReportsXml = AppConfig.SitePath + "App_Data\\ClaimReports.xml"; // xml filepath having list of reports

            //// read the xml into dataset and bind the grid
            //DataSet ds = new DataSet();
            //ds.ReadXml(strReportsXml);
            //gvReports.DataSource = ds;
            //gvReports.DataBind();
            DataTable dt = Tatva_Report.SelectByReportType("Dashboard").Tables[0];
            gvReports.DataSource = dt;
            gvReports.DataBind();
        }
    }

    # region Grid Events
    protected void gvReportList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlAnchor rptLink = (HtmlAnchor)e.Row.FindControl("rptLink");
            Int32 Report_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblPrimaryID")).Text);
            if (Report_ID == 47)
                rptLink.HRef = "rptFacilityInspectionReport.aspx";
            else if (Report_ID == 48)
                rptLink.HRef = "rptIncidentInvestigation.aspx";
            else if (Report_ID == 49)
                rptLink.HRef = "rptIncidentReduction.aspx";
            else if (Report_ID == 50)
                rptLink.HRef = "rptWCClaimManagement.aspx";
            else if (Report_ID == 54)
                rptLink.HRef = "SafetyFirstAwardReport.aspx";         
        }
    }
    #endregion
}
