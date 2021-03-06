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
            DataTable dt = Tatva_Report.SelectByReportType("Claim", clsSession.IsACIUser).Tables[0];
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
            if (Report_ID == 1)
                rptLink.HRef = "rptFinancialSummary.aspx";
            else if (Report_ID == 2)
                rptLink.HRef = "rptFinancialPayTypeSummary.aspx";
            else if (Report_ID == 3)
                rptLink.HRef = "rptEmployerLagSummary.aspx";
            else if (Report_ID == 4)
                rptLink.HRef = "rptInsurerLagSummary.aspx";
            else if (Report_ID == 5)
                rptLink.HRef = "rptCompletionLagSummary.aspx";
            else if (Report_ID == 6)
                rptLink.HRef = "rptFrequencyAnalysis.aspx";
            else if (Report_ID == 7)
                rptLink.HRef = "rptCauseAnalysis.aspx";
            else if (Report_ID == 8)
                rptLink.HRef = "rptLossLimitation.aspx";
            else if (Report_ID == 9)
                rptLink.HRef = "rptLossStratification.aspx";
            else if (Report_ID == 10)
                rptLink.HRef = "rptPointInTimeDetail.aspx";
            else if (Report_ID == 11)
                rptLink.HRef = "rptTPALagSummary.aspx";
            else if (Report_ID == 12)
                rptLink.HRef = "rptPointInTimeSummary.aspx";
            else if (Report_ID == 13)
                rptLink.HRef = "rptThreePITSummary.aspx";
            else if (Report_ID == 57)
                rptLink.HRef = "rptRiskManagementWorksheet.aspx";
            else if (Report_ID == 62)
                rptLink.HRef = "rptFROIRecap.aspx";
        }
    }
    #endregion
}
