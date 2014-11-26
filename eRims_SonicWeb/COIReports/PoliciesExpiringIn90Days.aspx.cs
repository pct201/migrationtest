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
public partial class COIReports_PoliciesExpiringIn90Days : clsBasePage
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
            // bind dropdown for the COI Type
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
        // get the data for the report
        DataSet dsReport = clsCOIReports.PoliciesExpiringIn90Days(Convert.ToInt32(drpCOIType.SelectedValue));
        DataTable dtReport = MergeData(dsReport, dsReport.Tables[0]);

        // show the export link if records are available
        btnExport.Visible = dtReport.Rows.Count > 0;
        if (dsReport.Tables.Count > 0)
        {
            DataTable dtTotal = dsReport.Tables[dsReport.Tables.Count - 1];
            if (dtTotal.Rows.Count > 0)
            {
                gvReport.Columns[0].FooterText = "Total";
                gvReport.Columns[1].FooterText = dtTotal.Rows.Count.ToString();
            }
        }
        dtReport.Columns.RemoveAt(0);

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
        gvReport.DataSource = dtReport;
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
    /// Event to Export Gridview data to Excel file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        // Export the data into excel spreadsheet
        //  clsGeneral.ExportData((DataTable)ViewState["dtReport"], "Entity (Producer and Insurance Company)");

        gvReport.GridLines = GridLines.Both;
        gvReport.FooterStyle.Font.Bold = true;
        // Check if Footer row is exist then remove extra cell from footer row
        if (gvReport.FooterRow != null)
        {
            gvReport.FooterRow.Cells[1].ColumnSpan = gvReport.FooterRow.Cells.Count - 1;
            while (gvReport.FooterRow.Cells.Count > 2)
                gvReport.FooterRow.Cells.Remove(gvReport.FooterRow.Cells[2]);
        }
        GridViewExportUtil.ExportGrid("PoliciesExpiringIn90Days.xls", gvReport);
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
    /// <summary>
    /// Event To Merge Data
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="dtReport"></param>
    /// <returns></returns>
    private DataTable MergeData(DataSet ds, DataTable dtReport)
    {
        int intColsAdded = 0;

        DataTable dtDest = dtReport.Copy();


        int intPolicyCol = 0;
        for (int intTab = 1; intTab < ds.Tables.Count - 1; intTab++)
        {
            int intRowIndex = 0;
            DataTable dt = ds.Tables[intTab];
            for (int intCol = 1; intCol < dt.Columns.Count; intCol++)
            {
                dtDest.Columns.Add(dt.Columns[intCol].ColumnName);
            }

            for (int i = 0; i < dtReport.Rows.Count; i++)
            {

                DataRow[] drPolicy = dt.Select(dt.Columns[0].ColumnName + " = " + dtReport.Rows[i][0].ToString());
                DataRow[] drCOIs = dtDest.Select("PK_COIs=" + dtReport.Rows[i][0].ToString());
                int intPolicyRowsAdded = 0;
                int intColumn = 0;
                foreach (DataRow dr in drPolicy)
                {
                    intColumn = (intTab == 1) ? dtReport.Columns.Count : intPolicyCol + dtReport.Columns.Count;

                    if (drPolicy.Length > drCOIs.Length && intPolicyRowsAdded > 0)
                    {
                        DataRow drNew = dtDest.NewRow();
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            drNew[0] = dtReport.Rows[i][0].ToString();
                            drNew[intColumn] = dr[j].ToString();
                            intColumn++;
                        }
                        dtDest.Rows.InsertAt(drNew, intRowIndex + intPolicyRowsAdded);
                    }
                    else
                    {
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            dtDest.Rows[intRowIndex + intPolicyRowsAdded][intColumn] = dr[j].ToString();
                            intColumn++;
                        }
                    }
                    intPolicyRowsAdded++;
                }
                if (drPolicy.Length > drCOIs.Length)
                    intRowIndex += intPolicyRowsAdded;
                else
                    intRowIndex += drCOIs.Length;

            }
            intPolicyCol += dt.Columns.Count - 1;

        }
        return dtDest;
    }
    #endregion
}
