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

/************************************************************************************************************************************
 * File Name    : WCAllocationMonthlyDetailReport.aspx
 *
 *  Description : This page is used for generate WC Allocation Monthly Detail Report.
 *                User selects Year and Month as filter criteria for this Report. User can also export this report to excel sheet.
 *
 *************************************************************************************************************************************/

public partial class SONIC_FirstReport_WCAllocationMonthlyDetailReport : clsBasePage
{
    DataTable dtRegionTotals, dtDetails, dtGrandTotal;

    public string ReportLabel
    {
        get { return rdoRunBy.SelectedValue; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // fill year drop-down
            DataTable dtYears = WC_FR.SelectDistinctIncidentYear().Tables[0];
            ddlYear.DataSource = dtYears;
            ddlYear.DataTextField = "WCYear";
            ddlYear.DataValueField = "WCYear";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    /// <summary>
    /// Handle Export To excel link button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        // set borders for tables and gridlines in grids to be displayed in excel file
        gvRegion.GridLines = GridLines.Both;
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 1;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvReport");
            gvDetail.GridLines = GridLines.Both;
        }
        GridViewExportUtil.ExportGrid("WCAllocationDetailsReport.xls", gvRegion);

        //Hide the Grid lines
        gvRegion.GridLines = GridLines.None;
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 0;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvReport");
            gvDetail.GridLines = GridLines.None;

        }
    }

    /// <summary>
    /// Handle Show Report button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        // select record for reprot
        DataSet dsReport = new DataSet();

        if(rdoRunBy.SelectedValue == "Region")
           dsReport = WC_Allocation_Charges.WCAllocationMonthlyDetailReport(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));
        else if (rdoRunBy.SelectedValue == "Market")
            dsReport = WC_Allocation_Charges.WCAllocationMonthlyDetailReport_ByMarket(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));


        dtDetails = dsReport.Tables[0];
        dtRegionTotals = dsReport.Tables[1];
        dtGrandTotal = dsReport.Tables[2];

        gvRegion.DataSource = dtRegionTotals;
        gvRegion.DataBind();

        dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dtRegionTotals.Rows.Count > 0) ? "scroll;" : "hidden;";

        //Check if any record found and subtotal table is exist then display Total
        if (dtDetails.Rows.Count > 0)
        {
            if (dtGrandTotal.Rows.Count > 0)
            {
                DataRow drTotal = dtGrandTotal.Rows[0];
                ((Label)gvRegion.FooterRow.FindControl("lblReportLag")).Text = String.Format("{0:N0}", drTotal["Report_Lag"]); ;
                ((Label)gvRegion.FooterRow.FindControl("lblClaimCharge")).Text = String.Format("{0:C2}", drTotal["Initial_Charge"]);
                ((Label)gvRegion.FooterRow.FindControl("lblPenaltyCharge")).Text = String.Format("{0:C2}", drTotal["Lag_Charge"]);
                ((Label)gvRegion.FooterRow.FindControl("lblPerformanceCredit")).Text = String.Format("{0:C2}", drTotal["Lag_Credit"]);
                ((Label)gvRegion.FooterRow.FindControl("lblClosedCredit")).Text = String.Format("{0:C2}", drTotal["Early_Close_Credit"]);
                ((Label)gvRegion.FooterRow.FindControl("lblReopenedCharge")).Text = String.Format("{0:C2}", drTotal["Reopen_Charge"]);
                ((Label)gvRegion.FooterRow.FindControl("lblTotalCharge")).Text = String.Format("{0:C2}", drTotal["Total_Charge"]);
                ((Label)gvRegion.FooterRow.FindControl("lblNurseTriageCredit")).Text = String.Format("{0:C2}", drTotal["Nurse_Triage_Credit"]);
                ((Label)gvRegion.FooterRow.FindControl("lblIncidentInvestigationCredit")).Text = String.Format("{0:C2}", drTotal["Incident_Investigation_Credit"]);

            }
        }

        lnkExportToExcel.Visible = dtDetails.Rows.Count > 0;
    }

    /// <summary>
    /// Handle Gridview Row created event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;

            // create a table cell to be added in row
            TableCell Cell = new TableCell();
            Cell.HorizontalAlign = HorizontalAlign.Center;
            Cell.Text = "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                            "<table width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=0>" +
                                "<tr><td width='100%' align='center' colspan='16'>WC Allocation Monthly Detail Report </td></tr></table>" +
                            "</td></tr></table>";
            // add cell in row
            gRow.Cells.Add(Cell);

            // add row in gridview header
            ((Table)gvRegion.Controls[0]).Rows.AddAt(0, gRow);

        }
    }

    /// <summary>
    /// handle Row Data bound event for grid view
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string strReportLabel = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReportLabel"));
            DataView dvDetails = dtDetails.DefaultView;
            // filter data table for region 
            dvDetails.RowFilter = "ReportLabel = '" + strReportLabel + "'";

            // bind grid
            GridView gvReport = (GridView)e.Row.FindControl("gvReport");
            gvReport.DataSource = dvDetails.ToTable();
            gvReport.DataBind();

            DataRow[] dr = dtRegionTotals.Select("ReportLabel= '" + strReportLabel + "'");

            // Check if datarow exists for Region wise total
            if (dr.Length > 0)
            {
                DataRow drTotal = dr[0];

                gvReport.FooterRow.Cells[9].Text = String.Format("{0:N0}", drTotal["Report_Lag"]);
                gvReport.FooterRow.Cells[7].Text = String.Format("{0:C2}", drTotal["Initial_Charge"]);
                gvReport.FooterRow.Cells[11].Text = String.Format("{0:C2}", drTotal["Lag_Charge"]);
                gvReport.FooterRow.Cells[10].Text = String.Format("{0:C2}", drTotal["Lag_Credit"]);
                gvReport.FooterRow.Cells[12].Text = String.Format("{0:C2}", drTotal["Nurse_Triage_Credit"]);
                gvReport.FooterRow.Cells[13].Text = String.Format("{0:C2}", drTotal["Incident_Investigation_Credit"]);
                gvReport.FooterRow.Cells[15].Text = String.Format("{0:C2}", drTotal["Early_Close_Credit"]);
                gvReport.FooterRow.Cells[17].Text = String.Format("{0:C2}", drTotal["Reopen_Charge"]);
                gvReport.FooterRow.Cells[18].Text = String.Format("{0:C2}", drTotal["Total_Charge"]);
            }
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
}
