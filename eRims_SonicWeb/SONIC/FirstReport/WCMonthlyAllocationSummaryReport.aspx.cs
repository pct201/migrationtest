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
 * File Name    : WCMonthlyAllocationSummaryReport.aspx
 *
 *  Description : This page is used for generate Wc Monthly allocation summary report.
 *                User selects Year as filter criteria for this Report. User can also export this report to excel sheet.
 *
 *************************************************************************************************************************************/
public partial class SONIC_FirstReport_WCMonthlyAllocationSummaryReport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lnkExportToExcel.Visible = false;
            
            // Fill Year DropDown
            DataTable dtYears = WC_FR.SelectDistinctIncidentYear().Tables[0];
            ddlYear.DataSource = dtYears;
            ddlYear.DataTextField = "WCYear";
            ddlYear.DataValueField = "WCYear";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    /// <summary>
    /// Hanlde Show Report Button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        int year = ddlYear.SelectedIndex > 0 ? Convert.ToInt32(ddlYear.SelectedValue) : 0;
        ViewState["Year"] = year.ToString().Substring(2, 2);

        // fetch records for report as per year selected
        DataSet dsResult = WC_Allocation_Charges.WC_Monthly_Allocation_Summary_Report(year);
        DataTable dtResult = dsResult.Tables[0];
        DataRow drResult = dtResult.NewRow();
        drResult[0] = "Total";
        // Count Total for each month in header of table 
        drResult[3] = dtResult.Compute("Sum(JAN)", "");
        drResult[4] = dtResult.Compute("Sum(FEB)", "");
        drResult[5] = dtResult.Compute("Sum(MAR)", "");
        drResult[6] = dtResult.Compute("Sum(APR)", "");
        drResult[7] = dtResult.Compute("Sum(MAY)", "");
        drResult[8] = dtResult.Compute("Sum(JUN)", "");
        drResult[9] = dtResult.Compute("Sum(JUL)", "");
        drResult[10] = dtResult.Compute("Sum(AUG)", "");
        drResult[11] = dtResult.Compute("Sum(SEP)", "");
        drResult[12] = dtResult.Compute("Sum(OCT)", "");
        drResult[13] = dtResult.Compute("Sum(NOV)", "");
        drResult[14] = dtResult.Compute("Sum(DEC)", "");
        drResult[15] = dtResult.Compute("Sum(Next_JAN)", "");
        drResult[16] = dtResult.Compute("Sum(Next_FEB)", "");
        drResult[17] = dtResult.Compute("Sum(Next_MAR)", "");
        drResult[18] = dtResult.Compute("Sum(Total)", "");
        dtResult.Rows.Add(drResult);
        gvworkers_comp_summary.DataSource = dtResult;
        gvworkers_comp_summary.DataBind();

        // set Backgroung color and Font Color for each cell in row
        for (int i = 0; i < gvworkers_comp_summary.Rows[gvworkers_comp_summary.Rows.Count - 1].Cells.Count; i++)
            gvworkers_comp_summary.Rows[gvworkers_comp_summary.Rows.Count - 1].Cells[i].Attributes.Add("style", "background-color:#507cd1;font-weight:bold;color:white;");

        // Show hide scrollbar and Link button
        if (dtResult.Rows.Count > 0)
        {
            lnkExportToExcel.Visible = true;
            dvReport.Style[HtmlTextWriterStyle.OverflowX] = "scroll;";
        }
        else
        {
            lnkExportToExcel.Visible = false;
            dvReport.Style[HtmlTextWriterStyle.OverflowX] = "hidden;";
        }
    }

    /// <summary>
    /// Hanlde export To excel link Button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        gvworkers_comp_summary.GridLines = GridLines.Both;
        GridViewExportUtil.ExportAdHoc("WC Allocation Summary Report.xls", gvworkers_comp_summary);
        gvworkers_comp_summary.GridLines = GridLines.None;
    }

    /// <summary>
    /// Hanlde row created event of grid view
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvworkers_comp_summary_RowCreated(object sender, GridViewRowEventArgs e)
    {

        GridViewRow row = e.Row;
        // Display Year in header Row with Month Name
        if (e.Row.RowType == DataControlRowType.Header)
        {

            //row.Cells[2].Text = row.Cells[2].Text + "'" + ViewState["Year"].ToString();
            row.Cells[3].Text = row.Cells[3].Text + "'" + ViewState["Year"].ToString();
            row.Cells[4].Text = row.Cells[4].Text + "'" + ViewState["Year"].ToString();
            row.Cells[5].Text = row.Cells[5].Text + "'" + ViewState["Year"].ToString();
            row.Cells[6].Text = row.Cells[6].Text + "'" + ViewState["Year"].ToString();
            row.Cells[7].Text = row.Cells[7].Text + "'" + ViewState["Year"].ToString();
            row.Cells[8].Text = row.Cells[8].Text + "'" + ViewState["Year"].ToString();
            row.Cells[9].Text = row.Cells[9].Text + "'" + ViewState["Year"].ToString();
            row.Cells[10].Text = row.Cells[10].Text + "'" + ViewState["Year"].ToString();
            row.Cells[11].Text = row.Cells[11].Text + "'" + ViewState["Year"].ToString();
            row.Cells[12].Text = row.Cells[12].Text + "'" + ViewState["Year"].ToString();
            row.Cells[13].Text = row.Cells[13].Text + "'" + ViewState["Year"].ToString();
            row.Cells[14].Text = row.Cells[14].Text + "'" + ViewState["Year"].ToString();
            row.Cells[15].Text = row.Cells[15].Text + "'" + string.Format("{0:D2}", (Convert.ToInt32(ViewState["Year"]) + 1));
            row.Cells[16].Text = row.Cells[16].Text + "'" + string.Format("{0:D2}", (Convert.ToInt32(ViewState["Year"]) + 1));
            row.Cells[17].Text = row.Cells[17].Text + "'" + string.Format("{0:D2}", (Convert.ToInt32(ViewState["Year"]) + 1));
            row.Cells[18].Text = row.Cells[18].Text + "'" + ViewState["Year"].ToString();

        }

    }
}
