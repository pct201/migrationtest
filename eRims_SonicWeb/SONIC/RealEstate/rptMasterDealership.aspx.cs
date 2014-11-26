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

public partial class SONIC_RealEstate_rptMasterDealership : clsBasePage
{
    #region "Variable"

    DataTable dtDetails;
    decimal? _MonthlyRent;

    #endregion
    #region "Properties"

    private string strTime
    {
        get { return Convert.ToString(ViewState["strTime"]); }
        set { ViewState["strTime"] = value; }
    }

    #endregion
    #region "Page Event"
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
    /// Handles RowDataBound event when row is generated in Region grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //// get details for specific region from datatable having details data
         
            // get the subgrid
            GridView gvReport = (GridView)e.Row.FindControl("gvReport");
            decimal _PK_RE_Information = 0;
            // get the data for current DBA record   
            string strRE_Information = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PK_RE_Information"));
            if (strRE_Information != "")
            {
                _PK_RE_Information = Convert.ToDecimal(strRE_Information);
            }
            string strLocationStatus = string.Empty;
            foreach (ListItem li in lstBuildingStatus.Items)
            {
                if (li.Selected)
                    strLocationStatus = strLocationStatus + "'" + li.Value + "',";
            }
            DataTable dtBuilding = RE_Building.SelectByFK_RE_Information(_PK_RE_Information).Tables[0];
            if (dtBuilding.Rows.Count > 0)
            {
                DataView dvBuilding = dtBuilding.DefaultView;
                if (strLocationStatus != "")
                    dvBuilding.RowFilter = "Location_Status IN (" + strLocationStatus + ")";
                // bind sub grid view
                gvReport.DataSource = dvBuilding;
                gvReport.DataBind();
            }
            else
            {
                DataRow dr = dtBuilding.NewRow();
                dr["Building_Number"] = "";
                dr["Address"] = "";               
                dtBuilding.Rows.Add(dr);
                gvReport.DataSource = dtBuilding;
                gvReport.DataBind();
            }

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
            if (strTime == "") strTime = string.Format("{0:t}", DateTime.Now);
                      
            // create a table cell with the heading text
            TableCell Cell = new TableCell();
            Cell.Text = "<table width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=4><tr>" +
                                "<td colspan='2' align='left' >Sonic Automotive</td>" +
                                "<td colspan='5' align='center' >Master Dealership List </td>" +
                                "<td colspan='5' align='right'>" + clsGeneral.FormatDateToDisplay(DateTime.Now) + " " + strTime + "</td></tr></table>";
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
        
        // show gridlines to be shown in excel
        gvReport.GridLines = GridLines.Both;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 1;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblBLHeader")).Border = 1;    
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            ((HtmlTable)gRow.FindControl("tblDetails")).Border = 1;
        }
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvReport");
            gvDetail.GridLines = GridLines.Both;
        }
        // export gridview to excel
        GridViewExportUtil.ExportGrid("MasterDealershipListReport.xls", gvReport);

        // hide gridlines
        gvReport.GridLines = GridLines.None;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblDetails")).Border = 0;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 0;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblBLHeader")).Border = 0;    
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            ((HtmlTable)gRow.FindControl("tblDetails")).Border = 0;
        }
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvReport");
            gvDetail.GridLines = GridLines.None;

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
        string strRegion = string.Empty, strLocationStatus = string.Empty;
        DataSet dsResult;
        strTime = "";
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

        foreach (ListItem li in lstBuildingStatus.Items)
        {
            if (li.Selected)
                strLocationStatus = strLocationStatus + "'" + li.Value + "',";
        }
        strLocationStatus = strLocationStatus.TrimEnd(',');

        // get report result from database
        dsResult = Report.GetMasterDealershipByRegion(strRegion, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, strLocationStatus);
        dtDetails = dsResult.Tables[0];
        // set scrollbar propery
        dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dsResult.Tables[0].Rows.Count > 0) ? "scroll;" : "hidden;";

        // bind grid view
        gvReport.DataSource = dsResult.Tables[0];
        gvReport.DataBind();
        dvGrid.Visible = true;

        // check any row is found or not.
        if (gvReport.Rows.Count > 0)
        {

            ((Label)gvReport.FooterRow.FindControl("lblTotalClaimCount")).Text = dtDetails.Rows.Count.ToString();
            ((Label)gvReport.FooterRow.FindControl("lblMonthlyRent")).Text = string.Format("{0:N2}", dsResult.Tables[0].Compute("sum(MonthlyRent)", ""));
            if (((Label)gvReport.FooterRow.FindControl("lblMonthlyRent")).Text == "")
                ((Label)gvReport.FooterRow.FindControl("lblMonthlyRent")).Text = "0.00";

            ((Label)gvReport.FooterRow.FindControl("lblSubtenantMonthlyRent")).Text = string.Format("{0:N2}", dsResult.Tables[0].Compute("sum(SubtenantMonthlyRent)", ""));
            if (((Label)gvReport.FooterRow.FindControl("lblSubtenantMonthlyRent")).Text == "")
                ((Label)gvReport.FooterRow.FindControl("lblSubtenantMonthlyRent")).Text = "0.00";

            lnkExportToExcel.Visible = true;
            gvReport.Width = new Unit("1900px");
        }
        else
        {
            lnkExportToExcel.Visible = false;
            gvReport.Width = new Unit("997px");
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
    }

    #endregion
}
