using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;
public partial class SONIC_Exposures_rptDefault : clsBasePage
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

            DataTable dt = Tatva_Report.SelectByReportType("CRM", clsSession.IsACIUser).Tables[0];
            
            //Insert Ad-Hoc Report Record
            DataRow dr = dt.NewRow();
            dr[0]=0;
            dr[1] = "Ad-Hoc Report Writer";            
            dr[3] = "CRM";
            dt.Rows.InsertAt(dr, 0);  

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
            if (Report_ID == 44)
                rptLink.HRef = "rptCustomerIncidentSummary.aspx";
            if (Report_ID == 45)
                rptLink.HRef = "rptNonCustomerInquiry.aspx";
            if (Report_ID == 46)
                rptLink.HRef = "rptCustomerIncidentTotals.aspx";
            if (Report_ID == 0)
                rptLink.HRef = "AdHocReportWriter.aspx";
        }
    }
    #endregion
}
