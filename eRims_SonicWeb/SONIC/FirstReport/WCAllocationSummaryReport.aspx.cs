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

public partial class SONIC_FirstReport_WCAllocationSummaryReport : clsBasePage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lnkExportToExcel.Visible = false;
            ComboHelper.FillDistinctYear_Worker_Comp_Charge(new DropDownList[] { ddlYear } , true);
        }
    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        decimal year = ddlYear.SelectedIndex > 0 ? Convert.ToDecimal(ddlYear.SelectedValue) : 0;
        ViewState["Year"] = year.ToString().Substring(2, 2);
        DataSet dsResult = WC_ClaimInfo.WC_Allocation_Location_Summary_Report(year);
        DataTable dtResult = dsResult.Tables[0];
        DataRow drResult = dtResult.NewRow();
        drResult[0] = "Total";
        drResult[2] = dtResult.Compute("Sum(JAN)", "");
        drResult[3] = dtResult.Compute("Sum(FEB)", "");
        drResult[4] = dtResult.Compute("Sum(MAR)", "");
        drResult[5] = dtResult.Compute("Sum(APR)", "");
        drResult[6] = dtResult.Compute("Sum(MAY)", "");
        drResult[7] = dtResult.Compute("Sum(JUN)", "");
        drResult[8] = dtResult.Compute("Sum(JUL)", "");
        drResult[9] = dtResult.Compute("Sum(AUG)", "");
        drResult[10] = dtResult.Compute("Sum(SEP)", "");
        drResult[11] = dtResult.Compute("Sum(OCT)", "");
        drResult[12] = dtResult.Compute("Sum(NOV)", "");
        drResult[13] = dtResult.Compute("Sum(DEC)", "");
        drResult[14] = dtResult.Compute("Sum(Total_Count)", "");
        dtResult.Rows.Add(drResult);
        gvworkers_comp_summary.DataSource = dtResult;
        gvworkers_comp_summary.DataBind();
        gvworkers_comp_summary.Rows[gvworkers_comp_summary.Rows.Count - 1].Attributes.Add("style", "background-color:#507cd1;font-weight:bold;color:white;");
        if (dtResult.Rows.Count > 0)
            lnkExportToExcel.Visible = true;
        else
            lnkExportToExcel.Visible = false;
    }

    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        gvworkers_comp_summary.GridLines = GridLines.Both;
        GridViewExportUtil.ExportAdHoc("WC Allocation Summary Report.xls", gvworkers_comp_summary);
        gvworkers_comp_summary.GridLines = GridLines.None;
    }
    protected void gvworkers_comp_summary_RowCreated(object sender, GridViewRowEventArgs e)
    {

        GridViewRow row = e.Row;

        if (e.Row.RowType == DataControlRowType.Header)
        {

            row.Cells[2].Text = row.Cells[2].Text + "'" + ViewState["Year"].ToString();
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

        }

    }

}
