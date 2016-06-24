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
using System.IO;

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
        DataSet dsResult = new DataSet();
        if (rdoRunBy.SelectedValue == "Region")
            dsResult = WC_Allocation_Charges.WC_Monthly_Allocation_Summary_Report(year);
        else if (rdoRunBy.SelectedValue == "Market")
            dsResult = WC_Allocation_Charges.WC_Monthly_Allocation_Summary_Report_ByMarket(year);

        DataTable dtResult = dsResult.Tables[0];
        DataRow drResult = dtResult.NewRow();
        drResult[0] = "Total";
        // Count Total for each month in header of table 
        drResult[4] = dtResult.Compute("Sum(JAN)", "");
        drResult[5] = dtResult.Compute("Sum(FEB)", "");
        drResult[6] = dtResult.Compute("Sum(MAR)", "");
        drResult[7] = dtResult.Compute("Sum(APR)", "");
        drResult[8] = dtResult.Compute("Sum(MAY)", "");
        drResult[9] = dtResult.Compute("Sum(JUN)", "");
        drResult[10] = dtResult.Compute("Sum(JUL)", "");
        drResult[11] = dtResult.Compute("Sum(AUG)", "");
        drResult[12] = dtResult.Compute("Sum(SEP)", "");
        drResult[13] = dtResult.Compute("Sum(OCT)", "");
        drResult[14] = dtResult.Compute("Sum(NOV)", "");
        drResult[15] = dtResult.Compute("Sum(DEC)", "");
        drResult[16] = dtResult.Compute("Sum(Next_JAN)", "");
        drResult[17] = dtResult.Compute("Sum(Next_FEB)", "");
        drResult[18] = dtResult.Compute("Sum(Next_MAR)", "");
        drResult[19] = dtResult.Compute("Sum(Total)", "");
        dtResult.Rows.Add(drResult);
        gvworkers_comp_summary.DataSource = dtResult;
        gvworkers_comp_summary.DataBind();

        //if (rdoRunBy.SelectedValue == "Region")
        //{
        //    gvworkers_comp_summary.Columns[3].Visible = false;
        //}
        //else
        //{
        //    gvworkers_comp_summary.Columns[3].Visible = true;
        //}

        if (rdoRunBy.SelectedValue == "Region")
        {
            gvworkers_comp_summary.HeaderRow.Cells[3].Visible = false;
            for (int i = 0; i < gvworkers_comp_summary.Rows.Count; i++)
            {
                GridViewRow row = gvworkers_comp_summary.Rows[i];
                row.Cells[3].Visible = false;
            }

        }
        else
        {
            gvworkers_comp_summary.HeaderRow.Cells[3].Visible = true;
            for (int i = 0; i < gvworkers_comp_summary.Rows.Count; i++)
            {
                GridViewRow row = gvworkers_comp_summary.Rows[i];
                row.Cells[3].Visible = true;
            }
            gvworkers_comp_summary.HeaderRow.Cells[2].Visible = false;
            for (int i = 0; i < gvworkers_comp_summary.Rows.Count; i++)
            {
                GridViewRow row = gvworkers_comp_summary.Rows[i];
                row.Cells[2].Visible = false;
            }
        }

        // set Background color and Font Color for each cell in row
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
        if (rdoRunBy.SelectedValue == "Region")
        {
            gvworkers_comp_summary.HeaderRow.Cells[3].Visible = false;
            for (int i = 0; i < gvworkers_comp_summary.Rows.Count; i++)
            {
                GridViewRow row = gvworkers_comp_summary.Rows[i];
                row.Cells[3].Visible = false;
            }

        }
        else
        {
            gvworkers_comp_summary.HeaderRow.Cells[3].Visible = true;
            for (int i = 0; i < gvworkers_comp_summary.Rows.Count; i++)
            {
                GridViewRow row = gvworkers_comp_summary.Rows[i];
                row.Cells[3].Visible = true;
            }
        }
        string htmlContent = GridViewExportUtil.ExportAdHoc_New(gvworkers_comp_summary);
        gvworkers_comp_summary.GridLines = GridLines.None;

        String strPath = String.Empty, data = String.Empty, outputFiles = String.Empty;
        strPath = AppConfig.SitePath + @"temp\" + DateTime.Now.ToString("ddMMyyyyhhmmss");
        if (!File.Exists(strPath))
        {
            if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
                Directory.CreateDirectory(AppConfig.SitePath + @"temp\");
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(strPath))
            {
                sw.Write(htmlContent);
            }
        }

        data = File.ReadAllText(strPath);
        data = data.Trim();
        HTML2Excel objHtml2Excel = new HTML2Excel(data);
        outputFiles = Path.GetFullPath(strPath) + ".xlsx";
        bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);

        if (blnHTML2Excel)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"WC Allocation Summary Report.xlsx\""));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.TransmitFile(outputFiles);
                HttpContext.Current.Response.Flush();
            }
            finally
            {
                if (File.Exists(outputFiles))
                    File.Delete(outputFiles);
                if (File.Exists(strPath))
                    File.Delete(strPath);

                HttpContext.Current.Response.End();
            }
        }
    }

    /// <summary>
    /// Handle row created event of grid view
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
            row.Cells[15].Text = row.Cells[15].Text + "'" + ViewState["Year"].ToString();
            row.Cells[16].Text = row.Cells[16].Text + "'" + string.Format("{0:D2}", (Convert.ToInt32(ViewState["Year"]) + 1));
            row.Cells[17].Text = row.Cells[17].Text + "'" + string.Format("{0:D2}", (Convert.ToInt32(ViewState["Year"]) + 1));
            row.Cells[18].Text = row.Cells[18].Text + "'" + string.Format("{0:D2}", (Convert.ToInt32(ViewState["Year"]) + 1));
            row.Cells[19].Text = row.Cells[19].Text + "'" + ViewState["Year"].ToString();

        }

    }
}
