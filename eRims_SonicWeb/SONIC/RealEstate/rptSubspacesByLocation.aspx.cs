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
 * Description : This page allow user to generate Subspaces By Location Report. User can see report result into grid and also export output to
 *               Excel(.xls) files. user can filter this reprot By Region, Lease Type ,Lease Commencement Date and Lease
 *               Expiration Date.
 * 
 ********************************************************************************************************************************/

public partial class SONIC_RealEstate_rptSubspacesByLocation : clsBasePage
{

    #region "Variable"

    DataTable dtDetails;
    decimal? _Leaseable_Area;

    #endregion

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
    /// Handles RowDataBound event when row is generated in Region grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get details for specific region from datatable having details data
            DataView dvDetails = dtDetails.DefaultView;
            string STR_Region = string.Empty;
            STR_Region = DataBinder.Eval(e.Row.DataItem, "PK_LU_Location_ID").ToString();
            dvDetails.RowFilter = "PK_LU_Location_ID = " + STR_Region;

            // reset Leaseable area for inner grid
            _Leaseable_Area = null;
            //bind the sub grid for Region grid 
            GridView gvDetail = e.Row.FindControl("gvDetail") as GridView;
            gvDetail.DataSource = dvDetails.ToTable();
            gvDetail.DataBind();

        }
    }

    /// <summary>
    /// Handle gvDetail Gridview Row dta bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if row is data row then add Leasable Area  
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // calculate leasable area
            if (DataBinder.Eval(e.Row.DataItem, "Total_Gross_Leaseable_Area") != DBNull.Value)
                _Leaseable_Area = (_Leaseable_Area == null ? 0 : _Leaseable_Area) + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total_Gross_Leaseable_Area"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            // display Count and Leasable area in inner grid footer row
            ((Label)e.Row.FindControl("lblTotalCount")).Text = ((GridView)e.Row.NamingContainer).Rows.Count.ToString();
            ((Label)e.Row.FindControl("lblLeaseable_Area")).Text = string.Format("{0:N0}", _Leaseable_Area);
        }
    }

    /// <summary>
    /// handle grid view row created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // create gridview row
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;

            // create a table cell to be added in row
            TableCell Cell = new TableCell();
            Cell.HorizontalAlign = HorizontalAlign.Center;
            Cell.Text = "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                            "<table width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=0>" +
                                "<tr><td  align='left' colspan='3'> Sonic Automotive </td>" +
                                "<td  align='center' colspan='3'> Subspaces By Location </td>" +
                                "<td align='right' colspan='4'> " + System.DateTime.Now + " </td></tr></table>" +
                            "</td></tr></table>";
            // add cell in row
            gRow.Cells.Add(Cell);

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

        // set border to Header and footer table
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 1;

        // set Border to Inner grid
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvDetail");
            gvDetail.GridLines = GridLines.Both;

            // Check if Footer row is exist then remove extra cell from footer row
            if (gvDetail.FooterRow != null)
                while (gvDetail.FooterRow.Cells.Count > 3)
                    gvDetail.FooterRow.Cells.Remove(gvDetail.FooterRow.Cells[3]);
        }
        // export gridview to excel
        GridViewExportUtil.ExportGrid("SubspacesByLocation.xlsx", gvReport, true);
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

        // set filter Criteria
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
                strMarket = strMarket + "'" + li.Value + "',";
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
        dsResult = Report.GetSubspacesByLocation(strRegion,strMarket,strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);
        dtDetails = dsResult.Tables[0];
        // set scrollbar propery
        dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dsResult.Tables[0].Rows.Count > 0) ? "scroll;" : "hidden;";

        // bind grid view
        gvReport.DataSource = dsResult.Tables[1];
        gvReport.DataBind();
        dvGrid.Visible = true;

        // check any row is found or not.
        if (gvReport.Rows.Count > 0)
        {
            ((Label)gvReport.FooterRow.FindControl("lblTotalClaimCount")).Text = dtDetails.Rows.Count.ToString();
            ((Label)gvReport.FooterRow.FindControl("lblGrandTotalRentableArea")).Text = string.Format("{0:N0}", dsResult.Tables[0].Compute("sum(Total_Gross_Leaseable_Area)", ""));
            lnkExportToExcel.Visible = true;
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

    private void BindDropDownList()
    {
        // fill Region drop down
        ComboHelper.FillRegionListBox(new ListBox[] { ddlRegion }, false);

        //Bind Market Dropdown
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);

        //Lease Type
        ComboHelper.FillLeaseTypeListBox(new ListBox[] { ddlLeaseType }, false);

    }

    #endregion
}
