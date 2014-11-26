using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_RealEstate_rptLeaseDetailReport : clsBasePage
{
    #region "Page Event"

    #region Properties

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortLocation
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : "asc"); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes Column Index selected for Sorting
    /// </summary>
    private int _ColumnIndex
    {
        get { return (!clsGeneral.IsNull(ViewState["ColumnIndex"]) ? Convert.ToInt32(ViewState["ColumnIndex"]) : -1); }
        set { ViewState["ColumnIndex"] = value; }
    }


    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortRegion
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : "asc"); }
        set { ViewState["SortOrder"] = value; }
    }

    #endregion

    /// <summary>
    /// Handle Page load Event - Initialize the Controls and Bind Data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //bind listboxs
            BindListData();
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind List view Data
    /// </summary>
    private void BindListData()
    {
        ComboHelper.FillRegionListBox(new ListBox[] { lstRegion }, false);

        //Lease Type
        ComboHelper.FillLeaseTypeListBox(new ListBox[] { lstLeaseType }, false);
    }

    /// <summary>
    /// Bind grid based on search criteria selected
    /// </summary>
    private void BindGrid()
    {
        //initialize the local variables
        string strRegion = "";
        string strLeaseType = "";
        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

        // get selected Ranks
        foreach (ListItem itmRegion in lstRegion.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + "'" + itmRegion.Value.Replace("'", "''") + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        // get selected Status
        foreach (ListItem itmLeaseType in lstLeaseType.Items)
        {
            if (itmLeaseType.Selected)
                strLeaseType = strLeaseType + "'" + itmLeaseType.Value + "',";
        }
        strLeaseType = strLeaseType.TrimEnd(',');

        if (txtLCDateFrom.Text.Trim() != string.Empty)
            dtLCDFrom = Convert.ToDateTime(txtLCDateFrom.Text);

        if (txtLCDateTo.Text.Trim() != string.Empty)
            dtLCDTo = Convert.ToDateTime(txtLCDateTo.Text);

        if (txtLEDateFrom.Text.Trim() != string.Empty)
            dtLEDFrom = Convert.ToDateTime(txtLEDateFrom.Text);

        if (txtLEDateTo.Text.Trim() != string.Empty)
            dtLEDTo = Convert.ToDateTime(txtLEDateTo.Text);


        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
        DataSet dsRegion = Report.GetLeaseDetailReport(strRegion, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, _SortRegion);

        //bind thr Group grid
        gvRegion.DataSource = dsRegion.Tables[0];
        gvRegion.DataBind();

        if (dsRegion != null && dsRegion.Tables.Count > 0 && dsRegion.Tables[0].Rows.Count > 0)
        {
            lnkExportToExcel.Visible = true;
            //bind the grand total with footer
            if (dsRegion.Tables.Count >= 1 && dsRegion.Tables[1].Rows.Count > 0)
            {
                ((Label)gvRegion.FooterRow.FindControl("lblGrandTotal")).Text = clsGeneral.GetStringValue(Convert.ToString(dsRegion.Tables[1].Rows[0][0])).Replace(".00", "");
            }
            if (dsRegion.Tables.Count > 1 && dsRegion.Tables[2].Rows.Count > 0)
            {
                ((Label)gvRegion.FooterRow.FindControl("lblTotalRentableArea")).Text = clsGeneral.GetStringValue(Convert.ToString(dsRegion.Tables[2].Rows[0][0])).Replace(".00", "");
            }
        }
        else
        {
            lnkExportToExcel.Visible = false;
        }
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow, GridView gvSearch)
    {
        Int32 iCol = _ColumnIndex;
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder;
        if (_ColumnIndex == 1)
        {
            strSortOrder = _SortRegion == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        }
        else
        {
            strSortOrder = _SortLocation == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        }

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        //headerRow.Cells[iCol].Controls.Add(sortImage);
        ((HtmlTable)headerRow.FindControl("tblHeader")).Rows[1].Cells[iCol].Controls.Add(sortImage);
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    #endregion

    #region "Events"

    /// <summary>
    /// Handle button click event - Clear all Search Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        //clear all selected item in listbox
        lstRegion.ClearSelection();
        lstLeaseType.ClearSelection();
        txtLCDateFrom.Text = "";
        txtLCDateTo.Text = "";
        txtLEDateFrom.Text = "";
        txtLEDateTo.Text = "";
        trSearchResult.Visible = false;
    }

    /// <summary>
    /// Handle button click Event - generate Report
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        //Assign defaulr sort order values
        _SortLocation = "asc";
        _SortRegion = "asc";
        _ColumnIndex = 1;
        ////Bind grid based on search criteria
        BindGrid();
        trSearchResult.Visible = true;
    }


    /// <summary>
    /// handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        gvRegion.GridLines = GridLines.Both;
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 1;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            GridView gvLeaseDetails = (GridView)gRow.FindControl("gvLeaseDetails");
            gvLeaseDetails.GridLines = GridLines.Both;
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("LeaseDetaiolReport.xls", gvRegion);

        // reset the settings
        gvRegion.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            GridView gvLeaseDetails = (GridView)gRow.FindControl("gvLeaseDetails");
            gvLeaseDetails.GridLines = GridLines.None;
        }
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 0;
    }

    #endregion

    #region "Grid Event"

    /// <summary>
    ///Handle data row bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check for Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find control from data row
            //HiddenField hdGroupValue = (HiddenField)e.Row.FindControl("hdGroupValue");
            GridView gvLeaseDetails = (GridView)e.Row.FindControl("gvLeaseDetails");

            //initialize the local variables
            string strRegion = Convert.ToString(gvRegion.DataKeys[e.Row.RowIndex].Value); ;
            string strLeaseType = "";
            DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

            // get selected Status
            foreach (ListItem itmLeaseType in lstLeaseType.Items)
            {
                if (itmLeaseType.Selected)
                    strLeaseType = strLeaseType + "'" + itmLeaseType.Value + "',";
            }
            strLeaseType = strLeaseType.TrimEnd(',');

            if (txtLCDateFrom.Text.Trim() != string.Empty)
                dtLCDFrom = Convert.ToDateTime(txtLCDateFrom.Text);

            if (txtLCDateTo.Text.Trim() != string.Empty)
                dtLCDTo = Convert.ToDateTime(txtLCDateTo.Text);

            if (txtLEDateFrom.Text.Trim() != string.Empty)
                dtLEDFrom = Convert.ToDateTime(txtLEDateFrom.Text);

            if (txtLEDateTo.Text.Trim() != string.Empty)
                dtLEDTo = Convert.ToDateTime(txtLEDateTo.Text);


            //get the all Employee records by search criteria by group
            DataSet dsDetails = Report.GetLeaseDetailReport_SubDetails(strRegion, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, _SortLocation);
            //bind Employee detail grid
            gvLeaseDetails.DataSource = dsDetails.Tables[0];
            gvLeaseDetails.DataBind();

            //bind sub total for each group
            if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[1].Rows.Count > 0)
            {
                gvLeaseDetails.FooterRow.Cells[1].Text = clsGeneral.GetStringValue(Convert.ToString(dsDetails.Tables[1].Rows[0][0])).Replace(".00", "");
            }
            if (dsDetails != null && dsDetails.Tables.Count > 1 && dsDetails.Tables[2].Rows.Count > 0)
            {
                gvLeaseDetails.FooterRow.Cells[8].Text = clsGeneral.GetStringValue(Convert.ToString(dsDetails.Tables[2].Rows[0][0])).Replace(".00", "") + "&nbsp;&nbsp;";
            }
        }
    }

    /// <summary>
    /// Handle Data row created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegion_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //// check for the header row
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    // update sort image beside the column header 
        //    AddSortImage(e.Row, gvRegion);
        //}
    }

    /// <summary>
    /// Handle Row command event for sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Region")
        {
            _SortRegion = _SortRegion == "asc" ? "desc" : "asc";
        }
        else if (e.CommandName == "Location")
        {
            _SortLocation = _SortLocation == "asc" ? "desc" : "asc";
        }

        // update sort field and sort order and bind the grid      
        _ColumnIndex = Convert.ToInt32(e.CommandArgument);
        //bind the report again
        BindGrid();
    }

    #endregion
}
