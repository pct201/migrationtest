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
public partial class COIReports_NonCompliantByEntity : clsBasePage
{
    #region Page Event

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
            // bind the dropdown for COI type
            DataTable dtType = COI_Type.SelectAll().Tables[0];
            drpCOIType.DataSource = dtType;
            drpCOIType.DataTextField = "Fld_Desc";
            drpCOIType.DataValueField = "PK_COI_Type";
            drpCOIType.DataBind();
            drpCOIType.Items.Insert(0, new ListItem("--All Types--", "0"));
        }
    }
    #endregion

    #region Event

    /// <summary>
    /// Event to Generate Report according to specific criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        // get the report data
        DataTable dtReport = clsCOIReports.NonCompliantByEntityReport(Convert.ToInt32(drpCOIType.SelectedValue)).Tables[0];
        btnExport.Visible = dtReport.Rows.Count > 0;

        // add the total in footer if records are available
        if (dtReport.Rows.Count > 0)
        {
            gvReport.Columns[0].FooterText = "Total";
            gvReport.Columns[1].FooterText = dtReport.Rows.Count.ToString();
        }

        // bind the grid
        gvReport.DataSource = dtReport;
        gvReport.DataBind();

        // Check if Footer row is exist then remove extra cell from footer row
        if (gvReport.FooterRow != null)
        {
            gvReport.FooterRow.Cells[1].ColumnSpan = 6;
            while (gvReport.FooterRow.Cells.Count > 2)
                gvReport.FooterRow.Cells.Remove(gvReport.FooterRow.Cells[2]);
        }

        dvGrid.Style["display"] = "block";
    }

    /// <summary>
    /// Event to Export Gridview data to Excel file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        // Export the data into excel spreadsheet
        gvReport.GridLines = GridLines.Both;
        gvReport.FooterStyle.Font.Bold = true;
        // Check if Footer row is exist then remove extra cell from footer row
        if (gvReport.FooterRow != null)
        {
            gvReport.FooterRow.Cells[1].ColumnSpan = 6;
            while (gvReport.FooterRow.Cells.Count > 2)
                gvReport.FooterRow.Cells.Remove(gvReport.FooterRow.Cells[2]);
        }
        GridViewExportUtil.ExportGrid("NonCompliantByEntity.xlsx", gvReport);
        gvReport.GridLines = GridLines.None;
    }
    #endregion

    #region Method
    // <summary>
    // This method is added for export Girdview To Excel which contains SubGridview.
    // </summary>
    // <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    //private DataTable GetTotals(DataTable dtSource)
    //{
    //    // Copy the source table to destination table
    //    DataTable dtDest = dtSource.Copy();

    //    int intLoopIndex = 0; // counter for the rows to loop through
    //    int intRowsAdded = 0; // counter for the rows added

    //    if (dtSource.Rows.Count > 0)
    //    {
    //        // loop through the source table
    //        for (int i = 0; i < dtSource.Rows.Count; i++)
    //        {
    //            intLoopIndex = i; // starting from ith position

    //            //select rows having the same district name
    //            DataRow[] drDis = dtSource.Select("[DIS] = '" + dtSource.Rows[i]["DIS"].ToString() + "'");

    //            //if array length is 0 then find for null values in District Column
    //            if (drDis.Length == 0)
    //                drDis = dtSource.Select("[DIS] is null");

    //            int intTotal = 0;

    //            int intDestRowIndex = i + intRowsAdded; // row pointer in destination table

    //            foreach (DataRow dr in drDis)
    //            {
    //                intTotal++;                        
    //                intDestRowIndex++;
    //                intLoopIndex++; // increment the loop index for the next row
    //            }
    //            DataRow drTotal = dtDest.NewRow();
    //            drTotal[0] = dtSource.Rows[i]["DIS"].ToString() + " Total :" +  intTotal;

    //            // insert the row after the last row position 
    //            dtDest.Rows.InsertAt(drTotal, intLoopIndex + intRowsAdded);

    //            intRowsAdded++; // increment the counter as we have added a row

    //            dtDest.Rows.InsertAt(dtDest.NewRow(), intLoopIndex + intRowsAdded);
    //            intRowsAdded++;

    //            i = intLoopIndex - 1; // i will now denote the row position of the next row
    //        }
    //        // add grand total row
    //        DataRow drGrandTotal = dtDest.NewRow();
    //        drGrandTotal[0] = "Total :" + dtSource.Rows.Count;
    //        dtDest.Rows.Add(drGrandTotal);
    //    }
    //    ViewState["dtReport"] = dtDest;
    //    return dtDest;
    //}

    #endregion
}
