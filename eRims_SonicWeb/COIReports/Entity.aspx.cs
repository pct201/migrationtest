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
public partial class COIReports_Entity : clsBasePage
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
            // bind the dropdown for the COI type
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
        DataSet dsReport = clsCOIReports.EntityReport(Convert.ToInt32(drpCOIType.SelectedValue));
        // select report records
        DataTable dtReport = dsReport.Tables[0];
        btnExport.Visible = dtReport.Rows.Count > 0;

        // if records are available then set total in footer
        if (dsReport.Tables.Count > 0)
        {
            if (dtReport.Rows.Count > 0)
            {
                gvReport.Columns[0].FooterText = "Total";
                gvReport.Columns[1].FooterText = dsReport.Tables[1].Rows[0][0].ToString();
            }
        }

        // set the width of grid and scrollbar as per the records available
        if (dtReport.Rows.Count > 0)
        {
            gvReport.Width = new Unit("1050px");
            pnlGrid.ScrollBars = ScrollBars.Horizontal;

        }
        else
        {
            gvReport.Width = new Unit("990px");
            pnlGrid.ScrollBars = ScrollBars.None;
        }

        // bind the grid
        gvReport.DataSource = dtReport;
        gvReport.DataBind();

        // Check if Footer row is exist then remove extra cell from footer row
        if (gvReport.FooterRow != null)
        {
            gvReport.FooterRow.Cells[1].ColumnSpan = 7;
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
            gvReport.FooterRow.Cells[1].ColumnSpan = 7;
            while (gvReport.FooterRow.Cells.Count > 2)
                gvReport.FooterRow.Cells.Remove(gvReport.FooterRow.Cells[2]);
        }

        GridViewExportUtil.ExportGridNew("Entity.xlsx", gvReport);
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
    #endregion

}
