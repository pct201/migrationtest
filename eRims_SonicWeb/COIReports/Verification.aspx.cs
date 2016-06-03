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
public partial class COIReports_Verification : clsBasePage
{
    #region Page Events

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
            // bind the dropdown for COI Type
            DataTable dtType = COI_Type.SelectAll().Tables[0];
            drpCOIType.DataSource = dtType;
            drpCOIType.DataTextField = "Fld_Desc";
            drpCOIType.DataValueField = "PK_COI_Type";
            drpCOIType.DataBind();
            drpCOIType.Items.Insert(0, new ListItem("--All Types--", "0"));
        }
    }
    #endregion

    #region Controls Events

    /// <summary>
    /// Handles Show Report button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        // get the report data
        DataTable dtReport = clsCOIReports.VerificationReport(Convert.ToInt32(drpCOIType.SelectedValue)).Tables[0];

        // add total in footer if records are available
        if (dtReport.Rows.Count > 0)
        {
            gvReport.Columns[0].FooterText = "Total";
            gvReport.Columns[1].FooterText = dtReport.Rows.Count.ToString();
        }

        // set the width of grid and scrollbar as per the records available
        if (dtReport.Rows.Count > 0)
        {
            gvReport.Width = new Unit("1150px");
            pnlGrid.ScrollBars = ScrollBars.Horizontal;
        }
        else
        {
            gvReport.Width = new Unit("990px");
            pnlGrid.ScrollBars = ScrollBars.None;
        }

        // bind the grid and show export link if records are available
        btnExport.Visible = dtReport.Rows.Count > 0;
        gvReport.DataSource = GetTotals(dtReport);
        gvReport.DataBind();

        // Check if Footer row is exist then remove extra cell from footer row
        if (gvReport.FooterRow != null)
        {
            gvReport.FooterRow.Cells[1].ColumnSpan = gvReport.FooterRow.Cells.Count - 1;
            while (gvReport.FooterRow.Cells.Count > 2)
                gvReport.FooterRow.Cells.Remove(gvReport.FooterRow.Cells[2]);
        }

        dvGrid.Style["display"] = "block";
    }

    /// <summary>
    /// Handles event when Export to Excel link is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        gvReport.GridLines = GridLines.Both;
        // Check if Footer row is exist then remove extra cell from footer row
        if (gvReport.FooterRow != null)
        {
            gvReport.FooterRow.Cells[1].ColumnSpan = gvReport.FooterRow.Cells.Count - 1;
            while (gvReport.FooterRow.Cells.Count > 2)
                gvReport.FooterRow.Cells.Remove(gvReport.FooterRow.Cells[2]);
        }
        // Export the data into excel spreadsheet
        GridViewExportUtil.ExportGrid("VerificationOfInsurance.xlsx", gvReport, true);
        gvReport.GridLines = GridLines.None;
    }
    #endregion

    #region " Methods "

    private DataTable GetTotals(DataTable dtSource)
    {
        // Copy the source table to destination table
        DataTable dtDest = dtSource.Copy();

        int intLoopIndex = 0; // counter for the rows to loop through
        int intRowsAdded = 0; // counter for the rows added

        if (dtSource.Rows.Count > 0)
        {
            // loop through the source table
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                intLoopIndex = i; // starting from ith position

                //select rows having the same district name
                DataRow[] drDis = dtSource.Select("[Certificate of Insurance Received] = '" + dtSource.Rows[i]["Certificate of Insurance Received"].ToString() + "'");

                int intTotal = 0;

                int intDestRowIndex = i + intRowsAdded; // row pointer in destination table

                foreach (DataRow dr in drDis)
                {
                    intTotal++;
                    intDestRowIndex++;
                    intLoopIndex++; // increment the loop index for the next row
                }
                DataRow drTotal = dtDest.NewRow();
                drTotal[0] = dtSource.Rows[i]["Certificate of Insurance Received"].ToString() + " Total :" + intTotal;

                // insert the row after the last row position 
                dtDest.Rows.InsertAt(drTotal, intLoopIndex + intRowsAdded);

                intRowsAdded++; // increment the counter as we have added a row

                dtDest.Rows.InsertAt(dtDest.NewRow(), intLoopIndex + intRowsAdded);
                intRowsAdded++;

                i = intLoopIndex - 1; // i will now denote the row position of the next row
            }
            //// add grand total row
            //DataRow drGrandTotal = dtDest.NewRow();
            //drGrandTotal[0] = "Total :" + dtSource.Rows.Count;
            //dtDest.Rows.Add(drGrandTotal);
        }

        return dtDest;
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
