using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class SONIC_RealEstate_rptlandlordInformation : clsBasePage
{
    #region "Variable"

    DataTable dtDetails;

    #endregion

    #region "Properties"

    private string strTime
    {
        get { return Convert.ToString(ViewState["strTime"]); }
        set { ViewState["strTime"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind Drop down
            ComboHelper.FillRegionListBox(new ListBox[] { ddlRegion }, false);

            //Bind Market Dropdown
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);

            // set focus to first field
            ddlRegion.Focus();
        }

        clsGeneral.SetDropDownToolTip(new ListBox[] { ddlRegion });
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
            TableCell Cell = new TableCell();
            Cell.Text = "<table width='100%' style='border: black 0.5px solid;font-weight: bold;' cellspacing=0 cellpadding=4><tr style='font-weight: bold;'>" +
                                "<td colspan='2' align='left' >Sonic Automotive</td>" +
                                "<td colspan='7' align='center' >Landlord Report </td>" +
                                "<td colspan='6' align='right'>" + clsGeneral.FormatDateToDisplay(DateTime.Now) + " " + strTime + "</td></tr></table>";
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
        GridViewExportUtil.ExportGrid("LandlordReport.xlsx", gvReport, false);

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
        string strRegion = string.Empty, strLeaseType = string.Empty, strLocationStatus = string.Empty, strMarket = string.Empty;
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

        foreach (ListItem li in lstBuildingStatus.Items)
        {
            if (li.Selected)
                strLocationStatus = strLocationStatus + "'" + li.Value + "',";
        }
        strLocationStatus = strLocationStatus.TrimEnd(',');

        foreach (ListItem li in lstMarket.Items)
        {
            if (li.Selected)
                strMarket = strMarket + "" + li.Value + ",";
        }

        strMarket = strMarket.TrimEnd(',');

        // get report result from database
        dsResult = Report.GetLandlordInfoReport(strRegion, strMarket, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, strLocationStatus);
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
            ((Label)gvReport.FooterRow.FindControl("lblGrandTotal")).Text = dtDetails.Rows.Count.ToString();
            lnkExportToExcel.Visible = true;
            gvReport.Width = new Unit("2440px");
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
}
