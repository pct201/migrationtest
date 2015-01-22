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


public partial class SONIC_ClaimInfo_rptFinancialSummary : clsBasePage
{
    #region "Variables"

    DataTable dtYears, dtDetails, dtRegionTotal, dtGrandTotal; // datatables will be used for filtering records
    string STR_ACCIEDENT_YEAR, STR_REGION;

    #endregion

    #region "Methods"
    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    #endregion

    #region "Page Events"
    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if(!IsPostBack)
        {
            // get available years for claims from DB and bind Accident year list box
            DataTable dtYears = clsClaimReports.GetClaimReportYears().Tables[0];            
            lstAccidentYear.DataSource = dtYears;
            lstAccidentYear.DataTextField = "AccidentYear";
            lstAccidentYear.DataValueField = "AccidentYear";
            lstAccidentYear.DataBind();

            // get regions for user having access to and bind the regions list box
            DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegions;
            lstRegions.DataTextField = "region";
            lstRegions.DataValueField = "region";
            lstRegions.DataBind();

            //Bind Market Dropdown
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
            
        }

    }
    #endregion

    #region "Controls Events"

    /// <summary>
    /// Handles Show report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        string strYear = "";
        string strClaimType = "";
        string strRegion = "";
        string strMarket = string.Empty;
        DateTime dtValuation = txtValuationDate.Text != "" ? Convert.ToDateTime(txtValuationDate.Text) : DateTime.Now;

        // get selected years
        foreach (ListItem itmYear in lstAccidentYear.Items)
        {
            if (itmYear.Selected)
                strYear = strYear + itmYear.Value + ",";
        }
        strYear = strYear.TrimEnd(',');

        // get selected claim types
        foreach (ListItem itmClaimType in lstClaimType.Items)
        {
            if (itmClaimType.Selected)
                strClaimType = strClaimType + itmClaimType.Value + ",";
        }
        strClaimType = strClaimType.TrimEnd(',');

        // get selected regions
        foreach (ListItem itmRegion in lstRegions.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + "'" + itmRegion.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        // get selected Markets
        foreach (ListItem itmMarket in lstMarket.Items)
        {
            if (itmMarket.Selected)
                strMarket = strMarket +  itmMarket.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        // get data for financial summary report for selected values
        DataSet dsReport = clsClaimReports.GetFinancialSummaryData(strYear, strClaimType, strRegion, strMarket, dtValuation);

        // get datatbles from dataset
        dtYears = dsReport.Tables[0];
        dtDetails = dsReport.Tables[1];
        dtRegionTotal = dsReport.Tables[2];
        dtGrandTotal = dsReport.Tables[3];

        // bind the main grid
        gvReportOuter.DataSource = dtYears;
        gvReportOuter.DataBind();

        // show grid and export link according to data
        dvGrid.Style["display"] = "block";
        lnkExportToExcel.Visible = dtYears.Rows.Count > 0;
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again 
        Response.Redirect("rptFinancialSummary.aspx", false);
    }

    /// <summary>
    /// handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        // set borders for tables and gridlines in grids to be displayed in excel file
        gvReportOuter.GridLines = GridLines.Both;
        ((HtmlTable)gvReportOuter.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReportOuter.FooterRow.FindControl("tblFooter")).Border = 1;
        foreach (GridViewRow gRow in gvReportOuter.Rows)
        {
            GridView gvRegion = (GridView)gRow.FindControl("gvRegion");
            gvRegion.GridLines = GridLines.Both;
            foreach (GridViewRow row in gvRegion.Rows)
            {
                GridView gvDetail = (GridView)row.FindControl("gvDetail");
                gvDetail.GridLines = GridLines.Both;
            }
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("FinancialSummary.xls", gvReportOuter);

        // reset the settings
        gvReportOuter.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvReportOuter.Rows)
        {
            GridView gvRegion = (GridView)gRow.FindControl("gvRegion");
            gvRegion.GridLines = GridLines.None;
            foreach (GridViewRow row in gvRegion.Rows)
            {
                GridView gvDetail = (GridView)row.FindControl("gvDetail");
                gvDetail.GridLines = GridLines.None;
            }
        }
        ((HtmlTable)gvReportOuter.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvReportOuter.FooterRow.FindControl("tblFooter")).Border = 0;
    }
    #endregion

    #region "Gridview Events"

    /// <summary>
    /// Handles Rowdatabound event for gvReportOuter gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReportOuter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get all regions for an Accident year into a default view
            DataView dvRegions = dtRegionTotal.DefaultView;            
            STR_ACCIEDENT_YEAR = DataBinder.Eval(e.Row.DataItem, "AccidentYear").ToString();
            dvRegions.RowFilter = "AccidentYear=" + STR_ACCIEDENT_YEAR;

            // get datatable for the default view
            DataTable dtRegions = dvRegions.ToTable();

            // get the subgrid and bind it using datatable
            GridView gvRegions = (GridView)e.Row.FindControl("gvRegion");                        
            gvRegions.DataSource = dtRegions;
            gvRegions.DataBind();        
        }
        else if (e.Row.RowType == DataControlRowType.Footer) // if row type is footer
        {
            // check if grand total row count is greater than 0
            if (dtGrandTotal.Rows.Count > 0)
            {
                // get the data row from datatable
                DataRow drTotal = dtGrandTotal.Rows[0];

                // get label controls for totals
                Label lblIncurred = (Label)e.Row.FindControl("lblIncurred");
                Label lblPaid = (Label)e.Row.FindControl("lblPaid");
                Label lblOutstanding = (Label)e.Row.FindControl("lblOutstanding");
                Label lblNoOfClaim = (Label)e.Row.FindControl("lblNoOfClaim");
                Label lblPercent = (Label)e.Row.FindControl("lblPercent");

                // set values in labels from data row
                lblIncurred.Text = string.Format("{0:C2}", drTotal["Total_Incurred"]);
                lblPaid.Text = string.Format("{0:C2}", drTotal["Total_Paid"]);
                lblOutstanding.Text = string.Format("{0:C2}", drTotal["Total_OutStanding"]);
                lblNoOfClaim.Text = drTotal["Total_Claims"].ToString();
                lblPercent.Text = string.Format("{0:N2}", drTotal["Total_Percent"]);
            }
        }
    }

    /// <summary>
    /// Handles events for Regions grid data rows
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the claim details data for the region and accident year in a datatable
            DataView dvDetail = dtDetails.DefaultView;
            STR_REGION = DataBinder.Eval(e.Row.DataItem, "Region").ToString();
            dvDetail.RowFilter = "AccidentYear=" + STR_ACCIEDENT_YEAR + " and Region='" + STR_REGION + "'";
            DataTable dtDetail = dvDetail.ToTable();

            // get the sub grid for details from the datatable
            GridView gvDetail = (GridView)e.Row.FindControl("gvDetail");            
            gvDetail.DataSource = dtDetail;
            gvDetail.DataBind();
        }       
    }

    /// <summary>
    /// Handles event for gvDetails Rows
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is footer
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // get total for specific region and accident year from datatable for region totals 
            DataRow[] dr = dtRegionTotal.Select("AccidentYear=" + STR_ACCIEDENT_YEAR +" and Region='" + STR_REGION + "'");
            if (dr.Length > 0)
            {
                DataRow drTotal = dr[0];
                // get label controls for totals
                Label lblSubTotal = (Label)e.Row.FindControl("lblSubTotal");
                Label lblIncurred = (Label)e.Row.FindControl("lblIncurred");
                Label lblPaid = (Label)e.Row.FindControl("lblPaid");
                Label lblOutstanding = (Label)e.Row.FindControl("lblOutstanding");
                Label lblNoOfClaim = (Label)e.Row.FindControl("lblNoOfClaim");
                Label lblPercent = (Label)e.Row.FindControl("lblPercent");

                // set values in labels 
                lblIncurred.Text = string.Format("{0:C2}", drTotal["Total_Incurred"]);
                lblPaid.Text = string.Format("{0:C2}", drTotal["Total_Paid"]);
                lblOutstanding.Text = string.Format("{0:C2}", drTotal["Total_OutStanding"]);
                lblNoOfClaim.Text = drTotal["Total_Claims"].ToString();
                lblPercent.Text = string.Format("{0:N2}", drTotal["Total_Percent"]);
            }
        }
    }
    #endregion
}
