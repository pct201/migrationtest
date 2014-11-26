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
public partial class ERReports_ReportableClaims : clsBasePage
{
    #region "Variables"
    DataTable dtRegion, dtClaimData, dtTotal;
    string STR_Region;
    #endregion

    private string strTime
    {
        get { return Convert.ToString(ViewState["strTime"]); }
        set { ViewState["strTime"] = value; }
    }

    #region "Page Events"
    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            // bind report grid
            BindGrid();            
        }
    }
    #endregion

    #region "Other Controls Events"
    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// Binds the report grid
    /// </summary>
    protected void BindGrid()
    {
        // get result records from database for the report
        DataSet dsReport = ERReports.Get_Reportable_Claims_Report();

        // get data tables from result dataset
        dtClaimData = dsReport.Tables[0];
        dtRegion = dsReport.Tables[1];
        dtTotal = dsReport.Tables[2];

        // bind the main grid having list of regions and total in footer
        gvReport.DataSource = dtRegion;
        gvReport.DataBind();

        // make visible the export link if data available
        lnkExport.Visible = (dtRegion.Rows.Count > 0);

        // set design settings according to the data availability
        if (dtRegion.Rows.Count > 0)
            divReport_Grid.Attributes.Add("style", "width:995px;overflow-x: scroll;overflow-y:hidden;");
        else
            divReport_Grid.Attributes.Add("style", "width:995px;height: 50px;overflow: hidden;");

        divReport_Grid.Style["display"] = "block";
    }

    /// <summary>
    /// Handles Export button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExport_Click(object sender, EventArgs e)
    {
        // set borders for tables and gridlines in grids to be displayed in excel file
        gvReport.GridLines = GridLines.Both;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 1;
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvClaim = (GridView)gRow.FindControl("gvClaimData");
            gvClaim.GridLines = GridLines.Both;
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("Immediately_Reportable_Claims.xls", gvReport);

        // reset the settings
        gvReport.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvClaim = (GridView)gRow.FindControl("gvClaimData");
            gvClaim.GridLines = GridLines.None;
        }
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 0;
    }
    #endregion

    #region "GridView Events"

    /// <summary>
    /// Handles an event when row is created in main grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // if the row is header
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // create a new gridview row in header row
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;

            // create a table cell to be added in row
            TableCell Cell = new TableCell();
            
            // set text for the cell
            if (strTime == "") strTime = string.Format("{0:t}", DateTime.Now);
            string strCellText = "FINPRO Immediately Reportable Claims<br />" + DateTime.Now.ToLongDateString() + " " + strTime + "<br/>";
            Cell.Text = strCellText;

            // add cell in row
            gRow.Cells.Add(Cell);

            // add row in gridview header
            ((Table)gvReport.Controls[0]).Rows.AddAt(0, gRow);
        }
    }

    /// <summary>
    /// Handles rowdatabound event for main grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if the row is datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the subgrid
            GridView gvClaimData = (GridView)e.Row.FindControl("gvClaimData");

            // get region of the row
            string strRegion = DataBinder.Eval(e.Row.DataItem, "Region").ToString();
            STR_Region = strRegion;

            // create a dataview from datatable for claim data
            DataView dvDetail = new DataView();
            dvDetail = dtClaimData.DefaultView;

            // get filtered data for the region
            dvDetail.RowFilter = "Region='" + strRegion + "'";

            // bind the subgrid
            DataTable dtReport = dvDetail.ToTable();
            gvClaimData.DataSource = dtReport;
            gvClaimData.DataBind();
        }
        else if (e.Row.RowType == DataControlRowType.Footer) // if the row is footer row
        {
            // get labels for total and total estimated exposure
            Label lblTotal = (Label)e.Row.FindControl("lblFTotal");
            Label lblTotalExposure = (Label)e.Row.FindControl("lblFTotalExposure");

            // get the datarow from datatable for total and set values in labels
            DataRow dr = dtTotal.Rows[0];
            lblTotal.Text = dr["Total"].ToString();
            lblTotalExposure.Text = "$ " + clsGeneral.GetStringValue(dr["Total_Exposure"]);
            
        }
    }

    /// <summary>
    /// Handles row data bound for subgrid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row is footer row
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // get the labels for total and total estimated exposure
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            Label lblTotalExposure = (Label)e.Row.FindControl("lblTotalExposure");

            // get the total from datatable for regions and set values in labels
            DataRow[] dr = dtRegion.Select("Region='" + STR_Region + "'");
            lblTotal.Text = dr[0]["Total"].ToString();
            lblTotalExposure.Text = "$ " + clsGeneral.GetStringValue(dr[0]["Total_Exposure"]);
        }
    }
    #endregion
}
