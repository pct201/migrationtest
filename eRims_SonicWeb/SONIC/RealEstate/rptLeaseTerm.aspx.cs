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

/*********************************************************************************************************************************
 * 
 * Developer Name : Ravi Patel
 * 
 * Description : This page allow user to generate lease Term Report. User can see report result into grid and also export output to
 *               Excel(.xls) files. user can filter this reprot By Region, Lease Type ,Lease Commencement Date and Lease
 *               Expiration Date.
 * 
 ********************************************************************************************************************************/
public partial class SONIC_RealEstate_rptLeaseTerm : clsBasePage
{
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

    #region "Events"

    /// <summary>
    /// handle grid view row created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;

            // create a table cell to be added in row
            TableCell Cell = new TableCell();
            Cell.Text = "Sonic Automotive";
            Cell.ColumnSpan = 3;
            Cell.HorizontalAlign = HorizontalAlign.Left;
            // add cell in row
            gRow.Cells.AddAt(0, Cell);

            Cell = new TableCell();
            Cell.HorizontalAlign = HorizontalAlign.Center;
            Cell.Text = "Lease Term";
            Cell.ColumnSpan = 5;
            // add cell in row
            gRow.Cells.AddAt(1, Cell);

            Cell = new TableCell();
            Cell.HorizontalAlign = HorizontalAlign.Right;
            Cell.Text = DateTime.Now.ToString();
            Cell.ColumnSpan = 2;
            // add cell in row
            gRow.Cells.AddAt(2, Cell);

            // add row in gridview header
            ((Table)gvReport.Controls[0]).Rows.AddAt(0, gRow);
        }
    }

    /// <summary>
    /// handle Export To Excel Link button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        //btnShowReport_Click(sender, e);
        gvReport.GridLines = GridLines.Both;

        // set fore color and back color
        foreach (TableCell tc in gvReport.FooterRow.Cells)
        {
            tc.ForeColor = System.Drawing.Color.White;
            tc.BackColor = System.Drawing.ColorTranslator.FromHtml("#507cd1");
        }
        // export gridview to excel
        GridViewExportUtil.ExportGrid("LeaseTerm.xls", gvReport, true);
        gvReport.GridLines = GridLines.None;
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

        // get report result from database
        dsResult = Report.GetLeaseTermReport(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

        // set scrollbar propery
        dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dsResult.Tables[0].Rows.Count > 0) ? "scroll;" : "hidden;";

        // bind grid view
        gvReport.DataSource = dsResult;
        gvReport.DataBind();
        dvGrid.Visible = true;

        // check any row is found or not.
        if (gvReport.Rows.Count > 0)
        {
            ((Label)gvReport.FooterRow.FindControl("lblTotal")).Text = gvReport.Rows.Count.ToString();
            ((Label)gvReport.FooterRow.FindControl("lblLeaseable_Area")).Text = string.Format("{0:N0}", dsResult.Tables[0].Compute("sum(Total_Gross_Leaseable_Area)", ""));
            lnkExportToExcel.Visible = true;
        }
        else
        {
            gvReport.Width = Unit.Pixel(997);
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
