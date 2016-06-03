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

public partial class SONIC_ClaimInfo_rptLossStratification : clsBasePage
{
    #region "Variables"

    // data tables will be used for report
    DataTable dtClaimTotals, dtDetails, dtYearTotals;
    
    // variables used for filtering the records 
    string STR_ACCIDENT_YEAR, STR_CLAIM_TYPE;

    // used for calculating grand totals
    double _dblGrandClaimCount, _dblGrandIncurredCount;

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
        if (!IsPostBack)
        {
            // get claim years available in DB
            DataTable dtYears = clsClaimReports.GetClaimReportYears().Tables[0];
            lsbPolicyYear.DataSource = dtYears;
            lsbPolicyYear.DataTextField = "AccidentYear";
            lsbPolicyYear.DataValueField = "AccidentYear";
            lsbPolicyYear.DataBind();
        }
    }
    #endregion

    #region "Controls Events"
    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        // get filter criteria entered for report 
        string strYears = "";
        string strClaimTypes = "";
        foreach (ListItem itmYears in lsbPolicyYear.Items)
        {
            if (itmYears.Selected)
                strYears = strYears + itmYears.Value + ",";
        }
        strYears = strYears.TrimEnd(',');

        foreach (ListItem itmType in lsbClaimType.Items)
        {
            if (itmType.Selected)
                strClaimTypes = strClaimTypes + itmType.Value + ",";
        }
        strClaimTypes = strClaimTypes.TrimEnd(',');

        // search report data into a data set
        DataSet dsReport = clsClaimReports.GetLossStratificationData(strYears, strClaimTypes);

        // get data tables from dataset
        dtClaimTotals = dsReport.Tables[0];
        dtDetails = dsReport.Tables[1];
        dtYearTotals = dsReport.Tables[2];
        if (dtYearTotals.Rows.Count > 0)
        {
            _dblGrandClaimCount = Convert.ToDouble(dtYearTotals.Compute("SUM(ClaimCount)", ""));
            _dblGrandIncurredCount = Convert.ToDouble(dtYearTotals.Compute("SUM(TotalIncurred)", ""));
        }

        // bind grid which lists accident years
        gvReportYear.DataSource = dtYearTotals;
        gvReportYear.DataBind();

        // show report panel
        pnlReport.Visible = true;
        lbtExportToExcel.Visible = dtYearTotals.Rows.Count > 0;
    }

    /// <summary>
    /// Handles Clear Criteria button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // reload the page again to clear all selections
        Response.Redirect("rptLossStratification.aspx", false);
    }

    /// <summary>
    /// Handles Export To Excel link click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        // set grid lines and table borders in grid for export
        ((HtmlTable)gvReportYear.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReportYear.FooterRow.FindControl("tblFooter")).Border = 1;
        gvReportYear.GridLines = GridLines.Both;
        foreach (GridViewRow rowClaim in gvReportYear.Rows)
        {
            GridView gvClaimType = ((GridView)(rowClaim.FindControl("gvReportClaimType")));
            gvClaimType.GridLines = GridLines.Both;
            ((HtmlTable)gvClaimType.FooterRow.FindControl("tblFooter")).Border = 1;
            foreach (GridViewRow rowDtl in gvClaimType.Rows)
            {
                ((GridView)rowDtl.FindControl("gvReportDetail")).GridLines = GridLines.Both;
            }
        }
        
        // export grid data into excel sheet
        GridViewExportUtil.ExportGrid("LossStratificationReport.xlsx", gvReportYear, true);

        // reset the grid lines and borders
        ((HtmlTable)gvReportYear.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvReportYear.FooterRow.FindControl("tblFooter")).Border = 0;
        gvReportYear.GridLines = GridLines.None;        
        foreach (GridViewRow rowClaim in gvReportYear.Rows)
        {
            GridView gvClaimType = ((GridView)(rowClaim.FindControl("gvReportClaimType")));
            gvClaimType.GridLines = GridLines.None;
            ((HtmlTable)gvClaimType.FooterRow.FindControl("tblFooter")).Border = 0;
            foreach (GridViewRow rowDtl in gvClaimType.Rows)
            {
                ((GridView)rowDtl.FindControl("gvReportDetail")).GridLines = GridLines.None;
            }
        }
    }
    #endregion

    #region "Gridview Events"
    /// <summary>
    /// Handles RowDataBound event for Years grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReportYear_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is header row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get detail data for perticular accident year
            STR_ACCIDENT_YEAR = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AccidentYear"));
            DataView dvClaimTotal = dtClaimTotals.DefaultView;
            dvClaimTotal.RowFilter = "AccidentYear = '" + STR_ACCIDENT_YEAR + "'";            

            // bind the subgrid for details
            GridView gvReportClaimType = (GridView)e.Row.FindControl("gvReportClaimType");
            gvReportClaimType.DataSource = dvClaimTotal.ToTable(); 
            gvReportClaimType.DataBind();           
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            // display totals in labels from data row for totals
            ((Label)e.Row.FindControl("lblGrandTotalNoOFClaim")).Text = string.Format("{0:N0}", _dblGrandClaimCount);
            ((Label)e.Row.FindControl("lblGrandTotalIncurred")).Text = string.Format("{0:C2}", _dblGrandIncurredCount);
        }
    }

    /// <summary>
    /// Handles RowDataBound event for the Claim Details subgrid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReportClaimType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if the row is datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get data for specific claim type
            STR_CLAIM_TYPE = DataBinder.Eval(e.Row.DataItem, "Claim_Type").ToString();
            DataView dvDetails = dtDetails.DefaultView;
            dvDetails.RowFilter = "AccidentYear = '" + STR_ACCIDENT_YEAR + "' and Claim_Type = '" + STR_CLAIM_TYPE + "'";
            
            // bind the grid for details 
            GridView gvReportDetail = (GridView)e.Row.FindControl("gvReportDetail");
            gvReportDetail.DataSource = dvDetails.ToTable();
            gvReportDetail.DataBind();
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            // get the data for specific accident year
            DataRow[] dr = dtYearTotals.Select("AccidentYear = '" + STR_ACCIDENT_YEAR + "'");
            DataRow drTotal = dr[0];

            // set the totals in labels in footer
            ((Label)e.Row.FindControl("lblPolicy_Type")).Text = "Total Accident Year : " + STR_ACCIDENT_YEAR;
            ((Label)e.Row.FindControl("lblYearTotalClaim")).Text = string.Format("{0:N0}", drTotal["ClaimCount"]);
            ((Label)e.Row.FindControl("lblYearInCurred")).Text = string.Format("{0:C2}", drTotal["TotalIncurred"]);
            
            double _dblGrandClaimPercent = (_dblGrandClaimCount != 0) ? System.Math.Round(Convert.ToDouble(drTotal["ClaimCount"]) * 100 / _dblGrandClaimCount, 2) : 0.00;
            double _dblGrandIncurredPercent = (_dblGrandIncurredCount != 0) ? System.Math.Round(Convert.ToDouble(drTotal["TotalIncurred"]) * 100 / _dblGrandIncurredCount, 2) : 0.00;

            ((Label)e.Row.FindControl("lblYearClaimPercent")).Text = string.Format("{0:0.00}", _dblGrandClaimPercent);
            ((Label)e.Row.FindControl("lblYearIncurredPercent")).Text = string.Format("{0:0.00}", _dblGrandIncurredPercent);

        }
    }

    /// <summary>
    /// Handles RowDataBound for report details grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReportDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Check if End limit value is less than or equal to 0.00 then display message as "Less than 0.01"
            if (Convert.ToDecimal(((Label)e.Row.FindControl("lblEndLimit")).Text) <= 0.01m)
            {
                ((Label)e.Row.FindControl("lblStartLimit")).Text = "Less than 0.01";
                ((Label)e.Row.FindControl("lblEndLimit")).Text = "";
                ((Label)e.Row.FindControl("lblMsgTo")).Text = "";
            }
            // Check if Start limit value is greater than or equal to 500000.01 then display message as "greate than 500000.00"
            else if (Convert.ToDecimal(((Label)e.Row.FindControl("lblStartLimit")).Text) >= 500000.01m)
            {
                ((Label)e.Row.FindControl("lblStartLimit")).Text = "Greater than " + (string.Format("{0:0,0.00}", 500000.00m));
                ((Label)e.Row.FindControl("lblEndLimit")).Text = "";
                ((Label)e.Row.FindControl("lblMsgTo")).Text = "";
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer) // if row is footer row
        {
            // get the totals for specific accident year and claim type
            DataRow[] dr = dtClaimTotals.Select("AccidentYear = '" + STR_ACCIDENT_YEAR + "' and Claim_Type = '" + STR_CLAIM_TYPE + "'");
            DataRow drTotal = dr[0];
            ((Label)e.Row.FindControl("lblClaimFooter")).Text = "Total Claim Type : " + STR_CLAIM_TYPE;
            ((Label)e.Row.FindControl("lblClaim")).Text = string.Format("{0:N0}", drTotal["ClaimCount"]);
            ((Label)e.Row.FindControl("lblIncurredTotal")).Text = string.Format("{0:C2}", drTotal["TotalIncurred"]);            
        }
    }

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
