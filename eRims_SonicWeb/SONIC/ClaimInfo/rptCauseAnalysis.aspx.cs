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
public partial class SONIC_ClaimInfo_rptCauseAnalysis : clsBasePage
{
    #region "Variables"

    // variables used for report 
    string STR_REGION;
    DataTable dtDetails, dtRegionTotal, dtGrandTotal;

    #endregion

    #region " Methods "

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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region "Control Events"

    /// <summary>
    /// Handles Show Report button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        DateTime dtFrom = Convert.ToDateTime(txtAccidentFromDate.Text);
        DateTime dtTo = Convert.ToDateTime(txtAccidentToDate.Text);
 
        // get report data into a dataset
        DataSet dsReport = clsClaimReports.GetWCCauseAnalysisData(dtFrom, dtTo);

        // get data tables from the dataset
        dtDetails = dsReport.Tables[0];
        dtRegionTotal = dsReport.Tables[1];
        dtGrandTotal = dsReport.Tables[2];

        // Bind the main grid which lists regions
        gvRegions.DataSource = dtRegionTotal;
        gvRegions.DataBind();

        // show grid and export link
        pnlReport.Visible = true;
        lnkExportToExcel.Visible = dtRegionTotal.Rows.Count > 0;

    }

    /// <summary>
    /// Handles Clear Criteria button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        Response.Redirect("rptCauseAnalysis.aspx", false);
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        // set borders for tables and gridlines in grids to be displayed in excel file
        ((HtmlTable)gvRegions.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvRegions.FooterRow.FindControl("tblFooter")).Border = 1;
        gvRegions.GridLines = GridLines.Both;
        foreach (GridViewRow gvRow in gvRegions.Rows)
        {
            GridView gv = (GridView)gvRow.FindControl("gvDetails");
            gv.GridLines = GridLines.Both;
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("WCCauseAnalysisReport.xls", gvRegions);

        // reset the settings
        foreach (GridViewRow gvRow in gvRegions.Rows)
        {
            GridView gv = (GridView)gvRow.FindControl("gvDetails");
            gv.GridLines = GridLines.None;

        }
        gvRegions.GridLines = GridLines.None;
        ((HtmlTable)gvRegions.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvRegions.FooterRow.FindControl("tblFooter")).Border = 0;
    }
    #endregion

    #region "Gridview Events"
    /// <summary>
    /// Handles RowDataBound event of gvRegions grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get details for the region from datatable for details into a default view             
            STR_REGION = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Region"));
            DataView dvDetails = dtDetails.DefaultView;
            dvDetails.RowFilter = "Region = '" + STR_REGION + "'";

            // get the subgrid for details and bind it using the default view
            GridView gvDetails = (GridView)e.Row.FindControl("gvDetails");
            gvDetails.DataSource = dvDetails.ToTable();
            gvDetails.DataBind();

        }
        else if (e.Row.RowType == DataControlRowType.Footer) // if row type is footer
        {
            // check if grand total rows greater than 0
            if (dtGrandTotal.Rows.Count > 0)
            {
                // get the data row for total
                DataRow drTotal = dtGrandTotal.Rows[0];

                // get the label controls for totals
                Label lblTotalClaimCount = (Label)e.Row.FindControl("lblTotalClaimCount");
                Label lblTotalIncurred = (Label)e.Row.FindControl("lblTotalIncurred");
                Label lblTotalAvgCost = (Label)e.Row.FindControl("lblTotalAvgCost");

                // set values in labels for totals from data row
                lblTotalClaimCount.Text = string.Format("{0:N0}", drTotal["Total_ClaimCount"]);
                lblTotalIncurred.Text = string.Format("{0:C2}", drTotal["Total_Incurred"]);
                lblTotalAvgCost.Text = string.Format("{0:C2}", drTotal["Total_AvgCostPerClaim"]);
            }
        }
    }

    /// <summary>
    /// Handles RowDataBound event for gvDetails grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is footer
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // get the row for total for the region
            DataRow[] dr = dtRegionTotal.Select("Region='" + STR_REGION + "'");
            if (dr.Length > 0)
            {
                DataRow drTotal = dr[0];

                // get the label controls for totals
                Label lblTotalClaimCount = (Label)e.Row.FindControl("lblTotalClaimCount");
                Label lblTotalIncurred = (Label)e.Row.FindControl("lblTotalIncurred");
                Label lblTotalAvgCost = (Label)e.Row.FindControl("lblTotalAvgCost");

                // set values in labels from data row
                lblTotalClaimCount.Text = string.Format("{0:N0}", drTotal["Total_ClaimCount"]);
                lblTotalIncurred.Text = string.Format("{0:C2}", drTotal["Total_Incurred"]);
                lblTotalAvgCost.Text = string.Format("{0:C2}", drTotal["Total_AvgCostPerClaim"]);
            }
        }
    }
    #endregion
}
