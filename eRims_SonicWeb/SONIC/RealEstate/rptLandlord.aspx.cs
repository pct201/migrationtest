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
public partial class SONIC_RealEstate_rptLandlord : clsBasePage
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
    /// handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
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
    /// handle grid view row created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDBA_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // if it is header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // create a grdview row
            GridViewRow row;
            row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            row.Font.Bold = true;
            if (strTime == "") strTime = string.Format("{0:t}", DateTime.Now);

            // create a table cell with the heading text
            TableCell Cell = new TableCell();
            Cell.Text = "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                                "<table width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=4><tr>" +
                                "<td colspan='2' align='left' >Sonic Automotive</td>" +
                                "<td colspan='4' align='center' >Landlord Report</td>" +
                                "<td colspan='2' align='right'>" + clsGeneral.FormatDateToDisplay(DateTime.Now) + " " + strTime + "</td>" +
                            "</tr></table></td></tr></table>";

            // add the table in the gridview row
            row.Cells.Add(Cell);

            // add the row in the gridview header
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
        GridViewExportUtil.ExportGrid("LandlordReport.xls", gvDBA);

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
    /// Handles event when gridview rows are bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDBA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the subgrid
            GridView gvReport = (GridView)e.Row.FindControl("gvReport");

            // get the data for current DBA record
            DataTable dt = dtReport;
            dt.DefaultView.RowFilter = "DBA='" + DataBinder.Eval(e.Row.DataItem, "DBA").ToString() + "'";
            dt = dt.DefaultView.ToTable();

            // bind sub grid view
            gvReport.DataSource = dt;
            gvReport.DataBind();
            dvGrid.Visible = true;

            // if rows are available
            if (dt.Rows.Count > 0)
            {
                // display sub total
                ((Label)gvReport.FooterRow.FindControl("lblTotal")).Text = dt.Rows.Count.ToString();
                ((Label)gvReport.FooterRow.FindControl("lblTotalLeaseTerm")).Text = string.Format("{0:N0}", dt.Compute("sum(Lease_Term)", ""));
                ((Label)gvReport.FooterRow.FindControl("lblLeaseable_Area")).Text = string.Format("{0:N0}", dt.Compute("sum(Rentable_Area)", ""));
            }
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
        string strRegion = string.Empty, strLeaseType = string.Empty;
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

        // get selected regions
        foreach (ListItem li in ddlLeaseType.Items)
        {
            if (li.Selected)
                strLeaseType = strLeaseType + li.Value + ",";
        }
        strLeaseType = strLeaseType.TrimEnd(',');

        strTime = "";

        // get report result from database
        dsResult = Report.GetLandlordReport(strRegion, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

        // get the location(dba) list
        dtDBA = dsResult.Tables[0];

        // get all data
        dtReport = dsResult.Tables[1];

        // set scrollbar propery
        dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dsResult.Tables[0].Rows.Count > 0) ? "scroll;" : "hidden;";

        // bind the main grid with the location list
        gvDBA.DataSource = dtDBA;
        gvDBA.DataBind();
        dvGrid.Visible = true;

        // if datarows are available
        if (dtReport.Rows.Count > 0)
        {
            // count and display the grand total in the footer row
            ((Label)gvDBA.FooterRow.FindControl("lblTotal")).Text = dtReport.Rows.Count.ToString();
            ((Label)gvDBA.FooterRow.FindControl("lblTotalLeaseTerm")).Text = string.Format("{0:N0}", dtReport.Compute("sum(Lease_Term)", ""));
            ((Label)gvDBA.FooterRow.FindControl("lblLeaseable_Area")).Text = string.Format("{0:N0}", dtReport.Compute("sum(Rentable_Area)", ""));
            lnkExportToExcel.Visible = true;
            gvDBA.Width = new Unit("1285px");
        }
        else
        {
            gvDBA.Width = new Unit("950px");
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
        // Fill Region
        ComboHelper.FillRegionListBox(new ListBox[] { ddlRegion }, false);

        //Lease Type
        ComboHelper.FillLeaseTypeListBox(new ListBox[] { ddlLeaseType }, false);

    }

    #endregion
}
