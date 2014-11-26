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

public partial class ERReports_Default : clsBasePage
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
            DataTable dt = Tatva_Report.SelectByReportType("ER").Tables[0];
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
            if (Report_ID == 14)
                rptLink.HRef = "RptBordereau.aspx";
            else if (Report_ID == 15)
                rptLink.HRef = "RptNotif_Bordereau.aspx";
            else if (Report_ID == 16)
                rptLink.HRef = "RptLitigationSummary.aspx";
            else if (Report_ID == 17)
                rptLink.HRef = "RptReportableClaims.aspx";
            else if (Report_ID == 18)
                rptLink.HRef = "RptNetWorkCallSummary.aspx";
            else if (Report_ID == 60)
            {
                //System.Web.UI.HtmlControls.HtmlInputButton  btn = (System.Web.UI.HtmlControls.HtmlInputButton)e.Row.FindControl("btnSchedule");
                //if (btn != null)
                //    btn.Visible = false;
                rptLink.HRef = "rptExecutiveRiskData.aspx";

            }
                
        }
    }
    #endregion
}
