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
public partial class COIReports_LocationsByState : clsBasePage
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
        DataTable dtReport = clsCOIReports.LocationsByStateReport(Convert.ToInt32(drpCOIType.SelectedValue)).Tables[0];
        btnExport.Visible = dtReport.Rows.Count > 0;

        // DataTable dtReport = dtReport;
        btnExport.Visible = dtReport.Rows.Count > 0;

        // set the width of grid and scrollbar as per the records available
        if (dtReport.Rows.Count > 0)
        {
            gvReport.Width = new Unit("2500px");
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
        // clsGeneral.ExportData((DataTable)ViewState["dtReport"], "Locations by State");
        gvReport.GridLines = GridLines.Both;
        GridViewExportUtil.ExportGrid("LocationsByState.xls", gvReport);
        gvReport.GridLines = GridLines.None;
    }

    /// <summary>
    /// Rowdata bound Event to handle State and Zip
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[20].Text = "State";
            e.Row.Cells[21].Text = "Zip";
        }
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
