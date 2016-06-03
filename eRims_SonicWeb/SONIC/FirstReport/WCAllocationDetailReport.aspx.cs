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

public partial class SONIC_FirstReport_WCAllocationDetailReport : clsBasePage
{

    DataTable dtRegionTotals, dtDetails, dtGrandTotal;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtYears = WC_FR.SelectDistinctIncidentYear().Tables[0];
            ddlYear.DataSource = dtYears;
            ddlYear.DataTextField = "WCYear";
            ddlYear.DataValueField = "WCYear";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("--Select--", "0"));

            DataTable dtRegion = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegion;
            lstRegions.DataTextField = "Region";
            lstRegions.DataValueField = "Region";
            lstRegions.DataBind();
        }
    }

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
        GridViewExportUtil.ExportGrid("WCAllocationDetailsReport.xls", gvRegion, true);

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

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string strRegions = "";
        foreach (ListItem itmReg in lstRegions.Items)
        {
            if (itmReg.Selected)
                strRegions = strRegions + "," + itmReg.Value;
        }
        strRegions = strRegions.TrimEnd(',');

        DataSet dsReport = WC_FR.GetWCAllocationDetailData(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), strRegions);

        dtDetails = dsReport.Tables[0];
        dtRegionTotals = dsReport.Tables[1];
        dtGrandTotal = dsReport.Tables[2];

        gvRegion.DataSource = dtRegionTotals;
        gvRegion.DataBind();
        if (dtDetails.Rows.Count > 0)
        {
            if (dtGrandTotal.Rows.Count > 0)
            {
                DataRow drTotal = dtGrandTotal.Rows[0];
                ((Label)gvRegion.FooterRow.FindControl("lblReportLag")).Text = String.Format("{0:N0}", drTotal["Report_Lag"]); ;
                ((Label)gvRegion.FooterRow.FindControl("lblClaimCharge")).Text = String.Format("{0:C2}", drTotal["claimCharge"]);
                ((Label)gvRegion.FooterRow.FindControl("lblPenaltyCharge")).Text = String.Format("{0:C2}", drTotal["PenaltyCharge"]);
                ((Label)gvRegion.FooterRow.FindControl("lblPerformanceCredit")).Text = String.Format("{0:C2}", drTotal["PerformanceCredit"]);
                ((Label)gvRegion.FooterRow.FindControl("lblTotalCharge")).Text = String.Format("{0:C2}", drTotal["TotalCharge"]);

            }
        }

        lnkExportToExcel.Visible = dtDetails.Rows.Count > 0;
    }

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
                                "<tr><td width='100%' align='center' colspan='11'>Sonic Automotive WC Loss Allocation Report (First Report Only)</td></tr></table>" +
                            "</td></tr></table>";
            // add cell in row
            gRow.Cells.Add(Cell);

            // add row in gridview header
            ((Table)gvRegion.Controls[0]).Rows.AddAt(0, gRow);

        }
    }

    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strRegion = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Region"));
            DataView dvDetails = dtDetails.DefaultView;
            dvDetails.RowFilter = "Region = '" + strRegion + "'";

            GridView gvReport = (GridView)e.Row.FindControl("gvReport");
            gvReport.DataSource = dvDetails.ToTable();
            gvReport.DataBind();

            DataRow[] dr = dtRegionTotals.Select("Region= '" + strRegion + "'");

            if (dr.Length > 0)
            {
                DataRow drTotal = dr[0];

                gvReport.FooterRow.Cells[6].Text = String.Format("{0:N0}", drTotal["Report_Lag"]);
                gvReport.FooterRow.Cells[7].Text = String.Format("{0:C2}", drTotal["claimCharge"]);
                gvReport.FooterRow.Cells[8].Text = String.Format("{0:C2}", drTotal["PenaltyCharge"]);
                gvReport.FooterRow.Cells[9].Text = String.Format("{0:C2}", drTotal["PerformanceCredit"]);
                gvReport.FooterRow.Cells[10].Text = String.Format("{0:C2}", drTotal["TotalCharge"]);
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
