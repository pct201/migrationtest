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

public partial class SONIC_FirstReport_RptDefault_WCAllocation : clsBasePage
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
            DataTable dt = Tatva_Report.SelectByReportType("WC", clsSession.IsACIUser).Tables[0];
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
            if (Report_ID == 19)
                rptLink.HRef = "WCAllocationDetailReport.aspx";
            else if (Report_ID == 20)
                rptLink.HRef = "WCAllocationSummaryReport.aspx";
            else if (Report_ID == 21)
                rptLink.HRef = "WCAllocationLocationReport.aspx";
            else if (Report_ID == 22)
                rptLink.HRef = "WCAllocationMonthlyDetailReport.aspx";
            else if (Report_ID == 23)
                rptLink.HRef = "WCMonthlyAllocationSummaryReport.aspx";
            else if (Report_ID == 36)
                rptLink.HRef = "RptAllocationYTDChargeReport.aspx";
            else if (Report_ID == 53)
                rptLink.HRef = "RptSonicCauseCodeReclassification.aspx";
        }
    }
    #endregion
}
