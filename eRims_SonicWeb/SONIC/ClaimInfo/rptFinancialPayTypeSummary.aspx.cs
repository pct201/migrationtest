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

public partial class SONIC_ClaimInfo_rptFinancialPayTypeSummary : clsBasePage
{
    #region "Variables"

    DataTable dtYears, dtDetails, dtRegionTotal, dtGrandTotal; // datatables will be used for filtering records
    string STR_ACCIEDENT_YEAR, STR_CLAIM_TYPE, STR_REGION;

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
        }
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
        string strYear = "";        
        string strRegion = "";
        DateTime dtValuation = txtValuationDate.Text != "" ? Convert.ToDateTime(txtValuationDate.Text) : DateTime.Now;

        // get selected years
        foreach (ListItem itmYear in lstAccidentYear.Items)
        {
            if (itmYear.Selected)
                strYear = strYear + itmYear.Value + ",";
        }
        strYear = strYear.TrimEnd(',');

        // get selected regions
        foreach (ListItem itmRegion in lstRegions.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + itmRegion.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');

        // get data for financial pay type summary report for selected values
        DataSet dsReport = clsClaimReports.GetFinancialPayTypeSummaryData(strYear, strRegion, dtValuation);

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
        Response.Redirect("rptFinancialPayTypeSummary.aspx", false);
    }

    /// <summary>
    /// handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        ((HtmlTable)gvReportOuter.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReportOuter.FooterRow.FindControl("tblFooter")).Border = 1;
        // set borders for tables and gridlines in grids to be displayed in excel file
        gvReportOuter.GridLines = GridLines.Both;
        
        foreach (GridViewRow gRow in gvReportOuter.Rows)
        {
            GridView gvRegion = (GridView)gRow.FindControl("gvRegion");
            gvRegion.GridLines = GridLines.Both;
            foreach (GridViewRow row in gvRegion.Rows)
            {
                GridView gvDetail = (GridView)row.FindControl("gvDetail");
                gvDetail.GridLines = GridLines.Both;
                ((HtmlTable)gvDetail.FooterRow.FindControl("tblFooter")).Border = 1;
                foreach (GridViewRow dtlRow in gvDetail.Rows)
                {
                    ((HtmlTable)dtlRow.FindControl("tblDetails")).Border = 1;
                }
            }
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("FinancialPayTypeSummary.xls", gvReportOuter);

        // reset the settings
        ((HtmlTable)gvReportOuter.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvReportOuter.FooterRow.FindControl("tblFooter")).Border = 0;
        gvReportOuter.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvReportOuter.Rows)
        {
            GridView gvRegion = (GridView)gRow.FindControl("gvRegion");
            gvRegion.GridLines = GridLines.None;
            foreach (GridViewRow row in gvRegion.Rows)
            {
                GridView gvDetail = (GridView)row.FindControl("gvDetail");
                gvDetail.GridLines = GridLines.None;
                ((HtmlTable)gvDetail.FooterRow.FindControl("tblFooter")).Border = 0;
                foreach (GridViewRow dtlRow in gvDetail.Rows)
                {
                    ((HtmlTable)dtlRow.FindControl("tblDetails")).Border = 0;
                }
            }
        }
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
        // if row type is data row
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
                Label lblGrandTotalIncurredClaim = (Label)e.Row.FindControl("lblGrandTotalIncurredClaim");
                Label lblGrandTotalIncurredMedical = (Label)e.Row.FindControl("lblGrandTotalIncurredMedical");
                Label lblGrandTotalIncurredExpenses = (Label)e.Row.FindControl("lblGrandTotalIncurredExpenses");
                Label lblGrandTotalofIncurred = (Label)e.Row.FindControl("lblGrandTotalofIncurred");
                Label lblGrandClaimCount = (Label)e.Row.FindControl("lblGrandClaimCount");

                Label lblGrandTotalPaidClaim = (Label)e.Row.FindControl("lblGrandTotalPaidClaim");
                Label lblGrandTotalPaidMedical = (Label)e.Row.FindControl("lblGrandTotalPaidMedical");
                Label lblGrandTotalPaidExpenses = (Label)e.Row.FindControl("lblGrandTotalPaidExpenses");
                Label lblGrandTotalofPaid = (Label)e.Row.FindControl("lblGrandTotalofPaid");

                Label lblGrandTotalOutStandingClaim = (Label)e.Row.FindControl("lblGrandTotalOutStandingClaim");
                Label lblGrandTotalOutStandingMedical = (Label)e.Row.FindControl("lblGrandTotalOutStandingMedical");
                Label lblGrandTotalOutStandingExpenses = (Label)e.Row.FindControl("lblGrandTotalOutStandingExpenses");
                Label lblGrandTotalofOutStanding = (Label)e.Row.FindControl("lblGrandTotalofOutStanding");


                // set values in labels from data row
                lblGrandTotalIncurredClaim.Text = string.Format("{0:C2}", drTotal["Total_Indemnity_Incurred"]);
                lblGrandTotalIncurredMedical.Text = string.Format("{0:C2}", drTotal["Total_Medical_Incurred"]);
                lblGrandTotalIncurredExpenses.Text = string.Format("{0:C2}", drTotal["Total_Expense_Incurred"]);
                lblGrandTotalofIncurred.Text = string.Format("{0:C2}", drTotal["Total_Incurred"]);
                lblGrandClaimCount.Text = string.Format("{0:N0}", drTotal["Total_Claims"]);

                lblGrandTotalPaidClaim.Text = string.Format("{0:C2}", drTotal["Total_Indemnity_Paid"]);
                lblGrandTotalPaidMedical.Text = string.Format("{0:C2}", drTotal["Total_Medical_Paid"]);
                lblGrandTotalPaidExpenses.Text = string.Format("{0:C2}", drTotal["Total_Expense_Paid"]);
                lblGrandTotalofPaid.Text = string.Format("{0:C2}", drTotal["Total_Paid"]);

                lblGrandTotalOutStandingClaim.Text = string.Format("{0:C2}", drTotal["Total_Indemnity_OutStanding"]);
                lblGrandTotalOutStandingMedical.Text = string.Format("{0:C2}", drTotal["Total_Medical_OutStanding"]);
                lblGrandTotalOutStandingExpenses.Text = string.Format("{0:C2}", drTotal["Total_Expense_OutStanding"]);
                lblGrandTotalofOutStanding.Text = string.Format("{0:C2}", drTotal["Total_Outstanding"]);
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
            DataRow[] dr = dtRegionTotal.Select("AccidentYear=" + STR_ACCIEDENT_YEAR + " and Region='" + STR_REGION + "'");
            if (dr.Length > 0)
            {
                DataRow drTotal = dr[0];

                // get label controls for totals
                Label lblSubTotalIncurredClaim = (Label)e.Row.FindControl("lblSubTotalIncurredClaim");
                Label lblSubTotalIncurredMedical = (Label)e.Row.FindControl("lblSubTotalIncurredMedical");
                Label lblSubTotalIncurredExpenses = (Label)e.Row.FindControl("lblSubTotalIncurredExpenses");
                Label lblSubTotalofIncurred = (Label)e.Row.FindControl("lblSubTotalofIncurred");
                Label lblSubTotalClaimCount = (Label)e.Row.FindControl("lblSubTotalClaimCount");

                Label lblSubTotalPaidClaim = (Label)e.Row.FindControl("lblSubTotalPaidClaim");
                Label lblSubTotalPaidMedical = (Label)e.Row.FindControl("lblSubTotalPaidMedical");
                Label lblSubTotalPaidExpenses = (Label)e.Row.FindControl("lblSubTotalPaidExpenses");
                Label lblSubTotalofPaid = (Label)e.Row.FindControl("lblSubTotalofPaid");

                Label lblSubTotalOutStandingClaim = (Label)e.Row.FindControl("lblSubTotalOutStandingClaim");
                Label lblSubTotalOutStandingMedical = (Label)e.Row.FindControl("lblSubTotalOutStandingMedical");
                Label lblSubTotalOutStandingExpenses = (Label)e.Row.FindControl("lblSubTotalOutStandingExpenses");
                Label lblSubTotalofOutStanding = (Label)e.Row.FindControl("lblSubTotalofOutStanding");

                // set values in labels 
                lblSubTotalIncurredClaim.Text = string.Format("{0:C2}", drTotal["Total_Indemnity_Incurred"]);
                lblSubTotalIncurredMedical.Text = string.Format("{0:C2}", drTotal["Total_Medical_Incurred"]);
                lblSubTotalIncurredExpenses.Text = string.Format("{0:C2}", drTotal["Total_Expense_Incurred"]);
                lblSubTotalofIncurred.Text = string.Format("{0:C2}", drTotal["Total_Incurred"]);
                lblSubTotalClaimCount.Text = string.Format("{0:N0}", drTotal["Total_Claims"]);

                lblSubTotalPaidClaim.Text = string.Format("{0:C2}", drTotal["Total_Indemnity_Paid"]);
                lblSubTotalPaidMedical.Text = string.Format("{0:C2}", drTotal["Total_Medical_Paid"]);
                lblSubTotalPaidExpenses.Text = string.Format("{0:C2}", drTotal["Total_Expense_Paid"]);
                lblSubTotalofPaid.Text = string.Format("{0:C2}", drTotal["Total_Paid"]);

                lblSubTotalOutStandingClaim.Text = string.Format("{0:C2}", drTotal["Total_Indemnity_OutStanding"]);
                lblSubTotalOutStandingMedical.Text = string.Format("{0:C2}", drTotal["Total_Medical_OutStanding"]);
                lblSubTotalOutStandingExpenses.Text = string.Format("{0:C2}", drTotal["Total_Expense_OutStanding"]);
                lblSubTotalofOutStanding.Text = string.Format("{0:C2}", drTotal["Total_Outstanding"]);
                
            }
        }
    }
    #endregion
}
