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
public partial class SONIC_ClaimInfo_rptTPALagSummary : clsBasePage
{
    #region "Variables"

    string STR_REGION;
    GridLines GridLineType = GridLines.None;
    DataTable dtRegions, dtDetails, dtRegionTotal, dtGrandTotal;

    #endregion
    private int intMedian
    {
        get { return Convert.ToInt32(ViewState["Median"]); }
        set { ViewState["Median"] = value; }
    }
    #region "Page Events"

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // get regions for user having access to and bind the regions list box
            DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegions;
            lstRegions.DataTextField = "region";
            lstRegions.DataValueField = "region";
            lstRegions.DataBind();

            //get Market
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        }
    }
    #endregion

    #region "Control Events"

    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string strRegion = "";

        // get selected regions
        foreach (ListItem itmRegion in lstRegions.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + itmRegion.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');

        string strMarket = "";

        // get selected Markets
        foreach (ListItem itmMarket in lstMarket.Items)
        {
            if (itmMarket.Selected)
                strMarket = strMarket + itmMarket.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        // get report data for selected values
        DataSet dsReport = clsClaimReports.GetTPALagSummaryData(Convert.ToDateTime(txtLossFromDate.Text), Convert.ToDateTime(txtLossToDate.Text), strRegion, strMarket);

        // get data tables from dataset
        dtRegions = dsReport.Tables[0];
        dtDetails = dsReport.Tables[1];
        dtRegionTotal = dsReport.Tables[2];
        dtGrandTotal = dsReport.Tables[3];
        intMedian = Convert.ToInt32(dsReport.Tables[4].Rows[0][0]);
        // bind the main grid which lists regions
        gvDescription.DataSource = dtRegions;
        gvDescription.DataBind();

        // show grid and export link 
        pnlReport.Visible = true;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        // set borders for tables and gridlines in grids to be displayed in excel file
        ((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvDescription.FooterRow.FindControl("tblFooter")).Border = 1;   
        gvDescription.GridLines = GridLines.Both;
        foreach (GridViewRow gvRow in gvDescription.Rows)
        {
            GridView gv = (GridView)gvRow.FindControl("gvLagSummaryReport");
            gv.GridLines = GridLines.Both;
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("TPALagSummaryReport.xlsx", gvDescription);

        // reset the settings
        foreach (GridViewRow gvRow in gvDescription.Rows)
        {
            GridView gv = (GridView)gvRow.FindControl("gvLagSummaryReport");
            gv.GridLines = GridLines.None;

        }
        gvDescription.GridLines = GridLines.None;
        ((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvDescription.FooterRow.FindControl("tblFooter")).Border = 0;   
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        Response.Redirect("rptTPALagSummary.aspx", false);
    }

    #endregion

    #region "Grid Row Events"

    /// <summary>
    /// Handles RowDataBound event for gvDescription grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDescription_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if type of row is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get data for the Region into a default view from details datatable
            DataView dvDetail = new DataView();
            DataTable dtLagSummaryReport = new DataTable();
            dvDetail = dtDetails.DefaultView;
            STR_REGION = Convert.ToString(((GridView)sender).DataKeys[e.Row.RowIndex].Values["Region"]);
            dvDetail.RowFilter = "Region='" + STR_REGION + "'";

            // get data table from default view
            dtLagSummaryReport = dvDetail.ToTable();

            // find the subgrid for the details and bind it using datatable
            GridView gvLagSummaryReport = e.Row.FindControl("gvLagSummaryReport") as GridView;
            gvLagSummaryReport.DataSource = dtLagSummaryReport;
            gvLagSummaryReport.DataBind();

        }
        else if (e.Row.RowType == DataControlRowType.Footer) // if row type is footer row
        {
            // if grand total row count is greater than 0
            if (dtGrandTotal.Rows.Count > 0)
            {
                // get the data row
                DataRow dr = dtGrandTotal.Rows[0];

                // find the labes for totals and set text from data row
                ((Label)e.Row.FindControl("lblTotalClaims")).Text = string.Format("{0:0}", dr["TotalClaims"]);
                ((Label)e.Row.FindControl("lblTotalClaimPercent")).Text = string.Format("{0:N2}", dr["TotalClaimPercent"]);
                ((Label)e.Row.FindControl("lblTotalIncurred")).Text = string.Format("{0:C}", dr["TotalIncurred"]);
                ((Label)e.Row.FindControl("lblToalIncurredPercent")).Text = string.Format("{0:N2}", dr["TotalIncurredPercent"]);

                ((Label)e.Row.FindControl("lblMedian")).Text = "<b>Median Lag Time in Days : " + intMedian + "</b>";
            }
        }
    }

    /// <summary>
    /// Handles RowDataBound event for gvLagSummary grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLagSummaryReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is footer row
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // select rows containing totals for the region
            DataRow[] dr = dtRegionTotal.Select("Region='" + STR_REGION + "'");
            if (dr.Length > 0)
            {                
                // get the label controls for total and set totals from data row
                ((Label)e.Row.FindControl("lblFooterClaimCount")).Text = string.Format("{0:0}", dr[0]["TotalClaims"]);
                ((Label)e.Row.FindControl("lblFooterClaimCountPercentage")).Text = string.Format("{0:N2}", dr[0]["TotalClaimPercent"]);
                ((Label)e.Row.FindControl("lblFooterIncurred")).Text = string.Format("{0:C}", dr[0]["TotalIncurred"]);
                ((Label)e.Row.FindControl("lblFooterIncurredPercentage")).Text = string.Format("{0:N2}", dr[0]["TotalIncurredPercent"]);
            }            
        }
    }
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

}
