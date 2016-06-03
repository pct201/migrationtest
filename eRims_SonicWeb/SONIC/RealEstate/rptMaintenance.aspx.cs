using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;
public partial class SONIC_RealEstate_rptMaintenance : clsBasePage
{
    #region "Variables"
    DataTable dtDBA, dtReport;
    #endregion

    #region "Properties"
    private string strTime
    {
        get { return Convert.ToString(ViewState["strTime"]); }
        set { ViewState["strTime"] = value; }
    }
    #endregion

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
            // Bind Drop down
            BindDropDownList();
            // set focus to first field
            ddlRegion.Focus();
        }
    }
    #endregion

    #region "Events"

    /// <summary>
    /// Handles event when gridview row is bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDBA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the sub grid
            GridView gvReport = (GridView)e.Row.FindControl("gvReport");

            // get the data for current DBA record
            DataTable dt = dtReport;
            string str = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DBA"));
            dt.DefaultView.RowFilter = "DBA='" + str.Replace("'", "''") + "'";
            dt = dt.DefaultView.ToTable();

            // bind grid view
            gvReport.DataSource = dt;
            gvReport.DataBind();
            dvGrid.Visible = true;

            // if data rows are available
            if (dt.Rows.Count > 0)
            {
                // calculate and display the sub total
                ((Label)gvReport.FooterRow.FindControl("lblTotal")).Text = dt.Rows.Count.ToString();
                ((Label)gvReport.FooterRow.FindControl("lblTotalLeaseTerm")).Text = string.Format("{0:N0}", dt.Compute("sum(Lease_Term)", ""));
                ((Label)gvReport.FooterRow.FindControl("lblLeaseable_Area")).Text = string.Format("{0:N0}", dt.Compute("sum(Rentable_Area)", ""));
                ((Label)gvReport.FooterRow.FindControl("lblTotalItems")).Text = string.Format("{0:N0}", dt.Compute("sum(Items_Per_Location)", ""));
            }
        }
    }

    /// <summary>
    /// handle grid view row created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDBA_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // if it is header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // create gridview row
            GridViewRow row;
            row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            row.Font.Bold = true;
            if (strTime == "") strTime = string.Format("{0:t}", DateTime.Now);

            // create a tablecell with the heading text
            TableCell Cell = new TableCell();
            Cell.Text = "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                                "<table width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=4><tr>" +
                                "<td align='left' >Sonic Automotive</td>" +
                                "<td colspan='3' align='center' >Maintenance and Repair Items</td>" +
                                "<td align='right'>" + clsGeneral.FormatDateToDisplay(DateTime.Now) + " " + strTime + "</td>" +
                            "</tr></table></td></tr></table>";

            // add cell in row
            row.Cells.Add(Cell);

            // add row in gridview header
            ((Table)gvDBA.Controls[0]).Rows.AddAt(0, row);
        }
    }

    /// <summary>
    /// handle Export To Excel Link button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        // show gridlines to be shown in excel 
        gvDBA.GridLines = GridLines.Both;
        ((HtmlTable)gvDBA.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvDBA.FooterRow.FindControl("tblFooter")).Border = 1;

        foreach (GridViewRow gRow in gvDBA.Rows)
        {
            GridView gvReport = (GridView)gRow.FindControl("gvReport");
            gvReport.GridLines = GridLines.Both;
        }

        // export gridview to excel
        GridViewExportUtil.ExportGrid("MaintenanceAndRepairItems.xlsx", gvDBA, true);

        // hide gridlines
        gvDBA.GridLines = GridLines.None;
        ((HtmlTable)gvDBA.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvDBA.FooterRow.FindControl("tblFooter")).Border = 0;

        foreach (GridViewRow gRow in gvDBA.Rows)
        {
            GridView gvReport = (GridView)gRow.FindControl("gvReport");
            gvReport.GridLines = GridLines.None;
        }
    }

    /// <summary>
    /// Handle Button Show Report click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;
        string strRegion = string.Empty, strLeaseType = string.Empty, strMarket = string.Empty;
        DataSet dsResult;

        if (txtLCDateFrom.Text.Trim() != string.Empty)
            dtLCDFrom = Convert.ToDateTime(txtLCDateFrom.Text);

        if (txtLCDateTo.Text.Trim() != string.Empty)
            dtLCDTo = Convert.ToDateTime(txtLCDateTo.Text);

        if (txtLEDateFrom.Text.Trim() != string.Empty)
            dtLEDFrom = Convert.ToDateTime(txtLEDateFrom.Text);

        if (txtLEDateTo.Text.Trim() != string.Empty)
            dtLEDTo = Convert.ToDateTime(txtLEDateTo.Text);

        // get selected regions
        foreach (ListItem li in ddlRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        // get selected Markets
        foreach (ListItem li in lstMarket.Items)
        {
            if (li.Selected)
                strMarket = strMarket + "" + li.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        // get selected regions
        foreach (ListItem li in ddlLeaseType.Items)
        {
            if (li.Selected)
                strLeaseType = strLeaseType + li.Value + ",";
        }
        strLeaseType = strLeaseType.TrimEnd(',');

        strTime = "";

        // get report result from database
        dsResult = Report.GetMaintenanceAndRepairItems(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

        dtDBA = dsResult.Tables[0];
        dtReport = dsResult.Tables[1];

        //// set scrollbar propery
        //dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dtDBA.Rows.Count > 0) ? "scroll;" : "hidden;";

        gvDBA.DataSource = dtDBA;
        gvDBA.DataBind();
        dvGrid.Visible = true;

        if (dtReport.Rows.Count > 0)
        {
            ((Label)gvDBA.FooterRow.FindControl("lblTotal")).Text = dtReport.Rows.Count.ToString();
            ((Label)gvDBA.FooterRow.FindControl("lblTotalLeaseTerm")).Text = string.Format("{0:N0}", dtReport.Compute("sum(Lease_Term)", ""));
            ((Label)gvDBA.FooterRow.FindControl("lblLeaseable_Area")).Text = string.Format("{0:N0}", dtReport.Compute("sum(Rentable_Area)", ""));
            ((Label)gvDBA.FooterRow.FindControl("lblTotalItems")).Text = string.Format("{0:N0}", dtReport.Compute("sum(Items_Per_Location)", ""));
            lnkExportToExcel.Visible = true;            
        }
        else
        {
            lnkExportToExcel.Visible = false;
        }

    }

    /// <summary>
    /// handle Clear Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        // reload the page
        Response.Redirect(Request.AppRelativeCurrentExecutionFilePath);
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

    #region "Methods"

    /// <summary>
    /// Bind Drop Down List
    /// </summary>    
    private void BindDropDownList()
    {
        //Region
        ComboHelper.FillRegionListBox(new ListBox[] { ddlRegion }, false);

        //Bind Market Dropdown
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);

        //Lease Type
        ComboHelper.FillLeaseTypeListBox(new ListBox[] { ddlLeaseType }, false);

    }

    #endregion
}
