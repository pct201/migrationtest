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
            DataTable dt = Tatva_Report.SelectByReportType("EXP").Tables[0];
            gvReports.DataSource = dt;
            gvReports.DataBind();
        }
    }

    #region Click Events

    protected void btnSchedule_Click(object sender, EventArgs e)
    {
        Int32 Report_ID = Convert.ToInt32((sender as Button).CommandArgument);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "javascript:openWindowSchedule(" + Report_ID + ");", true);
    } 

    #endregion

    # region Grid Events
    protected void gvReportList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlAnchor rptLink = (HtmlAnchor)e.Row.FindControl("rptLink");
            Button btnSchedule = (Button)e.Row.FindControl("btnSchedule");
            Int32 Report_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblPrimaryID")).Text);
            if (Report_ID == 37)
                rptLink.HRef = "rptPropertyStatementofValues.aspx";
            if (Report_ID == 42)
                rptLink.HRef = "rptNewExposures.aspx";
            if (Report_ID == 43)
                rptLink.HRef = "rptFacilityInspectionReport.aspx";
            if (Report_ID == 56)
                rptLink.HRef = "rptInspectionsByInspector.aspx";
            if (Report_ID == 58)
                rptLink.HRef = "rptRM_Dealership_Facility_Specs.aspx";
            if (Report_ID == 59)
                rptLink.HRef = "rptInspectionLagTime.aspx";
            if (Report_ID == 61)
            {
                rptLink.HRef = "rpt_d_b_a_MainReport.aspx";
                btnSchedule.Visible = false;
            }
            if (Report_ID == 71)
            {
                rptLink.HRef = "rptACI_Key_Contact_Report.aspx";
            }
            if (Report_ID == 73)
            {
                rptLink.HRef = "rptRepairAndMaintanance.aspx";
                btnSchedule.Visible = false;
            }
        }
    }
    #endregion
}
